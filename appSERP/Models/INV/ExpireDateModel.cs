using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class ExpireDateModel
    {
        public int ExpireDateId { get; set; }
        public string ExpireDateCode { get; set; }
        public DateTime ExpireDate { get; set; }
        public int ItemId { get; set; }
        public bool ExpireDateIsActive { get; set; }
       
    }
}