using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace appSERP.appCode.dbCode.SEC
{
    public class dbUserLock : IdbUserLock
    {
        // System Message
        public string vSystemMessage { get; set; } = "";
        public int vSystemMessageTypeId { get; set; } = 0;

        private IclsADO _clsADO;
        public dbUserLock(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        // UserLockLock Save
        public string funUserLockGET(
            int? pUserLockId = null,
            int? pUserId = null,
            string pDevice = "",
            DateTime? pLastLoginTime = null,
            int? pQueryTypeId = null)
        {
            // Declaration
            string vUserLock;
            // Parameters
            List<SqlParameter> vlsParam = new List<SqlParameter>();
            vlsParam.Add(new SqlParameter("UserLockId", pUserLockId));
            vlsParam.Add(new SqlParameter("UserId", pUserId));
            vlsParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlsParam.Add(new SqlParameter("Device", pDevice));
            vlsParam.Add(new SqlParameter("LastLoginTime", clsTimeSetting.funBranchTime()));
            vlsParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));

            vUserLock = _clsADO.funExecuteScalar("SEC.spUserLockCRUD", vlsParam, "UserLock Save").ToString();
            // Execute
            return vUserLock;
        }


    }
}