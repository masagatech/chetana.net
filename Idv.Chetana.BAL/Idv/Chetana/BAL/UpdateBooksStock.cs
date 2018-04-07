namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;

    public class UpdateBooksStock
    {
        private string _BookCode = Constants.NullString;
        private int _stock = Constants.NullInt;
        private int _Fy = Constants.NullInt;
        private string _createdBy = Constants.NullString;
        private string _remark1 = Constants.NullString;
        private string _remark2 = Constants.NullString;
        private string _remark3 = Constants.NullString;

        public void Save()
        {
            new AdminDataService().SaveUpdateBookStock(this._BookCode, this._stock, this._Fy, this._createdBy, this._remark1, this._remark2, this._remark3);
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

        public int stock
        {
            get
            {
                return this._stock;
            }
            set
            {
                this._stock = value;
            }
        }

        public int Fy
        {
            get
            {
                return this._Fy;
            }
            set
            {
                this._Fy = value;
            }
        }

        public string createdBy
        {
            get
            {
                return this._createdBy;
            }
            set
            {
                this._createdBy = value;
            }
        }

        public string remark1
        {
            get
            {
                return this._remark1;
            }
            set
            {
                this._remark1 = value;
            }
        }

        public string remark2
        {
            get
            {
                return this._remark2;
            }
            set
            {
                this._remark2 = value;
            }
        }

        public string remark3
        {
            get
            {
                return this._remark3;
            }
            set
            {
                this._remark3 = value;
            }
        }
    }
}

