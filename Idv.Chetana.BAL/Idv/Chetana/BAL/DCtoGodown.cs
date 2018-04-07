namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;

    public class DCtoGodown
    {
        private int _DCDetailID = Constants.NullInt;
        private int _DocumentNo = Constants.NullInt;
        private string _EmpID = Constants.NullString;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private decimal _SubDocNo = Constants.NullDecimal;

        public void SaveGodown()
        {
            new AdminDataService_DC().Save_DCToGodown(this._SubDocNo, this._DocumentNo, this._EmpID, this._CreatedBy, this._UpdatedBy);
        }

        public int DCDetailID
        {
            get
            {
                return this._DCDetailID;
            }
            set
            {
                this._DCDetailID = value;
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

        public string EmpID
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

        public decimal SubDocNo
        {
            get
            {
                return this._SubDocNo;
            }
            set
            {
                this._SubDocNo = value;
            }
        }
    }
}

