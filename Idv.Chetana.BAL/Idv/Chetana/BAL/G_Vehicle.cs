namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class G_Vehicle
    {
        private int _Veh_id = Constants.NullInt;
        private string _Veh_desc = Constants.NullString;
        private string _Veh_no = Constants.NullString;
        private string _veh_type = Constants.NullString;
        private string _I_M = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDelete = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;

        public static DataSet GetVehicle(string flag, int ID, string flag1)
        {
            return new AdminDataService_Go().getVehicle(flag, ID, flag1);
        }

        public void Save()
        {
            new AdminDataService_Go().SaveIdv_Chetana_Vehicle(this._Veh_id, this._Veh_desc, this._Veh_no, this._veh_type, this._I_M, this._IsActive, this._CreatedBy, this._UpdatedBy);
        }

        public int Veh_id
        {
            get
            {
                return this._Veh_id;
            }
            set
            {
                this._Veh_id = value;
            }
        }

        public string Veh_desc
        {
            get
            {
                return this._Veh_desc;
            }
            set
            {
                this._Veh_desc = value;
            }
        }

        public string Veh_no
        {
            get
            {
                return this._Veh_no;
            }
            set
            {
                this._Veh_no = value;
            }
        }

        public string veh_type
        {
            get
            {
                return this._veh_type;
            }
            set
            {
                this._veh_type = value;
            }
        }

        public string I_M
        {
            get
            {
                return this._I_M;
            }
            set
            {
                this._I_M = value;
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

        public bool IsDelete
        {
            get
            {
                return this._IsDelete;
            }
            set
            {
                this._IsDelete = value;
            }
        }

        public DateTime CreatedOn
        {
            get
            {
                return this._CreatedOn;
            }
            set
            {
                this._CreatedOn = value;
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

        public DateTime UpdatedOn
        {
            get
            {
                return this._UpdatedOn;
            }
            set
            {
                this._UpdatedOn = value;
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
    }
}

