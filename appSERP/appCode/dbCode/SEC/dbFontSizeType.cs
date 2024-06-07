using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.Company;
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
    public class dbFontSizeType: IdbFontSizeType
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbFontSizeType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funFontSizeTypeGET(
        int? pFontSizeTypeId = null,
        string pFontSizeTypeNameL1 = null,
        string pFontSizeTypeNameL2 = null,
        int? pFontSizeTypeValue = null,
        bool? pFontSizeTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("FontSizeTypeId", pFontSizeTypeId));
            vlstParam.Add(new SqlParameter("FontSizeTypeNameL1", pFontSizeTypeNameL1));
            vlstParam.Add(new SqlParameter("FontSizeTypeNameL2", pFontSizeTypeNameL2));
            vlstParam.Add(new SqlParameter("FontSizeTypeValue", pFontSizeTypeValue));
            vlstParam.Add(new SqlParameter("FontSizeTypeIsActive", pFontSizeTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SEC.spFontSizeTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}