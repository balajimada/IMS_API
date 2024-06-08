using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Utitlity
{
    public static class Helper
    {
        public static string ToStr(this Object str)
        {
            if(str == DBNull.Value)
            {
                return string.Empty;
            }
            else
            {
                return Convert.ToString(str).Trim();
            }
        }

        public static decimal ToDecimal(this Object str)
        {
            if (str == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(str);
            }
        }

        public static string GetMethodName(ControllerContext conrollerContext)
        {
            return "api/" + conrollerContext?.RouteData?.Values["controller"].ToString() + "/" + conrollerContext?.RouteData?.Values["action"].ToString();
        }

    }
}
