using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.Setting.User.Abstract
{
    public interface IclsUserType
    {

        void funUserTypeGET();


        int vUserTypeIdAdmin { get; set; }
        string vUserTypeCodeAdmin { get; set; }
        string vUserTypeNameL1Admin { get; set; }
        string vUserTypeNameL2Admin { get; set; }
        int vUserTypeMaxDisAdmin { get; set; }


        int vUserTypeIdSystemUser { get; set; }
        string vUserTypeCodeSystemUser { get; set; }
        string vUserTypeNameL1SystemUser { get; set; }
        string vUserTypeNameL2SystemUser { get; set; }
        int vUserTypeMaxDisSystemUser { get; set; }
    }
}
