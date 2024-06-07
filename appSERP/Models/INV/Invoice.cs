using System;
using System.Linq;
using System.Collections.Generic;
namespace appSERP.Models
{
    public  class Invoice: IEquatable<Invoice>
    {
        public int InvId { get; set; }
        public string InvCode { get; set; }
        public int? Invtype { get; set; }
        public int? Year { get; set; }
        public double? Total { get; set; }
        public string InvRef { get; set; }
        public DateTime? InvDate { get; set; }
        public long? SellerId { get; set; }
        public bool? PayCash { get; set; }
        public bool? PayCheck { get; set; }
        public bool? PayLater { get; set; }
        public double? InvBaseAmt { get; set; }
        public double? DiscPerc { get; set; }
        public bool? IsPosted { get; set; }
        public short? StoreId { get; set; }
        public double? DiscAmt { get; set; }
        public short? InvSubCost { get; set; }
        public string Notes { get; set; }
        public int? PermitId { get; set; }
        public short? PermitType { get; set; }
        public short? OrderType { get; set; }
        public long? OrderId { get; set; }
        public int? CustomerId { get; set; }
        public short? SaleTax { get; set; }
        public short? SaleTax2 { get; set; }
        public string Person { get; set; }
        public long? InvSeq { get; set; }
        public DateTime? InvRefDate { get; set; }
        public double? InvCurValue { get; set; }
        public short? InvCur { get; set; }
        public double? InvDisc { get; set; }
        public double? PermitYear { get; set; }
        public short? BankId { get; set; }
        public short? BranchId { get; set; }
        public string CardNo { get; set; }
        public string AccountId { get; set; }
        public DateTime? ExpireDate { get; set; }
        public short? CardType { get; set; }
        public double? Amt { get; set; }
        public double? CurValue { get; set; }
        public double? BaseAmt { get; set; }
        public string BankSource { get; set; }
        public short? PayVisa { get; set; }
        public short? AreaId { get; set; }
        public int? QutId { get; set; }
        public int? QutType { get; set; }
        public short? TypeId { get; set; }
        public short? Payed { get; set; }
        public short? GetComm { get; set; }
        public string Deliveries { get; set; }
        public double? ReturnOnDelivery { get; set; }
        public long? GoodInvId { get; set; }
        public short? SetSaleRet { get; set; }
        public short? RetOnDelyear { get; set; }
        public string PatId { get; set; }
        public short? VisitNo { get; set; }
        public double? ReqNo { get; set; }
        public double? SurgId { get; set; }
        public short? DebitType { get; set; }
        public long? InsurTrans { get; set; }
        public short? ContNo { get; set; }
        public long? InsurancePerc { get; set; }
        public long? CmpAccId { get; set; }
        public double? SalesId { get; set; }
        public short? FromBranches { get; set; }
        public bool? InvIsWait { get; set; }
        public bool? InvIsCancel { get; set; }
        public double? PeriodId { get; set; }
        public int? BranchCompId { get; set; }
        public int? SubSeq { get; set; }
        public int? PayTypeId { get; set; }
        public int? CostCenterId { get; set; }
        public int? CashDeskId { get; set; }
        public int? InvStatus { get; set; }
        public int? OrderSeq { get; set; }
        public double? Insurance { get; set; }
        public int? InsurPerc { get; set; }
        public double? Service { get; set; }
        public int? ServicePerc { get; set; }
        public double? Tax { get; set; }
        public int? TaxPerc { get; set; }
        public int? Discount { get; set; }
        public int? DiscountPerc { get; set; }
        public int? PointId { get; set; }
        public int? Delivery { get; set; }
        public int? DeliveryPerc { get; set; }
        public string InvMachine { get; set; }
        public string PcIdentification { get; set; }
        public int? OrderLocSeq { get; set; }
        public int? OrederDaySeq { get; set; }
        public int? InvPayType { get; set; }
        public bool? DeliveryInvoice { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? DelLocSeq { get; set; }
        public string InvPhoneNo { get; set; }
        public bool? IsPrepare { get; set; }
        public bool? IsTransPost { get; set; }
        public int? PriceCat { get; set; }
        public int? SiteId { get; set; }
        public string LocAddressInvoice { get; set; }
        public int? AnotherInvId { get; set; }
        public int? CasherDiscount { get; set; }
        public int? DiscountSell { get; set; }
        public string CustomerName { get; set; }
        public string BranchTransId { get; set; }
        public int? CompanyId { get; set; }
        public double? UsedPoints { get; set; }
        public int? MealPoints { get; set; }
        public bool? InvoiceIsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public bool Equals(Invoice invoice)
        {
            if (InvId == invoice.InvId && InvCode == invoice.InvCode && Total == invoice.Total && CustomerName == invoice.CustomerName && InvPhoneNo == invoice.InvPhoneNo && InvDate == invoice.InvDate)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hashInvId = InvId == null ? 0 : InvId.GetHashCode();
            int hashLInvCode = InvCode == null ? 0 : InvCode.GetHashCode();
            int hashTotal = Total == null ? 0 : Total.GetHashCode();
            int hashCustomerName = CustomerName == null ? 0 : CustomerName.GetHashCode();
            int hashLInvPhoneNo = InvPhoneNo == null ? 0 : InvPhoneNo.GetHashCode();
            int hashInvDate = InvDate == null ? 0 : InvDate.GetHashCode();

            return hashInvId ^ hashLInvCode ^ hashTotal ^ hashCustomerName ^ hashLInvPhoneNo ^ hashInvDate;
        }
    }
}
