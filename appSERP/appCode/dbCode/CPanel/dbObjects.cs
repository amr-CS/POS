using appSERP.appCode.dbCode.SYSSETT.Abstract;
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

namespace appSERP.appCode.dbCode.SYSSETT
{
    public class dbObjects : IdbObjects
    {
        // Message
        public string vSQLResult { get; set; }
        public string vSQLResultTypeId { get; set; }

        // ObjectName
        public string vObjectName { get; set; }

        private IclsADO _clsADO;
        public dbObjects(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funObjectsGET(
        int? pObjectId = null,
         int? pObjectSeq = null,
        string pObjectProName = null,
        string pObjectCode = null,
        string pObjectNameL1 = null,
        string pObjectNameL2 = null,
        string pObjectNameL3 = null,
        string pObjectNameL4 = null,
        string pObjectNameL5 = null,
        string pObjectNameL6 = null,
        string pObjectNameL7 = null,
        string pObjectNameL8 = null,
        string pObjectNameL9 = null,
        string pObjectNameL10 = null,
        string pObjectIconW = null,
        string pObjectIconB = null,
        string pObjectAction = null,
        string pObjectImage = null,
        string pObjectURL = null,
        bool? pObjectIsMainMenu = null,
        bool? pObjectIsActive = null,
        int? pObjectTypeId = null,
        int? pCompanyId = null,
        int? pLanguageId = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("ObjectId", pObjectId));
            vlstParam.Add(new SqlParameter("ObjectSeq", pObjectSeq));
            vlstParam.Add(new SqlParameter("ObjectProName", pObjectProName));
            vlstParam.Add(new SqlParameter("ObjectCode", pObjectCode));
            vlstParam.Add(new SqlParameter("ObjectNameL1", pObjectNameL1));
            vlstParam.Add(new SqlParameter("ObjectNameL2", pObjectNameL2));
            vlstParam.Add(new SqlParameter("ObjectNameL3", pObjectNameL3));
            vlstParam.Add(new SqlParameter("ObjectNameL4", pObjectNameL4));
            vlstParam.Add(new SqlParameter("ObjectNameL5", pObjectNameL5));
            vlstParam.Add(new SqlParameter("ObjectNameL6", pObjectNameL6));
            vlstParam.Add(new SqlParameter("ObjectNameL7", pObjectNameL7));
            vlstParam.Add(new SqlParameter("ObjectNameL8", pObjectNameL8));
            vlstParam.Add(new SqlParameter("ObjectNameL9", pObjectNameL9));
            vlstParam.Add(new SqlParameter("ObjectNameL10", pObjectNameL10));
            vlstParam.Add(new SqlParameter("ObjectIconW", pObjectIconW));
            vlstParam.Add(new SqlParameter("ObjectIconB", pObjectIconB));
            vlstParam.Add(new SqlParameter("ObjectAction", pObjectAction));
            vlstParam.Add(new SqlParameter("ObjectImage", pObjectImage));
            vlstParam.Add(new SqlParameter("ObjectURL", pObjectURL));
            vlstParam.Add(new SqlParameter("ObjectIsMainMenu", pObjectIsMainMenu));
            vlstParam.Add(new SqlParameter("ObjectIsActive", pObjectIsActive));
            vlstParam.Add(new SqlParameter("ObjectTypeId", pObjectTypeId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SYSSETT.spObjectCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
       
    }
}