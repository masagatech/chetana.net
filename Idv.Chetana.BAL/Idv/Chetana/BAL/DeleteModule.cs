namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;

    public class DeleteModule
    {
        private string _ID = Constants.NullString;
        private string _Created_BY = Constants.NullString;
        private string _Module = Constants.NullString;
        private bool _Is_Restore = Constants.NullBoolean;
        private int _FY = Constants.NullInt;

        public void Save()
        {
            new AdminDataService_DC().DELETE_DATA_FROM_MODULE(this._ID, this._Module, this._Is_Restore, this._Created_BY, this._FY);
        }

        public string ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        public string Created_BY
        {
            get
            {
                return this._Created_BY;
            }
            set
            {
                this._Created_BY = value;
            }
        }

        public string Module
        {
            get
            {
                return this._Module;
            }
            set
            {
                this._Module = value;
            }
        }

        public bool Is_Restore
        {
            get
            {
                return this._Is_Restore;
            }
            set
            {
                this._Is_Restore = value;
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

