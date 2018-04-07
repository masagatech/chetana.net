namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;

    public class LedgerCN
    {
        private int _CNNo = Constants.NullInt;
        private int _strFY = Constants.NullInt;
        private DateTime _CNDate = Constants.NullDateTime;
        private string _IsExciseApplicable = Constants.NullString;

        public void Ledger_CN()
        {
            new AdminDataService_DC().LedgerCN(this.CNNo, this.strFY, this.CNDate);
        }

        public void Ledger_CN(string s)
        {
            new AdminDataService_DC().LedgerCN(this.CNNo, this.strFY, this.CNDate, this.IsExciseApplicable);
        }

        public int CNNo
        {
            get
            {
                return this._CNNo;
            }
            set
            {
                this._CNNo = value;
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

        public DateTime CNDate
        {
            get
            {
                return this._CNDate;
            }
            set
            {
                this._CNDate = value;
            }
        }

        public string IsExciseApplicable
        {
            get
            {
                return this._IsExciseApplicable;
            }
            set
            {
                this._IsExciseApplicable = value;
            }
        }
    }
}

