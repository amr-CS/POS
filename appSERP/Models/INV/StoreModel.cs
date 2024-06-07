using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.INV
{
    public class StoreModel
    {
        public int StoreId { get; set; }
        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string StoreCode { get; set; }
        [Display(Name = "_Store", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string StoreNameL1 { get; set; }
        [Display(Name = "_Store", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string StoreNameL2 { get; set; }
        [Display(Name = "StoreShortName", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string StoreShortName { get; set; }
        [Display(Name = "StoreTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string StoreTypeId { get; set; }
        [Display(Name = "_Country", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int CountryId { get; set; }
        [Display(Name = "_City", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int CityId { get; set; }
        [Display(Name = "_Note", ResourceType = typeof(appResource))]
        public string StoreNotes { get; set; }
        [Display(Name = "_Phone1", ResourceType = typeof(appResource))]
        public string StorePhone { get; set; }
        [Display(Name = "_Address", ResourceType = typeof(appResource))]
        public string StoreAddress { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool StoreIsActive { get; set; }
   
    }
}