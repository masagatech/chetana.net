namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;

    public class OpeningBalance
    {
        private string _Remarks1 = Constants.NullString;
        private string _Remarks2 = Constants.NullString;
        private string _Remarks3 = Constants.NullString;
        private string _Flag = Constants.NullString;
        private string _CreatedBy = Constants.NullString;
        private int _strFY = Constants.NullInt;

        public void Save()
        {
            new AdminDataService().Idv_Chetana_Upload_Opening_Balance(this.CreatedBy, this.strFY, this.Flag, this.Remarks1, this.Remarks2, this.Remarks3);
        }

        public string Remarks1
        {
            get
            {
                return this._Remarks1;
            }
            set
            {
                this._Remarks1 = value;
            }
        }

        public string Remarks2
        {
            get
            {
                return this._Remarks2;
            }
            set
            {
                this._Remarks2 = value;
            }
        }

        public string Remarks3
        {
            get
            {
                return this._Remarks3;
            }
            set
            {
                this._Remarks3 = value;
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

