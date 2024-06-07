using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.User.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace appSERP.appCode.Setting.User
{
    public class clsUserType : IclsUserType
    {
        public int vUserTypeIdAdmin { get; set; } = 1;
        public string vUserTypeCodeAdmin { get; set; } = "123";
        public string vUserTypeNameL1Admin { get; set; } = "";
        public string vUserTypeNameL2Admin { get; set; } = "";
        public int vUserTypeMaxDisAdmin { get; set; } = 0;


        public int vUserTypeIdSystemUser { get; set; } = 1;
        public string vUserTypeCodeSystemUser { get; set; } = "123";
        public string vUserTypeNameL1SystemUser { get; set; } = "";
        public string vUserTypeNameL2SystemUser { get; set; } = "";
        public int vUserTypeMaxDisSystemUser { get; set; } = 0;

        private IclsAPI _clsAPI;
        public clsUserType(IclsAPI clsAPI)
        {
            _clsAPI = clsAPI;
        }

        // 
        public void funUserTypeGET()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIUserType;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);

            // User Type Admin
            vUserTypeIdAdmin = Convert.ToInt32(vDtData.Rows[0]["UserTypeId"]);
            vUserTypeCodeAdmin = vDtData.Rows[0]["UserTypeCode"].ToString();
            vUserTypeNameL1Admin = vDtData.Rows[0]["UserTypeNameL1"].ToString();
            vUserTypeNameL2Admin = vDtData.Rows[0]["UserTypeNameL2"].ToString();
            vUserTypeMaxDisAdmin = Convert.ToInt32(vDtData.Rows[0]["UserTypeMaxDis"]);
            // User Type SystemUser
            vUserTypeIdSystemUser = Convert.ToInt32(vDtData.Rows[1]["UserTypeId"]);
            vUserTypeCodeSystemUser = vDtData.Rows[1]["UserTypeCode"].ToString();
            vUserTypeNameL1SystemUser = vDtData.Rows[1]["UserTypeNameL1"].ToString();
            vUserTypeNameL2SystemUser = vDtData.Rows[1]["UserTypeNameL2"].ToString();
            vUserTypeMaxDisSystemUser = Convert.ToInt32(vDtData.Rows[1]["UserTypeMaxDis"]);
        }

    }
}