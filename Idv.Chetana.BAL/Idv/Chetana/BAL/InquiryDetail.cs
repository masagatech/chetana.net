namespace Idv.Chetana.BAL
{
    using System;

    public class InquiryDetail
    {
        private DateTime _EnqDate;
        private string _TKTID;
        private string _Action;
        private string _CustomerName;
        private string _TktNumber;
        private DateTime _Fromdate;
        private DateTime _ToDate;
        private string _TKTFrom;
        private string _TKTTO;
        private string _EnqType;
        private string _EnqActionOn;
        private string _CustID;
        private string _RtoInq1;
        private string _RtoInq2;
        private string _RtoInq3;
        private string _Severity;
        private string _Status;
        private string _Remarks;

        public string TktNumber
        {
            get
            {
                return this._TktNumber;
            }
            set
            {
                this._TktNumber = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return this._CustomerName;
            }
            set
            {
                this._CustomerName = value;
            }
        }

        public string Action
        {
            get
            {
                return this._Action;
            }
            set
            {
                this._Action = value;
            }
        }

        public DateTime Fromdate
        {
            get
            {
                return this._Fromdate;
            }
            set
            {
                this._Fromdate = value;
            }
        }

        public DateTime ToDate
        {
            get
            {
                return this._ToDate;
            }
            set
            {
                this._ToDate = value;
            }
        }

        public string TKTFrom
        {
            get
            {
                return this._TKTFrom;
            }
            set
            {
                this._TKTFrom = value;
            }
        }

        public string TKTTO
        {
            get
            {
                return this._TKTTO;
            }
            set
            {
                this._TKTTO = value;
            }
        }

        public string TKTID
        {
            get
            {
                return this._TKTID;
            }
            set
            {
                this._TKTID = value;
            }
        }

        public string RtoInq1
        {
            get
            {
                return this._RtoInq1;
            }
            set
            {
                this._RtoInq1 = value;
            }
        }

        public string RtoInq2
        {
            get
            {
                return this._RtoInq2;
            }
            set
            {
                this._RtoInq2 = value;
            }
        }

        public string RtoInq3
        {
            get
            {
                return this._RtoInq3;
            }
            set
            {
                this._RtoInq3 = value;
            }
        }

        public string CustID
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

        public string EnqActionOn
        {
            get
            {
                return this._EnqActionOn;
            }
            set
            {
                this._EnqActionOn = value;
            }
        }

        public string EnqType
        {
            get
            {
                return this._EnqType;
            }
            set
            {
                this._EnqType = value;
            }
        }

        public DateTime EnqDate
        {
            get
            {
                return this._EnqDate;
            }
            set
            {
                this._EnqDate = value;
            }
        }

        public string Severity
        {
            get
            {
                return this._Severity;
            }
            set
            {
                this._Severity = value;
            }
        }

        public string Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this._Status = value;
            }
        }

        public string Remarks
        {
            get
            {
                return this._Remarks;
            }
            set
            {
                this._Remarks = value;
            }
        }
    }
}

