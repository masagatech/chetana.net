namespace Idv.Chetana.DAL
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class InquiryDAL
    {
        private string ConnString = ConfigurationManager.ConnectionStrings["idvConString"].ConnectionString;

        public int SaveRecord(string EnqType, string InqSeverity, string EnqStatus, DateTime EnqDate, string EnqRemarks, string EnqActionOn, string CustID)
        {
            try
            {
                string str = "Insert";
                SqlConnection connection = new SqlConnection(this.ConnString);
                string cmdText = "Sp_InsertEnquiry";
                SqlCommand command = new SqlCommand(cmdText, connection);
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EnqType", EnqType));
                command.Parameters.Add(new SqlParameter("@EnqDate", EnqDate));
                command.Parameters.Add(new SqlParameter("@Severity", InqSeverity));
                command.Parameters.Add(new SqlParameter("@Status", EnqStatus));
                command.Parameters.Add(new SqlParameter("@Remarks", EnqRemarks));
                command.Parameters.Add(new SqlParameter("@ActionOnEmp_id", EnqActionOn));
                command.Parameters.Add(new SqlParameter("@CustID", CustID));
                command.Parameters.Add(new SqlParameter("@Action", str));
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return 0;
        }

        public int UpdateRecord(string TKDID, string InqSeverity, string EnqStatus, DateTime EnqDate, string EnqRemarks, string EnqType)
        {
            try
            {
                SqlConnection connection = new SqlConnection(this.ConnString);
                string cmdText = "Sp_InquiryUpdate";
                SqlCommand command = new SqlCommand(cmdText, connection);
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@TKTID", TKDID));
                command.Parameters.Add(new SqlParameter("@EnqType", EnqType));
                command.Parameters.Add(new SqlParameter("@EnqDate", EnqDate));
                command.Parameters.Add(new SqlParameter("@Severity", InqSeverity));
                command.Parameters.Add(new SqlParameter("@Status", EnqStatus));
                command.Parameters.Add(new SqlParameter("@Remarks", EnqRemarks));
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return 0;
        }
    }
}

