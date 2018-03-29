namespace Others
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CustCategory : DataServiceBase
    {
        private int _CMID = Constants.NullInt;
        private string _CName = Constants.NullString;
        private int _CParentID = Constants.NullInt;
        private bool _CIsActive = Constants.NullBoolean;
        private bool _CIsDeleted = Constants.NullBoolean;
        private string _CCreatedBy = Constants.NullString;
        private string _CUpdatedBy = Constants.NullString;
        private string _CDMCode = Constants.NullString;

        public void CSave()
        {
            new CustCategory().SaveCustomerCategoryMaster(this._CMID, this._CName, this._CParentID, this._CIsActive, this._CIsDeleted, this._CCreatedBy, this._CUpdatedBy, this._CDMCode);
        }

        public static DataSet GetCustomerCategoryMaster(string flag)
        {
            return new CustCategory().GetCustomerCategoryMasterDAL(flag);
        }

        public DataSet GetCustomerCategoryMasterDAL(string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CustomerCategoryMaster", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public void SaveCustomerCategoryMaster(int CMID, string Name, int ParentID, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy, string CMCode)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_CustomerCategoryMaster", new IDataParameter[] { base.CreateParameter("@CMID", SqlDbType.Int, CMID), base.CreateParameter("@Name", SqlDbType.NVarChar, Name), base.CreateParameter("@ParentID", SqlDbType.Int, ParentID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@CMCode", SqlDbType.NVarChar, CMCode) });
            command.Dispose();
        }

        public int CMID
        {
            get
            {
                return this._CMID;
            }
            set
            {
                this._CMID = value;
            }
        }

        public string CName
        {
            get
            {
                return this._CName;
            }
            set
            {
                this._CName = value;
            }
        }

        public int CParentID
        {
            get
            {
                return this._CParentID;
            }
            set
            {
                this._CParentID = value;
            }
        }

        public bool CIsActive
        {
            get
            {
                return this._CIsActive;
            }
            set
            {
                this._CIsActive = value;
            }
        }

        public bool CIsDeleted
        {
            get
            {
                return this._CIsDeleted;
            }
            set
            {
                this._CIsDeleted = value;
            }
        }

        public string CCreatedBy
        {
            get
            {
                return this._CCreatedBy;
            }
            set
            {
                this._CCreatedBy = value;
            }
        }

        public string CUpdatedBy
        {
            get
            {
                return this._CUpdatedBy;
            }
            set
            {
                this._CUpdatedBy = value;
            }
        }

        public string CDMCode
        {
            get
            {
                return this._CDMCode;
            }
            set
            {
                this._CDMCode = value;
            }
        }
    }
}

