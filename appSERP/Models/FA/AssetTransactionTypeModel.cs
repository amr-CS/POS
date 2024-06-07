﻿using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{   
    public class AssetTransactionTypeModel
    {
        public int TransactionTypeId       { get; set; }
        [Display(Name = "_Code", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string TransactionTypeCode     { get; set; }

        [Display(Name = "_TransactionType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string TransactionTypeNameL1   { get; set; }

        [Display(Name = "_TransactionType", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public string TransactionTypeNameL2   { get; set; }


        [Display(Name = "_IsActive", ResourceType = typeof(appResource))]
        [Required(ErrorMessageResourceType = typeof(appResource), ErrorMessageResourceName = "msgRequired")]
        public bool TransactionTypeIsActive { get; set; } = true;
    }
}