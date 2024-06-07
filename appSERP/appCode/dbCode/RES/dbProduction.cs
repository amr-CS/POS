using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.Utils;
using appSERP.Models;
using appSERP.Models.RES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.RES
{
    public class dbProduction: IdbProduction
    {

        private IclsADO _clsADO;
        public dbProduction(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funProductionGET(
        int? pProductionId = null,
        string pProductionCode = null,
        int? pSubSeq = null,
        int? pTransId = null,
        DateTime? pTransDate = null,
        int? pTransStatus = null,
        int? pEmpId = null,
        int? pProdLine = null,
        bool? pIsPosted = null,
        int? pCompanyId = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pProductionDtlId = null,
        int? pItemId = null,
        int? pSourceStore = null,
        int? pDestStore = null,
        int? pSellStore = null,
        int? pAddId = null,
        int? pQTY = null,
        int? pUnitId = null,
        int? pTagId = null,
        string pNOTES = null,
        int? pRemainderQty = null,
        string phNumbers = null,
        int? pLanguageId = null,
        bool? pIsDetail = null,
        int? branchid = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("ProductionId", pProductionId));
            vlstParam.Add(new SqlParameter("ProductionCode", pProductionCode));
            vlstParam.Add(new SqlParameter("SubSeq", pSubSeq));
            vlstParam.Add(new SqlParameter("TransId", pTransId));
            vlstParam.Add(new SqlParameter("TransDate", DateTime.Now));
            vlstParam.Add(new SqlParameter("TransStatus", pTransStatus));
            vlstParam.Add(new SqlParameter("EmpId", pEmpId));
            vlstParam.Add(new SqlParameter("ProdLine", pProdLine));
            vlstParam.Add(new SqlParameter("IsPosted", pIsPosted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("ProductionDtlId", pProductionDtlId));
            vlstParam.Add(new SqlParameter("ItemId", pItemId));
            vlstParam.Add(new SqlParameter("SourceStore", pSourceStore));
            vlstParam.Add(new SqlParameter("DestStore", pDestStore));
            vlstParam.Add(new SqlParameter("SellStore", pSellStore));
            vlstParam.Add(new SqlParameter("AddId", pAddId));
            vlstParam.Add(new SqlParameter("QTY", pQTY));
            vlstParam.Add(new SqlParameter("UnitId", pUnitId));
            vlstParam.Add(new SqlParameter("TagId", pTagId));
            vlstParam.Add(new SqlParameter("NOTES", pNOTES));
            vlstParam.Add(new SqlParameter("RemainderQty", pRemainderQty));
            vlstParam.Add(new SqlParameter("hNumbers", phNumbers));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("IsDetail", pIsDetail));
            vlstParam.Add(new SqlParameter("branchid", branchid));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("RES.spProductionCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        //public static DataTable funGetProductionOrderReport(int? pProductionId = null, int? pDestStore = null,int? pSourceStore = null, DateTime? pTodayDate = null)
        public DataTable funGetProductionOrderReport(int? pProductionId = null, DateTime? pDateFrom = null, DateTime? pDateTo = null, bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
   
          vlstParam.Add(new SqlParameter("ProductionId", pProductionId));
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            //vlstParam.Add(new SqlParameter("TodayDate", pTodayDate));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));
            vData = _clsADO.funFillDataTable("RES.spProductionOrderReport", vlstParam, "Data GET");


            return vData;
        }
        public DataTable funGetProductionContentReport(int? pProductionId = null, DateTime? pDateFrom = null, DateTime? pDateTo = null, bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters



            List<SqlParameter> vlstParam = new List<SqlParameter>();

            vlstParam.Add(new SqlParameter("ProductionId", pProductionId));
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));
            vData = _clsADO.funFillDataTable("RES.spProductionContentReport", vlstParam, "Data GET");


            return vData;
        }
        public DataTable funGetProductionOutReport(int? pProductionId = null, DateTime? pDateFrom = null, DateTime? pDateTo = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters



            List<SqlParameter> vlstParam = new List<SqlParameter>();

            vlstParam.Add(new SqlParameter("ProductionId", pProductionId));
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));

            vData = _clsADO.funFillDataTable("RES.spProductionOutReport", vlstParam, "Data GET");


            return vData;
        }
   
        public object AddQtyBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? InvType, int? StoreId, DateTime? InvDate, int? UserId = null, int? BranchId = null)
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("InvoiceDtls", InvoiceDtls);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvoiceDtls", xml));
            vlstParam.Add(new SqlParameter("InvId", InvId));
            vlstParam.Add(new SqlParameter("InvType", InvType));
            vlstParam.Add(new SqlParameter("StoreId", StoreId));
            vlstParam.Add(new SqlParameter("InvDate", InvDate));
            vlstParam.Add(new SqlParameter("UserId", UserId));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            return _clsADO.funExecuteScalar("[INV].[spInvoiceAddQty_Bulk]", vlstParam, "Data GET");
        }
        public object RemoveQtyBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? InvType, int? StoreId, DateTime? InvDate, int? UserId = null, int? BranchId = null)
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("InvoiceDtls", InvoiceDtls);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvoiceDtls", xml));
            vlstParam.Add(new SqlParameter("InvId", InvId));
            vlstParam.Add(new SqlParameter("InvType", InvType));
            vlstParam.Add(new SqlParameter("StoreId", StoreId));
            vlstParam.Add(new SqlParameter("InvDate", InvDate));
            vlstParam.Add(new SqlParameter("UserId", UserId));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            return _clsADO.funExecuteScalar("[INV].[spInvoiceRemoveQty_Bulk]", vlstParam, "Data GET");
        }

        public object ProductionBulk(ICollection<Production> ProductionDtl, int? ProductionId)
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("ProductionDtl", ProductionDtl);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("ProductionDtl", xml));
            vlstParam.Add(new SqlParameter("ProductionId", ProductionId));
            return _clsADO.funExecuteScalar("[RES].[spProductionOrder_Bulk]", vlstParam, "Data GET");
        }
    }
}