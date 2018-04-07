namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class CMS
    {
        private int _Status_ID;
        private string _Status_Name;
        private int _SeverityID;
        private string _Severity_Name;
        private int _ITM_ID;
        private string _ITM_Name;
        private string _EmailFrom;
        private string _EmailSub;
        private string _EmailBody;
        private string _EmailSign;
        private bool _IsDefault;
        private bool _IsActive;
        private bool _IsDeleted;
        private string _CreatedBy;
        private string _UpdatedBy;
        private string _TktNumber;

        public static bool GetCMSCodeValidation(string Group, string code)
        {
            DataTable table = new DataTable();
            table = new AdminDataService().GetCMSCodeValidation(Group, code).Tables[0];
            return (table.Rows.Count > 0);
        }

        public static DataSet GetSeverityMaster(string flag)
        {
            return new AdminDataService().GetSeverityMaster(flag);
        }

        public static DataSet GetStatus()
        {
            return new AdminDataService_DC().BindStatus();
        }

        public static DataSet GetStatusMaster(string flag)
        {
            return new AdminDataService().GetStatusMaster(flag);
        }

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

        public static DataSet GetTypeMaster(string flag)
        {
            return new AdminDataService().GetTypeMaster(flag);
        }

        public static DataSet Idv_Chetana_CMS_Check()
        {
            return new AdminDataService().Idv_Chetana_CMS_Check();
        }

        public static DataSet Idv_Chetana_CMS_TKTESCALATE(string Flag)
        {
            return new AdminDataService().Idv_Chetana_CMS_TKTESCALATE(Flag);
        }

        public static DataSet Idv_Chetana_Rep_CallReport(string FromDate, string ToDate, string TicketNoFrom, string TicketNoTo, string Status, int CustID, string Action)
        {
            return new AdminDataService().Idv_Chetana_Rep_CallReport(FromDate, ToDate, TicketNoFrom, TicketNoTo, Status, CustID, Action);
        }

        public void Save_CMS_Email()
        {
            new AdminDataService().Save_CMS_Email(this._TktNumber, this._CreatedBy, this._IsActive);
        }

        public void SaveSeverityMaster()
        {
            new AdminDataService().SaveSeverityMaster(this._SeverityID, this._Severity_Name, this._IsDefault, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public void SaveStatusMaster()
        {
            new AdminDataService().SaveStatusMaster(this._Status_ID, this._Status_Name, this._IsDefault, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public void SaveTypeMaster()
        {
            new AdminDataService().SaveTypeMaster(this._ITM_ID, this._ITM_Name, this._EmailFrom, this._EmailSub, this._EmailBody, this._EmailSign, this._IsDefault, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public int Status_ID
        {
            get
            {
                return this._Status_ID;
            }
            set
            {
                this._Status_ID = value;
            }
        }

        public string Status_Name
        {
            get
            {
                return this._Status_Name;
            }
            set
            {
                this._Status_Name = value;
            }
        }

        public int SeverityID
        {
            get
            {
                return this._SeverityID;
            }
            set
            {
                this._SeverityID = value;
            }
        }

        public string Severity_Name
        {
            get
            {
                return this._Severity_Name;
            }
            set
            {
                this._Severity_Name = value;
            }
        }

        public int ITM_ID
        {
            get
            {
                return this._ITM_ID;
            }
            set
            {
                this._ITM_ID = value;
            }
        }

        public string ITM_Name
        {
            get
            {
                return this._ITM_Name;
            }
            set
            {
                this._ITM_Name = value;
            }
        }

        public string EmailFrom
        {
            get
            {
                return this._EmailFrom;
            }
            set
            {
                this._EmailFrom = value;
            }
        }

        public string EmailSub
        {
            get
            {
                return this._EmailSub;
            }
            set
            {
                this._EmailSub = value;
            }
        }

        public string EmailBody
        {
            get
            {
                return this._EmailBody;
            }
            set
            {
                this._EmailBody = value;
            }
        }

        public string EmailSign
        {
            get
            {
                return this._EmailSign;
            }
            set
            {
                this._EmailSign = value;
            }
        }

        public bool IsDefault
        {
            get
            {
                return this._IsDefault;
            }
            set
            {
                this._IsDefault = value;
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

        public string TktNumber
        {
            get
            {
                return this._TktNumber;
            }
            set
            {
                this._TktNumber = value;
            }
        }
    }
}

