using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.ReportSetting;
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

namespace appSERP.appCode.dbCode.RES
{
    public class dbPrinter: IdbPrinter
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbPrinter(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funPrinterGET(
         int? pPrinterId  = null,
         string pPrinterCode = null, 
        int? pPrinterSeq = null,
        string pReportNameL1    = null, 
        string pReportNameL2 = null, 
        string pPrinterDescL1 = null, 
        string pPrinterDescL2 = null,
        bool? pPrinterIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null,
        string pPrintersList = null
        )
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("PrinterId", pPrinterId));
            vlstParam.Add(new SqlParameter("PrinterCode", pPrinterCode));
            vlstParam.Add(new SqlParameter("PrinterSeq", pPrinterSeq));
            vlstParam.Add(new SqlParameter("ReportNameL1", pReportNameL1));
            vlstParam.Add(new SqlParameter("ReportNameL2", pReportNameL2));
            vlstParam.Add(new SqlParameter("PrinterDescL1", pPrinterDescL1));
            vlstParam.Add(new SqlParameter("PrinterDescL2", pPrinterDescL2));
            vlstParam.Add(new SqlParameter("PrinterIsActive", pPrinterIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("PrintersList", pPrintersList));

            
            vData = _clsADO.funExecuteScalar("RES.spAllPrintersCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }


        public DataTable funGetPrinterReport(bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));
            vData = _clsADO.funFillDataTable("RES.GetPrintersReport", vlstParam, "Data GET");


            return vData;
        }

     
    }
}
