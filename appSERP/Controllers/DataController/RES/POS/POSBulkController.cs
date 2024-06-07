using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.Logger;
using appSERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.RES.POS
{
    public class POSBulkController : Controller
    {
        private ILog _ILog;
        private IdbINVInvoice _dbINVInvoice;
        public POSBulkController(ILog log, IdbINVInvoice dbINVInvoice)
        {
            _ILog = log;
            _dbINVInvoice = dbINVInvoice;

        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        public JsonResult InsertPOSBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId,
            int? Invtype = null, bool? InvIsWait = null, string CardNo = null, DateTime? InvDate = null, int? PayTypeId = null, string Notes = null, int? CashDeskId = null, float? Insurance = null, int? Service = null, float? Tax = null, float? Discount = null, string InvMachine = null, bool? DeliveryInvoice = null, int? Delivery = 0, DateTime? DeliveryDate = null, string InvPhoneNo = null, int? SiteId = null, string LocAddressInvoice = null, float? InvCurValue = null, string CustomerName = null, int? CustomerId = null, int? OrderType = null, int? UsedPoints = null, int? MealPoints = null, string CustomerAddress = null, string CustomerPhoneNumber = null, int? UserId = null, int? BranchId = null, int? TableId = null, int? InvStatus = null)

        {
       
            return  Json( _dbINVInvoice.spInvoicePOSBulk(InvoiceDtls, InvId, Invtype, InvIsWait, CardNo, InvDate, PayTypeId, Notes, CashDeskId, Insurance, Service, Tax, Discount, InvMachine, DeliveryInvoice, Delivery, DeliveryDate, InvPhoneNo, SiteId, LocAddressInvoice, InvCurValue, CustomerName, CustomerId, OrderType, UsedPoints, MealPoints, CustomerAddress, CustomerPhoneNumber, UserId, BranchId, TableId, InvStatus));
        }
    }
}