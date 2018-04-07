namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class DCDetails
    {
        private int _DCDetailID = Constants.NullInt;
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
        private bool _Cancel = Constants.NullBoolean;
        private bool _PCancel = Constants.NullBoolean;
        private int _CanceledQty = Constants.NullInt;

        public static DataTable DC_Get_DCDetails_for_MultiPrint(int InvNo, string MultiDocNo)
        {
            DataSet set = new AdminDataService_DC().DC_Get_DCDetails_for_MultiPrint(InvNo, MultiDocNo);
            DataTable table = new DataTable();
            return set.Tables[0];
        }

        public static DataTable DC_Get_InvoiceDetails_On_subdocID(decimal subDocNo)
        {
            DataSet set = new AdminDataService_DC().DC_Get_InvoiceDetails_On_subdocID(subDocNo);
            DataTable table = new DataTable();
            return set.Tables[0];
        }

        public static DataTable DC_Get_InvoiceDetails_On_subdocID(string MultiDocNo)
        {
            DataSet set = new AdminDataService_DC().DC_Get_InvoiceDetails_On_subdocID(MultiDocNo);
            DataTable table = new DataTable();
            return set.Tables[0];
        }

        public static DataTable DC_Get_InvoiceDetails_On_subdocID(decimal subDocNo, int Docno)
        {
            DataSet set = new AdminDataService_DC().DC_Get_InvoiceDetails_On_subdocID(subDocNo, Docno);
            DataTable table = new DataTable();
            return set.Tables[0];
        }

        public static DataTable DC_Get_InvoiceDetails_On_subdocID(decimal InvNo, string MultiDocNo, string CreatedBy)
        {
            DataSet set = new AdminDataService_DC().DC_Get_InvoiceDetails_On_subdocID(InvNo, MultiDocNo, CreatedBy);
            DataTable table = new DataTable();
            return set.Tables[0];
        }

        public static DataSet Get_DC_Completed_IsApproved()
        {
            return new AdminDataService_DC().Get_DC_Completed_IsApproved();
        }

        public static DataSet Get_DC_Completed_IsApproved(int FY)
        {
            return new AdminDataService_DC().Get_DC_Completed_IsApproved(FY);
        }

        public static DataSet Get_SubDocId_And_ItsRecords_By_DocNo(int DocNo, string flag)
        {
            return new AdminDataService_DC().Get_SubDocId_And_ItsRecords_By_DocNo(DocNo, flag);
        }

        public static DataSet Get_SubDocId_And_ItsRecords_By_DocNo(int DocNo, string flag, int FY)
        {
            return new AdminDataService_DC().Get_SubDocId_And_ItsRecords_By_DocNo(DocNo, flag, FY);
        }

        public static DataSet GetDCDatilsByCode(string EmpCode, string Flag)
        {
            return new AdminDataService_DC().GetDCDatilsByCode(EmpCode, Flag);
        }

        public static DataSet Idv_Get_DCDetails_By_DocNo(int DocNo, string Flag)
        {
            return new AdminDataService_DC().Idv_Get_DCDetails_By_DocNo(DocNo, Flag);
        }

        public static DataSet Idv_Get_DCDetails_By_DocNo(int DocNo, string Flag, int FY)
        {
            return new AdminDataService_DC().Idv_Get_DCDetails_By_DocNo(DocNo, Flag, FY);
        }

        public static DataTable Rep_DC_Get_Datails_OnSubdocno(int Docno)
        {
            DataSet set = new AdminDataService_DC().Rep_DC_Get_Datails_OnSubdocno(Docno);
            DataTable table = new DataTable();
            return set.Tables[0];
        }

        public void Save()
        {
            new AdminDataService_DC().SaveDCDetails(this._DCDetailID, this._DocumentNo, this._BookCode, this._BookName, this._Standard, this._Medium, this._Quantity, this._Rate, this._Amount, this._Discount, this._Publisher, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy, this._DeliveryDate);
        }

        public void UpdateDCDetails()
        {
            new AdminDataService_DC().UpdateDCDetails(this._DCDetailID, this._CanceledQty, this._Cancel, this._PCancel);
        }

        public int DCDetailID
        {
            get
            {
                return this._DCDetailID;
            }
            set
            {
                this._DCDetailID = value;
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

        public bool Cancel
        {
            get
            {
                return this._Cancel;
            }
            set
            {
                this._Cancel = value;
            }
        }

        public bool PCancel
        {
            get
            {
                return this._PCancel;
            }
            set
            {
                this._PCancel = value;
            }
        }

        public int CanceledQty
        {
            get
            {
                return this._CanceledQty;
            }
            set
            {
                this._CanceledQty = value;
            }
        }
    }
}

