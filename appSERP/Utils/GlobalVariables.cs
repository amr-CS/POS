using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.Utils
{
    // GeneralFunctionsDRY

    // سؤال في Poe - ChatGPT
    // إضافة متغير في الويب بحيث عندما يحدثه قيمته في الرام اي مستخدم يفتح النظام يسمع عند كل المستخدمين الاخرين المتصفحين للموقع asp.net
    public class GlobalVariables
    {
        #region لتخزين تاريخ التنفيذ المشترك في السيرفر
        public delegate void ValueChangedEventHandler(string newValue);
        public static event ValueChangedEventHandler ValueChanged;

        private static string _sharedValue;
        public static string SharedValue
        {
            get { return _sharedValue; }
            set
            {
                _sharedValue = value;
                OnValueChanged(value);
            }
        }

        private static void OnValueChanged(string newValue)
        {
            ValueChanged?.Invoke(newValue);
        }
        #endregion


        #region لتخزين حالة التنفيذ المشترك في السيرفر

        public delegate void StatusChangedEventHandler(bool newStatus);
        public static event StatusChangedEventHandler StatusChanged;

        private static bool _sharedStatus;
        public static bool SharedStatus
        {
            get { return _sharedStatus; }
            set
            {
                _sharedStatus = value;
                OnStatusChanged(value);
            }
        }

        private static void OnStatusChanged(bool newStatus)
        {
            StatusChanged?.Invoke(newStatus);
        }

        #endregion
    }
}