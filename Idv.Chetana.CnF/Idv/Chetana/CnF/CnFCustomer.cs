namespace Idv.Chetana.CnF
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CnFCustomer : DataServiceBase
    {
        private int _CnFID = Constants.NullInt;
        private string _CnFCode = Constants.NullString;
        private string _CnFName = Constants.NullString;
        private string _Address = Constants.NullString;
        private string _ContactPerson = Constants.NullString;
        private string _Mobile = Constants.NullString;
        private string _Phone1 = Constants.NullString;
        private string _Phone2 = Constants.NullString;
        private string _EmailID = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private string _SuperZoneId = Constants.NullString;
        private int _Fyfrom = Constants.NullInt;
        private string _Remark1 = Constants.NullString;
        private string _Remark2 = Constants.NullString;
        private string _Remark3 = Constants.NullString;
        private string _Remark4 = Constants.NullString;
        private string _Remark5 = Constants.NullString;

        public DataSet GetCnF_Master()
        {
            return base.ExecuteDataSet("c_idv_Chetana_GetCnF_Master", new IDataParameter[] { base.CreateParameter("@Id", SqlDbType.Int, this._CnFID), base.CreateParameter("@Flag1", SqlDbType.NVarChar, this._Remark1), base.CreateParameter("@Flag2", SqlDbType.NVarChar, this._Remark2), base.CreateParameter("@Flag3", SqlDbType.NVarChar, this._Remark3) });
        }

        public void Save()
        {
            this.SaveCnFrMaster();
        }

        public void SaveCnFrMaster()
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "c_idv_Chetana_CnF_Master", new IDataParameter[] { base.CreateParameter("@Id", SqlDbType.Int, this._CnFID), base.CreateParameter("@Code", SqlDbType.NVarChar, this._CnFCode), base.CreateParameter("@CnFName", SqlDbType.NVarChar, this._CnFName), base.CreateParameter("@Address", SqlDbType.NVarChar, this._Address), base.CreateParameter("@ContactPersonName", SqlDbType.NVarChar, this._ContactPerson), base.CreateParameter("@Email", SqlDbType.NVarChar, this._EmailID), base.CreateParameter("@Mobile", SqlDbType.NVarChar, this._Mobile), base.CreateParameter("@SuperZoneID", SqlDbType.NVarChar, this._SuperZoneId), base.CreateParameter("@Remark1", SqlDbType.NVarChar, this._Remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, this._Remark2), base.CreateParameter("@Remark3", SqlDbType.NVarChar, this._Remark3), base.CreateParameter("@Remark4", SqlDbType.NVarChar, this._Remark4), base.CreateParameter("@Remark5", SqlDbType.NVarChar, this._Remark5), base.CreateParameter("@IsActive", SqlDbType.Bit, this.IsActive), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, this.CreatedBy) });
            command.Dispose();
        }

        public int CnFID
        {
            get
            {
                return this._CnFID;
            }
            set
            {
                this._CnFID = value;
            }
        }

        public string CnFCode
        {
            get
            {
                return this._CnFCode;
            }
            set
            {
                this._CnFCode = value;
            }
        }

        public string CnFName
        {
            get
            {
                return this._CnFName;
            }
            set
            {
                this._CnFName = value;
            }
        }

        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this._Address = value;
            }
        }

        public string ContactPerson
        {
            get
            {
                return this._ContactPerson;
            }
            set
            {
                this._ContactPerson = value;
            }
        }

        public string Mobile
        {
            get
            {
                return this._Mobile;
            }
            set
            {
                this._Mobile = value;
            }
        }

        public string Phone1
        {
            get
            {
                return this._Phone1;
            }
            set
            {
                this._Phone1 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return this._Phone2;
            }
            set
            {
                this._Phone2 = value;
            }
        }

        public string EmailID
        {
            get
            {
                return this._EmailID;
            }
            set
            {
                this._EmailID = value;
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

        public string SuperZoneId
        {
            get
            {
                return this._SuperZoneId;
            }
            set
            {
                this._SuperZoneId = value;
            }
        }

        public string Remark1
        {
            get
            {
                return this._Remark1;
            }
            set
            {
                this._Remark1 = value;
            }
        }

        public string Remark2
        {
            get
            {
                return this._Remark2;
            }
            set
            {
                this._Remark2 = value;
            }
        }

        public string Remark3
        {
            get
            {
                return this._Remark3;
            }
            set
            {
                this._Remark3 = value;
            }
        }

        public string Remark4
        {
            get
            {
                return this._Remark4;
            }
            set
            {
                this._Remark4 = value;
            }
        }

        public string Remark5
        {
            get
            {
                return this._Remark5;
            }
            set
            {
                this._Remark5 = value;
            }
        }

        public int Fyfrom
        {
            get
            {
                return this._Fyfrom;
            }
            set
            {
                this._Fyfrom = value;
            }
        }
    }
}

