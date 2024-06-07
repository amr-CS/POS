using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Controllers.DataController.FA
{
    public class AssetReleaseDetailModel
    {
        public int AssetReleaseDetailId { get; set; }
        [Display(Name = "AssetReleaseDetail", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AssetReleaseDetailNameL1 { get; set; }
        [Display(Name = "AssetReleaseDetail", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AssetReleaseDetailNameL2 { get; set; }
        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string AssetReleaseDetailCode { get; set; }
        [Display(Name = "_Qty", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetReleaseQty { get; set; }
        [Display(Name = "_Seq", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetReleaseSeq { get; set; }
        [Display(Name = "AssetRelease", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetReleaseId { get; set; }
        [Display(Name = "AssetId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int AssetId { get; set; }
        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool AssetReleaseDetailIsActive { get; set; } = true;
    }
}