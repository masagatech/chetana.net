namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class ReciptCancelBook
    {
        private int _AutoCancelRecNo = Constants.NullInt;
        private int _FromNo = Constants.NullInt;
        private int _ToNo = Constants.NullInt;
        private string _Resion = Constants.NullString;
        private bool _IsDelete = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private string _EmpCode = Constants.NullString;

        public static DataSet get_ReciptCancel_book(string EmpCode)
        {
            return new AdminDataService_DC().get_CancelRecipt(EmpCode);
        }

        public static DataSet Get_Validate_ReceiptCancelBook(string EmpCode, int fromno)
        {
            return new AdminDataService_DC().Get_Validate_ReceiptCancelBook(EmpCode, fromno);
        }

        public void Save()
        {
            new AdminDataService_DC().Save_CancelRecipt(this._AutoCancelRecNo, this._FromNo, this._ToNo, this._Resion, this._IsDelete, this._CreatedBy, this._EmpCode);
        }

        public static DataSet saveReciptbook_valid(string EMcode, int receiptNo)
        {
            return new AdminDataService_DC().saveReciptbook_valid(EMcode, receiptNo);
        }

        public int AutoCancelRecNo
        {
            get
            {
                return this._AutoCancelRecNo;
            }
            set
            {
                this._AutoCancelRecNo = value;
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

        public string Resion
        {
            get
            {
                return this._Resion;
            }
            set
            {
                this._Resion = value;
            }
        }

        public bool IsDelete
        {
            get
            {
                return this._IsDelete;
            }
            set
            {
                this._IsDelete = value;
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
    }
}

