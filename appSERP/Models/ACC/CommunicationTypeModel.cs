using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{
    public class CommunicationTypeModel
    {
        public int    TypeId       { get; set; }
        public string TypeCode     { get; set; }
        public string TypeNameL1   { get; set; }
        public string TypeNameL2   { get; set; }
        public bool   TypeIsActive { get; set; }
    }
}