using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.Utils;
using appSERP.ZatcaEInvoicing.LinkPro;
using appSERP.ZatcaEInvoicing.LinkPro.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.ZatcaEInvoicing
{
    // كلاس تجهيز الفاتورة قبل إرسالها الى الهيئة للضريبة
    public class PrepareInvoiceBeforeSendingToZatca
    {

        private IdbInvItem _dbInvItem;
        private IdbINVInvoice _dbINVInvoice;
        private IdbResOrder _dbResOrder;
        private IZatcaEInvoice _api;
        public PrepareInvoiceBeforeSendingToZatca(IdbInvItem dbInvItem, IdbINVInvoice dbINVInvoice, IdbResOrder dbResOrder, IZatcaEInvoice api)
        {
            _dbInvItem = dbInvItem;
            _dbINVInvoice = dbINVInvoice;
            _dbResOrder = dbResOrder;
            _api = api;
        }

        // دالة إعادة ارسال الفاتورة الى الهيئة للموافقة عليها
        public Tuple<bool, string> ResendInvoice(int pInvId, int? pOrderId)
        {
            bool SuccessStatus = false;
            // نتحقق من الفاتورة انه تم مصادقتها
            var json = _dbINVInvoice.funInvoiceOrderOrPOS(pInvId: pInvId, pQueryTypeId: 401).ToString();
            if (string.IsNullOrWhiteSpace(json) || json.Trim().Length < 1)
                //return SystemMessageCode.ToJSON(SystemMessageCode.GetError("لا يوجد فاتورة بهذا الرقم"));
                return Tuple.Create(SuccessStatus, "لا يوجد فاتورة بهذا الرقم");
            var dtInv = JsonConvert.DeserializeObject<DataTable>(json);
            DateTime invDate = Convert.ToDateTime(dtInv.Rows[0].Field<DateTime>("InvDate").ToString());
            if (invDate > DateTime.Now.AddMinutes(-2))
                return Tuple.Create(SuccessStatus, "انتظر دقيقتين ثم أعد إرسالها لإنها فاتورة جديدة");

            bool isPassed = Convert.ToBoolean(dtInv.Rows[0].Field<bool>("IsPassed").ToString());

            bool allowResend = Convert.ToBoolean(dtInv.Rows[0].Field<bool>("allowResend").ToString());
            if (isPassed == false && allowResend == false) 
                return Tuple.Create(SuccessStatus, "انتظر دقيقتين لانه تم أعادة إرسالها قبل لحظات");

            if (isPassed == false)
            {
                InvoiceResponseDto dto = new InvoiceResponseDto();
                if (pOrderId != null && pOrderId > 0)
                    dto = SendToZatcaOrder((int)pOrderId);
                else
                {
                    DataTable dt = GetInvoicePOSData(pInvId);
                    dto = _SendToZatcaPOS(pInvId, dt);
                }
                if (dto.isSuccess)
                    return Tuple.Create(true, "تمت الإعادة بنجاح");
                else
                    return Tuple.Create(SuccessStatus, "فشلت العملية");
            }
            else
                return Tuple.Create(true, "تم إجتياز الفاتورة مسبقا");

        }


        #region Send Invoice POS To Zatca
        private DataTable GetInvoicePOSData(int InvId)
        {
            DataTable Data = _dbInvItem.funInvItemGET(InvId, null);
            return Data;
        }

        public void SendToZatcaPOS(DataTable dataTable)
        {
            //Task.Run(async()=> await Task.Delay(120000));
            int InvId = Convert.ToInt32(dataTable.Rows[0].Field<int>("InvId").ToString());
            _SendToZatcaPOS(InvId, dataTable);

        }
        private InvoiceResponseDto _SendToZatcaPOS(int InvId, DataTable dataTable)
        {
            var TokenDb = dataTable.Rows[0].Field<string>("LinkProApi").ToString();
            InvoiceCreateRequest obj = SetZatcaInvoicePOSValues(dataTable);
            InvoiceResponseDto dto = SendInvoice(TokenDb, obj);
            string responseJson = string.Empty;
            if (dto.isSuccess)
            {
                responseJson = JsonConvert.SerializeObject(dto);
                //responseJson = JsonConvert.SerializeObject(dto, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                PassedInvoicePOS(InvId, responseJson);
            }
            SendInvoiceToZatcaLog(obj.invoice_pk, dto);
            return dto;
        }
        void PassedInvoicePOS(int InvId, string responseJson, bool isPassed = true)
        {
            // تعديل الموافقة على الفاتورة وإجتيازها
            // تعديل حالة موافقة الضرائب للفاتورة عندنا
            var dt = _dbINVInvoice.funInvoiceOrderOrPOS(pInvId: InvId, pQueryTypeId: 200, pZatcaResponse: responseJson, pIsPassed: isPassed);
        }
        InvoiceCreateRequest SetZatcaInvoicePOSValues(DataTable dataTable)
        {
            InvoiceCreateRequest obj = new InvoiceCreateRequest();

            List<InvoiceItem> itemlst = new List<InvoiceItem>() { };

            string organization = dataTable.Rows[0].Field<string>("organization").ToString();
            string tax_number = dataTable.Rows[0].Field<string>("tax_number").ToString();
            string IsReturn = Convert.ToString(dataTable.Rows[0].Field<string>("IsReturn"));
            string reference_pk = null;
            string reference_date = null;
            if (IsReturn == "true")
            {
                reference_pk = dataTable.Rows[0].Field<string>("invref").ToString();
                reference_date = dataTable.Rows[0].Field<string>("IDate").ToString();
            }
            InvoiceCustomer customerLinkPro = new InvoiceCustomer()
            {
                organization = organization,
                tax_number = tax_number,
                street = dataTable.Rows[0].Field<string>("street").ToString(),
                city = dataTable.Rows[0].Field<string>("city").ToString(),
                building_number = dataTable.Rows[0].Field<string>("building_number").ToString(),
                postal_zone = dataTable.Rows[0].Field<string>("postal_zone").ToString(),
                district_name = dataTable.Rows[0].Field<string>("district_name").ToString()
            };


            foreach (DataRow item in dataTable.Rows)
            {
                // فاتورة كاشير فقط إرسال الاصناف للضريبة بدون التأمين والاضافات
                if (item["ItemType"].ToString() == "1")
                {
                    itemlst.Add(
                    new InvoiceItem()
                    {
                        name = item["InvItemNameL1"].ToString(),
                        price = item["PricePro"].ToString(),
                        quantity = item["Qty"].ToString()
                    });
                }
            }

            //itemlst.Add(
            //        new InvoiceItem()
            //        {
            //            name = "جريش مجاني",
            //            price = "0",
            //            quantity = "1"
            //        });

            //var TokenDb = dataTable.Rows[0].Field<string>("LinkProApi").ToString();
            var InvCode = dataTable.Rows[0].Field<string>("InvCode").ToString();
            var account_id = dataTable.Rows[0].Field<string>("account_id").ToString();
            var Discount = dataTable.Rows[0].Field<double>("DiscountBeforeVAT").ToString();

            if (!String.IsNullOrEmpty(tax_number) && !String.IsNullOrEmpty(organization))
            {
                obj = new InvoiceCreateRequest()
                {
                    account_id = account_id,
                    invoice_code = InvoiceCode.InvoiceCodeType(IsReturn), //invoice, credit, debit
                    invoice_pk = InvCode,
                    payment_method = "10",
                    discount_amount = Discount,
                    items = itemlst,
                    customer = customerLinkPro,
                    reference_pk = reference_pk,
                    reference_date = reference_date
                };
            }
            else
            {
                obj = new InvoiceCreateRequest()
                {
                    account_id = account_id,
                    invoice_code = InvoiceCode.InvoiceCodeType(IsReturn),
                    invoice_pk = InvCode,
                    payment_method = "10",
                    discount_amount = Discount,
                    items = itemlst,
                    reference_pk = reference_pk,
                    reference_date = reference_date

                };
            }

            return obj;
        }

        #endregion

        #region Send Invoice Order To Zatca

        public InvoiceResponseDto SendToZatcaOrder(int OrderId)
        {
            DataTable dt = GetInvoiceOrderData(OrderId);
            return _SendToZatcaOrder(OrderId, dt);
        }
        //public void SendToZatcaOrder(DataTable dataTable)
        //{
        //    //Task.Run(async()=> await Task.Delay(120000));
        //    int OrderId = Convert.ToInt32(dataTable.Rows[0].Field<int>("OrderId").ToString());
        //    _SendToZatcaOrder(OrderId,dataTable);
        //}
        private DataTable GetInvoiceOrderData(int OrderId)
        {
            DataTable Data = _dbResOrder.funResOrderReport(OrderId);
            return Data;
        }
        private InvoiceResponseDto _SendToZatcaOrder(int OrderId, DataTable dataTable)
        {
            var TokenDb = dataTable.Rows[0].Field<string>("LinkProApi").ToString();
            InvoiceCreateRequest obj = SetZatcaInvoiceOrderValues(dataTable);
            InvoiceResponseDto dto = SendInvoice(TokenDb, obj);
            string responseJson = string.Empty;
            if (dto.isSuccess)
            {
                responseJson = JsonConvert.SerializeObject(dto);
                //responseJson = JsonConvert.SerializeObject(dto, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                PassedInvoiceOrder(OrderId, responseJson);
            }
            SendInvoiceToZatcaLog(obj.invoice_pk, dto);
            return dto;
        }
        InvoiceCreateRequest SetZatcaInvoiceOrderValues(DataTable dataTable)
        {
            InvoiceCreateRequest obj = new InvoiceCreateRequest();
            List<InvoiceItem> itemlst = new List<InvoiceItem>() { };
            string organization = dataTable.Rows[0].Field<string>("organization").ToString();
            string tax_number = dataTable.Rows[0].Field<string>("tax_number").ToString();
            string IsReturn = "false";
            InvoiceCustomer customerLinkPro = new InvoiceCustomer()
            {
                organization = organization,
                tax_number = tax_number,
                street = dataTable.Rows[0].Field<string>("street").ToString(),
                city = dataTable.Rows[0].Field<string>("city").ToString(),
                building_number = dataTable.Rows[0].Field<string>("building_number").ToString(),
                postal_zone = dataTable.Rows[0].Field<string>("postal_zone").ToString(),
                district_name = dataTable.Rows[0].Field<string>("district_name").ToString()
            };


            foreach (DataRow item in dataTable.Rows)
            {
                // فاتورة طلب فقط إرسال الاصناف للضريبة بدون التأمين
                if (item["CategoryId"].ToString() != item["PlateCode"].ToString())
                {
                    itemlst.Add(
                     new InvoiceItem()
                     {
                         name = item["InvItemNameL1"].ToString(),
                         price = item["PRICEPro"].ToString(),
                         quantity = item["QTY"].ToString()
                     }
                    );
                }

            }

            //var TokenDb = dataTable.Rows[0].Field<string>("LinkProApi").ToString();
            var InvCode = dataTable.Rows[0].Field<string>("InvCode").ToString();
            var account_id = dataTable.Rows[0].Field<string>("account_id").ToString();
            var Discount = dataTable.Rows[0].Field<double>("DiscountBeforeVAT").ToString();
            if (!String.IsNullOrEmpty(tax_number) && !String.IsNullOrEmpty(organization))
            {
                obj = new InvoiceCreateRequest()
                {
                    account_id = account_id,
                    invoice_code = InvoiceCode.InvoiceCodeType(IsReturn), //"invoice",
                    invoice_pk = InvCode,
                    payment_method = "10",
                    discount_amount = Discount,
                    items = itemlst,
                    customer = customerLinkPro


                };
            }
            else
            {
                obj = new InvoiceCreateRequest()
                {
                    account_id = account_id,
                    invoice_code = InvoiceCode.InvoiceCodeType(IsReturn),//"invoice",
                    invoice_pk = InvCode,
                    payment_method = "10",
                    discount_amount = Discount,
                    items = itemlst,

                };
            }
            return obj;
        }
        void PassedInvoiceOrder(int OrderId, string responseJson, bool isPassed = true)
        {
            // تعديل حالة موافقة الضرائب للفاتورة عندنا
            var dt = _dbINVInvoice.funInvoiceOrderOrPOS(pOrderId: OrderId, pQueryTypeId: 201, pZatcaResponse: responseJson, pIsPassed: isPassed);
        }
        #endregion

        #region Send To Zatca
        // async Task<InvoiceResponseDto> SendInvoice(string TokenDb, InvoiceCreateRequest obj)
        InvoiceResponseDto SendInvoice(string TokenDb, InvoiceCreateRequest obj)
        {
            try
            {
                //await Task.Delay(120000); // تأخير دقيقتين
                // await Task.Delay(60000); // تأخير دقيقة
                if (obj.items.Count > 0)
                {
                    //IZatcaEInvoice _api = new ZatcaEInvoiceAPI();
                    var result = Task.Run(() => _api.SendInvoice(TokenDb, obj));
                    InvoiceResponseDto invoiceResponseDto = result.Result;
                    if (string.IsNullOrWhiteSpace(invoiceResponseDto.status) == false)
                        invoiceResponseDto.status = invoiceResponseDto.status.ToLower();
                    invoiceResponseDto.isSuccess = false;
                    if (invoiceResponseDto != null && (invoiceResponseDto.statusCode == "200" || invoiceResponseDto.statusCode == "201" || invoiceResponseDto.statusCode == "202")
                        && invoiceResponseDto.qrcode != null && string.IsNullOrWhiteSpace(invoiceResponseDto.qrcode) == false
                        && string.IsNullOrWhiteSpace(invoiceResponseDto.status) != true && invoiceResponseDto.status != "rejected" && invoiceResponseDto.status != "error" && invoiceResponseDto.status != "failed")
                        invoiceResponseDto.isSuccess = true; // (passed - passed with warnings - rejected) - failed

                    return invoiceResponseDto;
                }
                else
                {
                    var invoiceResponseDto = new InvoiceResponseDto() { isSuccess = false, note = " items.Count = 0", statusCode = "error user" };
                    return invoiceResponseDto;
                }

            }
            catch (Exception ex)
            {
                var invoiceResponseDto = new InvoiceResponseDto() { isSuccess = false, note = ex.Message, statusCode = "Exception" };
                SendInvoiceToZatcaLog(obj.invoice_pk, invoiceResponseDto);
                throw new AggregateException(ex);
            }
        }

        #region Send the invoice to the Zatca Log
        void SendInvoiceToZatcaLog(string invoice_pk, InvoiceResponseDto dto)
        {
            try
            {
                string responseJson = JsonConvert.SerializeObject(dto);
                string pathDirectory = string.Format(@"{0}\{1}\{2}\{3}", AppDomain.CurrentDomain.BaseDirectory, "WhiteCloud", "Log User File", "SendInvoiceToZatca");
                string fileName = string.Format("{0}_{1}.txt", "SendToZatca", DateTime.Now.ToString("dd-MM-yyyy"));
                string filePath = string.Format(@"{0}\{1}", pathDirectory, fileName);

                if (Directory.Exists(pathDirectory) == false)
                    Directory.CreateDirectory(pathDirectory);
                if (File.Exists(filePath) == false)
                    File.CreateText(filePath).Dispose();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("== Send Invoice To Zatca : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                sb.AppendLine("invoice_pk = " + invoice_pk + " , status = " + dto.status + " , isSuccess = " + dto.isSuccess + " , statusCode = " + dto.statusCode + " .");
                sb.AppendLine("Response : " + responseJson + " .");
                sb.AppendLine("======================================================================================");

                using (StreamWriter write = new StreamWriter(filePath, true)) //using (StreamWriter w = File.AppendText(filePath))
                {
                    write.Write(sb.ToString());
                    write.Flush();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        /*
         void SendInvoice(string TokenDb, InvoiceCreateRequest obj)
        {
            try
            {
                //await Task.Delay(120000); // تأخير دقيقتين
                //await Task.Delay(60000); // تأخير دقيقة
                IZatcaEInvoice api = new ZatcaEInvoiceAPI();
                var result = Task.Run(() => api.SendInvoice(TokenDb, obj));
                string status = "";
                string responseJson = "";
               InvoiceResponseDto invoiceResponseDto = result.Result;
                if (invoiceResponseDto != null && (invoiceResponseDto.statusCode != "200" || invoiceResponseDto.statusCode != "201"))
                {
                    // DOTO : تعديل حالة موافقة الضرائب للفاتورة عندنا
                    responseJson = JsonConvert.SerializeObject(invoiceResponseDto);
                    //responseJson = JsonConvert.SerializeObject(invoiceResponseDto, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    status = invoiceResponseDto.status;
                }
                //var result = Task.Run(() => api.SendInvoiceStr(TokenDb, obj));
                //string invoiceResponseDto = result.Result;
                //string responseJson = JsonConvert.SerializeObject(invoiceResponseDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        } 
         */

        #endregion


    }
}