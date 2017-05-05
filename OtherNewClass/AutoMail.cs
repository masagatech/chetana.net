using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Idv.Chetana.DAL;

namespace OtherNewClass
{
    public class AutoMail : DataServiceBase
    {
        public static DataSet AutoMailParams(string Remark1, string Remark2, string Remark3, string Remark4, string Remark5, 
            string Remark6, string Remark7, string Remark8, string Remark9)
        {
        
        return new AutoMail().PreAutoMailParams(Remark1, Remark2, Remark3, Remark4, Remark5, 
            Remark6, Remark7, Remark8, Remark9);
        }

        public DataSet PreAutoMailParams(string Remark1, string Remark2, string Remark3, string Remark4, string Remark5, 
            string Remark6, string Remark7, string Remark8, string Remark9)
        {
            return ExecuteDataSet("Idv_Chetana_Get_AutoMailParams",
                CreateParameter("@Remark1", SqlDbType.VarChar, Remark1),
                CreateParameter("@Remark2", SqlDbType.VarChar, Remark2),
                CreateParameter("@Remark3", SqlDbType.VarChar, Remark3),
                CreateParameter("@Remark4", SqlDbType.VarChar, Remark4),
                CreateParameter("@Remark5", SqlDbType.VarChar, Remark5),
                CreateParameter("@Remark6", SqlDbType.VarChar, Remark6),
                CreateParameter("@Remark7", SqlDbType.VarChar, Remark7),
                CreateParameter("@Remark8", SqlDbType.VarChar, Remark8),
                CreateParameter("@Remark9", SqlDbType.VarChar, Remark9));
        }


    }

    public class MailDetails
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Subject { get; set; }
        public string Attachment { get; set; }
        public string Desc { get; set; }
    }

    public class MailSetting
    {
        public string CC{ get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
