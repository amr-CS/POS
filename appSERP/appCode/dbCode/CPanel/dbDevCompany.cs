using appSERP.appCode.dbCode.CPanel.Abstract;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.GD
{
    ///  BELAL    16/2/2019 
    public class dbDevCompany : IdbDevCompany
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbDevCompany(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funDevCompanyGET(
        int? pDevCompanyId  = null,
        string pDevCompanyNameL1  = null,
        string pDevCompanyNameL2 = null,
        string pDevCompanyPhone = null, 
        string pDevCompanyPhone2 = null, 
        string pDevCompanyEmail = null, 
        string pDevCompanyWebsite = null, 
        string pDevCompanyAddress = null, 
        object pDevCompanyImage = null,
        object pDevCompanyImageFull = null,
         string pDevAppNameL1 = null,
        string pDevAppNameL2 = null,
         object pDevAppImage = null,
        bool? pDevCompanyIsActive  = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DevCompanyId", pDevCompanyId));
            vlstParam.Add(new SqlParameter("DevCompanyNameL1", pDevCompanyNameL1));
            vlstParam.Add(new SqlParameter("DevCompanyNameL2", pDevCompanyNameL2));
            vlstParam.Add(new SqlParameter("DevCompanyPhone", pDevCompanyPhone));
            vlstParam.Add(new SqlParameter("DevCompanyPhone2", pDevCompanyPhone2));
            vlstParam.Add(new SqlParameter("DevCompanyEmail", pDevCompanyEmail));
            vlstParam.Add(new SqlParameter("DevCompanyWebsite", pDevCompanyWebsite));
            vlstParam.Add(new SqlParameter("DevCompanyAddress", pDevCompanyAddress));
            vlstParam.Add(new SqlParameter("DevCompanyImage", pDevCompanyImage));
            vlstParam.Add(new SqlParameter("DevCompanyImageFull", pDevCompanyImageFull));
            vlstParam.Add(new SqlParameter("DevAppNameL1", pDevAppNameL1));
            vlstParam.Add(new SqlParameter("DevAppNameL2", pDevAppNameL2));
            vlstParam.Add(new SqlParameter("DevAppImage", pDevAppImage));
            vlstParam.Add(new SqlParameter("DevCompanyIsActive ", pDevCompanyIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("GD.spDevCompanyCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}