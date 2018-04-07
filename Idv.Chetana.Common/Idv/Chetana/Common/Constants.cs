namespace Idv.Chetana.Common
{
    using System;

    public sealed class Constants
    {
        public static bool DefaultBoolValue = false;
        public static DateTime NullDateTime = DateTime.MinValue;
        public static decimal NullDecimal = -79228162514264337593543950335M;
        public static double NullDouble = double.MinValue;
        public static Guid NullGuid = Guid.Empty;
        public static int NullInt = 0;
        public static long NullLong = -9223372036854775808L;
        public static float NullFloat = float.MinValue;
        public static string NullString = string.Empty;
        public static DateTime SqlMaxDate = new DateTime(0x270f, 1, 3, 0x17, 0x3b, 0x3b);
        public static DateTime SqlMinDate = new DateTime(0x6d9, 1, 1, 0, 0, 0);
        public static bool NullBoolean = false;
        public static char splitseperator = ':';
        public static string save = "Record Saved Successfully";
        public static string Delete = "Record Deleted Successfully";
        public static string selectCSV = "Kindly select CSV file.";
    }
}

