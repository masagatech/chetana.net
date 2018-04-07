namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class JVMaster
    {
        private int _JVMasterID = Constants.NullInt;
        private int _JVDocNo = Constants.NullInt;
        private DateTime _JVDocDate = Constants.NullDateTime;
        private string _CompanyCode = Constants.NullString;
        private string _BookCode = Constants.NullString;
        private bool _Isactive = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private int _DocNo = Constants.NullInt;
        private int _JVMID = Constants.NullInt;
        private bool _IsDeleted = Constants.NullBoolean;
        private int _strFY = Constants.NullInt;

        public void DeleteJV()
        {
            new AdminDataService_DC().DeleteJV(this._JVMasterID, this._JVDocNo, this._UpdatedBy, this._strFY);
        }

        public void Save(out int _DocNo, out int _JVMID)
        {
            this.Save(null, out _DocNo, out _JVMID);
        }

        public void Save(IDbTransaction txn, out int _DocNo, out int _JVMID)
        {
            new AdminDataService_DC().SaveJVMaster(this._JVMasterID, this._JVDocNo, this._JVDocDate, this._CompanyCode, this._BookCode, this._Isactive, this._CreatedBy, this._UpdatedBy, out _DocNo, out _JVMID, this._strFY);
        }

        public int JVMasterID
        {
            get
            {
                return this._JVMasterID;
            }
            set
            {
                this._JVMasterID = value;
            }
        }

        public int JVDocNo
        {
            get
            {
                return this._JVDocNo;
            }
            set
            {
                this._JVDocNo = value;
            }
        }

        public DateTime JVDocDate
        {
            get
            {
                return this._JVDocDate;
            }
            set
            {
                this._JVDocDate = value;
            }
        }

        public string CompanyCode
        {
            get
            {
                return this._CompanyCode;
            }
            set
            {
                this._CompanyCode = value;
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

        public bool Isactive
        {
            get
            {
                return this._Isactive;
            }
            set
            {
                this._Isactive = value;
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

        public int JVMID
        {
            get
            {
                return this._JVMID;
            }
            set
            {
                this._JVMID = value;
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

