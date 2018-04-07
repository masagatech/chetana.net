namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class DCReturnBook
    {
        private int _DCReturnBkID = Constants.NullInt;
        private string _CustCode = Constants.NullString;
        private string _BookCode = Constants.NullString;
        private int _ReturnQty = Constants.NullInt;
        private string _Comment = Constants.NullString;
        private string _CreatedBy = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private DateTime _Updatedon = Constants.NullDateTime;
        private string _Flag = Constants.NullString;
        private int _DefectQty = Constants.NullInt;
        private int _strFY = Constants.NullInt;

        public static DataSet Get_DC_CustAd(string CustCode)
        {
            return new AdminDataService_DC().Get_DC_CustAd(CustCode);
        }

        public static DataSet Get_DC_RateByBook(string CustCode, string BookCode1)
        {
            return new AdminDataService_DC().Get_DC_RateByBook(CustCode, BookCode1);
        }

        public static DataSet Get_DC_ReturnBkview(string CustCode, string BookCode)
        {
            return new AdminDataService_DC().Get_DC_ReturnBkview(CustCode, BookCode);
        }

        public static DataSet Get_DC_ReturnBkview(int strFY, string CustCode, string BookCode)
        {
            return new AdminDataService_DC().Get_DC_ReturnBkview(strFY, CustCode, BookCode);
        }

        public static DataSet Get_DC_ReturnBook(string CustCode, string flag)
        {
            return new AdminDataService_DC().Get_DC_ReturnBook(CustCode, flag);
        }

        public static DataSet Get_DC_ReturnBook(int strFY, string CustCode, string flag)
        {
            return new AdminDataService_DC().Get_DC_ReturnBook(strFY, CustCode, flag);
        }

        public static DataSet Get_DC_ReturnBookR(string CustCode, string flag)
        {
            return new AdminDataService_DC().Get_DC_ReturnBook(CustCode, flag);
        }

        public static DataSet GetCustAddress(string CustCode, string flag)
        {
            return new AdminDataService_DC().GetCustAddress(CustCode, flag);
        }

        public void Save_DC_ReturnBook()
        {
            new AdminDataService_DC().Save_DC_ReturnBook(this._DCReturnBkID, this._CustCode, this._BookCode, this._ReturnQty, this._Comment, this._CreatedBy, this._Flag, this._DefectQty);
        }

        public void Save_DC_ReturnBook(int strFY)
        {
            new AdminDataService_DC().Save_DC_ReturnBook(this._DCReturnBkID, this._CustCode, this._BookCode, this._ReturnQty, this._Comment, this._CreatedBy, this._Flag, this._DefectQty, this._strFY);
        }

        public int DCReturnBkID
        {
            get
            {
                return this._DCReturnBkID;
            }
            set
            {
                this._DCReturnBkID = value;
            }
        }

        public string CustCode
        {
            get
            {
                return this._CustCode;
            }
            set
            {
                this._CustCode = value;
            }
        }

        public string BookCode
        {
            get
            {
                return this._BookCode;
            }
            set
            {
                this._BookCode = value;
            }
        }

        public int ReturnQty
        {
            get
            {
                return this._ReturnQty;
            }
            set
            {
                this._ReturnQty = value;
            }
        }

        public string Comment
        {
            get
            {
                return this._Comment;
            }
            set
            {
                this._Comment = value;
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

        public DateTime Updatedon
        {
            get
            {
                return this._Updatedon;
            }
            set
            {
                this._Updatedon = value;
            }
        }

        public string Flag
        {
            get
            {
                return this._Flag;
            }
            set
            {
                this._Flag = value;
            }
        }

        public int DefectQty
        {
            get
            {
                return this._DefectQty;
            }
            set
            {
                this._DefectQty = value;
            }
        }

        public int strFY
        {
            get
            {
                return this._strFY;
            }
            set
            {
                this._strFY = value;
            }
        }
    }
}

