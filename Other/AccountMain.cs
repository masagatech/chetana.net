using Idv.Chetana.Common;
using Idv.Chetana.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Others
{
    public class AccountMain : DataServiceBase
    {
        #region "Field"

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

        #endregion

        #region "Properties"

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

        #endregion

        #region "User-Defined Function"

        public void SaveAccountMain()
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_chetana_Save_Account_main", new IDataParameter[] { 
                base.CreateParameter("@AutoID", SqlDbType.Int, AutoID),
                base.CreateParameter("@AC_CODE", SqlDbType.NVarChar, AC_CODE),
                base.CreateParameter("@AC_NAME", SqlDbType.NVarChar, AC_NAME),
                base.CreateParameter("@AC_GROUP", SqlDbType.NVarChar, AC_GROUP),
                base.CreateParameter("@AC_ADD1", SqlDbType.NVarChar, AC_ADD1),
                base.CreateParameter("@AC_ADD2", SqlDbType.NVarChar, AC_ADD2),
                base.CreateParameter("@AC_ADD3", SqlDbType.NVarChar, AC_ADD3),
                base.CreateParameter("@TEL1", SqlDbType.NVarChar, TEL1),
                base.CreateParameter("@TEL2", SqlDbType.NVarChar, TEL2),
                base.CreateParameter("@TELR", SqlDbType.NVarChar, TELR),
                base.CreateParameter("@CITY_CODE", SqlDbType.NVarChar, CITY_CODE),
                base.CreateParameter("@PIN_CODE", SqlDbType.NVarChar, PIN_CODE),
                base.CreateParameter("@STATE_CODE", SqlDbType.NVarChar, STATE_CODE),
                base.CreateParameter("@COUNTRY", SqlDbType.NVarChar, COUNTRY),
                base.CreateParameter("@ZONE_CODE", SqlDbType.NVarChar, ZONE_CODE),
                base.CreateParameter("@BROKER", SqlDbType.NVarChar, BROKER),
                base.CreateParameter("@MEDIUM", SqlDbType.NVarChar, MEDIUM),
                base.CreateParameter("@BROK_PERC", SqlDbType.Decimal, BROK_PERC),
                base.CreateParameter("@PRIN_int", SqlDbType.NVarChar, PRIN_int),
                base.CreateParameter("@BLACKLIST", SqlDbType.NVarChar, BLACKLIST),
                base.CreateParameter("@AC_TYPE", SqlDbType.NVarChar, AC_TYPE),
                base.CreateParameter("@AC_ST_NO", SqlDbType.NVarChar, AC_ST_NO),
                base.CreateParameter("@AC_PA_NO", SqlDbType.NVarChar, AC_PA_NO),
                base.CreateParameter("@AC_CST_NO", SqlDbType.NVarChar, AC_CST_NO),
                base.CreateParameter("@AC_int_RAT", SqlDbType.Decimal, AC_int_RAT),
                base.CreateParameter("@AC_TDS_LIM", SqlDbType.Decimal, AC_TDS_LIM),
                base.CreateParameter("@AC_TDS_RAT", SqlDbType.Decimal, AC_TDS_RAT),
                base.CreateParameter("@AC_H15", SqlDbType.Bit, AC_H15),
                base.CreateParameter("@AC_DEPR_C", SqlDbType.Decimal, AC_DEPR_C),
                base.CreateParameter("@AC_DEPR_N", SqlDbType.Decimal, AC_DEPR_N),
                base.CreateParameter("@GST_NO", SqlDbType.NVarChar, GST_NO),
                base.CreateParameter("@APPLICABLE_GST", SqlDbType.NVarChar, APPLICABLE_GST),
                base.CreateParameter("@TRANSPORT", SqlDbType.NVarChar, TRANSPORT),
                base.CreateParameter("@PAYEE_BANK", SqlDbType.NVarChar, PAYEE_BANK),
                base.CreateParameter("@CR_DAYS", SqlDbType.Int, CR_DAYS),
                base.CreateParameter("@DISC_PREC", SqlDbType.Decimal, DISC_PREC),
                base.CreateParameter("@TAX_TYPE", SqlDbType.NVarChar, TAX_TYPE),
                base.CreateParameter("@AREA", SqlDbType.NVarChar, AREA),
                base.CreateParameter("@SR_ORDER", SqlDbType.Int, SR_ORDER),
                base.CreateParameter("@OPEN_BAL", SqlDbType.Decimal, OPEN_BAL),
                base.CreateParameter("@PROFIT", SqlDbType.Decimal, PROFIT),
                base.CreateParameter("@REMUNA", SqlDbType.Decimal, REMUNA),
                base.CreateParameter("@CR_LIMIT", SqlDbType.Decimal, CR_LIMIT),
                base.CreateParameter("@SP_DISC", SqlDbType.Decimal, SP_DISC),
                base.CreateParameter("@EMAIL_NO", SqlDbType.NVarChar, EMAIL_NO),
                base.CreateParameter("@MOR_TIME", SqlDbType.NVarChar, MOR_TIME),
                base.CreateParameter("@EVE_TIME", SqlDbType.NVarChar, EVE_TIME),
                base.CreateParameter("@IN_CHARGE", SqlDbType.NVarChar, IN_CHARGE),
                base.CreateParameter("@CTYPE_CODE", SqlDbType.NVarChar, CTYPE_CODE),
                base.CreateParameter("@L_O", SqlDbType.NVarChar, L_O),
                base.CreateParameter("@FAM_CODE", SqlDbType.NVarChar, FAM_CODE),
                base.CreateParameter("@CF_CODE", SqlDbType.NVarChar, CF_CODE),
                base.CreateParameter("@INSTRCTION", SqlDbType.NVarChar, INSTRCTION),
                base.CreateParameter("@VIC_REMARK", SqlDbType.NVarChar, VIC_REMARK),
                base.CreateParameter("@DELETEREC", SqlDbType.NVarChar, DELETEREC),
                base.CreateParameter("@ACTIVE", SqlDbType.Bit, ACTIVE),
                base.CreateParameter("@INSTRUCT2", SqlDbType.NVarChar, INSTRUCT2),
                base.CreateParameter("@INSTRUCT3", SqlDbType.NVarChar, INSTRUCT3),
                base.CreateParameter("@INSTRUCT4", SqlDbType.NVarChar, INSTRUCT4),
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
                base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy)
            });

            command.Dispose();
        }

        public DataSet GetAccountMainData(string AcCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Account_main", new IDataParameter[] {
                base.CreateParameter("@AcCode", SqlDbType.NVarChar, AcCode)
            });
        }

        public static DataSet GetAccountMain(string AcCode)
        {
            return new AccountMain().GetAccountMainData(AcCode);
        }

        public DataSet ACCodeValidatonData(string AcCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_AcCode", new IDataParameter[] {
                base.CreateParameter("@AcCode", SqlDbType.NVarChar, AcCode)
            });
        }

        public static bool ACCodeValidaton(string AcCode)
        {
            DataTable table = new DataTable();
            table = new AccountMain().ACCodeValidatonData(AcCode).Tables[0];
            return (table.Rows.Count > 0);
        }

        #endregion
    }
}
