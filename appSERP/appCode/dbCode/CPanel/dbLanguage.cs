using appSERP.appCode.dbCode.SETT.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace appSERP.appCode.dbCode.SETT
{
    public class dbLanguage: IdbLanguage
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbLanguage(clsADO clsADO)
        {
            _clsADO = clsADO;
        }


        public string funLanguageGET(
            int? pLanguageId = null,
            string pLanguageCode = null,
            string pLanguageNameL1 = null,
            string pLanguageNameL2 = null,
            string pCultureName = null,
            string pLanguageImage = null,
            int? pDefaultFontId = null,
            bool? pLanguageIsActive = null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("LanguageId", pLanguageId));
            vlstParam.Add(new SqlParameter("LanguageCode", pLanguageCode));
            vlstParam.Add(new SqlParameter("LanguageNameL1", pLanguageNameL1));
            vlstParam.Add(new SqlParameter("LanguageNameL2", pLanguageNameL2));
            vlstParam.Add(new SqlParameter("CultureName", pCultureName));
            vlstParam.Add(new SqlParameter("LanguageImage", pLanguageImage));
            vlstParam.Add(new SqlParameter("DefaultFontId", pDefaultFontId));
            vlstParam.Add(new SqlParameter("LanguageIsActive", pLanguageIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("UserLanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SETT.spLanguageCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }

        // User Language GET
        public DataTable funUserLanguageGET()
        {
            // Declaration 
            string vData = null;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("LanguageIsActive", true));
            vlstParam.Add(new SqlParameter("IsDeleted", false));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("QueryTypeId", clsQueryType.qSelectExtra));
            vData = _clsADO.funExecuteScalar("SETT.spLanguageCRUD", vlstParam, "User Language GET").ToString();

            // Data [Data Table]
            DataTable vDtResult = new DataTable();
            // Check Result
            if (!string.IsNullOrEmpty(vData))
            {
                try
                {
                    vDtResult = JsonConvert.DeserializeObject<DataTable>(vData);
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            // Return Result
            return vDtResult;
        }

        
    }
}