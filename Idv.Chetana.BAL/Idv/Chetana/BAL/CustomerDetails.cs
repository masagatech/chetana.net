namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;

    public class CustomerDetails
    {
        private int _CustDetailID = Constants.NullInt;
        private string _CustCode = Constants.NullString;
        private string _CreditLimit = Constants.NullString;
        private bool _BlackList = Constants.NullBoolean;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private string _PrincipalName = Constants.NullString;
        private string _PrincipalMobile = Constants.NullString;
        private string _PrincipalDOB = Constants.NullString;
        private string _KeyPersonName = Constants.NullString;
        private string _KeyPersonMobile = Constants.NullString;
        private string _KeyPersonDOB = Constants.NullString;
        private string _AdditinalDis = Constants.NullString;
        private string _VIPRemark = Constants.NullString;
        private string _StNo = Constants.NullString;
        private string _CstNo = Constants.NullString;
        private string _PanNo = Constants.NullString;
        private string _Medium = Constants.NullString;
        private int _SectionID = Constants.NullInt;
        private int _custId = Constants.NullInt;
        private string _creditdays = Constants.NullString;
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
        private string _BlackListDate = Constants.NullString;
        private string _BlackListRemark = Constants.NullString;
        private decimal _ADDITIONALAMT = Constants.NullDecimal;

        public void Save()
        {
            new AdminDataService().Save_CustomerDetails(this._CustDetailID, this._CustCode, this._CreditLimit, this._BlackList, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy, this._PrincipalName, this._PrincipalMobile, this._PrincipalDOB, this._KeyPersonName, this._KeyPersonMobile, this._KeyPersonDOB, this._AdditinalDis, this._VIPRemark, this._Medium, this._SectionID, this._custId, this._creditdays, this._BoardID, this._Business_Potential, this._CGP, this._Association, this._Payment_Track, this._Remark1, this._Remark2, this._Remark3, this._Remark4, this._Remark5, this._BlackListDate, this._BlackListRemark);
        }

        public void Updateamount()
        {
            new AdminDataService().Save_DiscountamountDetails(this._CustCode, this._ADDITIONALAMT);
        }

        public decimal ADDITIONALAMT
        {
            get
            {
                return this._ADDITIONALAMT;
            }
            set
            {
                this._ADDITIONALAMT = value;
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

        public string CreditLimit
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

        public int CustId
        {
            get
            {
                return this._custId;
            }
            set
            {
                this._custId = value;
            }
        }

        public string creditdays
        {
            get
            {
                return this._creditdays;
            }
            set
            {
                this._creditdays = value;
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
    }
}

