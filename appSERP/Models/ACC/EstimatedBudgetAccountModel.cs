using appSERP.Views.Shared.appResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appSERP.Models.ACC
{
    public class EstimatedBudgetAccountModel
    {

        public int EstimatedBudgetAccountId { get; set; }
        [Display(Name = "_Account", ResourceType = typeof(appResource))]
        public int AccountId { get; set; }
        [Display(Name = "_Value", ResourceType = typeof(appResource))]
        public decimal EstimatedBudgetAccountValue { get; set; }
    }
}