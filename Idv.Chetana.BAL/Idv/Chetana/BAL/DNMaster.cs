namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class DNMaster
    {
        private int _DNMasterID = Constants.NullInt;
        private int _DNDocNo = Constants.NullInt;
        private DateTime _DNDocDate = Constants.NullDateTime;
        private string _BookCode = Constants.NullString;
        private string _DNAccountCode = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private int _DocNo = Constants.NullInt;
        private int _DNMID = Constants.NullInt;
        private bool _IsDeleted = Constants.NullBoolean;
        private int _strFY = Constants.NullInt;

        public void Save(out int _DocNo, out int _DNMID)
        {
            this.Save(null, out _DocNo, out _DNMID);
        }

        public void Save(IDbTransaction txn, out int _DocNo, out int _DNMID)
        {
            new AdminDataService_DC().SaveDNMaster(this._DNMasterID, this._DNDocNo, this._DNDocDate, this._BookCode, this._DNAccountCode, this._IsActive, this._CreatedBy, this._UpdatedBy, out _DocNo, out _DNMID, this._strFY);
        }

        public int DNMasterID
        {
            get
            {
                return this._DNMasterID;
            }
            set
            {
                this._DNMasterID = value;
            }
        }

        public int DNDocNo
        {
            get
            {
                return this._DNDocNo;
            }
            set
            {
                this._DNDocNo = value;
            }
        }

        public DateTime DNDocDate
        {
            get
            {
                return this._DNDocDate;
            }
            set
            {
                this._DNDocDate = value;
            }
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

        public string DNAccountCode
        {
            get
            {
                return this._DNAccountCode;
            }
            set
            {
                this._DNAccountCode = value;
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

        public int DocNo
        {
            get
            {
                return this._DocNo;
            }
            set
            {
                this._DocNo = value;
            }
        }

        public int DNMID
        {
            get
            {
                return this._DNMID;
            }
            set
            {
                this._DNMID = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return this._IsDeleted;
            }
            set
            {
                this._IsDeleted = value;
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

