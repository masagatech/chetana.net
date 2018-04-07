namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class AccountGroupSub
    {
        private int _MAIN_Code = Constants.NullInt;
        private int _SUB_GR = Constants.NullInt;
        private int _GROUP = Constants.NullInt;
        private string _GR_HEAD = Constants.NullString;
        private int _SR_ORDER = Constants.NullInt;
        private string _SCHEDULE = Constants.NullString;
        private string _TYPE = Constants.NullString;
        private string _CONTROL = Constants.NullString;
        private int _AutoId = Constants.NullInt;

        public static DataSet Idv_Chetana_Get_idv_chetana_main_group_Sub()
        {
            return new AdminDataService().Idv_Chetana_Get_idv_chetana_main_group_Sub();
        }

        public static DataSet Idv_Chetana_Get_main_group()
        {
            return new AdminDataService().Idv_Chetana_Get_main_group();
        }

        public static DataSet Idv_Chetana_Get_Main_group_sub()
        {
            return new AdminDataService().Idv_Chetana_Get_Main_group_sub();
        }

        public void Save()
        {
            new AdminDataService().SaveIDV_Chetana_sub_group(this._MAIN_Code, this._GR_HEAD, this._SR_ORDER, this._SCHEDULE, this._TYPE, this._CONTROL, this._AutoId);
        }

        public int MAIN_Code
        {
            get
            {
                return this._MAIN_Code;
            }
            set
            {
                this._MAIN_Code = value;
            }
        }

        public int SUB_GR
        {
            get
            {
                return this._SUB_GR;
            }
            set
            {
                this._SUB_GR = value;
            }
        }

        public int GROUP
        {
            get
            {
                return this._GROUP;
            }
            set
            {
                this._GROUP = value;
            }
        }

        public string GR_HEAD
        {
            get
            {
                return this._GR_HEAD;
            }
            set
            {
                this._GR_HEAD = value;
            }
        }

        public int SR_ORDER
        {
            get
            {
                return this._SR_ORDER;
            }
            set
            {
                this._SR_ORDER = value;
            }
        }

        public string SCHEDULE
        {
            get
            {
                return this._SCHEDULE;
            }
            set
            {
                this._SCHEDULE = value;
            }
        }

        public string TYPE
        {
            get
            {
                return this._TYPE;
            }
            set
            {
                this._TYPE = value;
            }
        }

        public string CONTROL
        {
            get
            {
                return this._CONTROL;
            }
            set
            {
                this._CONTROL = value;
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

