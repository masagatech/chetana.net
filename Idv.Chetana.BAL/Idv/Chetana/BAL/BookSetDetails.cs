namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class BookSetDetails
    {
        private int _BooksetDetailID = Constants.NullInt;
        private int _BookSetID = Constants.NullInt;
        private int _BookID = Constants.NullInt;
        private int _Quantity = Constants.NullInt;
        private bool _Active = Constants.NullBoolean;
        private bool _Deleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;

        public static DataSet Get_BookSetDetailsOn_SetID(int BookSetID)
        {
            return new AdminDataService().Get_BookSetDetailsOn_SetID(BookSetID);
        }

        public static DataSet Get_BookSetDetailsOn_SetID_ForDC(int BookSetID, string srate)
        {
            return new AdminDataService_DC().Get_BookSetDetailsOn_SetID_ForDC(BookSetID, srate);
        }

        public static DataSet Get_BookSetDetailsOn_SetIDForSpec(int BookSetID, string srate)
        {
            return new AdminDataService().Get_BookSetDetailsOn_SetIDForSpec(BookSetID, srate);
        }

        public static DataSet GetDescription_Of_bookset(int BookSetID, string Flag)
        {
            return new AdminDataService().GetDescription_Of_bookset(BookSetID, Flag);
        }

        public int BooksetDetailID
        {
            get
            {
                return this._BooksetDetailID;
            }
            set
            {
                this._BooksetDetailID = value;
            }
        }

        public int BookSetID
        {
            get
            {
                return this._BookSetID;
            }
            set
            {
                this._BookSetID = value;
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

        public bool Active
        {
            get
            {
                return this._Active;
            }
            set
            {
                this._Active = value;
            }
        }

        public bool Deleted
        {
            get
            {
                return this._Deleted;
            }
            set
            {
                this._Deleted = value;
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
    }
}

