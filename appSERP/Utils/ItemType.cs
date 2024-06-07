using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Utils
{
    public class ItemType
    {
        public const int Products = 1; // المنتجات
        public const int Items = 2; // الاصناف
        public const int Meals = 3; // الوجبات
        public static string GetTypeName(int? pItemType)
        {
            if (pItemType == null)
                return "";
            string name = "الصنف";
            /*
                المنتجات = 1
                الاصناف = 2
                الوجبات = 3
             */
            switch (pItemType)
            {
                case Products: name = "المنتج"; break;
                case Meals: name = "الوجبة"; break;
            }
            return name;
        }
    }
}