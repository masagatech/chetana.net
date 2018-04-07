namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class Books
    {
        private int _bookID = Constants.NullInt;
        private string _BookCode = Constants.NullString;
        private string _BookName = Constants.NullString;
        private string _BookType = Constants.NullString;
        private string _Bookgroup = Constants.NullString;
        private string _Standard = Constants.NullString;
        private decimal _PurchasePrice = Constants.NullDecimal;
        private decimal _SellingPrice = Constants.NullDecimal;
        private decimal _OMPrice = Constants.NullDecimal;
        private decimal _OIPrice = Constants.NullDecimal;
        private string _Medium = Constants.NullString;
        private bool _UpdateRate = Constants.NullBoolean;
        private int _Quantity = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _Description = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private string _ChetanaCompanyName = Constants.NullString;
        private int _FY = Constants.NullInt;
        private string _Confirm = Constants.NullString;
        private int _DocNo = Constants.NullInt;
        private int _PhysicalStock = Constants.NullInt;
        private int _VirtualStock = Constants.NullInt;
        private bool _IsBlock = Constants.NullBoolean;

        public static DataSet Get_BooksMaster(string BookCode)
        {
            return new AdminDataService().GetBooksMaster(BookCode);
        }

        public static DataSet Get_BooksMasterForDC(string BookCode, string srate)
        {
            return new AdminDataService_DC().GetBooksMasterForDC(BookCode, srate);
        }

        public static DataSet Get_BooksMasterForspecimen(string BookCode, string srate)
        {
            return new AdminDataService().Get_BooksMasterForspecimen(BookCode, srate);
        }

        public static DataSet Get_Booktypewise_summary(string BkTypeCode, DateTime FromDt, DateTime ToDt, int strFY)
        {
            return new AdminDataService_DC().Get_Booktypewise_summary(BkTypeCode, FromDt, ToDt, strFY);
        }

        public static DataSet Get_Booktypewise_Zonal(int SuperZoneID, DateTime FromDt, DateTime ToDt, string BkTypeCode, int ZoneID, int strFY)
        {
            return new AdminDataService_DC().Get_Booktypewise_Zonal(SuperZoneID, FromDt, ToDt, BkTypeCode, ZoneID, strFY);
        }

        public static DataSet Get_Booktypewise_ZonalDetail(int SuperZoneID, DateTime FromDt, DateTime ToDt, string BkTypeCode, int strFY)
        {
            return new AdminDataService_DC().Get_Booktypewise_ZonalDetail(SuperZoneID, FromDt, ToDt, BkTypeCode, strFY);
        }

        public static DataSet Get_BooktypewiseCust_Sold(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY)
        {
            return new AdminDataService_DC().Get_BooktypewiseCust_Sold(FromDt, ToDt, Bkcode, strFY);
        }

        public static DataSet Get_BooktypewiseCust_Sold(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY, int SuperZone, int Zone)
        {
            return new AdminDataService_DC().Get_BooktypewiseCust_Sold(FromDt, ToDt, Bkcode, strFY, SuperZone, Zone);
        }

        public static DataSet Get_BooktypewiseCust_summary(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY)
        {
            return new AdminDataService_DC().Get_BooktypewiseCust_summary(FromDt, ToDt, Bkcode, strFY);
        }

        public static DataSet Get_BooktypewiseCust_summary(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY, int SuperZone, int Zone)
        {
            return new AdminDataService_DC().Get_BooktypewiseCust_summary(FromDt, ToDt, Bkcode, strFY, SuperZone, Zone);
        }

        public static DataSet Get_Bookwise_summary(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY)
        {
            return new AdminDataService_DC().Get_Bookwise_summary(FromDt, ToDt, Bkcode, strFY);
        }

        public static DataSet Get_Bookwise_Zonal(int SuperZoneID, DateTime FromDt, DateTime ToDt, string Bkcode, int ZoneID, int strFY)
        {
            return new AdminDataService_DC().Get_Bookwise_Zonal(SuperZoneID, FromDt, ToDt, Bkcode, ZoneID, strFY);
        }

        public static DataSet Get_Bookwise_ZonalDetail(int SuperZoneID, DateTime FromDt, DateTime ToDt, string Bkcode, int strFY)
        {
            return new AdminDataService_DC().Get_Bookwise_ZonalDetail(SuperZoneID, FromDt, ToDt, Bkcode, strFY);
        }

        public static DataSet Get_BookwiseCust_SoldQty(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY)
        {
            return new AdminDataService_DC().Get_BookwiseCust_SoldQty(FromDt, ToDt, Bkcode, strFY);
        }

        public static DataSet Get_BookwiseCust_SoldQty(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY, int SuperZone, int Zone)
        {
            return new AdminDataService_DC().Get_BookwiseCust_SoldQty(FromDt, ToDt, Bkcode, strFY, SuperZone, Zone);
        }

        public static DataSet Get_BookwiseCust_summary(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY)
        {
            return new AdminDataService_DC().Get_BookwiseCust_summary(FromDt, ToDt, Bkcode, strFY);
        }

        public static DataSet Get_BookwiseCust_summary(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY, int SuperZone, int Zone)
        {
            return new AdminDataService_DC().Get_BookwiseCust_summary(FromDt, ToDt, Bkcode, strFY, SuperZone, Zone);
        }

        public static DataTable GetBookMaster()
        {
            DataSet bookMaster = new DataSet();
            bookMaster = new AdminDataService().GetBookMaster();
            DataTable table = new DataTable();
            return bookMaster.Tables[0];
        }

        public static DataTable GetBookMaster(string strChetanaCompanyName)
        {
            DataSet bookMaster = new DataSet();
            bookMaster = new AdminDataService().GetBookMaster(strChetanaCompanyName);
            DataTable table = new DataTable();
            return bookMaster.Tables[0];
        }

        public void Save()
        {
            new AdminDataService().Savebook(this._bookID, this._BookCode, this._BookName, this._BookType, this._Bookgroup, this._Standard, this._PurchasePrice, this._SellingPrice, this._OMPrice, this._OIPrice, this._Medium, this._UpdateRate, this._Quantity, this._IsActive, this._IsDeleted, this._CreatedBy, this._Description, this._UpdatedBy, this._ChetanaCompanyName);
        }

        public void Save(int id)
        {
            new AdminDataService().Savebook(this._bookID, this._BookCode, this._BookName, this._BookType, this._Bookgroup, this._Standard, this._PurchasePrice, this._SellingPrice, this._OMPrice, this._OIPrice, this._Medium, this._UpdateRate, this._Quantity, this._IsActive, this._IsDeleted, this._CreatedBy, this._Description, this._UpdatedBy, this._ChetanaCompanyName, this._FY, this._PhysicalStock, this._VirtualStock, this._IsBlock);
        }

        public void Update_New_Dc_Rate(out int _DocNo)
        {
            new AdminDataService().Update_New_Dc_Rate(this._FY, this._Confirm, out _DocNo);
        }

        public int BookID
        {
            get
            {
                return this._bookID;
            }
            set
            {
                this._bookID = value;
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

        public string BookType
        {
            get
            {
                return this._BookType;
            }
            set
            {
                this._BookType = value;
            }
        }

        public string Bookgroup
        {
            get
            {
                return this._Bookgroup;
            }
            set
            {
                this._Bookgroup = value;
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

        public decimal PurchasePrice
        {
            get
            {
                return this._PurchasePrice;
            }
            set
            {
                this._PurchasePrice = value;
            }
        }

        public decimal SellingPrice
        {
            get
            {
                return this._SellingPrice;
            }
            set
            {
                this._SellingPrice = value;
            }
        }

        public decimal OMPrice
        {
            get
            {
                return this._OMPrice;
            }
            set
            {
                this._OMPrice = value;
            }
        }

        public decimal OIPrice
        {
            get
            {
                return this._OIPrice;
            }
            set
            {
                this._OIPrice = value;
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

        public bool UpdateRate
        {
            get
            {
                return this._UpdateRate;
            }
            set
            {
                this._UpdateRate = value;
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

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
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

        public string ChetanaCompanyName
        {
            get
            {
                return this._ChetanaCompanyName;
            }
            set
            {
                this._ChetanaCompanyName = value;
            }
        }

        public int FY
        {
            get
            {
                return this._FY;
            }
            set
            {
                this._FY = value;
            }
        }

        public string Confirm
        {
            get
            {
                return this._Confirm;
            }
            set
            {
                this._Confirm = value;
            }
        }

        public int DocNo
        {
            get
            {
                return this._DocNo;
            }
            set
            {
                this._DocNo = value;
            }
        }

        public int PhysicalStock
        {
            get
            {
                return this._PhysicalStock;
            }
            set
            {
                this._PhysicalStock = value;
            }
        }

        public int VirtualStock
        {
            get
            {
                return this._VirtualStock;
            }
            set
            {
                this._VirtualStock = value;
            }
        }

        public bool IsBlock
        {
            get
            {
                return this._IsBlock;
            }
            set
            {
                this._IsBlock = value;
            }
        }
    }
}

