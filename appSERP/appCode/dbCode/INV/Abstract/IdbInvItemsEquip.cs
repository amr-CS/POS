using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbInvItemsEquip
    {
        string funInvItemsEquipGET(
        int? pEquipId = null,
        string pEquipCode = null,
        string pEquipName = null,
         int? pItemId = null,
        string pNotes = null,
        bool? pEquipIsActive = true,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);
    }
}
