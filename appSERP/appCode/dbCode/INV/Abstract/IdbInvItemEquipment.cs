using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbInvItemEquipment
    {

        string funInvItemEquipmentGET(
        int? pInvItemEquipmentId = null,
        string pInvItemEquipmentCode = null,
        int? pItemId = null,
        int? pEquipmentId = null,
        int? pNotes = null,
        bool? pInvItemEquipmentIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
