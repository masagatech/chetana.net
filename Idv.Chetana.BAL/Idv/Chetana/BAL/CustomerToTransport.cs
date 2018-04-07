namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class CustomerToTransport
    {
        private int _CustTransportID = Constants.NullInt;
        private int _TransportID = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private string _CustCode = Constants.NullString;

        public static DataSet Get_CustomerandTransporterValueAD(string Custcode)
        {
            return new AdminDataService().Get_CustomerandTransporterValueAD(Custcode);
        }

        public static DataTable GetCustomerandTransporter1()
        {
            DataSet customerandTransporter = new DataSet();
            customerandTransporter = new AdminDataService().GetCustomerandTransporter();
            DataTable table = new DataTable();
            return customerandTransporter.Tables[0];
        }

        public bool isDelete(string Flag, string Code)
        {
            bool flag = false;
            DataTable table = new DataTable();
            table = new AdminDataService().Idv_check_Customer_for_delete(Flag, Code).Tables[0];
            if (Convert.ToInt32(table.Rows[0][0].ToString()) <= 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return false;
        }

        public void Save()
        {
            new AdminDataService().SaveTransporter(this._CustTransportID, this._CustCode, this._TransportID, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public int CustTransportID
        {
            get
            {
                return this._CustTransportID;
            }
            set
            {
                this._CustTransportID = value;
            }
        }

        public int TransportID
        {
            get
            {
                return this._TransportID;
            }
            set
            {
                this._TransportID = value;
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

        public string CustCode
        {
            get
            {
                return this._CustCode;
            }
            set
            {
                this._CustCode = value;
            }
        }
    }
}

