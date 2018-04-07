namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;

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
            this.InqDal.UpdateRecord(tKTID, severity, status, enqDate, remarks, enqType);
            return 0;
        }
    }
}

