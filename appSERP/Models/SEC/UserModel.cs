using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.SEC
{   ///  BELAL    21/1/2018 
    public class UserModel
    {
        public int UserId               { get; set; }

        [Display(Name = "_UserFullName", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserFullName      { get; set; }

        [Display(Name = "_Address", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserAddress       { get; set; }

        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        public string UserCode          { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserName          { get; set; }

        [Display(Name = "UserPassword", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserPassword      { get; set; }

        [Display(Name = "ConfirmPassword", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        [Compare("UserPassword", ErrorMessage = "تأكيد الباسورد غير صحيح")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "_Phone1", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserPhone         { get; set; }

        [Display(Name = "Printer", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string Printer { get; set; }
        [Display(Name = "_Email", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserEmail         { get; set; }

        [Display(Name = "IsUserLock", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool IsUserLock          { get; set; }

        [Display(Name = "_Image", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string UserImage         { get; set; }


        [Display(Name = "UserTimeZoneId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int UserTimeZoneId { get; set; }

        [Display(Name = "UserTimeZoneIsDST", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool UserTimeZoneIsDST { get; set; }

        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool UserIsActive        { get; set; } = true;

        [Display(Name = "SecurityGradeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int SecurityGradeId      { get; set; }

        [Display(Name = "_Language", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int LanguageId           { get; set; }

        [Display(Name = "_Country", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int CountryId            { get; set; }

        [Display(Name = "FontSizeTypeId", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int FontSizeTypeId       { get; set; }

        [Display(Name = "_UserType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public int UserTypeId           { get; set; }
    }
}