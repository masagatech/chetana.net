namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;

    public class AccountSubGroup
    {
        private int _Main_Code = Constants.NullInt;
        private int _Sub_Main_Code = Constants.NullInt;
        private string _Sub_HEAD = Constants.NullString;
        private bool _Inactive = Constants.NullBoolean;
        private int _AutoId = Constants.NullInt;

        public void Save()
        {
            new AdminDataService().Idv_chetana_Save_main_group_Sub(this._Main_Code, this._Sub_HEAD, this._Inactive, this._AutoId);
        }

        public int Main_Code
        {
            get
            {
                return this._Main_Code;
            }
            set
            {
                this._Main_Code = value;
            }
        }

        public int Sub_Main_Code
        {
            get
            {
                return this._Sub_Main_Code;
            }
            set
            {
                this._Sub_Main_Code = value;
            }
        }

        public string Sub_HEAD
        {
            get
            {
                return this._Sub_HEAD;
            }
            set
            {
                this._Sub_HEAD = value;
            }
        }

        public bool Inactive
        {
            get
            {
                return this._Inactive;
            }
            set
            {
                this._Inactive = value;
            }
        }

        public int AutoId
        {
            get
            {
                return this._AutoId;
            }
            set
            {
                this._AutoId = value;
            }
        }
    }
}

