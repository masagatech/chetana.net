namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;

    public class G_GetPassSub
    {
        private int _DOC_SUB_ID = Constants.NullInt;
        private int _DOC_ID = Constants.NullInt;
        private string _BILL_NO = Constants.NullString;
        private string _SCHL_NAME = Constants.NullString;
        private string _SCHL_AREA = Constants.NullString;
        private string _NO_OF_BUNDLES = Constants.NullString;
        private bool _DELIVERY = Constants.NullBoolean;
        private decimal _DC_NO = Constants.NullDecimal;
        private int _IS_Delete = Constants.NullInt;
        private DateTime _Created_On = Constants.NullDateTime;
        private string _Created_By = Constants.NullString;
        private DateTime _Updated_On = Constants.NullDateTime;
        private string _Updated_By = Constants.NullString;
        private int _Cust_ID = Constants.NullInt;

        public void Save()
        {
            new AdminDataService_Go().SaveIdv_Chetana_G_GetPass_Sub(this._DOC_SUB_ID, this._DOC_ID, this._BILL_NO, this._SCHL_NAME, this._SCHL_AREA, this._NO_OF_BUNDLES, this._DELIVERY, this._DC_NO, this._Created_By, this._Updated_By, this._Cust_ID);
        }

        public int DOC_SUB_ID
        {
            get
            {
                return this._DOC_SUB_ID;
            }
            set
            {
                this._DOC_SUB_ID = value;
            }
        }

        public int DOC_ID
        {
            get
            {
                return this._DOC_ID;
            }
            set
            {
                this._DOC_ID = value;
            }
        }

        public string BILL_NO
        {
            get
            {
                return this._BILL_NO;
            }
            set
            {
                this._BILL_NO = value;
            }
        }

        public string SCHL_NAME
        {
            get
            {
                return this._SCHL_NAME;
            }
            set
            {
                this._SCHL_NAME = value;
            }
        }

        public string SCHL_AREA
        {
            get
            {
                return this._SCHL_AREA;
            }
            set
            {
                this._SCHL_AREA = value;
            }
        }

        public string NO_OF_BUNDLES
        {
            get
            {
                return this._NO_OF_BUNDLES;
            }
            set
            {
                this._NO_OF_BUNDLES = value;
            }
        }

        public bool DELIVERY
        {
            get
            {
                return this._DELIVERY;
            }
            set
            {
                this._DELIVERY = value;
            }
        }

        public decimal DC_NO
        {
            get
            {
                return this._DC_NO;
            }
            set
            {
                this._DC_NO = value;
            }
        }

        public int IS_Delete
        {
            get
            {
                return this._IS_Delete;
            }
            set
            {
                this._IS_Delete = value;
            }
        }

        public DateTime Created_On
        {
            get
            {
                return this._Created_On;
            }
            set
            {
                this._Created_On = value;
            }
        }

        public string Created_By
        {
            get
            {
                return this._Created_By;
            }
            set
            {
                this._Created_By = value;
            }
        }

        public DateTime Updated_On
        {
            get
            {
                return this._Updated_On;
            }
            set
            {
                this._Updated_On = value;
            }
        }

        public string Updated_By
        {
            get
            {
                return this._Updated_By;
            }
            set
            {
                this._Updated_By = value;
            }
        }

        public int Cust_ID
        {
            get
            {
                return this._Cust_ID;
            }
            set
            {
                this._Cust_ID = value;
            }
        }
    }
}

