using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Idv.Chetana.Common;
using Idv.Chetana.DAL;
using System.Data;
using System.Data.SqlClient;


namespace Others
{
    public class CustCategory : DataServiceBase
    {

        #region Fields
        private int _CMID = Constants.NullInt;
        private string _CName = Constants.NullString;
        private int _CParentID = Constants.NullInt;
        private bool _CIsActive = Constants.NullBoolean;
        private bool _CIsDeleted = Constants.NullBoolean;
        private string _CCreatedBy = Constants.NullString;
        private string _CUpdatedBy = Constants.NullString;
        private string _CDMCode = Constants.NullString;
        #endregion

        #region Properties
        public int CMID
        {
            get { return _CMID; }
            set { _CMID = value; }
        }
        public string CName
        {
            get { return _CName; }
            set { _CName = value; }
        }
        public int CParentID
        {
            get { return _CParentID; }
            set { _CParentID = value; }
        }
        public bool CIsActive
        {
            get { return _CIsActive; }
            set { _CIsActive = value; }
        }

        public bool CIsDeleted
        {
            get { return _CIsDeleted; }
            set { _CIsDeleted = value; }
        }
        public string CCreatedBy
        {
            get { return _CCreatedBy; }
            set { _CCreatedBy = value; }
        }
        public string CUpdatedBy
        {
            get { return _CUpdatedBy; }
            set { _CUpdatedBy = value; }
        }

        public string CDMCode
        {
            get { return _CDMCode; }
            set { _CDMCode = value; }
        }
        #endregion

        #region CustomerCategoryMaster BAL

        #region CSave()
        public void CSave()
        {
            new CustCategory().SaveCustomerCategoryMaster(_CMID, _CName, _CParentID, _CIsActive, _CIsDeleted, _CCreatedBy, _CUpdatedBy, _CDMCode);

        }
        #endregion

        #region Get
        public static DataSet GetCustomerCategoryMaster(string flag)
        {
            return new CustCategory().GetCustomerCategoryMasterDAL(flag);
        }
        #endregion

        #endregion

        #region CustomerCategoryMaster DAL

        #region SaveCCM
        public void SaveCustomerCategoryMaster(int CMID, string Name, int ParentID, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy, string CMCode)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "Idv_Chetana_Save_CustomerCategoryMaster",
            CreateParameter("@CMID", SqlDbType.Int, CMID),
            CreateParameter("@Name", SqlDbType.NVarChar, Name),
            CreateParameter("@ParentID", SqlDbType.Int, ParentID),
            CreateParameter("@IsActive", SqlDbType.Bit, IsActive),
            CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted),
            CreateParameter("@CreatedBy", SqlDbType.NVarChar, createdBy),
            CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy),
            CreateParameter("@CMCode", SqlDbType.NVarChar, CMCode));
            cmd.Dispose();
        }
        #endregion

        #region Get
        public DataSet GetCustomerCategoryMasterDAL(string Flag)
        {
            return ExecuteDataSet("Idv_Chetana_Get_CustomerCategoryMaster",
                 CreateParameter("@Flag", SqlDbType.NVarChar, Flag));
        }
        #endregion

        #endregion



    }

}
