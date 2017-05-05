namespace Other_Z
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using Idv.Chetana.Common;
    using System.Runtime.InteropServices;
    using System.Data.SqlClient;


    public class Customer_cs_rev : Idv.Chetana.DAL.DataServiceBase
    {
        private string _AdditinalDis = Constants.NullString;
        private string _Address = Constants.NullString;
        private string _AreaCode = Constants.NullString;
        private int _AreaID = Constants.NullInt;
        private int _AreaZoneID = Constants.NullInt;
        private string _Association = Constants.NullString;
        private bool _BlackList = Constants.NullBoolean;
        private string _BlackListDate = Constants.NullString;
        private string _BlackListRemark = Constants.NullString;
        private int _BoardID = Constants.NullInt;
        private decimal _Business_Potential = Constants.NullDecimal;
        private decimal _CGP = Constants.NullDecimal;
        private int _CID = Constants.NullInt;
        private int _City = Constants.NullInt;
        private int _CMID = Constants.NullInt;
        private int _CMIDsub = Constants.NullInt;
        private string _CreatedBy = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreditDays = Constants.NullString;
        private int _CreditLimit = Constants.NullInt;
        private string _CustCode = Constants.NullString;
        private int _CustDetailID = Constants.NullInt;
        private int _CustID = Constants.NullInt;
        private string _CustName = Constants.NullString;
        private string _CUSTOMERTYPE = Constants.NullString;
        private int _CustRating = Constants.NullInt;
        private int _DMID = Constants.NullInt;
        private string _EmailID = Constants.NullString;
        private string _FamilyCode = Constants.NullString;
        private int _Fyfrom = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private bool _IsDeleted1 = Constants.NullBoolean;
        private string _KeyPersonDOB = Constants.NullString;
        private string _KeyPersonMobile = Constants.NullString;
        private string _KeyPersonName = Constants.NullString;
        private string _Medium = Constants.NullString;
        private string _Payment_Track = Constants.NullString;
        private string _Phone1 = Constants.NullString;
        private string _Phone2 = Constants.NullString;
        private string _PrincipalDOB = Constants.NullString;
        private string _PrincipalMobile = Constants.NullString;
        private string _PrincipalName = Constants.NullString;
        private string _Remark1 = Constants.NullString;
        private string _Remark2 = Constants.NullString;
        private string _Remark3 = Constants.NullString;
        private string _Remark4 = Constants.NullString;
        private string _Remark5 = Constants.NullString;
        private string _SchAdditionalDis = Constants.NullString;
        private int _SectionID = Constants.NullInt;
        private string _ShortForm = Constants.NullString;
        private int _SuperZoneID = Constants.NullInt;
        private string _TODDisc1 = Constants.NullString;
        private string _TODDisc2 = Constants.NullString;
        private string _TODDisc3 = Constants.NullString;
        private string _TODValue1 = Constants.NullString;
        private string _TODValue2 = Constants.NullString;
        private string _TODValue3 = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _VIPRemark = Constants.NullString;
        private string _Zip = Constants.NullString;
        private int _ZoneID = Constants.NullInt;
        public string OtherFields { get; set; }
        public bool isSplit { get; set; }

        public void Save(out int _CID)
        {
            this.Save(null, out _CID);
        }

        public void Save(IDbTransaction txn, out int _CID)
        {
            this.SaveCustomerMaster(this._CustID, this._CustCode, this._ShortForm,
                this._FamilyCode, this._AreaID, this._Address, this._Zip, this._Phone1,
                this._Phone2, this._EmailID, this._IsActive, this._IsDeleted,
                this._CreatedBy, this._UpdatedBy, this._CustName, this._CUSTOMERTYPE,
                this._SuperZoneID, this._ZoneID, this._AreaZoneID, this._DMID, out _CID,
                this._City, this._CustRating, this._Fyfrom, this._CMID, this._CMIDsub,
                this._SchAdditionalDis, this._TODValue1, this._TODValue2,
                this._TODValue3, this._TODDisc1, this._TODValue2, this._TODValue3,
            this.OtherFields, this.isSplit);
        }


        public void SaveCustomerMaster(int CustID, string CustCode, string ShortForm,
            string FamilyCode, int AreaId, string Address, string Zip, string Phone1,
            string Phone2, string EmailID, bool IsActive, bool IsDeleted, string CreatedBy,
            string UpdatedBy, string CustName, string CUSTOMERTYPE, int SuperZoneID, int ZoneID,
            int AreaZoneID, int DMID, out int CID, int City, int CustRating, int Year,
            int CMID, int CMIDsub, string SchAdditionalDis, string TODValue1,
            string TODValue2, string TODValue3, string TODDisc1, string TODDisc2,
            string TODDisc3, string OtherFields, bool isSplit)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_CustomerMaster", new IDataParameter[] { 
                base.CreateParameter("@CustID", SqlDbType.Int, CustID),
                base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), 
                base.CreateParameter("@ShortForm", SqlDbType.NVarChar, ShortForm), 
                base.CreateParameter("@FamilyCode", SqlDbType.NVarChar, FamilyCode),
                base.CreateParameter("@AreaId", SqlDbType.Int, AreaId),
                base.CreateParameter("@Address", SqlDbType.NVarChar, Address), 
                base.CreateParameter("@Zip", SqlDbType.NVarChar, Zip), 
                base.CreateParameter("@Phone1", SqlDbType.NVarChar, Phone1),
                base.CreateParameter("@Phone2", SqlDbType.NVarChar, Phone2), 
                base.CreateParameter("@EmailID", SqlDbType.NVarChar, EmailID),
                base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), 
                base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), 
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), 
                base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy),
                base.CreateParameter("@CustName", SqlDbType.NVarChar, CustName),
                base.CreateParameter("@CUSTOMERTYPE", SqlDbType.NVarChar, CUSTOMERTYPE), 
                base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneID), 
                base.CreateParameter("@ZoneID", SqlDbType.Int, ZoneID),
                base.CreateParameter("@AreaZoneID", SqlDbType.Int, AreaZoneID),
                base.CreateParameter("@DMID", SqlDbType.Int, DMID), 
                base.CreateParameter("@CID", SqlDbType.Int, ParameterDirection.Output), 
                base.CreateParameter("@City", SqlDbType.Int, City), 
                base.CreateParameter("@CustRating", SqlDbType.Int, CustRating), 
                base.CreateParameter("@Fy", SqlDbType.Int, Year), 
                base.CreateParameter("@CMID", SqlDbType.Int, CMID), 
                base.CreateParameter("@CMIDsub", SqlDbType.Int, CMIDsub), 
                base.CreateParameter("@SchAdditionalDis", SqlDbType.NVarChar, SchAdditionalDis), 
                base.CreateParameter("@TODValue1", SqlDbType.NVarChar, TODValue1), 
                base.CreateParameter("@TODValue2", SqlDbType.NVarChar, TODValue2),
                base.CreateParameter("@TODValue3", SqlDbType.NVarChar, TODValue3),
                base.CreateParameter("@TODDisc1", SqlDbType.NVarChar, TODDisc1),
                base.CreateParameter("@TODDisc2", SqlDbType.NVarChar, TODDisc2), 
                base.CreateParameter("@TODDisc3", SqlDbType.NVarChar, TODDisc3),
                base.CreateParameter("@OtherFields",SqlDbType.Xml, OtherFields),
                base.CreateParameter("@isSplit",SqlDbType.Bit,isSplit)});
            CID = Convert.ToInt32(command.Parameters["@CID"].Value);
            command.Dispose();
        }
        //#####################################################################################3333

        public void Update()
        {
            this.Update(null);
        }

        public void Update(IDbTransaction txn)
        {
            this.Update_CustomerMaster(this._CustID, this._CustCode, this._ShortForm, this._FamilyCode, this._AreaID,
                this._Address, this._Zip, this._Phone1, this._Phone2, this._EmailID, this._IsActive, this._IsDeleted,
                this._CreatedBy, this._UpdatedBy, this._CustName, this._CustDetailID, this._CreditDays, this._CreditLimit,
                this._BlackList, this._IsDeleted1, this._PrincipalName, this._PrincipalMobile, this._PrincipalDOB, this._KeyPersonName,
                this._KeyPersonMobile, this._KeyPersonDOB, this._AdditinalDis, this._VIPRemark, this._SectionID, this._Medium,
                this._City, this._DMID, this._CustRating, this._SuperZoneID, this._ZoneID, this._AreaZoneID, this._BoardID,
                this._Business_Potential, this._CGP, this._Association, this._Payment_Track, this._Remark1, this._Remark2,
                this._Remark3, this._Remark4, this._Remark5, this._CMID, this._CMIDsub, this._SchAdditionalDis, this._TODValue1,
                this._TODValue2, this._TODValue3, this._TODDisc1, this._TODDisc2, this._TODDisc3, this._BlackListDate,
                this._BlackListRemark, this.OtherFields,this.isSplit);
        }

        public void Update_CustomerMaster(int CustID, string CustCode, string ShortForm, string FamilyCode, int AreaId,
            string Address, string Zip, string Phone1, string Phone2, string EmailID, bool IsActive, bool IsDeleted, string
            CreatedBy, string UpdatedBy, string CustName, int CustDetailID, string CreditDays, int CreditLimit, bool BlackList,
            bool IsDeleted1, string PrincipalName, string PrincipalMobile, string PrincipalDOB, string KeyPersonName, string KeyPersonMobile,
            string KeyPersonDOB, string AdditinalDis, string VIPRemark, int SectionID, string Medium, int City, int DMID, int CustRating,
            int SuperZoneID, int ZoneID, int AreaZoneID, int BoardID, decimal Business_Potential, decimal CGP, string Association,
            string Payment_Track, string Remark1, string Remark2, string Remark3, string Remark4, string Remark5, int CMID,
            int CMIDsub, string SchAdditionalDis, string TODValue1, string TODValue2,
            string TODValue3, string TODDisc1, string TODDisc2, string TODDisc3, string BlackListDate,
            string BlackListRemark, string OtherFields,bool isSplit)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Update_CustomerMaster", new IDataParameter[] { 
                base.CreateParameter("@CustID", SqlDbType.Int, CustID), 
                base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), 
                base.CreateParameter("@ShortForm", SqlDbType.NVarChar, ShortForm), 
                base.CreateParameter("@FamilyCode", SqlDbType.NVarChar, FamilyCode), 
                base.CreateParameter("@AreaId", SqlDbType.Int, AreaId), 
                base.CreateParameter("@Address", SqlDbType.NVarChar, Address), 
                base.CreateParameter("@City", SqlDbType.Int, City), 
                base.CreateParameter("@DMID", SqlDbType.Int, DMID),
                base.CreateParameter("@Zip", SqlDbType.NVarChar, Zip), 
                base.CreateParameter("@Phone1", SqlDbType.NVarChar, Phone1), 
                base.CreateParameter("@Phone2", SqlDbType.NVarChar, Phone2), 
                base.CreateParameter("@EmailID", SqlDbType.NVarChar, EmailID),
                base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), 
                base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted),
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), 
                base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), 
                base.CreateParameter("@CustName", SqlDbType.NVarChar, CustName), 
                base.CreateParameter("@CustDetailID", SqlDbType.Int, CustDetailID),
                base.CreateParameter("@CreditDays", SqlDbType.NVarChar, CreditDays),
                base.CreateParameter("@CreditLimit", SqlDbType.Int, CreditLimit),
                base.CreateParameter("@BlackList", SqlDbType.Bit, BlackList),
                base.CreateParameter("@IsDeleted1", SqlDbType.Bit, IsDeleted1), 
                base.CreateParameter("@PrincipalName", SqlDbType.NVarChar, PrincipalName), 
                base.CreateParameter("@PrincipalMobile", SqlDbType.NVarChar, PrincipalMobile), 
                base.CreateParameter("@PrincipalDOB", SqlDbType.NVarChar, PrincipalDOB), 
                base.CreateParameter("@KeyPersonName", SqlDbType.NVarChar, KeyPersonName), 
                base.CreateParameter("@KeyPersonMobile", SqlDbType.NVarChar, KeyPersonMobile),
                base.CreateParameter("@KeyPersonDOB", SqlDbType.NVarChar, KeyPersonDOB), 
                base.CreateParameter("@AdditinalDis", SqlDbType.NVarChar, AdditinalDis), 
                base.CreateParameter("@VIPRemark", SqlDbType.NVarChar, VIPRemark), 
                base.CreateParameter("@SectionID", SqlDbType.Int, SectionID), 
                base.CreateParameter("@Medium", SqlDbType.NVarChar, Medium), 
                base.CreateParameter("@CustRating", SqlDbType.Int, CustRating), 
                base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneID), 
                base.CreateParameter("@ZoneID", SqlDbType.Int, ZoneID), 
                base.CreateParameter("@AreaZoneID", SqlDbType.Int, AreaZoneID), 
                base.CreateParameter("@BoardID", SqlDbType.Int, BoardID), 
                base.CreateParameter("@Business_Potential", SqlDbType.Money, Business_Potential),
                base.CreateParameter("@CGP", SqlDbType.Money, CGP), 
                base.CreateParameter("@Association", SqlDbType.NVarChar, Association), 
                base.CreateParameter("@Payment_Track", SqlDbType.NVarChar, Payment_Track), 
                base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1), 
                base.CreateParameter("@Remark2", SqlDbType.NVarChar, Remark2),
                base.CreateParameter("@Remark3", SqlDbType.NVarChar, Remark3),
                base.CreateParameter("@Remark4", SqlDbType.NVarChar, Remark4), 
                base.CreateParameter("@Remark5", SqlDbType.NVarChar, Remark5), 
                base.CreateParameter("@CMID", SqlDbType.Int, CMID), 
                base.CreateParameter("@CMIDsub", SqlDbType.Int, CMIDsub), 
                base.CreateParameter("@SchAdditionalDis", SqlDbType.NVarChar, SchAdditionalDis),
                base.CreateParameter("@TODValue1", SqlDbType.NVarChar, TODValue1),
                base.CreateParameter("@TODValue2", SqlDbType.NVarChar, TODValue2), 
                base.CreateParameter("@TODValue3", SqlDbType.NVarChar, TODValue3), 
                base.CreateParameter("@TODDisc1", SqlDbType.NVarChar, TODDisc1), 
                base.CreateParameter("@TODDisc2", SqlDbType.NVarChar, TODDisc2),
                base.CreateParameter("@TODDisc3", SqlDbType.NVarChar, TODDisc3), 
                base.CreateParameter("@BlacklistDate", SqlDbType.NVarChar, BlackListDate), 
                base.CreateParameter("@Blacklistremark", SqlDbType.NVarChar, BlackListRemark),
                base.CreateParameter("@OtherFields", SqlDbType.Xml, OtherFields),
                base.CreateParameter("@isSplit", SqlDbType.Bit, isSplit)
             });
            command.Dispose();
        }


        //######################################################################################333

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

    }
}

