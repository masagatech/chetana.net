namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class ReciptBookDetails
    {
        private int _ReceiptBookID = Constants.NullInt;
        private string _EmpCode = Constants.NullString;
        private int _FromNo = Constants.NullInt;
        private int _ToNo = Constants.NullInt;
        private int _ActualReceiptNo = Constants.NullInt;
        private string _Description = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsCancel = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private bool _IsDeleted = Constants.NullBoolean;
        private int _FY = Constants.NullInt;

        public static DataSet Get_Multiplecanceldetails(string EmpCode, int FromNo, int ToNo)
        {
            return new AdminDataService_DC().getMultipleCancel_details(EmpCode, FromNo, ToNo);
        }

        public static bool getChequeCash_valid(int FromNo)
        {
            DataTable table = new DataTable();
            table = new AdminDataService_DC().saveChequeCash_valid(FromNo).Tables[0];
            return (table.Rows.Count > 0);
        }

        public static DataSet getReceiptBookDetails(string EmpCode, string fromno, string Tono, int ActualReceiptNo)
        {
            return new AdminDataService_DC().getReceiptBookDetails(EmpCode, fromno, Tono, ActualReceiptNo);
        }

        public static DataTable GetRecipt_Cancel_Used_Details(string EmpCode, int FromNo, int ToNo, string Flag)
        {
            return new AdminDataService_DC().GetRecipt_Cancel_Used_Details(EmpCode, FromNo, ToNo, Flag);
        }

        public static string getReciptbook_valid(int receiptNo)
        {
            DataSet set = new DataSet();
            set = new AdminDataService_DC().saveReciptbook_valid(receiptNo);
            if (set.Tables[0].Rows.Count > 0)
            {
                if (set.Tables[0].Rows[0][0].ToString().ToLower() == "0")
                {
                    return set.Tables[0].Rows[0][1].ToString();
                }
                return set.Tables[0].Rows[0][1].ToString();
            }
            return set.Tables[0].Rows[0][1].ToString();
        }

        public static bool getReciptbook_valid1(int FromNo, int ToNo)
        {
            DataTable table = new DataTable();
            table = new AdminDataService_DC().saveReciptbookEntry2_valid(FromNo, ToNo).Tables[0];
            return (table.Rows.Count > 0);
        }

        public static DataSet Idv_Chetana_Edit_Receipt_Book(string SalesManId_Old, int FromNo_Old, int ToNo_Old, string SalesManCode_New, int FromNo_New, int ToNo_New, int ReceiptBookID, int ActualReceiptNo)
        {
            return new AdminDataService_DC().Idv_Chetana_Edit_Receipt_Book(SalesManId_Old, FromNo_Old, ToNo_Old, SalesManCode_New, FromNo_New, ToNo_New, ReceiptBookID, ActualReceiptNo);
        }

        public static int IDV_CHETANA_Get_ReceiptBookDetails_MaxID(out int ActualReceiptNo)
        {
            return new AdminDataService_DC().IDV_CHETANA_Get_ReceiptBookDetails_MaxID(out ActualReceiptNo);
        }

        public static DataSet Idv_Chetana_Get_ReceiptBookDetails_Report(int ActualReceiptNo)
        {
            return new AdminDataService_DC().Idv_Chetana_Get_ReceiptBookDetails_Report(ActualReceiptNo);
        }

        public static DataSet Idv_Chetana_Get_ReceiptView_AT_EntryTime(int ReciptNo)
        {
            return new AdminDataService_DC().Idv_Chetana_Get_ReceiptView_AT_EntryTime(ReciptNo);
        }

        public static DataSet Idv_Chetana_Report_ReceiptBook(int ReceiptBookId)
        {
            return new AdminDataService_DC().Idv_Chetana_Report_ReceiptBook(ReceiptBookId);
        }

        public static DataSet Idv_Chetana_Report_ReceiptBook(string ReceiptBookId)
        {
            return new AdminDataService_DC().Idv_Chetana_Report_ReceiptBook(ReceiptBookId);
        }

        public void Save(out int _IDNo)
        {
            this.Save(null, out _IDNo);
        }

        public void Save(IDbTransaction txn, out int _IDNo)
        {
            new AdminDataService_DC().save_ReceiptBookDetailsdal(this._ReceiptBookID, this._EmpCode, this._FromNo, this._ToNo, this._ActualReceiptNo, this._IsActive, this._IsCancel, this._CreatedBy, this._FY, out _IDNo);
        }

        public int ReceiptBookID
        {
            get
            {
                return this._ReceiptBookID;
            }
            set
            {
                this._ReceiptBookID = value;
            }
        }

        public string EmpCode
        {
            get
            {
                return this._EmpCode;
            }
            set
            {
                this._EmpCode = value;
            }
        }

        public int FromNo
        {
            get
            {
                return this._FromNo;
            }
            set
            {
                this._FromNo = value;
            }
        }

        public int ToNo
        {
            get
            {
                return this._ToNo;
            }
            set
            {
                this._ToNo = value;
            }
        }

        public int ActualReceiptNo
        {
            get
            {
                return this._ActualReceiptNo;
            }
            set
            {
                this._ActualReceiptNo = value;
            }
        }

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return this._IsActive;
            }
            set
            {
                this._IsActive = value;
            }
        }

        public bool IsCancel
        {
            get
            {
                return this._IsCancel;
            }
            set
            {
                this._IsCancel = value;
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

        public bool IsDeleted
        {
            get
            {
                return this._IsDeleted;
            }
            set
            {
                this._IsDeleted = value;
            }
        }

        public int FY
        {
            get
            {
                return this._FY;
            }
            set
            {
                this._FY = value;
            }
        }
    }
}

