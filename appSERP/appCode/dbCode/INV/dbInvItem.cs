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
using System.Threading.Tasks;
using System.Web;

namespace appSERP.appCode.dbCode.INV
{
    public class dbInvItem : IdbInvItem
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbInvItem(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        //UnUsed anymore
        //public static int? ToNullableInt(this string s)
        //{
        //    int i;
        //    if (int.TryParse(s, out i)) return i;
        //    return null;
        //}
        public DataTable MealData(DateTime DateFrom, DateTime DateTo, int? CashId, int? ItemId, bool? IsGrouping)
        {

            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", DateFrom));
            vlstParam.Add(new SqlParameter("DateTo", DateTo));
            vlstParam.Add(new SqlParameter("CashId", CashId));
            vlstParam.Add(new SqlParameter("ItemId", ItemId));
            vlstParam.Add(new SqlParameter("IsGrouping", IsGrouping));
            
            return _clsADO.funFillDataTable("Res.NewReportStatMeals", vlstParam, "Data GET");
            
        }
        #region Added by BH
        // دالة إستعلام عن كود الصنف هل هو موجود
        public DataTable GetItemCode(string pInvItemCode, int? pInvItemId = null)
        {
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            string strWhere = "InvItemCode=@InvItemCode and IsDeleted=@pIsDeleted"; 
            if(pInvItemId !=null && pInvItemId > 0)
            {
                vlstParam.Add(new SqlParameter("@InvItemId", pInvItemId));
                strWhere += " and invItemId != @InvItemId";
            }            
            vlstParam.Add(new SqlParameter("@InvItemCode", pInvItemCode));
            vlstParam.Add(new SqlParameter("@pIsDeleted", false));
            string queryText = $"select invItemId, InvItemCode from INV.tblInvItem where {strWhere}";
            var dt= _clsADO.funFillDataTableQuery(queryText, vlstParam);
            return dt;
        }
        #endregion
        public string funInvItemGET(
int? BranchId =null,
        int? pInvItemId = null,
        string pInvItemCode = null,
        string pInvItemCodeSearch = null,
        string pInvItemSymbol = null,
        string pInvItemBarCode = null,
        string pInvItemNameL1 = null,
        string pInvItemNameL2 = null,
        int? pCategoryId = null,

        bool? pHasEdate = null,
        bool? pFollowUp = null,
        string pSupCompany = null,
        decimal? pBonusLimit = null,
        decimal? pBonus = null,
        decimal? pDiscLimit = null,
        decimal? pDiscPerc = null,
        decimal? pOrderLimit = null,
        decimal? pItemMaxQuantity = null,
        decimal? pItemMinQuantity = null,
        DateTime? pLastBuy = null,
        DateTime? pLastSell = null,
        decimal? pItemLastCost = null,
        string pNotes = null,
        int? pCurrencyId = null,
        int? pCollective = null,
        string pItemIdNo = null,
        int? pItemFactorId = null,
        int? pItemMeasurement = null,
        int? pCategoryMeasureId = null,
        DateTime? pProductDate = null,
        bool? pItemSales = null,
        int? pCategorySizes = null,
        int? pServiceItem = null,
        int? pGRPId = null,
        int? pStoreId = null,
        int? pPoints = null,
        bool? pIsDefault = null,
        bool? pDetailGroup = null,
        string pItemImage = null,
        int? pCatProduct = null,
        int? pCancel = null,
        int? pSequenceByCategory = null,
        bool? pIsVATApply = null,
        int? pItemType = null,
        bool? pInvItemIsActive = null,
        bool? pExternalProduct = false,
        bool? pIsItemContent = null,
        int? pItemContentId = null,
        int? pItemId = null,
        int? pGrp_id = null,
        int? pCont_id = null,
        bool? pExp = null,
        decimal? pQty = null,
        int? pUnit_id = null,
        bool? pItem_con_status = null,
        int? pItem_avl_qty = null,
        bool? pMark_as_packing = null,
        decimal? pPrice = null,
        int? pItem_unit_id = null,
        decimal? pPrice_cat = null,
        // ItemAdd
        bool? pIsItemAdd = null,
        int? pItemAddId = null,
        int? pItemAddSeq = null,
        int? pAddOrder = null,
        int? pItemAddQty = null,
        decimal? pItemAddPrice = null,
        // Search
        string pCatAccountName = null,
        string pGroupName = null,
        string pStoreName = null,
        string phNumbers = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null,
        int? pPrinterId = null,
          string pItemTypeList = null,
         string pAccount =null
        )
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvItemId", pInvItemId));
            vlstParam.Add(new SqlParameter("InvItemCode", pInvItemCode));
            vlstParam.Add(new SqlParameter("InvItemCodeSearch", pInvItemCodeSearch));
            vlstParam.Add(new SqlParameter("InvItemSymbol", pInvItemSymbol));
            vlstParam.Add(new SqlParameter("InvItemBarCode", pInvItemBarCode));
            vlstParam.Add(new SqlParameter("InvItemNameL1", pInvItemNameL1));
            vlstParam.Add(new SqlParameter("InvItemNameL2", pInvItemNameL2));
            vlstParam.Add(new SqlParameter("CategoryId", pCategoryId));
            vlstParam.Add(new SqlParameter("HasEdate", pHasEdate));
            vlstParam.Add(new SqlParameter("FollowUp", pFollowUp));
            vlstParam.Add(new SqlParameter("SupCompany", pSupCompany));
            vlstParam.Add(new SqlParameter("BonusLimit", pBonusLimit));
            vlstParam.Add(new SqlParameter("Bonus", pBonus));
            vlstParam.Add(new SqlParameter("DiscLimit", pDiscLimit));
            vlstParam.Add(new SqlParameter("DiscPerc", pDiscPerc));
            vlstParam.Add(new SqlParameter("OrderLimit", pOrderLimit));
            vlstParam.Add(new SqlParameter("ItemMaxQuantity", pItemMaxQuantity));
            vlstParam.Add(new SqlParameter("ItemMinQuantity", pItemMinQuantity));
            vlstParam.Add(new SqlParameter("LastBuy", pLastBuy));
            vlstParam.Add(new SqlParameter("LastSell", pLastSell));
            vlstParam.Add(new SqlParameter("ItemLastCost", pItemLastCost));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("Collective", pCollective));
            vlstParam.Add(new SqlParameter("ItemIdNo", pItemIdNo));
            vlstParam.Add(new SqlParameter("ItemFactorId", pItemFactorId));
            vlstParam.Add(new SqlParameter("ItemMeasurement ", pItemMeasurement));
            vlstParam.Add(new SqlParameter("CategoryMeasureId ", pCategoryMeasureId));
            vlstParam.Add(new SqlParameter("ProductDate", pProductDate));
            vlstParam.Add(new SqlParameter("ItemSales", pItemSales));
            vlstParam.Add(new SqlParameter("CategorySizes", pCategorySizes));
            vlstParam.Add(new SqlParameter("ServiceItem", pServiceItem));
            vlstParam.Add(new SqlParameter("GRPId", pGRPId));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("Points", pPoints));
            vlstParam.Add(new SqlParameter("IsDefault", pIsDefault));
            vlstParam.Add(new SqlParameter("DetailGroup", pDetailGroup));
            vlstParam.Add(new SqlParameter("ItemImage", pItemImage));
            vlstParam.Add(new SqlParameter("CatProduct", pCatProduct));
            vlstParam.Add(new SqlParameter("Cancel", pCancel));
            vlstParam.Add(new SqlParameter("SequenceByCategory", pSequenceByCategory));
            vlstParam.Add(new SqlParameter("IsVATApply", pIsVATApply));
            vlstParam.Add(new SqlParameter("ItemType", pItemType));
            vlstParam.Add(new SqlParameter("InvItemIsActive", pInvItemIsActive));
            vlstParam.Add(new SqlParameter("ExternalProduct", pExternalProduct));
            vlstParam.Add(new SqlParameter("IsItemContent", pIsItemContent));
            vlstParam.Add(new SqlParameter("ItemContentId", pItemContentId));
            vlstParam.Add(new SqlParameter("ItemId", pItemId));
            vlstParam.Add(new SqlParameter("Grp_id", pGrp_id));
            vlstParam.Add(new SqlParameter("Cont_id", pCont_id));
            vlstParam.Add(new SqlParameter("Exp", pExp));
            vlstParam.Add(new SqlParameter("Qty", pQty));
            vlstParam.Add(new SqlParameter("Unit_id", pUnit_id));
            vlstParam.Add(new SqlParameter("Item_con_status", pItem_con_status));
            vlstParam.Add(new SqlParameter("Item_avl_qty", pItem_avl_qty));
            vlstParam.Add(new SqlParameter("Mark_as_packing", pMark_as_packing));
            vlstParam.Add(new SqlParameter("Price", pPrice));
            vlstParam.Add(new SqlParameter("Item_unit_id", pItem_unit_id));
            vlstParam.Add(new SqlParameter("Price_cat", pPrice_cat));
            // Item Add
            vlstParam.Add(new SqlParameter("IsItemAdd", pIsItemAdd));
            vlstParam.Add(new SqlParameter("ItemAddId", pItemAddId));
            vlstParam.Add(new SqlParameter("ItemAddSeq", pItemAddSeq));
            vlstParam.Add(new SqlParameter("AddOrder", pAddOrder));
            vlstParam.Add(new SqlParameter("ItemAddQty", pItemAddQty));
            vlstParam.Add(new SqlParameter("ItemAddPrice", pItemAddPrice));
            vlstParam.Add(new SqlParameter("CatAccountName", pCatAccountName));
            vlstParam.Add(new SqlParameter("GroupName", pGroupName));
            vlstParam.Add(new SqlParameter("StoreName", pStoreName));
            vlstParam.Add(new SqlParameter("hNumbers", phNumbers));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("PrinterId", pPrinterId));
            vlstParam.Add(new SqlParameter("ItemTypeList", pItemTypeList));
            vlstParam.Add(new SqlParameter("Account", pAccount));
            vData = _clsADO.funExecuteScalar("INV.spInvItemCRUD", vlstParam, "Data GET").ToString();

            return vData;
        }
        public DataTable GetDistinctRecords(DataTable dt, string[] Columns)
        {
            DataTable dtUniqRecords = new DataTable();
            dtUniqRecords = dt.DefaultView.ToTable(true, Columns);
            return dtUniqRecords;
        }


        public string GETItem(string pInvItemCode)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvItemCode", pInvItemCode));
            vData = _clsADO.funExecuteScalar("INV.GetItem ", vlstParam, "Data GET").ToString();
            return vData;
        }

        // Get Item For Invoice
        public DataTable funInvItemGET(
                    int? pInvId = null,
                    string phNumbers = null)
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvId", pInvId));
            vlstParam.Add(new SqlParameter("hNumbers", phNumbers));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", 400));
            vData = _clsADO.funFillDataTable("RES.InvoicePOS", vlstParam, "Data GET");
            return vData;
        }

        // Get Item For Invoice
        public DataTable funKitchenGET(
                    int? pInvId = null,
                   string pPrinterId = null)
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvId", pInvId));
            vlstParam.Add(new SqlParameter("PrinterId", pPrinterId));
            vData = _clsADO.funFillDataTable("RES.InvoiceKitchenPOS", vlstParam, "Data GET");
            return vData;
        }


        public DataTable funGetResItemsReport(bool? pIsActive = null)
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
            vData = _clsADO.funFillDataTable("INV.spResItemsReport", vlstParam, "Data GET");


            return vData;
        }
        public DataTable funGetItemsReport(bool? pIsActive = null)
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
            vData = _clsADO.funFillDataTable("INV.spItemsReport", vlstParam, "Data GET");


            return vData;
        }
        public DataTable funGetMealsReport(bool? pIsActive = null)
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
            vData = _clsADO.funFillDataTable("INV.spResMealsReport", vlstParam, "Data GET");


            return vData;
        }
        public DataTable funGetItemReport(bool? pIsActive = null)
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
            vData = _clsADO.funFillDataTable("INV.spInvItemsReport", vlstParam, "Data GET");


            return vData;
        }
        public DataTable funGetItemsCardReport(int? pInvItemId = null, bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("InvItemId", pInvItemId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));
            vData = _clsADO.funFillDataTable("INV.spInvItemsReport", vlstParam, "Data GET");


            return vData;
        }

        public DataTable funGetItems(
       int? pInvItemId = null,
       int? BranchId = null,
        string pInvItemCode = null,
        string pInvItemCodeSearch = null,
        string pInvItemSymbol = null,
        string pInvItemBarCode = null,
        string pInvItemNameL1 = null,
        string pInvItemNameL2 = null,
        int? pCategoryId = null,

        bool? pHasEdate = null,
        bool? pFollowUp = null,
        string pSupCompany = null,
        decimal? pBonusLimit = null,
        decimal? pBonus = null,
        decimal? pDiscLimit = null,
        decimal? pDiscPerc = null,
        decimal? pOrderLimit = null,
        decimal? pItemMaxQuantity = null,
        decimal? pItemMinQuantity = null,
        DateTime? pLastBuy = null,
        DateTime? pLastSell = null,
        decimal? pItemLastCost = null,
        string pNotes = null,
        int? pCurrencyId = null,
        int? pCollective = null,
        string pItemIdNo = null,
        int? pItemFactorId = null,
        int? pItemMeasurement = null,
        int? pCategoryMeasureId = null,
        DateTime? pProductDate = null,
        bool? pItemSales = null,
        int? pCategorySizes = null,
        int? pServiceItem = null,
        int? pGRPId = null,
        int? pStoreId = null,
        int? pPoints = null,
        bool? pIsDefault = null,
        bool? pDetailGroup = null,
        string pItemImage = null,
        int? pCatProduct = null,
        int? pCancel = null,
        int? pSequenceByCategory = null,
        bool? pIsVATApply = null,
        int? pItemType = null,
        bool? pInvItemIsActive = null,
        bool? pExternalProduct = false,
        bool? pIsItemContent = null,
        int? pItemContentId = null,
        int? pItemId = null,
        int? pGrp_id = null,
        int? pCont_id = null,
        bool? pExp = null,
        decimal? pQty = null,
        int? pUnit_id = null,
        bool? pItem_con_status = null,
        int? pItem_avl_qty = null,
        bool? pMark_as_packing = null,
        decimal? pPrice = null,
        int? pItem_unit_id = null,
        decimal? pPrice_cat = null,
        // ItemAdd
        bool? pIsItemAdd = null,
        int? pItemAddId = null,
        int? pItemAddSeq = null,
        int? pAddOrder = null,
        int? pItemAddQty = null,
        decimal? pItemAddPrice = null,
        // Search
        string pCatAccountName = null,
        string pGroupName = null,
        string pStoreName = null,
        string phNumbers = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null,
        int? pPrinterId = null,
          string pItemTypeList = null
        )
        {
            // Declaration 
            DataTable vData = null;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvItemId", pInvItemId));
            vlstParam.Add(new SqlParameter("InvItemCode", pInvItemCode));
            vlstParam.Add(new SqlParameter("InvItemCodeSearch", pInvItemCodeSearch));
            vlstParam.Add(new SqlParameter("InvItemSymbol", pInvItemSymbol));
            vlstParam.Add(new SqlParameter("InvItemBarCode", pInvItemBarCode));
            vlstParam.Add(new SqlParameter("InvItemNameL1", pInvItemNameL1));
            vlstParam.Add(new SqlParameter("InvItemNameL2", pInvItemNameL2));
            vlstParam.Add(new SqlParameter("CategoryId", pCategoryId));
            vlstParam.Add(new SqlParameter("HasEdate", pHasEdate));
            vlstParam.Add(new SqlParameter("FollowUp", pFollowUp));
            vlstParam.Add(new SqlParameter("SupCompany", pSupCompany));
            vlstParam.Add(new SqlParameter("BonusLimit", pBonusLimit));
            vlstParam.Add(new SqlParameter("Bonus", pBonus));
            vlstParam.Add(new SqlParameter("DiscLimit", pDiscLimit));
            vlstParam.Add(new SqlParameter("DiscPerc", pDiscPerc));
            vlstParam.Add(new SqlParameter("OrderLimit", pOrderLimit));
            vlstParam.Add(new SqlParameter("ItemMaxQuantity", pItemMaxQuantity));
            vlstParam.Add(new SqlParameter("ItemMinQuantity", pItemMinQuantity));
            vlstParam.Add(new SqlParameter("LastBuy", pLastBuy));
            vlstParam.Add(new SqlParameter("LastSell", pLastSell));
            vlstParam.Add(new SqlParameter("ItemLastCost", pItemLastCost));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("Collective", pCollective));
            vlstParam.Add(new SqlParameter("ItemIdNo", pItemIdNo));
            vlstParam.Add(new SqlParameter("ItemFactorId", pItemFactorId));
            vlstParam.Add(new SqlParameter("ItemMeasurement ", pItemMeasurement));
            vlstParam.Add(new SqlParameter("CategoryMeasureId ", pCategoryMeasureId));
            vlstParam.Add(new SqlParameter("ProductDate", pProductDate));
            vlstParam.Add(new SqlParameter("ItemSales", pItemSales));
            vlstParam.Add(new SqlParameter("CategorySizes", pCategorySizes));
            vlstParam.Add(new SqlParameter("ServiceItem", pServiceItem));
            vlstParam.Add(new SqlParameter("GRPId", pGRPId));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("Points", pPoints));
            vlstParam.Add(new SqlParameter("IsDefault", pIsDefault));
            vlstParam.Add(new SqlParameter("DetailGroup", pDetailGroup));
            vlstParam.Add(new SqlParameter("ItemImage", pItemImage));
            vlstParam.Add(new SqlParameter("CatProduct", pCatProduct));
            vlstParam.Add(new SqlParameter("Cancel", pCancel));
            vlstParam.Add(new SqlParameter("SequenceByCategory", pSequenceByCategory));
            vlstParam.Add(new SqlParameter("IsVATApply", pIsVATApply));
            vlstParam.Add(new SqlParameter("ItemType", pItemType));
            vlstParam.Add(new SqlParameter("InvItemIsActive", pInvItemIsActive));
            vlstParam.Add(new SqlParameter("ExternalProduct", pExternalProduct));
            vlstParam.Add(new SqlParameter("IsItemContent", pIsItemContent));
            vlstParam.Add(new SqlParameter("ItemContentId", pItemContentId));
            vlstParam.Add(new SqlParameter("ItemId", pItemId));
            vlstParam.Add(new SqlParameter("Grp_id", pGrp_id));
            vlstParam.Add(new SqlParameter("Cont_id", pCont_id));
            vlstParam.Add(new SqlParameter("Exp", pExp));
            vlstParam.Add(new SqlParameter("Qty", pQty));
            vlstParam.Add(new SqlParameter("Unit_id", pUnit_id));
            vlstParam.Add(new SqlParameter("Item_con_status", pItem_con_status));
            vlstParam.Add(new SqlParameter("Item_avl_qty", pItem_avl_qty));
            vlstParam.Add(new SqlParameter("Mark_as_packing", pMark_as_packing));
            vlstParam.Add(new SqlParameter("Price", pPrice));
            vlstParam.Add(new SqlParameter("Item_unit_id", pItem_unit_id));
            vlstParam.Add(new SqlParameter("Price_cat", pPrice_cat));
            // Item Add
            vlstParam.Add(new SqlParameter("IsItemAdd", pIsItemAdd));
            vlstParam.Add(new SqlParameter("ItemAddId", pItemAddId));
            vlstParam.Add(new SqlParameter("ItemAddSeq", pItemAddSeq));
            vlstParam.Add(new SqlParameter("AddOrder", pAddOrder));
            vlstParam.Add(new SqlParameter("ItemAddQty", pItemAddQty));
            vlstParam.Add(new SqlParameter("ItemAddPrice", pItemAddPrice));
            //
            vlstParam.Add(new SqlParameter("CatAccountName", pCatAccountName));
            vlstParam.Add(new SqlParameter("GroupName", pGroupName));
            vlstParam.Add(new SqlParameter("StoreName", pStoreName));
            vlstParam.Add(new SqlParameter("hNumbers", phNumbers));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("PrinterId", pPrinterId));
            vlstParam.Add(new SqlParameter("ItemTypeList", pItemTypeList));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vData = _clsADO.funFillDataTable("INV.spInvItemCRUD", vlstParam, "Data GET");
            //vData = Task.Run(()=> _clsADO.funFillDataTable("INV.spInvItemCRUD", vlstParam, "Data GET")).Result;
            return vData;
        }

        public DataTable ItemCostMinMaxData(DateTime DateFrom, DateTime DateTo, int? ItemId)
        {
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", DateFrom));
            vlstParam.Add(new SqlParameter("DateTo", DateTo));
            vlstParam.Add(new SqlParameter("ItemId", ItemId));

            return _clsADO.funFillDataTable("Res.ItemCostMinMaxReport", vlstParam, "Data GET");

        }
    }
}


