using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.Setting.GD.Abstract
{
    public interface IDevCompanySetting
    {
        int DevCompanyId { get; set; }
        string DevCompanyNameL1 { get; set; }
        string DevCompanyNameL2 { get; set; }
        string DevAppNameL1 { get; set; }
        string DevAppNameL2 { get; set; }
        string DevCompanyPhone { get; set; }
        string DevCompanyPhone2 { get; set; }
        string DevCompanyEmail { get; set; }
        string DevCompanyWebsite { get; set; }
        string DevCompanyAddress { get; set; }
        string DevCompanyImage { get; set; }
        string DevAppImage { get; set; }
        bool DevCompanyIsActive { get; set; }
        DataTable SetDevCompanySetting();
    }
}
