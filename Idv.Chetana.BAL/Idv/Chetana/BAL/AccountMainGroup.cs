namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class AccountMainGroup
    {
        private int _AutoId = Constants.NullInt;
        private int _Main_Code = Constants.NullInt;
        private string _MAIN_HEAD = Constants.NullString;
        private bool _Inactive = Constants.NullBoolean;
        private string _createdby = Constants.NullString;

        public static DataSet Idv_Chetana_Get_AccountMain()
        {
            return new AdminDataService().Idv_Chetana_Get_AccountMain();
        }

        public static DataSet Idv_Chetana_Get_SubGroup(int SubGroup)
        {
            return new AdminDataService().Idv_Chetana_Get_SubGroup(SubGroup);
        }

        public void Save()
        {
            new AdminDataService().idv_chetana_Save_main_group(this._AutoId, this._Main_Code, this._MAIN_HEAD, this._Inactive, this._createdby);
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

        public string MAIN_HEAD
        {
            get
            {
                return this._MAIN_HEAD;
            }
            set
            {
                this._MAIN_HEAD = value;
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

        public string Createdby
        {
            get
            {
                return this._createdby;
            }
            set
            {
                this._createdby = value;
            }
        }
    }
}

