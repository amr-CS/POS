using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace appSERP.Controllers.DataController
{
    public class ZatcaAutoSendController : Controller
    {


        // GET: ZatcaAutoSend
        public ActionResult Index()
        {
            return View();
        }
        public async Task<string> AutoSendInvoice()
            {

            string today = DateTime.Now.ToShortDateString() + " 4:00:00";
            string tomorow = DateTime.Now.AddDays(1).ToShortDateString() + " 4:00:00";
            DateTime DateFrom = DateTime.Parse(today);
            DateTime DateTo = DateTime.Parse(tomorow);



            branchsettingForHangeFire branchsettingForHangeFire = new branchsettingForHangeFire();
            var invoices = branchsettingForHangeFire.ZatacaAuto(pDateFrom: DateFrom, pDateTo: DateTo, pIsPassed: false);

            if (invoices == null || invoices.Rows.Count < 1)
                return SystemMessageCode.ToJSON(SystemMessageCode.GetError("لا يوجد فواتير لكي نجتازها"));

            bool lastSharedStatus = GlobalVariables.SharedStatus;
            if (lastSharedStatus == true)
            {
                return SystemMessageCode.ToJSON(SystemMessageCode.GetError("من فضلك انتظر حتى تعود نتائج الضغطه الاولى من السيرفر"));
            }
            else
            {
                GlobalVariables.SharedStatus = true;
                foreach (DataRow item in invoices.Rows)
                {

                    if (Convert.ToInt32(item["InvId"].ToString()) < 1 && item["OrderId"].ToString() == null)
                        return SystemMessageCode.ToJSON(SystemMessageCode.GetError("رقم الفاتورة او الطلب غير صحيح"));
                }
                StringBuilder messageResult = new StringBuilder();
                int SuccessStatus = 0;
                int ErrorStatus = 0;
                foreach (DataRow item in invoices.Rows)
                {
                    var resultAPI = SendInvoice(Convert.ToInt32(item["InvId"].ToString()), Convert.ToInt32(item["OrderId"].ToString()));
                    if (resultAPI.Item1)
                        SuccessStatus += 1;
                    else
                        ErrorStatus += 1;
                    //await Task.Run(() => Task.Delay(9000));
                    //resultAPI = SystemMessageCode.ToJSON(SystemMessageCode.GetSuccess("تم الإرسال بنجاح"));
                }
                if (SuccessStatus > 0)
                    messageResult.Append("عدد الفواتير المجتازة حاليا = " + SuccessStatus);

                if (ErrorStatus > 0)
                {
                    messageResult.Append("عدد الفواتير الغير مجتازة حاليا = " + ErrorStatus);
                    messageResult.Append("هناك فواتير تم رفضها بسبب شروط في نظامنا او من الهيئة يجب إعادة إرسالها");
                }
                GlobalVariables.SharedStatus = false;
                if (SuccessStatus > 0)
                    return SystemMessageCode.ToJSON(SystemMessageCode.GetSuccess(messageResult.ToString()));
                else
                    return SystemMessageCode.ToJSON(SystemMessageCode.GetError(messageResult.ToString()));

                //GlobalVariables.SharedStatus = false;
                //return resultAPI;


                throw new NotImplementedException();
            }
        }

        public Tuple<bool, string> SendInvoice(int pInvId, int? pOrderId)
        {
            if (pInvId < 1 && pOrderId == null)
                return Tuple.Create(false, "رقم الفاتورة او الطلب غير صحيح");
            branchsettingForHangeFire branchsettingForHangeFire = new branchsettingForHangeFire();

            var result = branchsettingForHangeFire.ResendInvoice(pInvId, pOrderId);
            return result;
        }
    }
}