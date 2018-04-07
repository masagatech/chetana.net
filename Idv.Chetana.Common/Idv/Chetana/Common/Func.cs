namespace Idv.Chetana.Common
{
    using System;

    public class Func
    {
        public static string getMonthInNameDate(string str)
        {
            string str2 = "";
            string str3 = "";
            string str4 = "";
            if (str.Split(new char[] { '/' }).Length == 2)
            {
                return "Invalid";
            }
            str2 = str.Split(new char[] { '/' })[0].ToString();
            str3 = str.Split(new char[] { '/' })[1].ToString();
            str4 = str.Split(new char[] { '/' })[2].ToString();
            string str5 = "";
            switch (str3)
            {
                case "01":
                    str5 = "jan";
                    break;

                case "02":
                    str5 = "feb";
                    break;

                case "03":
                    str5 = "mar";
                    break;

                case "04":
                    str5 = "apr";
                    break;

                case "05":
                    str5 = "may";
                    break;

                case "06":
                    str5 = "jun";
                    break;

                case "07":
                    str5 = "jul";
                    break;

                case "08":
                    str5 = "aug";
                    break;

                case "09":
                    str5 = "sept";
                    break;

                case "10":
                    str5 = "oct";
                    break;

                case "11":
                    str5 = "nov";
                    break;

                case "12":
                    str5 = "dec";
                    break;

                default:
                    str5 = "0";
                    break;
            }
            if (str5 != "0")
            {
                str5 = str2 + "/" + str5 + "/" + str4;
            }
            else
            {
                str5 = "Invalid";
            }
            return str5;
        }
    }
}

