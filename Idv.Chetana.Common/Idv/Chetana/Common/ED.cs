namespace Idv.Chetana.Common
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;

    public class ED
    {
        public static string DecryptData(string text)
        {
            string expression = text;
            string str2 = "";
            int start = 1;
            if (expression.Length == 0)
            {
                return "";
            }
            int num2 = Strings.Len(expression);
            while (start <= num2)
            {
                string str3 = Conversions.ToString(Strings.Chr(Strings.Asc(Strings.Mid(expression, start, 1)) - 10));
                str2 = str2 + str3;
                start++;
            }
            return str2;
        }

        public static string EncryptData(string text)
        {
            string expression = text;
            string str2 = "";
            int start = 1;
            if (expression.Length == 0)
            {
                return "";
            }
            int num2 = Strings.Len(expression);
            while (start <= num2)
            {
                string str3 = Conversions.ToString(Strings.Chr(Strings.Asc(Strings.Mid(expression, start, 1)) + 10));
                str2 = str2 + str3;
                start++;
            }
            return str2;
        }
    }
}

