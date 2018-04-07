namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;

    public class SpecimentoGodown
    {
        private int _SpecimenDetailID = Constants.NullInt;
        private int _DocumentNo = Constants.NullInt;
        private string _EmpID = Constants.NullString;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;

        public void SaveGodown()
        {
            new AdminDataService().Save_SpecimenToGodown(this._SpecimenDetailID, this._DocumentNo, this._EmpID, this._CreatedBy, this._UpdatedBy);
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
    }
}

