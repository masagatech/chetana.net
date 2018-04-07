namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class SpecimanDetails
    {
        private int _SpecimenDetailID = Constants.NullInt;
        private int _DocumentNo = Constants.NullInt;
        private string _BookCode = Constants.NullString;
        private string _BookName = Constants.NullString;
        private string _Standard = Constants.NullString;
        private string _Medium = Constants.NullString;
        private int _Quantity = Constants.NullInt;
        private decimal _Rate = Constants.NullDecimal;
        private decimal _Amount = Constants.NullDecimal;
        private decimal _Discount = Constants.NullDecimal;
        private string _Publisher = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private decimal _subdocID = Constants.NullInt;

        public static DataSet Get_DC_Completed_IsApproved()
        {
            return new AdminDataService().Get_DC_Completed_IsApproved();
        }

        public static DataSet Get_DC_Completed_IsApproved(string flag, DateTime frmDate, DateTime toDate, int fy, string flag1)
        {
            return new AdminDataService().Get_DC_Completed_IsApproved(flag, frmDate, toDate, fy, flag1);
        }

        public static DataSet Get_QtyDetails_By_SpecimenDetailsID(int SpecimenDetailsID)
        {
            return new AdminDataService().Get_QtyDetails_By_SpecimenDetailsID(SpecimenDetailsID);
        }

        public static DataSet Get_Reports_SpecimenDashBoard(string flag, string flag1)
        {
            return new AdminDataService().Get_Reports_SpecimenDashBoard(flag, flag1);
        }

        public static DataSet Get_Specimen_NotConfirmed_Books()
        {
            return new AdminDataService().Get_Specimen_NotConfirmed_Books();
        }

        public static DataSet Get_SpecTransporterAndDetails(decimal Subdocid, string flag)
        {
            return new AdminDataService().Get_SpecTransporterAndDetails(Subdocid, flag);
        }

        public static DataSet Get_SubDocId_And_ItsRecords_By_DocNo(int DocNo, string flag)
        {
            return new AdminDataService().Get_SubDocId_And_ItsRecords_By_DocNo(DocNo, flag);
        }

        public static DataSet GetSpecimenDatilsByEmpCode(string EmpCode, string Flag)
        {
            return new AdminDataService().GetSpecimenDatilsByEmpCode(EmpCode, Flag);
        }

        public static DataSet Idv_Chetana_DC_Get_Details_By_DocNO_Report3(int DocNo)
        {
            return new AdminDataService().Idv_Chetana_DC_Get_Details_By_DocNO_Report3(DocNo);
        }

        public static DataSet Idv_Chetana_Get_SpecimenDetails_By_DocNo_Report(int DocNo)
        {
            return new AdminDataService().Idv_Chetana_Get_SpecimenDetails_By_DocNo_Report(DocNo);
        }

        public static DataSet Idv_Chetana_Get_SpecTransporterAndDetails_Report1(decimal Subdocid)
        {
            return new AdminDataService().Idv_Chetana_Get_SpecTransporterAndDetails_Report1(Subdocid);
        }

        public static DataSet Idv_Chetana_Get_SubDocId_And_ItsRecords_By_DocNo_forReport(decimal Subdocid)
        {
            return new AdminDataService().Idv_Chetana_Get_SubDocId_And_ItsRecords_By_DocNo_forReport(Subdocid);
        }

        public static DataSet Idv_Get_SpecimenDetails_By_DocNo(int DocNo, string Flag)
        {
            return new AdminDataService().Idv_Get_SpecimenDetails_By_DocNo(DocNo, Flag);
        }

        public void Save()
        {
            new AdminDataService().SaveSpecimenDetails(this._SpecimenDetailID, this._DocumentNo, this._BookCode, this._BookName, this._Standard, this._Medium, this._Quantity, this._Rate, this._Amount, this._Discount, this._Publisher, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public void UpdateSpecimenInvoice()
        {
            new AdminDataService().update_SpecimenInvoice(this._SpecimenDetailID, this._subdocID, this._DocumentNo, this._Quantity, this._Rate, this._Amount);
        }

        public decimal SubdocID
        {
            get
            {
                return this._subdocID;
            }
            set
            {
                this._subdocID = value;
            }
        }

        public int SpecimenDetailID
        {
            get
            {
                return this._SpecimenDetailID;
            }
            set
            {
                this._SpecimenDetailID = value;
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
    }
}

