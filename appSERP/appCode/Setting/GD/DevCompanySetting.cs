using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace appSERP.appCode.Setting.GD
{
    //Belal 16/2/2019
    public class DevCompanySetting : IDevCompanySetting
    {
        private IclsAPI _clsAPI;
        public DevCompanySetting(IclsAPI clsAPI)
        {
            _clsAPI = clsAPI;
        }
        public int DevCompanyId { get; set; } = 0;
        public string DevCompanyNameL1 { get; set; } = string.Empty;
        public string DevCompanyNameL2 { get; set; } = string.Empty;
        public string DevAppNameL1 { get; set; } = string.Empty;
        public string DevAppNameL2 { get; set; } = string.Empty;
        public string DevCompanyPhone { get; set; } = string.Empty;
        public string DevCompanyPhone2 { get; set; } = string.Empty;
        public string DevCompanyEmail { get; set; } = string.Empty;
        public string DevCompanyWebsite { get; set; } = string.Empty;
        public string DevCompanyAddress { get; set; } = string.Empty;
        public string DevCompanyImage { get; set; } = string.Empty;
        public string DevAppImage { get; set; } = string.Empty;
        public bool DevCompanyIsActive { get; set; }

        public DataTable SetDevCompanySetting()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIDevCompany;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            DevCompanyId = Convert.ToInt32(vDtData.Rows[0]["DevCompanyId"].ToString());
            DevCompanyNameL1 = vDtData.Rows[0]["DevCompanyNameL1"].ToString();
            DevCompanyNameL2 = vDtData.Rows[0]["DevCompanyNameL2"].ToString();
            DevCompanyPhone = vDtData.Rows[0]["DevCompanyPhone"].ToString();
            DevCompanyPhone2 = vDtData.Rows[0]["DevCompanyPhone2"].ToString();
            DevCompanyEmail = vDtData.Rows[0]["DevCompanyEmail"].ToString();
            DevCompanyWebsite = vDtData.Rows[0]["DevCompanyWebsite"].ToString();
            DevCompanyAddress = vDtData.Rows[0]["DevCompanyAddress"].ToString();
            DevCompanyImage = vDtData.Rows[0]["DevCompanyImage"].ToString();
            DevAppNameL1 = vDtData.Rows[0]["DevAppNameL1"].ToString();
            DevAppNameL2 = vDtData.Rows[0]["DevAppNameL2"].ToString();
            DevAppImage = vDtData.Rows[0]["DevAppImage"].ToString();
            DevCompanyIsActive = Convert.ToBoolean(vDtData.Rows[0]["DevCompanyIsActive"]);

            // Return Result
            return vDtData;
        }
    }

}