namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class ReturnBook
    {
        private int _ReturnBkID = Constants.NullInt;
        private int _DocumentNo = Constants.NullInt;
        private int _SpecimenDetailID = Constants.NullInt;
        private int _EmpID = Constants.NullInt;
        private int _ReturnQty = Constants.NullInt;
        private string _Comment = Constants.NullString;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;

        public static DataSet GetReturnBook()
        {
            return new AdminDataService().GetReturnBook();
        }

        public static DataSet GetReturnBookR(int SalesManId, string flag)
        {
            return new AdminDataService().GetReturnBookR(SalesManId, flag);
        }

        public void Save()
        {
            new AdminDataService().SaveReturnBook(this._ReturnBkID, this._DocumentNo, this._SpecimenDetailID, this._EmpID, this._ReturnQty, this._Comment, this._CreatedBy, this._UpdatedBy);
        }

        public int ReturnBkID
        {
            get
            {
                return this._ReturnBkID;
            }
            set
            {
                this._ReturnBkID = value;
            }
        }

        public int DocumentNo
        {
            get
            {
                return this._DocumentNo;
            }
            set
            {
                this._DocumentNo = value;
            }
        }

        public int SpecimenDetailID
        {
            get
            {
                return this._SpecimenDetailID;
            }
            set
            {
                this._SpecimenDetailID = value;
            }
        }

        public int EmpID
        {
            get
            {
                return this._EmpID;
            }
            set
            {
                this._EmpID = value;
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
    }
}

