using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Idv.Chetana.Common;
using Idv.Chetana.DAL;

namespace Other_Z
{
    public class InquiryDAL : DataServiceBase
    {
        //private string ConnString = ConfigurationManager.ConnectionStrings["idvConString"].ConnectionString;

        //public int SaveRecord(string EnqType, string InqSeverity, string EnqStatus, DateTime EnqDate, string EnqRemarks, string EnqActionOn, string CustID)
        //{
        //    try
        //    {
        //        string str = "Insert";
        //        SqlConnection connection = new SqlConnection(this.ConnString);
        //        string cmdText = "Sp_InsertEnquiry";
        //        SqlCommand command = new SqlCommand(cmdText, connection);
        //        connection.Open();
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(new SqlParameter("@EnqType", EnqType));
        //        command.Parameters.Add(new SqlParameter("@EnqDate", EnqDate));
        //        command.Parameters.Add(new SqlParameter("@Severity", InqSeverity));
        //        command.Parameters.Add(new SqlParameter("@Status", EnqStatus));
        //        command.Parameters.Add(new SqlParameter("@Remarks", EnqRemarks));
        //        command.Parameters.Add(new SqlParameter("@ActionOnEmp_id", EnqActionOn));
        //        command.Parameters.Add(new SqlParameter("@CustID", CustID));
        //        command.Parameters.Add(new SqlParameter("@Action", str));
        //        command.ExecuteNonQuery();
        //        connection.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    return 0;
        //}

        public void SaveRecord(string EnqType, string InqSeverity, string EnqStatus, DateTime EnqDate, string EnqRemarks, string EnqActionOn, string CustID)
        {
            try
            {
                string str = "Insert";
                //SqlConnection connection = new SqlConnection(this.ConnString);
                //string cmdText = "Sp_InsertEnquiry";
                //SqlCommand command = new SqlCommand(cmdText, connection);
                //connection.Open();
                //command.CommandType = CommandType.StoredProcedure;
                ExecuteNonQuery("Sp_InsertEnquiry",
                CreateParameter("@EnqType",SqlDbType.VarChar,EnqType),
                CreateParameter("@EnqDate",SqlDbType.DateTime,EnqDate),
                CreateParameter("@Severity",SqlDbType.VarChar, InqSeverity),
                CreateParameter("@Status",SqlDbType.VarChar,EnqStatus),
                CreateParameter("@Remarks",SqlDbType.VarChar,EnqRemarks),
                CreateParameter("@ActionOnEmp_id",SqlDbType.VarChar,EnqActionOn),
                CreateParameter("@CustID",SqlDbType.VarChar,CustID),
                CreateParameter("@Action",SqlDbType.VarChar, str));
                //command.ExecuteNonQuery();
                //connection.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        //public int UpdateRecord(string TKDID, string InqSeverity, string EnqStatus, DateTime EnqDate, string EnqRemarks, string EnqType)
        //{
        //    try
        //    {
        //        SqlConnection connection = new SqlConnection(this.ConnString);
        //        string cmdText = "Sp_InquiryUpdate";
        //        SqlCommand command = new SqlCommand(cmdText, connection);
        //        connection.Open();
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(new SqlParameter("@TKTID", TKDID));
        //        command.Parameters.Add(new SqlParameter("@EnqType", EnqType));
        //        command.Parameters.Add(new SqlParameter("@EnqDate", EnqDate));
        //        command.Parameters.Add(new SqlParameter("@Severity", InqSeverity));
        //        command.Parameters.Add(new SqlParameter("@Status", EnqStatus));
        //        command.Parameters.Add(new SqlParameter("@Remarks", EnqRemarks));
        //        command.ExecuteNonQuery();
        //        connection.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    return 0;
        //}

        public void UpdateRecord(string TKDID, string empname,string InqSeverity, string EnqStatus, DateTime EnqDate, string EnqRemarks, string EnqType)
        {
            try
            {
                //SqlConnection connection = new SqlConnection(this.ConnString);
                //string cmdText = "Sp_InquiryUpdate";
                //SqlCommand command = new SqlCommand(cmdText, connection);
                //connection.Open();
                //command.CommandType = CommandType.StoredProcedure;
                ExecuteNonQuery("Sp_InquiryUpdate",
                CreateParameter("@empname", SqlDbType.VarChar, empname),
                CreateParameter("@Remarks", SqlDbType.VarChar, EnqRemarks),
                CreateParameter("@Status", SqlDbType.VarChar, EnqStatus),
                CreateParameter("@Severity", SqlDbType.VarChar, InqSeverity),
                CreateParameter("@EnqType", SqlDbType.VarChar, EnqType),
                CreateParameter("@TKTID", SqlDbType.VarChar, TKDID));
                
                
                
                
                
                //command.ExecuteNonQuery();
                //connection.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

