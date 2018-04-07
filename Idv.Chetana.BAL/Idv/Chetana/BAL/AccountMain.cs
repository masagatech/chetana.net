namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class AccountMain
    {
        private int _AutoID = Constants.NullInt;
        private string _AC_CODE = Constants.NullString;
        private string _AC_NAME = Constants.NullString;
        private string _AC_GROUP = Constants.NullString;
        private string _AC_ADD1 = Constants.NullString;
        private string _AC_ADD2 = Constants.NullString;
        private string _AC_ADD3 = Constants.NullString;
        private string _TEL1 = Constants.NullString;
        private string _TEL2 = Constants.NullString;
        private string _TELR = Constants.NullString;
        private string _CITY_CODE = Constants.NullString;
        private string _STATE_CODE = Constants.NullString;
        private string _PIN_CODE = Constants.NullString;
        private string _COUNTRY = Constants.NullString;
        private string _ZONE_CODE = Constants.NullString;
        private string _BROKER = Constants.NullString;
        private string _MEDIUM = Constants.NullString;
        private decimal _BROK_PERC = Constants.NullDecimal;
        private string _PRIN_int = Constants.NullString;
        private string _BLACKLIST = Constants.NullString;
        private string _AC_TYPE = Constants.NullString;
        private string _AC_ST_NO = Constants.NullString;
        private string _AC_PA_NO = Constants.NullString;
        private string _AC_CST_NO = Constants.NullString;
        private decimal _AC_int_RAT = Constants.NullDecimal;
        private decimal _AC_TDS_LIM = Constants.NullDecimal;
        private decimal _AC_TDS_RAT = Constants.NullDecimal;
        private bool _AC_H15 = Constants.NullBoolean;
        private decimal _AC_DEPR_C = Constants.NullDecimal;
        private decimal _AC_DEPR_N = Constants.NullDecimal;
        private string _GST_NO = Constants.NullString;
        private string _APPLICABLE_GST = Constants.NullString;
        private string _TRANSPORT = Constants.NullString;
        private string _PAYEE_BANK = Constants.NullString;
        private int _CR_DAYS = Constants.NullInt;
        private decimal _BANK_int = Constants.NullDecimal;
        private decimal _DISC_PREC = Constants.NullDecimal;
        private string _TAX_TYPE = Constants.NullString;
        private string _AREA = Constants.NullString;
        private int _SR_ORDER = Constants.NullInt;
        private decimal _OPEN_BAL = Constants.NullDecimal;
        private decimal _PROFIT = Constants.NullDecimal;
        private decimal _REMUNA = Constants.NullDecimal;
        private decimal _CR_LIMIT = Constants.NullDecimal;
        private decimal _SP_DISC = Constants.NullDecimal;
        private string _EMAIL_NO = Constants.NullString;
        private string _MOR_TIME = Constants.NullString;
        private string _EVE_TIME = Constants.NullString;
        private string _IN_CHARGE = Constants.NullString;
        private string _CTYPE_CODE = Constants.NullString;
        private string _L_O = Constants.NullString;
        private string _FAM_CODE = Constants.NullString;
        private string _CF_CODE = Constants.NullString;
        private string _INSTRCTION = Constants.NullString;
        private string _VIC_REMARK = Constants.NullString;
        private string _DELETEREC = Constants.NullString;
        private bool _ACTIVE = Constants.NullBoolean;
        private string _INSTRUCT2 = Constants.NullString;
        private string _INSTRUCT3 = Constants.NullString;
        private string _INSTRUCT4 = Constants.NullString;
        private decimal _SMAN_COMM = Constants.NullDecimal;
        private decimal _ADD_DISC = Constants.NullDecimal;
        private string _CreatedBy = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;


        public int AutoID
        {
            get
            {
                return this._AutoID;
            }
            set
            {
                this._AutoID = value;
            }
        }

        public string AC_CODE
        {
            get
            {
                return this._AC_CODE;
            }
            set
            {
                this._AC_CODE = value;
            }
        }

        public string AC_NAME
        {
            get
            {
                return this._AC_NAME;
            }
            set
            {
                this._AC_NAME = value;
            }
        }

        public string AC_GROUP
        {
            get
            {
                return this._AC_GROUP;
            }
            set
            {
                this._AC_GROUP = value;
            }
        }

        public string AC_ADD1
        {
            get
            {
                return this._AC_ADD1;
            }
            set
            {
                this._AC_ADD1 = value;
            }
        }

        public string AC_ADD2
        {
            get
            {
                return this._AC_ADD2;
            }
            set
            {
                this._AC_ADD2 = value;
            }
        }

        public string AC_ADD3
        {
            get
            {
                return this._AC_ADD3;
            }
            set
            {
                this._AC_ADD3 = value;
            }
        }

        public string TEL1
        {
            get
            {
                return this._TEL1;
            }
            set
            {
                this._TEL1 = value;
            }
        }

        public string TEL2
        {
            get
            {
                return this._TEL2;
            }
            set
            {
                this._TEL2 = value;
            }
        }

        public string TELR
        {
            get
            {
                return this._TELR;
            }
            set
            {
                this._TELR = value;
            }
        }

        public string CITY_CODE
        {
            get
            {
                return this._CITY_CODE;
            }
            set
            {
                this._CITY_CODE = value;
            }
        }

        public string PIN_CODE
        {
            get
            {
                return this._PIN_CODE;
            }
            set
            {
                this._PIN_CODE = value;
            }
        }

        public string STATE_CODE
        {
            get { return _STATE_CODE; }
            set { _STATE_CODE = value; }
        }

        public string COUNTRY
        {
            get
            {
                return this._COUNTRY;
            }
            set
            {
                this._COUNTRY = value;
            }
        }

        public string ZONE_CODE
        {
            get
            {
                return this._ZONE_CODE;
            }
            set
            {
                this._ZONE_CODE = value;
            }
        }

        public string BROKER
        {
            get
            {
                return this._BROKER;
            }
            set
            {
                this._BROKER = value;
            }
        }

        public string MEDIUM
        {
            get
            {
                return this._MEDIUM;
            }
            set
            {
                this._MEDIUM = value;
            }
        }

        public decimal BROK_PERC
        {
            get
            {
                return this._BROK_PERC;
            }
            set
            {
                this._BROK_PERC = value;
            }
        }

        public string PRIN_int
        {
            get
            {
                return this._PRIN_int;
            }
            set
            {
                this._PRIN_int = value;
            }
        }

        public string BLACKLIST
        {
            get
            {
                return this._BLACKLIST;
            }
            set
            {
                this._BLACKLIST = value;
            }
        }

        public string AC_TYPE
        {
            get
            {
                return this._AC_TYPE;
            }
            set
            {
                this._AC_TYPE = value;
            }
        }

        public string AC_ST_NO
        {
            get
            {
                return this._AC_ST_NO;
            }
            set
            {
                this._AC_ST_NO = value;
            }
        }

        public string AC_PA_NO
        {
            get
            {
                return this._AC_PA_NO;
            }
            set
            {
                this._AC_PA_NO = value;
            }
        }

        public string AC_CST_NO
        {
            get
            {
                return this._AC_CST_NO;
            }
            set
            {
                this._AC_CST_NO = value;
            }
        }

        public decimal AC_int_RAT
        {
            get
            {
                return this._AC_int_RAT;
            }
            set
            {
                this._AC_int_RAT = value;
            }
        }

        public decimal AC_TDS_LIM
        {
            get
            {
                return this._AC_TDS_LIM;
            }
            set
            {
                this._AC_TDS_LIM = value;
            }
        }

        public decimal AC_TDS_RAT
        {
            get
            {
                return this._AC_TDS_RAT;
            }
            set
            {
                this._AC_TDS_RAT = value;
            }
        }

        public bool AC_H15
        {
            get
            {
                return this._AC_H15;
            }
            set
            {
                this._AC_H15 = value;
            }
        }

        public decimal AC_DEPR_C
        {
            get
            {
                return this._AC_DEPR_C;
            }
            set
            {
                this._AC_DEPR_C = value;
            }
        }

        public decimal AC_DEPR_N
        {
            get
            {
                return this._AC_DEPR_N;
            }
            set
            {
                this._AC_DEPR_N = value;
            }
        }

        public string GST_NO
        {
            get { return _GST_NO; }
            set { _GST_NO = value; }
        }

        public string APPLICABLE_GST
        {
            get { return _APPLICABLE_GST; }
            set { _APPLICABLE_GST = value; }
        }

        public string TRANSPORT
        {
            get
            {
                return this._TRANSPORT;
            }
            set
            {
                this._TRANSPORT = value;
            }
        }

        public string PAYEE_BANK
        {
            get
            {
                return this._PAYEE_BANK;
            }
            set
            {
                this._PAYEE_BANK = value;
            }
        }

        public int CR_DAYS
        {
            get
            {
                return this._CR_DAYS;
            }
            set
            {
                this._CR_DAYS = value;
            }
        }

        public decimal BANK_int
        {
            get
            {
                return this._BANK_int;
            }
            set
            {
                this._BANK_int = value;
            }
        }

        public decimal DISC_PREC
        {
            get
            {
                return this._DISC_PREC;
            }
            set
            {
                this._DISC_PREC = value;
            }
        }

        public string TAX_TYPE
        {
            get
            {
                return this._TAX_TYPE;
            }
            set
            {
                this._TAX_TYPE = value;
            }
        }

        public string AREA
        {
            get
            {
                return this._AREA;
            }
            set
            {
                this._AREA = value;
            }
        }

        public int SR_ORDER
        {
            get
            {
                return this._SR_ORDER;
            }
            set
            {
                this._SR_ORDER = value;
            }
        }

        public decimal OPEN_BAL
        {
            get
            {
                return this._OPEN_BAL;
            }
            set
            {
                this._OPEN_BAL = value;
            }
        }

        public decimal PROFIT
        {
            get
            {
                return this._PROFIT;
            }
            set
            {
                this._PROFIT = value;
            }
        }

        public decimal REMUNA
        {
            get
            {
                return this._REMUNA;
            }
            set
            {
                this._REMUNA = value;
            }
        }

        public decimal CR_LIMIT
        {
            get
            {
                return this._CR_LIMIT;
            }
            set
            {
                this._CR_LIMIT = value;
            }
        }

        public decimal SP_DISC
        {
            get
            {
                return this._SP_DISC;
            }
            set
            {
                this._SP_DISC = value;
            }
        }

        public string EMAIL_NO
        {
            get
            {
                return this._EMAIL_NO;
            }
            set
            {
                this._EMAIL_NO = value;
            }
        }

        public string MOR_TIME
        {
            get
            {
                return this._MOR_TIME;
            }
            set
            {
                this._MOR_TIME = value;
            }
        }

        public string EVE_TIME
        {
            get
            {
                return this._EVE_TIME;
            }
            set
            {
                this._EVE_TIME = value;
            }
        }

        public string IN_CHARGE
        {
            get
            {
                return this._IN_CHARGE;
            }
            set
            {
                this._IN_CHARGE = value;
            }
        }

        public string CTYPE_CODE
        {
            get
            {
                return this._CTYPE_CODE;
            }
            set
            {
                this._CTYPE_CODE = value;
            }
        }

        public string L_O
        {
            get
            {
                return this._L_O;
            }
            set
            {
                this._L_O = value;
            }
        }

        public string FAM_CODE
        {
            get
            {
                return this._FAM_CODE;
            }
            set
            {
                this._FAM_CODE = value;
            }
        }

        public string CF_CODE
        {
            get
            {
                return this._CF_CODE;
            }
            set
            {
                this._CF_CODE = value;
            }
        }

        public string INSTRCTION
        {
            get
            {
                return this._INSTRCTION;
            }
            set
            {
                this._INSTRCTION = value;
            }
        }

        public string VIC_REMARK
        {
            get
            {
                return this._VIC_REMARK;
            }
            set
            {
                this._VIC_REMARK = value;
            }
        }

        public string DELETEREC
        {
            get
            {
                return this._DELETEREC;
            }
            set
            {
                this._DELETEREC = value;
            }
        }

        public bool ACTIVE
        {
            get
            {
                return this._ACTIVE;
            }
            set
            {
                this._ACTIVE = value;
            }
        }

        public string INSTRUCT2
        {
            get
            {
                return this._INSTRUCT2;
            }
            set
            {
                this._INSTRUCT2 = value;
            }
        }

        public string INSTRUCT3
        {
            get
            {
                return this._INSTRUCT3;
            }
            set
            {
                this._INSTRUCT3 = value;
            }
        }

        public string INSTRUCT4
        {
            get
            {
                return this._INSTRUCT4;
            }
            set
            {
                this._INSTRUCT4 = value;
            }
        }

        public decimal SMAN_COMM
        {
            get
            {
                return this._SMAN_COMM;
            }
            set
            {
                this._SMAN_COMM = value;
            }
        }

        public decimal ADD_DISC
        {
            get
            {
                return this._ADD_DISC;
            }
            set
            {
                this._ADD_DISC = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return this._CreatedBy;
            }
            set
            {
                this._CreatedBy = value;
            }
        }

        public DateTime CreatedOn
        {
            get
            {
                return this._CreatedOn;
            }
            set
            {
                this._CreatedOn = value;
            }
        }

        public string UpdatedBy
        {
            get
            {
                return this._UpdatedBy;
            }
            set
            {
                this._UpdatedBy = value;
            }
        }

        public DateTime UpdatedOn
        {
            get
            {
                return this._UpdatedOn;
            }
            set
            {
                this._UpdatedOn = value;
            }
        }



        public static DataSet ACCodeGet(string AcCode)
        {
            return new AdminDataService().ACCodeGet(AcCode);
        }

        public static bool ACCodeValidaton(string AcCode)
        {
            DataTable table = new DataTable();
            table = new AdminDataService().ACCodeValidaton(AcCode).Tables[0];
            return (table.Rows.Count > 0);
        }

        public void Save()
        {
            new AdminDataService().SaveIdv_chetana_Account_main(this._AutoID, this._AC_CODE, this._AC_NAME, this._AC_GROUP, this._AC_ADD1, this._AC_ADD2, this._AC_ADD3,
                this._TEL1, this._TEL2, this._TELR, this._CITY_CODE, this._PIN_CODE, this._STATE_CODE, this._COUNTRY, this._ZONE_CODE, this._BROKER, this._MEDIUM,
                this._BROK_PERC, this._PRIN_int, this._BLACKLIST, this._AC_TYPE, this._AC_ST_NO, this._AC_PA_NO, this._AC_CST_NO, this._AC_int_RAT, this._AC_TDS_LIM,
                this._AC_TDS_RAT, this._AC_H15, this._AC_DEPR_C, this._AC_DEPR_N, this._GST_NO, this._APPLICABLE_GST, this._TRANSPORT, this._PAYEE_BANK, this._CR_DAYS,
                this._DISC_PREC, this._TAX_TYPE, this._AREA, this._SR_ORDER, this._OPEN_BAL, this._PROFIT, this._REMUNA, this._CR_LIMIT, this._SP_DISC, this._EMAIL_NO,
                this._MOR_TIME, this._EVE_TIME, this._IN_CHARGE, this._CTYPE_CODE, this._L_O, this._FAM_CODE, this._CF_CODE, this._INSTRCTION, this._VIC_REMARK,
                this._DELETEREC, this._ACTIVE, this._INSTRUCT2, this._INSTRUCT3, this._INSTRUCT4, this._CreatedBy, this._UpdatedBy);
        }
    }
}

