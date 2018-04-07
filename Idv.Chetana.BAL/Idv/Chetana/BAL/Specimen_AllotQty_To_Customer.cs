namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Specimen_AllotQty_To_Customer
    {
        private int _AllotCustID = Constants.NullInt;
        private int _SpecimenDetailId = Constants.NullInt;
        private int _CustID = Constants.NullInt;
        private int _AllotQty = Constants.NullInt;
        private bool _IsDelete = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;

        public static DataSet Get_AllotedSpecimenDetailId(int SpecimenDetailId)
        {
            return new AdminDataService().Get_AllotedSpecimenDetailId(SpecimenDetailId);
        }

        public static DataSet Get_DashBoardAllotQty(string EmpCode)
        {
            return new AdminDataService().GetDashBoardAllotQty(EmpCode);
        }

        public void Save()
        {
            new AdminDataService().Save_Specimen_AllotQty_To_Customer(this._AllotCustID, this._SpecimenDetailId, this._CustID, this._AllotQty, this._IsDelete, this._CreatedOn, this._CreatedBy, this._UpdatedOn, this._UpdatedBy);
        }

        public int AllotCustID
        {
            get
            {
                return this._AllotCustID;
            }
            set
            {
                this._AllotCustID = value;
            }
        }

        public int SpecimenDetailId
        {
            get
            {
                return this._SpecimenDetailId;
            }
            set
            {
                this._SpecimenDetailId = value;
            }
        }

        public int CustID
        {
            get
            {
                return this._CustID;
            }
            set
            {
                this._CustID = value;
            }
        }

        public int AllotQty
        {
            get
            {
                return this._AllotQty;
            }
            set
            {
                this._AllotQty = value;
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

