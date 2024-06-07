using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace appSERP.Models.RES
{
    public class Floor
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; }
        public int TableId { get; set; }
        public string TableName { get; set; }
        public string Tablestatue { get; set; }
    }
}