namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class ActualInvoiceDetails
    {
        private int _GanerateinvoiceId = Constants.NullInt;
        private int _DocumentNo = Constants.NullInt;
        private string _BookCode = Constants.NullString;
        private string _BookName = Constants.NullString;
        private int _Quantity = Constants.NullInt;
        private decimal _Rate = Constants.NullDecimal;
        private decimal _Amount = Constants.NullDecimal;
        private decimal _Discount = Constants.NullDecimal;
        private string _Publisher = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private DateTime _Updatedon = Constants.NullDateTime;
        private string _Standard = Constants.NullString;
        private string _Medium = Constants.NullString;
        private int _BookID = Constants.NullInt;
        private DateTime _DeliveryDate = Constants.NullDateTime;
        private decimal _SubDocId = Constants.NullDecimal;
        private decimal _Freight = Constants.NullDecimal;
        private decimal _Tax = Constants.NullDecimal;
        private decimal _TotalAmount = Constants.NullDecimal;
        private DateTime _InvoiceDate = Constants.NullDateTime;
        private string _LRNo = Constants.NullString;
        private string _Transporter = Constants.NullString;
        private string _flag = Constants.NullString;
        private string _Bundles = Constants.NullString;
        private string _FinancialYearFrom = Constants.NullString;
        private DateTime _LRDate = Constants.NullDateTime;
        private string _Remark1 = Constants.NullString;
        private string _Remark2 = Constants.NullString;
        private string _Remark3 = Constants.NullString;

        public void DeleteActual_InvoiceDetails()
        {
            new AdminDataService_DC().DeleteActual_InvoiceDetails(this._GanerateinvoiceId, this._IsActive, this._IsDeleted, this._DocumentNo, this._TotalAmount, this._SubDocId, this._flag);
        }

        public void DeleteActual_InvoiceDetails(int FY)
        {
            new AdminDataService_DC().DeleteActual_InvoiceDetails(this._GanerateinvoiceId, this._IsActive, this._IsDeleted, this._DocumentNo, this._TotalAmount, this._SubDocId, this._flag, this._FinancialYearFrom);
        }

        public static DataSet Get_Bank_Ledger(string Bankcode, string fromdate, string toDate)
        {
            return new AdminDataService_DC().Get_Bank_Ledger(Bankcode, fromdate, toDate);
        }

        public static DataSet Get_Bank_Ledger(string Bankcode, string FromDate, string TOdate, decimal OpenBal, decimal CloseBal, int FY)
        {
            return new AdminDataService_DC().Get_Bank_Ledger(Bankcode, FromDate, TOdate, OpenBal, CloseBal, FY);
        }

        public static DataSet Get_Invoice_OnDate(DateTime FromDate, DateTime ToDate)
        {
            return new AdminDataService_DC().Get_Invoice_OnDate(FromDate, ToDate);
        }

        public static DataSet Get_Invoice_OnDatechecklist(DateTime FromDate, DateTime ToDate)
        {
            return new AdminDataService_DC().Get_Invoice_OnDateChecklist(FromDate, ToDate);
        }

        public static DataSet GetConvertion_fromnumber(decimal number)
        {
            return new AdminDataService_DC().GetConvertion_fromnumber(number);
        }

        public static DataSet GetCustomer_OnView(int custid, string flag)
        {
            return new AdminDataService_DC().GetCustomer_OnView(custid, flag);
        }

        public static DataSet GetCustomer_OnView(int custid, string flag, int FY)
        {
            return new AdminDataService_DC().GetCustomer_OnView(custid, flag, FY);
        }

        public static DataSet Idv_Chetana_DC_Get_Details_By_DocNo_Report_allbydocno1(int DocNo, int FY)
        {
            return new AdminDataService_DC().Idv_Chetana_DC_Get_Details_By_DocNo_Report_allbydocno1(DocNo, FY);
        }

        public static DataSet Idv_Chetana_DC_Get_Details_By_DocNo_Report_allbydocno2(int DocNo, int FY)
        {
            return new AdminDataService_DC().Idv_Chetana_DC_Get_Details_By_DocNo_Report_allbydocno2(DocNo, FY);
        }

        public static DataSet Idv_Chetana_Report_Get_DC_Confiramation(DateTime FromDate, DateTime ToDate, int SuperZone, int Zone, int Fy, string Remark1, string Remark2, string Remark3)
        {
            return new AdminDataService_DC().Idv_Chetana_Report_Get_DC_Confiramation(FromDate, ToDate, SuperZone, Zone, Fy, Remark1, Remark2, Remark3);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SaveActual_InvoiceDetails()
        {
            new AdminDataService_DC().SaveActual_InvoiceDetails(this._GanerateinvoiceId, this._DocumentNo, this._SubDocId, this._BookCode, this._BookName, this._Standard, this._Medium, this._Quantity, this._Rate, this._Discount, this._Amount, this._Freight, this._Tax, this._TotalAmount, this._InvoiceDate, this._LRNo, this._Transporter, this._IsActive, this._IsDeleted, this._Bundles, this._CreatedBy);
        }

        public void SaveActual_InvoiceDetails(int FY)
        {
            new AdminDataService_DC().SaveActual_InvoiceDetails(this._GanerateinvoiceId, this._DocumentNo, this._SubDocId, this._BookCode, this._BookName, this._Standard, this._Medium, this._Quantity, this._Rate, this._Discount, this._Amount, this._Freight, this._Tax, this._TotalAmount, this._InvoiceDate, this._LRNo, this._Transporter, this._IsActive, this._IsDeleted, this._Bundles, this._CreatedBy, this._FinancialYearFrom, this._LRDate, this._Remark1, this._Remark2, this._Remark3);
        }

        public int GanerateinvoiceId
        {
            get
            {
                return this._GanerateinvoiceId;
            }
            set
            {
                this._GanerateinvoiceId = value;
            }
        }

        public int DocumentNo
        {
            get
            {
                return this._DocumentNo;
            }
            set
            {
                this._DocumentNo = value;
            }
        }

        public string BookCode
        {
            get
            {
                return this._BookCode;
            }
            set
            {
                this._BookCode = value;
            }
        }

        public string BookName
        {
            get
            {
                return this._BookName;
            }
            set
            {
                this._BookName = value;
            }
        }

        public int Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this._Quantity = value;
            }
        }

        public decimal Rate
        {
            get
            {
                return this._Rate;
            }
            set
            {
                this._Rate = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                this._Amount = value;
            }
        }

        public decimal Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this._Discount = value;
            }
        }

        public string Publisher
        {
            get
            {
                return this._Publisher;
            }
            set
            {
                this._Publisher = value;
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

        public DateTime CreatedOn
        {
            get
            {
                return this._CreatedOn;
            }
            set
            {
                this._CreatedOn = value;
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

        public DateTime Updatedon
        {
            get
            {
                return this._Updatedon;
            }
            set
            {
                this._Updatedon = value;
            }
        }

        public string Standard
        {
            get
            {
                return this._Standard;
            }
            set
            {
                this._Standard = value;
            }
        }

        public string Medium
        {
            get
            {
                return this._Medium;
            }
            set
            {
                this._Medium = value;
            }
        }

        public int BookID
        {
            get
            {
                return this._BookID;
            }
            set
            {
                this._BookID = value;
            }
        }

        public DateTime DeliveryDate
        {
            get
            {
                return this._DeliveryDate;
            }
            set
            {
                this._DeliveryDate = value;
            }
        }

        public decimal SubDocId
        {
            get
            {
                return this._SubDocId;
            }
            set
            {
                this._SubDocId = value;
            }
        }

        public decimal Freight
        {
            get
            {
                return this._Freight;
            }
            set
            {
                this._Freight = value;
            }
        }

        public decimal Tax
        {
            get
            {
                return this._Tax;
            }
            set
            {
                this._Tax = value;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return this._TotalAmount;
            }
            set
            {
                this._TotalAmount = value;
            }
        }

        public DateTime InvoiceDate
        {
            get
            {
                return this._InvoiceDate;
            }
            set
            {
                this._InvoiceDate = value;
            }
        }

        public string LRNo
        {
            get
            {
                return this._LRNo;
            }
            set
            {
                this._LRNo = value;
            }
        }

        public string Transporter
        {
            get
            {
                return this._Transporter;
            }
            set
            {
                this._Transporter = value;
            }
        }

        public string flag
        {
            get
            {
                return this._flag;
            }
            set
            {
                this._flag = value;
            }
        }

        public string Bundles
        {
            get
            {
                return this._Bundles;
            }
            set
            {
                this._Bundles = value;
            }
        }

        public string FinancialYearFrom
        {
            get
            {
                return this._FinancialYearFrom;
            }
            set
            {
                this._FinancialYearFrom = value;
            }
        }

        public DateTime LRDate
        {
            get
            {
                return this._LRDate;
            }
            set
            {
                this._LRDate = value;
            }
        }

        public string Remark1
        {
            get
            {
                return this._Remark1;
            }
            set
            {
                this._Remark1 = value;
            }
        }

        public string Remark2
        {
            get
            {
                return this._Remark2;
            }
            set
            {
                this._Remark2 = value;
            }
        }

        public string Remark3
        {
            get
            {
                return this._Remark3;
            }
            set
            {
                this._Remark3 = value;
            }
        }
    }
}

