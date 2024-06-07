using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.RES
{
    public class MenuItemModel
    {
        public int id { get; set; }
        public int MenuId { get; set; }
        public int SupplierId { get; set; }
        public int ItemId { get; set; }
        public float Price { get; set; }
    }
}