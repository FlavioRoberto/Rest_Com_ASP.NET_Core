using System;
using System.Globalization;

namespace Api.Extensions
{
    public static class StringMethods
    {
        public static bool EhNumerico(this string value)
        {
            decimal number;
            return decimal.TryParse(value, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);
        }

        public static Retorno<decimal> ToDecimal(this string value)
        {
            try
            {
                return new Retorno<decimal>(decimal.Parse(value), "");
            }
            catch (Exception e)
            {
                return new Retorno<decimal>(0, e.Message);
            }
        }
    }
}
