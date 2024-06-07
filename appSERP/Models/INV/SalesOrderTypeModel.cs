using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class SalesOrderTypeModel
    {

        public int SalesOrderTypeId { get; set; }
        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SalesOrderTypeCode { get; set; }

        [Display(Name = "SalesOrderTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SalesOrderTypeNameL1 { get; set; }

        [Display(Name = "SalesOrderTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string SalesOrderTypeNameL2 { get; set; }
        [Display(Name = "Abbr", ResourceType = typeof(appResource))]
        public string Abbr { get; set; }
        [Display(Name = "_IsDefault", ResourceType = typeof(appResource))]
        public bool IsDefault { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool SalesOrderTypeIsActive { get; set; } = true;
    }
}