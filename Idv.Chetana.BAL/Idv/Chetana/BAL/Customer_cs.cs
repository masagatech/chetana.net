namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class Customer_cs
    {
        private int _CustID = Constants.NullInt;
        private string _CustCode = Constants.NullString;
        private string _ShortForm = Constants.NullString;
        private string _FamilyCode = Constants.NullString;
        private string _AreaCode = Constants.NullString;
        private string _Address = Constants.NullString;
        private int _City = Constants.NullInt;
        private string _Zip = Constants.NullString;
        private string _Phone1 = Constants.NullString;
        private string _Phone2 = Constants.NullString;
        private string _EmailID = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private string _CustName = Constants.NullString;
        private int _AreaID = Constants.NullInt;
        private string _CUSTOMERTYPE = Constants.NullString;
        private int _SuperZoneID = Constants.NullInt;
        private int _ZoneID = Constants.NullInt;
        private int _AreaZoneID = Constants.NullInt;
        private int _DMID = Constants.NullInt;
        private int _CID = Constants.NullInt;
        private int _CustDetailID = Constants.NullInt;
        private string _CreditDays = Constants.NullString;
        private int _CreditLimit = Constants.NullInt;
        private bool _BlackList = Constants.NullBoolean;
        private bool _IsDeleted1 = Constants.NullBoolean;
        private string _PrincipalName = Constants.NullString;
        private string _PrincipalMobile = Constants.NullString;
        private string _PrincipalDOB = Constants.NullString;
        private string _KeyPersonName = Constants.NullString;
        private string _KeyPersonMobile = Constants.NullString;
        private string _KeyPersonDOB = Constants.NullString;
        private string _AdditinalDis = Constants.NullString;
        private string _VIPRemark = Constants.NullString;
        private int _SectionID = Constants.NullInt;
        private string _Medium = Constants.NullString;
        private int _CustRating = Constants.NullInt;
        private int _BoardID = Constants.NullInt;
        private decimal _Business_Potential = Constants.NullDecimal;
        private decimal _CGP = Constants.NullDecimal;
        private string _Association = Constants.NullString;
        private string _Payment_Track = Constants.NullString;
        private string _Remark1 = Constants.NullString;
        private string _Remark2 = Constants.NullString;
        private string _Remark3 = Constants.NullString;
        private string _Remark4 = Constants.NullString;
        private string _Remark5 = Constants.NullString;
        private int _Fyfrom = Constants.NullInt;
        private int _CMID = Constants.NullInt;
        private int _CMIDsub = Constants.NullInt;
        private string _SchAdditionalDis = Constants.NullString;
        private string _TODValue1 = Constants.NullString;
        private string _TODValue2 = Constants.NullString;
        private string _TODValue3 = Constants.NullString;
        private string _TODDisc1 = Constants.NullString;
        private string _TODDisc2 = Constants.NullString;
        private string _TODDisc3 = Constants.NullString;
        private string _BlackListDate = Constants.NullString;
        private string _BlackListRemark = Constants.NullString;

        public static DataTable Get_CustList()
        {
            DataSet set = new DataSet();
            set = new AdminDataService().Get_CustList();
            DataTable table = new DataTable();
            return set.Tables[0];
        }

        public static DataTable Get_CustList(string Flag, string ID)
        {
            return new AdminDataService().Get_CustList(Flag, ID).Tables[0];
        }

        public static DataTable Get_CustList(string Flag, string ID, string ZoneID)
        {
            return new AdminDataService().Get_CustList(Flag, ID, ZoneID).Tables[0];
        }

        public static DataTable Get_CustListReport(string Flag, string CustCateID, string ID, string ZoneID)
        {
            return new AdminDataService().Get_CustListReport(Flag, CustCateID, ID, ZoneID).Tables[0];
        }

        public static DataSet Get_DestinationMaster(string Flag)
        {
            return new AdminDataService().Get_DestinationMaster(Flag);
        }

        public static DataSet Get_TStyle_Report(string custCode, int zoneid, int FY, string Flag, DateTime FromDate, DateTime ToDate)
        {
            return new AdminDataService().Get_TStyle_Report(custCode, zoneid, FY, Flag, FromDate, ToDate);
        }

        public static DataTable GetAlphabets()
        {
            return new AdminDataService().GetAlphabets();
        }

        public static DataSet GetSchool_Names(string EmpCode)
        {
            return new AdminDataService().GetSchool_Names(EmpCode);
        }

        public static DataSet Idv_Chetana_Customer_BlackList(int CustID, string FromDate, string ToDate, decimal fromAmt, int FY, int Superzone, int Zone)
        {
            return new AdminDataService().Idv_Chetana_Customer_BlackList(CustID, FromDate, ToDate, fromAmt, FY, Superzone, Zone);
        }

        public static DataSet Idv_Chetana_Rep_BookSeller(int CustID, int FY, int Superzone, int Zone)
        {
            return new AdminDataService().Idv_Chetana_Rep_BookSeller(CustID, FY, Superzone, Zone);
        }

        public static DataSet Idv_Chetana_Rep_Customer_AdditionalCommission(int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return new AdminDataService().Idv_Chetana_Rep_Customer_AdditionalCommission(Superzone, Zone, CustID, CustCateID, FY);
        }

        public static DataSet Idv_Chetana_Rep_Customer_AdditionalCommissionamount(int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return new AdminDataService().Idv_Chetana_Rep_Customer_AdditionalCommissionatreport(Superzone, Zone, CustID, CustCateID, FY);
        }

        public static DataSet Idv_Chetana_Rep_Customer_AdditionalCommissionamountreport(int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return new AdminDataService().Idv_Chetana_Rep_Customer_AdditionalCommissionatreport(Superzone, Zone, CustID, CustCateID, FY);
        }

        public static DataSet Idv_Chetana_Rep_Customer_AdditionalCommissionCal(int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return new AdminDataService().Idv_Chetana_Rep_Customer_AdditionalCommissionCal(Superzone, Zone, CustID, CustCateID, FY);
        }

        public static DataSet Idv_Chetana_Rep_Customer_BlacklistedParty(string CustCateID, int CustID, int FY, int Superzone, int Zone)
        {
            return new AdminDataService().Idv_Chetana_Rep_Customer_BlacklistedParty(CustCateID, CustID, FY, Superzone, Zone);
        }

        public static DataSet Idv_Chetana_Rep_Customer_DisburseAdditionalCommission(int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return new AdminDataService().Idv_Chetana_Rep_Customer_DisburseAdditionalCommission(Superzone, Zone, CustID, CustCateID, FY);
        }

        public void Idv_Chetana_Rep_Customer_SaveDisburseAdditionalCommission(string CustCode, decimal NETBILLAMT, decimal NETCNAMT, decimal NETAMT, decimal NETADDDIS, decimal GROSSBILLAMT, decimal GROSSCNAMT, decimal GROSSNETAMT, decimal GROSSADDDIS, decimal Amount, string Details, int FY, string CreatedBy, out int DACId)
        {
            new AdminDataService().Idv_Chetana_Rep_Customer_SaveDisburseAdditionalCommission(CustCode, NETBILLAMT, NETCNAMT, NETAMT, NETADDDIS, GROSSBILLAMT, GROSSCNAMT, GROSSNETAMT, GROSSADDDIS, Amount, Details, FY, CreatedBy, out DACId);
        }

        public static DataSet Idv_Chetana_Rep_Customer_TODReport(int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return new AdminDataService().Idv_Chetana_Rep_Customer_TODReport(Superzone, Zone, CustID, CustCateID, FY);
        }

        public void Save(out int _CID)
        {
            this.Save(null, out _CID);
        }

        public void Save(IDbTransaction txn, out int _CID)
        {
            new AdminDataService().SaveCustomerMaster(this._CustID, this._CustCode, this._ShortForm, this._FamilyCode, this._AreaID, this._Address, this._Zip, this._Phone1, this._Phone2, this._EmailID, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy, this._CustName, this._CUSTOMERTYPE, this._SuperZoneID, this._ZoneID, this._AreaZoneID, this._DMID, out _CID, this._City, this._CustRating, this._Fyfrom, this._CMID, this._CMIDsub, this._SchAdditionalDis, this._TODValue1, this._TODValue2, this._TODValue3, this._TODDisc1, this._TODValue2, this._TODValue3);
        }

        public void Update()
        {
            this.Update(null);
        }

        public void Update(IDbTransaction txn)
        {
            new AdminDataService(txn).Update_CustomerMaster(this._CustID, this._CustCode, this._ShortForm, this._FamilyCode, this._AreaID, this._Address, this._Zip, this._Phone1, this._Phone2, this._EmailID, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy, this._CustName, this._CustDetailID, this._CreditDays, this._CreditLimit, this._BlackList, this._IsDeleted1, this._PrincipalName, this._PrincipalMobile, this._PrincipalDOB, this._KeyPersonName, this._KeyPersonMobile, this._KeyPersonDOB, this._AdditinalDis, this._VIPRemark, this._SectionID, this._Medium, this._City, this._DMID, this._CustRating, this._SuperZoneID, this._ZoneID, this._AreaZoneID, this._BoardID, this._Business_Potential, this._CGP, this._Association, this._Payment_Track, this._Remark1, this._Remark2, this._Remark3, this._Remark4, this._Remark5, this._CMID, this._CMIDsub, this._SchAdditionalDis, this._TODValue1, this._TODValue2, this._TODValue3, this._TODDisc1, this._TODDisc2, this._TODDisc3, this._BlackListDate, this._BlackListRemark);
        }

        public int CustID
        {
            get
            {
                return this._CustID;
            }
            set
            {
                this._CustID = value;
            }
        }

        public string CustCode
        {
            get
            {
                return this._CustCode;
            }
            set
            {
                this._CustCode = value;
            }
        }

        public string ShortForm
        {
            get
            {
                return this._ShortForm;
            }
            set
            {
                this._ShortForm = value;
            }
        }

        public string FamilyCode
        {
            get
            {
                return this._FamilyCode;
            }
            set
            {
                this._FamilyCode = value;
            }
        }

        public string AreaCode
        {
            get
            {
                return this._AreaCode;
            }
            set
            {
                this._AreaCode = value;
            }
        }

        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this._Address = value;
            }
        }

        public int City
        {
            get
            {
                return this._City;
            }
            set
            {
                this._City = value;
            }
        }

        public string Zip
        {
            get
            {
                return this._Zip;
            }
            set
            {
                this._Zip = value;
            }
        }

        public string Phone1
        {
            get
            {
                return this._Phone1;
            }
            set
            {
                this._Phone1 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return this._Phone2;
            }
            set
            {
                this._Phone2 = value;
            }
        }

        public string EmailID
        {
            get
            {
                return this._EmailID;
            }
            set
            {
                this._EmailID = value;
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

        public DateTime UpdatedOn
        {
            get
            {
                return this._UpdatedOn;
            }
            set
            {
                this._UpdatedOn = value;
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

        public string CustName
        {
            get
            {
                return this._CustName;
            }
            set
            {
                this._CustName = value;
            }
        }

        public int AreaID
        {
            get
            {
                return this._AreaID;
            }
            set
            {
                this._AreaID = value;
            }
        }

        public string CUSTOMERTYPE
        {
            get
            {
                return this._CUSTOMERTYPE;
            }
            set
            {
                this._CUSTOMERTYPE = value;
            }
        }

        public int SuperZoneID
        {
            get
            {
                return this._SuperZoneID;
            }
            set
            {
                this._SuperZoneID = value;
            }
        }

        public int ZoneID
        {
            get
            {
                return this._ZoneID;
            }
            set
            {
                this._ZoneID = value;
            }
        }

        public int AreaZoneID
        {
            get
            {
                return this._AreaZoneID;
            }
            set
            {
                this._AreaZoneID = value;
            }
        }

        public int DMID
        {
            get
            {
                return this._DMID;
            }
            set
            {
                this._DMID = value;
            }
        }

        public int CID
        {
            get
            {
                return this._CID;
            }
            set
            {
                this._CID = value;
            }
        }

        public int CustDetailID
        {
            get
            {
                return this._CustDetailID;
            }
            set
            {
                this._CustDetailID = value;
            }
        }

        public string CreditDays
        {
            get
            {
                return this._CreditDays;
            }
            set
            {
                this._CreditDays = value;
            }
        }

        public int CreditLimit
        {
            get
            {
                return this._CreditLimit;
            }
            set
            {
                this._CreditLimit = value;
            }
        }

        public bool BlackList
        {
            get
            {
                return this._BlackList;
            }
            set
            {
                this._BlackList = value;
            }
        }

        public bool IsDeleted1
        {
            get
            {
                return this._IsDeleted1;
            }
            set
            {
                this._IsDeleted1 = value;
            }
        }

        public string PrincipalName
        {
            get
            {
                return this._PrincipalName;
            }
            set
            {
                this._PrincipalName = value;
            }
        }

        public string PrincipalMobile
        {
            get
            {
                return this._PrincipalMobile;
            }
            set
            {
                this._PrincipalMobile = value;
            }
        }

        public string PrincipalDOB
        {
            get
            {
                return this._PrincipalDOB;
            }
            set
            {
                this._PrincipalDOB = value;
            }
        }

        public string KeyPersonName
        {
            get
            {
                return this._KeyPersonName;
            }
            set
            {
                this._KeyPersonName = value;
            }
        }

        public string KeyPersonMobile
        {
            get
            {
                return this._KeyPersonMobile;
            }
            set
            {
                this._KeyPersonMobile = value;
            }
        }

        public string KeyPersonDOB
        {
            get
            {
                return this._KeyPersonDOB;
            }
            set
            {
                this._KeyPersonDOB = value;
            }
        }

        public string AdditinalDis
        {
            get
            {
                return this._AdditinalDis;
            }
            set
            {
                this._AdditinalDis = value;
            }
        }

        public string VIPRemark
        {
            get
            {
                return this._VIPRemark;
            }
            set
            {
                this._VIPRemark = value;
            }
        }

        public int SectionID
        {
            get
            {
                return this._SectionID;
            }
            set
            {
                this._SectionID = value;
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

        public int CustRating
        {
            get
            {
                return this._CustRating;
            }
            set
            {
                this._CustRating = value;
            }
        }

        public int BoardID
        {
            get
            {
                return this._BoardID;
            }
            set
            {
                this._BoardID = value;
            }
        }

        public decimal Business_Potential
        {
            get
            {
                return this._Business_Potential;
            }
            set
            {
                this._Business_Potential = value;
            }
        }

        public decimal CGP
        {
            get
            {
                return this._CGP;
            }
            set
            {
                this._CGP = value;
            }
        }

        public string Association
        {
            get
            {
                return this._Association;
            }
            set
            {
                this._Association = value;
            }
        }

        public string Payment_Track
        {
            get
            {
                return this._Payment_Track;
            }
            set
            {
                this._Payment_Track = value;
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

        public string Remark4
        {
            get
            {
                return this._Remark4;
            }
            set
            {
                this._Remark4 = value;
            }
        }

        public string Remark5
        {
            get
            {
                return this._Remark5;
            }
            set
            {
                this._Remark5 = value;
            }
        }

        public int Fyfrom
        {
            get
            {
                return this._Fyfrom;
            }
            set
            {
                this._Fyfrom = value;
            }
        }

        public int CMID
        {
            get
            {
                return this._CMID;
            }
            set
            {
                this._CMID = value;
            }
        }

        public int CMIDsub
        {
            get
            {
                return this._CMIDsub;
            }
            set
            {
                this._CMIDsub = value;
            }
        }

        public string SchAdditionalDis
        {
            get
            {
                return this._SchAdditionalDis;
            }
            set
            {
                this._SchAdditionalDis = value;
            }
        }

        public string TODValue1
        {
            get
            {
                return this._TODValue1;
            }
            set
            {
                this._TODValue1 = value;
            }
        }

        public string TODValue2
        {
            get
            {
                return this._TODValue2;
            }
            set
            {
                this._TODValue2 = value;
            }
        }

        public string TODValue3
        {
            get
            {
                return this._TODValue3;
            }
            set
            {
                this._TODValue3 = value;
            }
        }

        public string TODDisc1
        {
            get
            {
                return this._TODDisc1;
            }
            set
            {
                this._TODDisc1 = value;
            }
        }

        public string TODDisc2
        {
            get
            {
                return this._TODDisc2;
            }
            set
            {
                this._TODDisc2 = value;
            }
        }

        public string TODDisc3
        {
            get
            {
                return this._TODDisc3;
            }
            set
            {
                this._TODDisc3 = value;
            }
        }

        public string BlackListDate
        {
            get
            {
                return this._BlackListDate;
            }
            set
            {
                this._BlackListDate = value;
            }
        }

        public string BlackListRemark
        {
            get
            {
                return this._BlackListRemark;
            }
            set
            {
                this._BlackListRemark = value;
            }
        }
    }
}

