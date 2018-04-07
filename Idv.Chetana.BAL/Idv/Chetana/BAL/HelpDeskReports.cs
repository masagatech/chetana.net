namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class HelpDeskReports
    {
        public static DataSet GetTicketInqByDates(InquiryDetail eq)
        {
            DateTime fromdate = eq.Fromdate;
            DateTime toDate = eq.ToDate;
            string tKTFrom = eq.TKTFrom;
            string tKTTO = eq.TKTTO;
            string customerName = eq.CustomerName;
            string enqActionOn = eq.EnqActionOn;
            string custID = eq.CustID;
            string action = eq.Action;
            string status = eq.Status;
            return new AdminDataService().AllRecordRepordTicketHistory(fromdate, toDate, tKTFrom, tKTTO, customerName, enqActionOn, custID, status, action);
        }
    }
}

