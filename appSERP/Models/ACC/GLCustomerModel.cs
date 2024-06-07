using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{
    public class GLCustomerModel
    {
    
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerSequence { get; set; }
        public string SeqByType { get; set; }
        public string CustomerNameL1 { get; set; }
        public string CustomerNameL2 { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerPostBox { get; set; }
        public string CustomerFax { get; set; }
        public string CustomerEmail { get; set; }
        public string AuthorizePerson { get; set; }
        public int CustomerTypeId { get; set; }
        public int SalesId { get; set; }
        public int SellCostTypeId { get; set; }
        public int CustomerDailyStopType { get; set; }
        public int CustomerDailyDay { get; set; }
        public int AreaId { get; set; }
        public int CategoryId { get; set; }
        public int Status { get; set; }
        public string AuthorizePersonTel { get; set; }
        public string CustomerVATCode { get; set; }
        public int CustomerParentId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public decimal CustomerAmountLimit { get; set; }
        public int AccountId { get; set; }
        
        public Boolean CustomerIsActive { get; set; }
       

    }
}