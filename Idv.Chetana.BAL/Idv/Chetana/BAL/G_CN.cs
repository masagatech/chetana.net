namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class G_CN
    {
        private int _GCN_ID = Constants.NullInt;
        private DateTime _GCN_DATE = Constants.NullDateTime;
        private string _GCN_NO = Constants.NullString;
        private string _SALES_REPRESENTATIVE = Constants.NullString;
        private int _SCHL_ID = Constants.NullInt;
        private string _SCHL_NAME = Constants.NullString;
        private string _AREA = Constants.NullString;
        private string _SALESMAN_CN_NO = Constants.NullString;
        private int _Fy = Constants.NullInt;
        private string _Narration = Constants.NullString;
        private string _Created_By = Constants.NullString;
        private string _Updated_By = Constants.NullString;

        public void DeleteCN()
        {
            new AdminDataService_Go().DeleteCN(this._GCN_ID);
        }

        public static DataSet GetCNOnDocNo(int DocNo, string Flag, int Fy)
        {
            return new AdminDataService_Go().GetCNOnDocNo(Fy, DocNo, Flag);
        }

        public void Save()
        {
            new AdminDataService_Go().SaveIdv_Chetana_G_GodownCN(this._GCN_ID, this._GCN_DATE, this._GCN_NO, this._SALES_REPRESENTATIVE, this._SCHL_ID, this._SCHL_NAME, this._AREA, this._SALESMAN_CN_NO, this._Fy, this._Created_By, this._Updated_By, this._Narration);
        }

        public int GCN_ID
        {
            get
            {
                return this._GCN_ID;
            }
            set
            {
                this._GCN_ID = value;
            }
        }

        public DateTime GCN_DATE
        {
            get
            {
                return this._GCN_DATE;
            }
            set
            {
                this._GCN_DATE = value;
            }
        }

        public string GCN_NO
        {
            get
            {
                return this._GCN_NO;
            }
            set
            {
                this._GCN_NO = value;
            }
        }

        public string SALES_REPRESENTATIVE
        {
            get
            {
                return this._SALES_REPRESENTATIVE;
            }
            set
            {
                this._SALES_REPRESENTATIVE = value;
            }
        }

        public int SCHL_ID
        {
            get
            {
                return this._SCHL_ID;
            }
            set
            {
                this._SCHL_ID = value;
            }
        }

        public string SCHL_NAME
        {
            get
            {
                return this._SCHL_NAME;
            }
            set
            {
                this._SCHL_NAME = value;
            }
        }

        public string AREA
        {
            get
            {
                return this._AREA;
            }
            set
            {
                this._AREA = value;
            }
        }

        public string SALESMAN_CN_NO
        {
            get
            {
                return this._SALESMAN_CN_NO;
            }
            set
            {
                this._SALESMAN_CN_NO = value;
            }
        }

        public int Fy
        {
            get
            {
                return this._Fy;
            }
            set
            {
                this._Fy = value;
            }
        }

        public string Created_By
        {
            get
            {
                return this._Created_By;
            }
            set
            {
                this._Created_By = value;
            }
        }

        public string Updated_By
        {
            get
            {
                return this._Updated_By;
            }
            set
            {
                this._Updated_By = value;
            }
        }

        public string Narration
        {
            get
            {
                return this._Narration;
            }
            set
            {
                this._Narration = value;
            }
        }
    }
}

