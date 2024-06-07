using appSERP.appCode.dbCode.INV.Abstract;
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

namespace appSERP.appCode.dbCode.INV
{
    public class dbInvStoreItemQty: IdbInvStoreItemQty
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }
        private IclsADO _clsADO;
        public dbInvStoreItemQty(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public DataTable funInvStoreItemQtyGET(

        int? pInvStoreItemQtyId  = null,
        int? pStoreId  = null,
       int? pItemId  = null,
        DateTime? pExpireDate  = null,
        float?  pItemOpenQty  = null,
        float? pItemQty = null,
        int? IsZero = null,
        int? ReportTypeId = null,
        float? pItemReservedQty  = null,
        string pNotes  = null, 
       string pUSERNAME  = null, 
       float? pItemOpenCost  = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null,
        int? pUnitId = null,
        int? pItemType = null)
        {
            // Declaration 
            //string vData = string.Empty;
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvStoreItemQtyId", pInvStoreItemQtyId));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("ItemId", pItemId));
            vlstParam.Add(new SqlParameter("ExpireDate", pExpireDate));
            vlstParam.Add(new SqlParameter("ItemOpenQty", pItemOpenQty));
            vlstParam.Add(new SqlParameter("ItemQty", pItemQty));
            vlstParam.Add(new SqlParameter("ItemReservedQty", pItemReservedQty));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("USERNAME", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsZero", IsZero));
            vlstParam.Add(new SqlParameter("ReportTypeId", ReportTypeId));
            vlstParam.Add(new SqlParameter("ItemOpenCost", pItemOpenCost));
            vlstParam.Add(new SqlParameter("CompanyId", clsUser.vUserCompanyId));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("UnitId", pUnitId));
            vlstParam.Add(new SqlParameter("ItemType", pItemType));
            //vData = _clsADO.funExecuteScalar("INV.spInvStoreItemQtyCRUD", vlstParam, "Data GET").ToString();
            vData = _clsADO.funFillDataTable("INV.spInvStoreItemQtyCRUD", vlstParam, "Data GET");
            return vData;
        }
        public DataTable funGetProductionQtyReport(int? pStoreId = null,int? pItemId = null, int? pItemType = null,int? pUnitId = null,string pType = null,
                int? IsZero = null,
        int? ReportTypeId = null, int ?BranchId=null
            )
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();

            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("ItemId", pItemId));
            vlstParam.Add(new SqlParameter("ItemType", pItemType));
            vlstParam.Add(new SqlParameter("UnitId", pUnitId));
            vlstParam.Add(new SqlParameter("IsZero", IsZero));
            vlstParam.Add(new SqlParameter("ReportTypeId", ReportTypeId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("Type", pType));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));

            vData = _clsADO.funFillDataTable("INV.spInvStoreItemQtyReport", vlstParam, "Data GET");


            return vData;
        }
    }
}