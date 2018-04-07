namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class CourierDetails
    {
        private float _SCMasterAutoId = Constants.NullFloat;
        private float _DocumentNo = Constants.NullFloat;
        private float _InvoiceNo = Constants.NullFloat;
        private int _SCD = Constants.NullInt;
        private int _POD = Constants.NullInt;
        private int _GeneralCourierID = Constants.NullInt;
        private decimal _Weight = Constants.NullDecimal;
        private DateTime _courierdate = Constants.NullDateTime;
        private bool _IsActive = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpDateBy = Constants.NullString;

        public void DeletePOD(float SCMasterAutoId, string flag, bool IsActive, string UpDateBy, int GeneralCourierID, int FY)
        {
            new AdminDataService_DC().DeletePOD(SCMasterAutoId, flag, IsActive, UpDateBy, GeneralCourierID, FY);
        }

        public void DeleteSendcourier(float SCMasterAutoId, bool IsActive, string UpDateBy, int FY)
        {
            new AdminDataService_DC().DeleteSendcourier(SCMasterAutoId, IsActive, UpDateBy, FY);
        }

        public static DataSet Get_CourierDetails(float DocNo, string flag, int FY)
        {
            return new AdminDataService_DC().Get_CourierDetails(DocNo, flag, FY);
        }

        public static DataSet Get_CourierDetailsCheck(string DocNo, string flag, int FY)
        {
            return new AdminDataService_DC().Get_CourierDetailsCheck(DocNo, flag, FY);
        }

        public static DataSet Get_CourierDetailsCheckSave(string DocNo, string flag, int CourierID, int BranchID, int FY)
        {
            return new AdminDataService_DC().Get_CourierDetailsCheckSave(DocNo, flag, CourierID, BranchID, FY);
        }

        public static DataSet Get_CourierDetailsGeneral(string DocNo, string flag, int FY)
        {
            return new AdminDataService_DC().Get_CourierDetailsGeneral(DocNo, flag, FY);
        }

        public static DataSet GetCourier(string flag)
        {
            return new AdminDataService_DC().GetCourier(flag);
        }

        public static DataSet GetCourierBranch(int DocID, string flag)
        {
            return new AdminDataService_DC().GetCourierBranch(DocID, flag);
        }

        public static DataSet GetCourierValidation(string Group, string code)
        {
            return new AdminDataService_DC().GetCourierValidation(Group, code);
        }

        public void Save(string DocNo, string flag, int FY, int CourierID, int BranchID, string BranchAdd, string Department, string Address, string Remark1, string CreatedBy, string Weight, DateTime Courierdate, out int _SCD)
        {
            new AdminDataService_DC().SaveCourierDetails(DocNo, flag, FY, CourierID, BranchID, BranchAdd, Department, Address, Remark1, CreatedBy, Weight, Courierdate, out _SCD);
        }

        public void Savecourier(string DocNo, string flag, int FY, int CourierID, int BranchID, string Address, string CreatedBy, out int _SCD)
        {
            new AdminDataService_DC().SaveCourierDetail(DocNo, flag, FY, CourierID, BranchID, Address, CreatedBy, out _SCD);
        }

        public void SaveDispatchEmailDetails(int DocNo, string flag, int FY, string CreatedBy, out int _SCD)
        {
            new AdminDataService_DC().SaveDispatchEmailDetails(DocNo, flag, FY, CreatedBy, out _SCD);
        }

        public static DataSet SendCourierEmail(float DocNo, string flag1, string flag2, int FY)
        {
            return new AdminDataService_DC().SendCourierEmail(DocNo, flag1, flag2, FY);
        }

        public static DataSet SendCourierEmail(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return new AdminDataService_DC().SendCourierEmail(SCMasterAutoId, DocumentNo, InvoiceNo, flag1, flag2, FY, FromID, PWD, CreatedBy);
        }

        public static DataSet SendCourierPrint(float DocNo, string flag, int FY)
        {
            return new AdminDataService_DC().SendCourierPrint(DocNo, flag, FY);
        }

        public static DataSet SendCourierPrintGeneral(float DocNo, string flag, int FY)
        {
            return new AdminDataService_DC().SendCourierPrintGeneral(DocNo, flag, FY);
        }

        public static DataSet SendDispatchEmail(float SCMasterAutoId, float DocumentNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return new AdminDataService_DC().SendDispatchEmail(SCMasterAutoId, DocumentNo, flag1, flag2, FY, FromID, PWD, CreatedBy);
        }

        public static DataSet UpdatePOD(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return new AdminDataService_DC().UpdatePOD(DocNo, FromDate, ToDate, Branch, CourierCompany, flag, FY);
        }

        public void UpdatePODNo(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag, int No, int FY)
        {
            new AdminDataService_DC().UpdatePODNo(SCMasterAutoId, DocumentNo, InvoiceNo, flag, No, FY);
        }

        public static DataSet ViewCourier(float DocNo, string flag, int FY)
        {
            return new AdminDataService_DC().ViewCourier(DocNo, flag, FY);
        }

        public static DataSet ViewCourierDate(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return new AdminDataService_DC().ViewCourierDate(DocNo, FromDate, ToDate, Branch, CourierCompany, flag, FY);
        }

        public DateTime Courierdate
        {
            get
            {
                return this._courierdate;
            }
            set
            {
                this._courierdate = value;
            }
        }

        public decimal Weight
        {
            get
            {
                return this._Weight;
            }
            set
            {
                this._Weight = value;
            }
        }

        public int GeneralCourierID
        {
            get
            {
                return this._GeneralCourierID;
            }
            set
            {
                this._GeneralCourierID = value;
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

        public int POD
        {
            get
            {
                return this._GeneralCourierID;
            }
            set
            {
                this._GeneralCourierID = value;
            }
        }

        public int SCD
        {
            get
            {
                return this._SCD;
            }
            set
            {
                this._SCD = value;
            }
        }

        public float SCMasterAutoId
        {
            get
            {
                return this._SCMasterAutoId;
            }
            set
            {
                this._SCMasterAutoId = value;
            }
        }

        public float DocumentNo
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

        public float InvoiceNo
        {
            get
            {
                return this._InvoiceNo;
            }
            set
            {
                this._InvoiceNo = value;
            }
        }

        public string UpDateBy
        {
            get
            {
                return this._UpDateBy;
            }
            set
            {
                this._UpDateBy = value;
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
    }
}

