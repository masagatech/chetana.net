using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Idv.Chetana.DAL;
using System.Data;
using Idv.Chetana.Common;
using System.Data.SqlClient;

namespace Other_Z
{
    public class DCMaster_cs : DataServiceBase
    {
        public DataSet GetDCOrderNoAuthentication(string TokenNo, int FY, string Flag)
        {
            return ExecuteDataSet("Idv_Chetana_Get_DCOrderNo_Authentication",
                  CreateParameter("@TokenNo", SqlDbType.VarChar, TokenNo),
                  CreateParameter("@FY", SqlDbType.Int, FY),
                  CreateParameter("@Flag", SqlDbType.VarChar, Flag));
        }
        public class DCMasterProp
        {

            public string _BankCode { get; set; }
            public string _BankName { get; set; }
            public DateTime _ChallanDate { get; set; }
            public string _ChallanNo { get; set; }
            public string _ChetanaCompanyName { get; set; }
            public string _CreatedBy { get; set; }
            public DateTime _CreatedOn { get; set; }
            public string _CustCode { get; set; }
            public int _DocNewNo { get; set; }
            public int _DocNo { get; set; }
            public DateTime _DocumentDate { get; set; }
            public int _DocumentNo { get; set; }
            public int _FinancialYearFrom { get; set; }
            public int _FinancialYearTo { get; set; }
            public bool _IsActive { get; set; }
            public bool _IsApprove { get; set; }
            public bool _IsApproved { get; set; }
            public bool _IsCanceled { get; set; }
            public bool _IsConfirm { get; set; }
            public bool _IsDeleted { get; set; }
            public bool _IsPartialConfirmed { get; set; }
            public DateTime _OrderDate { get; set; }
            public string _OrderNo { get; set; }
            public string _PIncharge { get; set; }
            public string _Remark { get; set; }
            public string _SalesmanCode { get; set; }
            public string _SpInstruction { get; set; }
            public string _Transporter { get; set; }
            public string _TransportID { get; set; }
            public string _UpdatedBy { get; set; }
            public DateTime _UpdatedOn { get; set; }
            public string Xmldata { get; set; }
        }

        public void SaveDCWithXml(DCMasterProp prop, out int DocNo, out int DocNewNo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_DCMasterWithXML", new IDataParameter[] {
                base.CreateParameter("@DocumentNo", SqlDbType.Int, prop._DocumentNo),
                base.CreateParameter("@DocumentDate", SqlDbType.DateTime,prop._DocumentDate),
                base.CreateParameter("@ChallanNo", SqlDbType.NVarChar, prop._ChallanNo),
                base.CreateParameter("@ChallanDate", SqlDbType.DateTime, prop._ChallanDate),
                base.CreateParameter("@OrderNo", SqlDbType.NVarChar, prop._OrderNo),
                base.CreateParameter("@OrderDate", SqlDbType.DateTime, prop._OrderDate),
                base.CreateParameter("@SalesmanCode", SqlDbType.NVarChar, prop._SalesmanCode),
                base.CreateParameter("@CustCode", SqlDbType.NVarChar, prop._CustCode),
                base.CreateParameter("@PIncharge", SqlDbType.NVarChar, prop._PIncharge),
                base.CreateParameter("@Transporter", SqlDbType.NVarChar, prop._Transporter),
                base.CreateParameter("@transportid", SqlDbType.NVarChar, prop._TransportID), 
                base.CreateParameter("@Bankcode", SqlDbType.NVarChar, prop._BankCode),
                base.CreateParameter("@SpInstruction", SqlDbType.NVarChar, prop._SpInstruction),
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, prop._CreatedBy),
                base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, prop._UpdatedBy),
                base.CreateParameter("@IsActive", SqlDbType.Bit, prop._IsActive), 
                base.CreateParameter("@IsDeleted", SqlDbType.Bit, prop._IsDeleted),
                base.CreateParameter("@ChetanaCompanyName", SqlDbType.NVarChar,prop._ChetanaCompanyName),
                base.CreateParameter("@xmldata", SqlDbType.Xml,prop.Xmldata),
                base.CreateParameter("@FY",SqlDbType.Int,prop._FinancialYearFrom),
                base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output),
                base.CreateParameter("@DocNewNo", SqlDbType.Int, ParameterDirection.Output),
             });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            DocNewNo = Convert.ToInt32(command.Parameters["@DocNewNo"].Value);
        }
    }
}
