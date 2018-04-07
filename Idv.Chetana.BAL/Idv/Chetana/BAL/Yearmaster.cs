namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Yearmaster
    {
        private int _yearAutoId = Constants.NullInt;
        private string _FromYear = Constants.NullString;
        private string _ToYear = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsBlock = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;

        public static DataTable GetFinancialYear()
        {
            DataSet financialYear = new DataSet();
            financialYear = new AdminDataService().GetFinancialYear();
            DataTable table = new DataTable();
            return financialYear.Tables[0];
        }

        public void Save()
        {
            new AdminDataService().SaveFinancialYear(this._yearAutoId, this._FromYear, this._ToYear, this._IsActive, this._CreatedBy, this._UpdatedBy);
        }

        public int yearAutoId
        {
            get
            {
                return this._yearAutoId;
            }
            set
            {
                this._yearAutoId = value;
            }
        }

        public string FromYear
        {
            get
            {
                return this._FromYear;
            }
            set
            {
                this._FromYear = value;
            }
        }

        public string ToYear
        {
            get
            {
                return this._ToYear;
            }
            set
            {
                this._ToYear = value;
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

        public bool IsBlock
        {
            get
            {
                return this._IsBlock;
            }
            set
            {
                this._IsBlock = value;
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
    }
}

