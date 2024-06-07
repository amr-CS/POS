using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbInvItem
    {
        DataTable MealData(DateTime DateFrom, DateTime DateTo, int? CashId, int? ItemId, bool? IsGrouping);
        DataTable ItemCostMinMaxData(DateTime DateFrom, DateTime DateTo,  int? ItemId);
        DataTable GetItemCode(string pInvItemCode, int? pInvItemId = null);
        string funInvItemGET(
        int?BranchId=null,
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
          string pAccount=null
        );

        DataTable GetDistinctRecords(DataTable dt, string[] Columns);
        string GETItem(string pInvItemCode);
        DataTable funInvItemGET(int? pInvId = null,string phNumbers = null);
        DataTable funKitchenGET(int? pInvId = null,string pPrinterId = null);
        DataTable funGetResItemsReport(bool? pIsActive = null);
        DataTable funGetItemsReport(bool? pIsActive = null);
        DataTable funGetMealsReport(bool? pIsActive = null);
        DataTable funGetItemReport(bool? pIsActive = null);
        DataTable funGetItemsCardReport(int? pInvItemId = null, bool? pIsActive = null);

        DataTable funGetItems(
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
        );

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
