using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.SEC
{
    public class SecurityRoleExceptionModel
    {

        public int SecurityRoleExceptionId { get; set; }

        public string SecurityRoleExceptionCode { get; set; }

        public string SecurityRoleExceptionNameL1 { get; set; }

        public string SecurityRoleExceptionNameL2 { get; set; }

        public bool SecurityRoleExceptionIsActive { get; set; } = true;
    }
}