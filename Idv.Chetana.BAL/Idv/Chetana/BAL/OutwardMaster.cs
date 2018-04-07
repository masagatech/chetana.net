namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class OutwardMaster
    {
        private int _OdMAutoId = Constants.NullInt;
        private int _OUTDocumentID = Constants.NullInt;
        private int _FY = Constants.NullInt;
        private DateTime _OutWardDate = Constants.NullDateTime;
        private string _HandOverTo = Constants.NullString;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private int _DocNo = Constants.NullInt;
        private int _OdMID = Constants.NullInt;
        private string _Remarks = Constants.NullString;

        public void Save(out int _DocNo, out int _OdMID)
        {
            this.Save(null, out _DocNo, out _OdMID);
        }

        public void Save(IDbTransaction txn, out int _DocNo, out int _OdMID)
        {
            new AdminDataService_DC().SaveODMaster(this._OdMAutoId, this._FY, this._OutWardDate, this._HandOverTo, this._CreatedBy, this._UpdatedBy, this._IsActive, this._IsDeleted, this._Remarks, out _DocNo, out _OdMID);
        }

        public int OdMAutoId
        {
            get
            {
                return this._OdMAutoId;
            }
            set
            {
                this._OdMAutoId = value;
            }
        }

        public int OUTDocumentID
        {
            get
            {
                return this._OUTDocumentID;
            }
            set
            {
                this._OUTDocumentID = value;
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

        public DateTime OutWardDate
        {
            get
            {
                return this._OutWardDate;
            }
            set
            {
                this._OutWardDate = value;
            }
        }

        public string HandOverTo
        {
            get
            {
                return this._HandOverTo;
            }
            set
            {
                this._HandOverTo = value;
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

        public int OdMID
        {
            get
            {
                return this._OdMID;
            }
            set
            {
                this._OdMID = value;
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

