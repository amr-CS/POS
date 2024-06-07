using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models
{
    public class AdminModel
    {
        public int     AdminId { get; set; }
        public string  AdminCode { get; set; }
        public string  AdminNameL1 { get; set; }
        public string  AdminNameL2 { get; set; }
        public string  AdminPassword { get; set; }
        public bool    AdminIsActive { get; set; }
    }
}