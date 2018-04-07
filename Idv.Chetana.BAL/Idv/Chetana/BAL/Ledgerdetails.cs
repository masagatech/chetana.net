namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;

    public class Ledgerdetails
    {
        private string _CustId = Constants.NullString;
        private decimal _Amount = Constants.NullDecimal;
        private string _OtherId = Constants.NullString;
        private int _FY = Constants.NullInt;

        public void update()
        {
            new AdminDataService_DC().updatePaymentPending(this._CustId, this._Amount, this._OtherId);
        }

        public void update(int FY)
        {
            new AdminDataService_DC().updatePaymentPending(this._CustId, this._Amount, this._OtherId, this._FY);
        }

        public string CustId
        {
            get
            {
                return this._CustId;
            }
            set
            {
                this._CustId = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                this._Amount = value;
            }
        }

        public string OtherId
        {
            get
            {
                return this._OtherId;
            }
            set
            {
                this._OtherId = value;
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

