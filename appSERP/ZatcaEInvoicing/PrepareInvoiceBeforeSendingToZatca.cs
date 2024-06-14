using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.Utils;
using appSERP.ZatcaEInvoicing.LinkPro;
using appSERP.ZatcaEInvoicing.LinkPro.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        public string ResendInvoice(int pInvId, int? pOrderId)
        {
            // نتحقق من الفاتورة انه تم مصادقتها
            var json = _dbINVInvoice.funInvoiceOrderOrPOS(pInvId: pInvId, pQueryTypeId: 401).ToString();
            if(string.IsNullOrWhiteSpace(json) || json.Trim().Length<1)
                return SystemMessageCode.ToJSON(SystemMessageCode.GetError("لا يوجد فاتورة بهذا الرقم"));
            var dtpInv = JsonConvert.DeserializeObject<DataTable>(json);           
            DateTime invDate = Convert.ToDateTime(dtpInv.Rows[0].Field<DateTime>("InvDate").ToString());       
            if(invDate > DateTime.Now.AddMinutes(-2))
             return SystemMessageCode.ToJSON(SystemMessageCode.GetError("انتظر دقيقتين ثم أعد إرسالها لإنها فاتورة جديدة"));

            bool isPassed = Convert.ToBoolean(dtpInv.Rows[0].Field<bool>("IsPassed").ToString());
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
                    return SystemMessageCode.ToJSON(SystemMessageCode.GetSuccess("تمت الإعادة بنجاح"));
                else
                    return SystemMessageCode.ToJSON(SystemMessageCode.GetError("فشلت العملية"));
            }
            else
                return SystemMessageCode.ToJSON(SystemMessageCode.GetSuccess("تم إجتياز الفاتورة مسبقا"));

        }
        // test
        public string ResendInvoiceTest(int pInvId, int? pOrderId)
        {
            string str = SendDelayTest();
            return str;
        }
        //public string ResendInvoiceTest(int pInvId, int? pOrderId)
        //{
        //    string str= SendDelayTest().Result;
        //    return str;
        //}
        //private async Task<string> SendDelayTest()
        //{
        //    await Task.Delay(5000);// 60000 , 120000
        //    return SystemMessageCode.ToJSON(SystemMessageCode.GetSuccess("تمت الإعادة بنجاح يا بدش"));
        //}
        private string SendDelayTest()
        {
            //BackgroundJob.Enqueue(() => DelayedMethod());
            return SystemMessageCode.ToJSON(SystemMessageCode.GetSuccess("تمت الإعادة بنجاح يا بدش"));
        }
        public async Task DelayedMethod()
        {
            await Task.Delay(TimeSpan.FromMinutes(5));
            // العملية المؤجلة التي تحتاج للتنفيذ بعد فترة زمنية
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
            var Discount = dataTable.Rows[0].Field<double>("Discount").ToString();

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
            var Discount = dataTable.Rows[0].Field<double>("Discount").ToString();
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
                    invoiceResponseDto.status = invoiceResponseDto.status.ToLower();
                    invoiceResponseDto.isSuccess = false;
                    if (invoiceResponseDto != null && (invoiceResponseDto.statusCode == "200" || invoiceResponseDto.statusCode == "201" || invoiceResponseDto.statusCode == "202")
                        && invoiceResponseDto.qrcode != null && string.IsNullOrWhiteSpace(invoiceResponseDto.qrcode) == false
                        && invoiceResponseDto.status != "rejected"  && invoiceResponseDto.status != "error" && invoiceResponseDto.status != "failed")
                        invoiceResponseDto.isSuccess = true; // (passed - passed with warnings - rejected) - failed
                               
                    return invoiceResponseDto;
                }
                else
                {
                    return new InvoiceResponseDto() { isSuccess = false };
                }

            }
            catch (Exception ex)
            {
                throw new AggregateException(ex);
            }
        }

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