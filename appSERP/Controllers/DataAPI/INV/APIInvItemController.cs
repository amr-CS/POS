using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text.Json;
using appSERP.Utils;

namespace appSERP.Controllers.DataAPI.INV
{
    public class APIInvItemController : ApiController
    {

        private IdbInvItem _dbInvItem;
        private IdbINVInvoice _dbINVInvoice;
        public APIInvItemController(IdbInvItem dbInvItem, IdbINVInvoice dbINVInvoice)
        {
            _dbInvItem = dbInvItem;
            _dbINVInvoice = dbINVInvoice;
        }
        [HttpGet]
        public string InvItemGET(
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
        bool? pInvItemIsActive = true,
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
        //
        string pCatAccountName = null,
        string pGroupName = null,
        string pStoreName = null,
        string phNumbers = null,
        bool? pIsDeleted = false,
          int? pPrinterId = null,
         int? pQueryTypeId = clsQueryType.qSelect,
         string pItemTypeList = null,
         string pAccount = null
      )
        {
            // فحص تكرار كود الصنف او الوجبة أثناء الاضافة والتعديل
            if (pQueryTypeId == clsQueryType.qInsert || pQueryTypeId == clsQueryType.qUpdate)
            {
                if (pItemType == 2 || (pInvItemCode != null && pInvItemCode.Length>0)) // فحص التكرار يكون الزامي في الاصناف فقط والبقية في حال كان غير فاضي يفحص
                {
                    var dt = _dbInvItem.GetItemCode(pInvItemCode, pInvItemId);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string name = ItemType.GetTypeName(pItemType);
                        return SystemMessageCode.ToJSON(SystemMessageCode.GetError($"كود {name} مكرر"));
                    }
                }
            }

            // فحص وجود حركات للصنف او الوجبة او المنتج قبل تنفيذ عملية حذف الصنف
            if (pQueryTypeId == clsQueryType.qDelete)
            {
                var dt = _dbINVInvoice.GetItemHasInvoice(pItemId = pInvItemId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string name = ItemType.GetTypeName(pItemType);
                    return SystemMessageCode.ToJSON(SystemMessageCode.GetError($"للآسف {name} له فاتورة من سابق لا يمكن حذفه"));
                }
            }
            // Get Data 
            string vData = _dbInvItem.funInvItemGET(
            pInvItemId: pInvItemId,
            pInvItemCode: pInvItemCode,
            pInvItemCodeSearch: pInvItemCodeSearch,
            pInvItemSymbol: pInvItemSymbol,
            pInvItemBarCode: pInvItemBarCode,
            pInvItemNameL1: pInvItemNameL1,
            pInvItemNameL2: pInvItemNameL2,
            pCategoryId: pCategoryId,
            //pHasEdate: pHasEdate,
            pFollowUp: pFollowUp,
            pSupCompany: pSupCompany,
             pBonusLimit: pBonusLimit,
            pBonus: pBonus,
             pDiscLimit: pDiscLimit,
            pDiscPerc: pDiscPerc,
          pOrderLimit: pOrderLimit,
            pItemMaxQuantity: pItemMaxQuantity,
            pItemMinQuantity: pItemMinQuantity,
            pLastBuy: pLastBuy,
            pLastSell: pLastSell,
            pItemLastCost: pItemLastCost,
            pNotes: pNotes,
            pCurrencyId: pCurrencyId,
          pCollective: pCollective,
       pItemIdNo: pItemIdNo,
       pItemFactorId: pItemFactorId,
         pItemMeasurement: pItemMeasurement,
         pCategoryMeasureId: pCategoryMeasureId,
        pProductDate: pProductDate,
        pItemSales: pItemSales,
         pCategorySizes: pCategorySizes,
         pServiceItem: pCategorySizes,
        pGRPId: pGRPId,
        pStoreId: pStoreId,
        pPoints: pPoints,
        pIsDefault: pIsDefault,
        pDetailGroup: pDetailGroup,
        pItemImage: pItemImage,
        pCatProduct: pCatProduct,
        pCancel: pCancel,
         pSequenceByCategory: pSequenceByCategory,
         pIsVATApply: pIsVATApply,
         pItemType: pItemType,
         pInvItemIsActive: pInvItemIsActive,
         pExternalProduct: pExternalProduct,
         pIsItemContent: pIsItemContent,
         pItemContentId: pItemContentId,
         pItemId: pItemId,
         pGrp_id: pGrp_id,
         pCont_id: pCont_id,
         pExp: pExp,
         pQty: pQty,
         pUnit_id: pUnit_id,
          pItem_con_status: pItem_con_status,
          pItem_avl_qty: pItem_avl_qty,
          pMark_as_packing: pMark_as_packing,
          pPrice: pPrice,
          pItem_unit_id: pItem_unit_id,
         pPrice_cat: pPrice_cat,
        // ItemAdd
        pIsItemAdd: pIsItemAdd,
        pItemAddId: pItemAddId,
        pItemAddSeq: pItemAddSeq,
        pAddOrder: pAddOrder,
        pItemAddQty: pItemAddQty,
        pItemAddPrice: pItemAddPrice,
         // search Parameters
         pCatAccountName: pCatAccountName,
         pGroupName: pGroupName,
         pStoreName: pStoreName,
         phNumbers: phNumbers,

         pIsDeleted: pIsDeleted,
           pPrinterId: pPrinterId,
          pQueryTypeId: pQueryTypeId,
          pItemTypeList: pItemTypeList,
          pAccount: pAccount

            );
            // Result
            return vData;
        }

        
    }
}
