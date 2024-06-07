using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Models.RES
{
    public class ResEmployeeModel
    {
       

         public int ResEmployeeId { get; set; }
        public string ResEmployeeCode { get; set; }
        public int EmpSeq { get; set; }
        public string ResEmployeeNameL1 { get; set; }
        public string ResEmployeeNameL2 { get; set; }
        public DateTime HireDate { get; set; }
        public int DeptSeq { get; set; }
        public int EmpStatusId { get; set; }
        public DateTime ExitDate { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Mobile { get; set; }
        public int Gender { get; set; }
        public int IdentityTypeId { get; set; }
        public int IdentityNumber { get; set; }
        public DateTime IdentityDate { get; set; }
        public int NationalityId { get; set; }
        public decimal DeliveryValue { get; set; }
        public int ValueTypeId { get; set; }
        public decimal PercentageRange { get; set; }
        public int ExitTypeId { get; set; }
        public string ExitReason { get; set; }
        public bool ResEmployeeIsActive { get; set; }
    }
}