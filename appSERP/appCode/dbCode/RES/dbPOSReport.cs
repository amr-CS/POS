using appSERP.appCode.dbCode.RES.Abstract;
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

namespace appSERP.appCode.dbCode.RES
{
    public class dbPOSReport: IdbPOSReport
    {
        private IclsADO _clsADO;
        public dbPOSReport(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public DataTable funPOSReportGET(
        DateTime? pDateFrom = null,
        DateTime? pDateTo = null,
        DateTime? pTodayDate = null,
        int ? pCashierId = null,
        int? BranchId=null
        )
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("TodayDate", pTodayDate));
            vlstParam.Add(new SqlParameter("CashierId", pCashierId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vData = _clsADO.funFillDataTable("RES.spPOSReport", vlstParam, "Data GET");
            return vData;
        }
        public DataTable SheepReportGET(
      DateTime? pDateFrom = null,
      DateTime? pDateTo = null,
      DateTime? pTodayDate = null,
      int? pCashierId = null
      )
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("TodayDate", pTodayDate));
            vlstParam.Add(new SqlParameter("CashierId", pCashierId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vData = _clsADO.funFillDataTable("RES.spInvoiceSheep", vlstParam, "Data GET");
            return vData;
        }
        public DataTable funPOSDTLReportGET(
    DateTime? pDateFrom = null,
    DateTime? pDateTo = null,
         DateTime? pTodayDate = null,
             int? pCashierId = null,
             int? BranchId = null
         )
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("TodayDate", pTodayDate));
            vlstParam.Add(new SqlParameter("CashierId", pCashierId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vData = _clsADO.funFillDataTable("RES.spPOSReportDTL", vlstParam, "Data GET");
            return vData;
        }
        public DataTable funPOSGroupingReportGET(
 DateTime? pDateFrom = null,
 DateTime? pDateTo = null,
      DateTime? pTodayDate = null,
          int? pCashierId = null,
             int? BranchId = null
      )
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("TodayDate", pTodayDate));
            vlstParam.Add(new SqlParameter("CashierId", pCashierId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName)); 
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vData = _clsADO.funFillDataTable("RES.spPOSGroupingReport", vlstParam, "Data GET");
            return vData;
        }


        public DataTable funDriverReportGET(
            DateTime? pDateFrom = null,
            DateTime? pDateTo = null,
            DateTime? pTodayDate = null,
            int? InvTypeId=null,
            int? BranchId = null
            )
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("InvTypeId", InvTypeId));
            vlstParam.Add(new SqlParameter("TodayDate", pTodayDate));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vData = _clsADO.funFillDataTable("[RES].[spDelivaryReport]", vlstParam, "Data GET");
            return  vData;
        }



        public DataTable funDriverCashReportGET(
          DateTime? pDateFrom = null,
          DateTime? pDateTo = null,
          DateTime? pTodayDate = null,
          int? DeliveryId=null,
          int? CashierId=null)
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("TodayDate", pTodayDate));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId",clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CashierId", CashierId));
            vlstParam.Add(new SqlParameter("DeliveryId", DeliveryId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vData = _clsADO.funFillDataTable("[RES].[spDelivaryCashReport]", vlstParam, "Data GET");
            return vData;
        }




        public DataTable funPOSGroupingCasherReportGET(
          DateTime? pDateFrom = null,
          DateTime? pDateTo = null,
          DateTime? pTodayDate = null,
          int? pCashierId = null
      )
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("TodayDate", pTodayDate));
            vlstParam.Add(new SqlParameter("CashierId", pCashierId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vData = _clsADO.funFillDataTable("RES.spPOSGroupingCasherReport", vlstParam, "Data GET");
            return vData;
        }
        public DataTable funPOSDTLCasherReportGET(
DateTime? pDateFrom = null,
DateTime? pDateTo = null,
       DateTime? pTodayDate = null,
           int? pCashierId = null
       )
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("TodayDate", pTodayDate));
            vlstParam.Add(new SqlParameter("CashierId", pCashierId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vData = _clsADO.funFillDataTable("RES.spPOSDTLCasherReport", vlstParam, "Data GET");
            return vData;
        }
        public DataTable funPOSInsReportGET(
DateTime? pDateFrom = null,
DateTime? pDateTo = null,
   DateTime? pTodayDate = null,
       int? pCashierId = null
   )
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("TodayDate", pTodayDate));
            vlstParam.Add(new SqlParameter("CashierId", pCashierId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vData = _clsADO.funFillDataTable("RES.spPOSInsuranceMovReport", vlstParam, "Data GET");
            return vData;
        }

        public DataTable funPOSInsReturnReportGET(
DateTime? pDateFrom = null,
DateTime? pDateTo = null,
DateTime? pTodayDate = null,
    int? pCashierId = null
)
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("TodayDate", pTodayDate));
            vlstParam.Add(new SqlParameter("CashierId", pCashierId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vData = _clsADO.funFillDataTable("RES.spPOSInsuranceReturnMovReport", vlstParam, "Data GET");
            return vData;
        }


        public DataTable funPOSDeletedReportGET(
DateTime? pDateFrom = null,
DateTime? pDateTo = null,
DateTime? pTodayDate = null,
       int? pCashierId = null,
       int? CustomerId = null,
       bool?IsCancel=null,
       int?InvType=null

            )
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("TodayDate", pTodayDate));
            vlstParam.Add(new SqlParameter("InvType", InvType));
            vlstParam.Add(new SqlParameter("CashierId", pCashierId));
            vlstParam.Add(new SqlParameter("CustomerId", CustomerId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsCancel", IsCancel));
            vData = _clsADO.funFillDataTable("RES.spPOSInsuranceMovDeletedReport", vlstParam, "Data GET");
            return vData;
        }
        public DataTable funPOSReceiptVoucherReportGET(
DateTime? pDateFrom = null,
DateTime? pDateTo = null,
DateTime? pTodayDate = null
 //,int? pCashierId = null
        )
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("TodayDate", pTodayDate));
            //vlstParam.Add(new SqlParameter("CashierId", pCashierId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vData = _clsADO.funFillDataTable("ACC.spGetReceiptVoucherTotal", vlstParam, "Data GET");
            return vData;
        }

    }
}