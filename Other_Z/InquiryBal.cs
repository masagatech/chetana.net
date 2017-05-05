
using Idv.Chetana.DAL;
using System;

namespace Other_Z
{

    public class InquiryBal
    {
        private InquiryDAL InqDal = new InquiryDAL();

        public int SaveRecord(InquiryDetail eq)
        {
            string enqType = eq.EnqType;
            string severity = eq.Severity;
            string status = eq.Status;
            DateTime enqDate = eq.EnqDate;
            string remarks = eq.Remarks;
            string enqActionOn = eq.EnqActionOn;
            string custID = eq.CustID;
            this.InqDal.SaveRecord(enqType, severity, status, enqDate, remarks, enqActionOn, custID);
            return 0;
        }

        public int UpdateRecord(InquiryDetail eq)
        {
            string tKTID = eq.TKTID;
            string enqType = eq.EnqType;
            string severity = eq.Severity;
            string status = eq.Status;
            DateTime enqDate = eq.EnqDate;
            string remarks = eq.Remarks;
            string empname = eq.EmpName;
            this.InqDal.UpdateRecord(tKTID, empname, severity, status, enqDate, remarks, enqType);
            return 0;
        }
    }
}

