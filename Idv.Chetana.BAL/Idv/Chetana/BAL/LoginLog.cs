namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class LoginLog
    {
        private int _LoginLogId = Constants.NullInt;
        private string _LoginPersonName = Constants.NullString;
        private string _LoginPesonId = Constants.NullString;
        private DateTime _LoginTime = Constants.NullDateTime;
        private DateTime _LoggOutTime = Constants.NullDateTime;
        private string _IpAddress = Constants.NullString;
        private string _ResonToLoggOut = Constants.NullString;

        public static DataTable getLoginLogDetails(string UserId)
        {
            return new AdminDataService().getLoginLogDetails(UserId);
        }

        public void Save(out int outLoginLogId)
        {
            this.Save(null, out outLoginLogId);
        }

        public void Save(IDbTransaction txn, out int outLoginLogId)
        {
            new AdminDataService().SaveLoginLog(this._LoginLogId, this._LoginPersonName, this._LoginPesonId, this._LoginTime, this._LoggOutTime, this._IpAddress, this._ResonToLoggOut, out outLoginLogId);
        }

        public int LoginLogId
        {
            get
            {
                return this._LoginLogId;
            }
            set
            {
                this._LoginLogId = value;
            }
        }

        public string LoginPersonName
        {
            get
            {
                return this._LoginPersonName;
            }
            set
            {
                this._LoginPersonName = value;
            }
        }

        public string LoginPesonId
        {
            get
            {
                return this._LoginPesonId;
            }
            set
            {
                this._LoginPesonId = value;
            }
        }

        public DateTime LoginTime
        {
            get
            {
                return this._LoginTime;
            }
            set
            {
                this._LoginTime = value;
            }
        }

        public DateTime LoggOutTime
        {
            get
            {
                return this._LoggOutTime;
            }
            set
            {
                this._LoggOutTime = value;
            }
        }

        public string IpAddress
        {
            get
            {
                return this._IpAddress;
            }
            set
            {
                this._IpAddress = value;
            }
        }

        public string ResonToLoggOut
        {
            get
            {
                return this._ResonToLoggOut;
            }
            set
            {
                this._ResonToLoggOut = value;
            }
        }
    }
}

