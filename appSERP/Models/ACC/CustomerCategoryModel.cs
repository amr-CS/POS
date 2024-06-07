using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{
    public class CustomerCategoryModel
    {

        public int CustomerCategoryId { get; set; }
        public string CustomerCategoryCode { get; set; }

        public string CustomerCategoryNameL1 { get; set; }


        public string CustomerCategoryNameL2 { get; set; }



        public bool CustomerCategoryIsActive { get; set; } = true;
    }
}