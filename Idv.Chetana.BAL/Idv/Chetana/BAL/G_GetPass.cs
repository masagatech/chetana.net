namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class G_GetPass
    {
        private int _Doc_ID = Constants.NullInt;
        private string _Local_Out;
        private DateTime _Doc_Date = Constants.NullDateTime;
        private int _Veh_ID = Constants.NullInt;
        private string _Driver_Name = Constants.NullString;
        private int _Driver_ID = Constants.NullInt;
        private string _Area = Constants.NullString;
        private string _Deliveruy_Boy = Constants.NullString;
        private int _Deliveruy_Boy_ID = Constants.NullInt;
        private int _Cust_ID = Constants.NullInt;
        private int _Transporter_ID = Constants.NullInt;
        private string _No_Bundles = Constants.NullString;
        private decimal _Value_Goods = Constants.NullDecimal;
        private string _Sent_By = Constants.NullString;
        private string _Bill_Nos = Constants.NullString;
        private string _LR_No = Constants.NullString;
        private string _Pay_Paid = Constants.NullString;
        private decimal _Amount = Constants.NullDecimal;
        private DateTime _LR_Date = Constants.NullDateTime;
        private decimal _DC_No = Constants.NullDecimal;
        private int _DR_ID = Constants.NullInt;
        private int _DB_ID = Constants.NullInt;
        private bool _Delivery = Constants.NullBoolean;
        private string _Created_By = Constants.NullString;
        private string _Updated_By = Constants.NullString;
        private int _Is_Deleted = Constants.NullInt;
        private int _Fy = Constants.NullInt;
        private string _remark1 = Constants.NullString;
        private string _remark2 = Constants.NullString;

        public static DataSet CustEMail_LocalEntry(int CustID)
        {
            return new AdminDataService_Go().CustEmail_LocalEntry(CustID);
        }

        public void Delete_Update_DCNo_BillNo()
        {
            new AdminDataService_Go().Local_GetPass_DCNo_BillNo_Validation(this._DC_No, this._Bill_Nos, this._Fy, this.Created_By);
        }

        public static DataSet GetDispatchEmail(int DocNo, string Flag, int Fy)
        {
            return new AdminDataService_Go().GetDispatchEmail(Fy, DocNo, Flag);
        }

        public static DataSet GetpassOnDCNo(int DC, string Flag, int Fy)
        {
            return new AdminDataService_Go().GetpassOnDCNo(Fy, DC, Flag);
        }

        public static DataSet GetpassOnDocNo(int DocNo, string Flag, int Fy)
        {
            return new AdminDataService_Go().GetpassOnDocNo(Fy, DocNo, Flag);
        }

        public static DataSet Local_Date_Report(string mode, DateTime fromdate, DateTime todate, string delivery, string fromdetails, int fy)
        {
            return new AdminDataService_Go().Local_Date_Report(mode, fromdate, todate, delivery, fromdetails, fy);
        }

        public static DataSet Local_GetPass_DCNo_BillNo_Validation(decimal Dc_No, string Bill_No, int fy, string flag)
        {
            return new AdminDataService_Go().Local_GetPass_DCNo_BillNo_Validation(Dc_No, Bill_No, fy, flag);
        }

        public static DataSet Local_Report(int Doc_ID, string Local_Out, int Fy)
        {
            return new AdminDataService_Go().Local_Report(Doc_ID, Local_Out, Fy);
        }

        public static DataSet LocalOut_PassReport(string mode, string flag, int fdcno, int tdcno, DateTime fromdate, DateTime todate, int fy)
        {
            return new AdminDataService_Go().LocalOut_PassReport(mode, flag, fdcno, tdcno, fromdate, todate, fy);
        }

        public static DataSet Out_Report(int Doc_ID, string Local_Out, int Fy)
        {
            return new AdminDataService_Go().Out_Report(Doc_ID, Local_Out, Fy);
        }

        public static DataSet Out_Transporter_Report(string flag, DateTime fromdate, DateTime todate, string Code, int fy, string flag1)
        {
            return new AdminDataService_Go().Out_Transporter_Report(flag, fromdate, todate, Code, fy, flag1);
        }

        public static DataSet Packing_Report(string mode, DateTime fromdate, DateTime todate, int supzone, int zone, int fy)
        {
            return new AdminDataService_Go().Packing_Report(mode, fromdate, todate, supzone, zone, fy);
        }

        public static DataSet Railway_Report(string flag, int fdcno, int tdcno, DateTime fromdate, DateTime todate, int fy)
        {
            return new AdminDataService_Go().Railway_Report(flag, fdcno, tdcno, fromdate, todate, fy);
        }

        public static DataSet Report_Outside_Credit(string flag, DateTime fromdate, DateTime todate, int GCNfNo, int GCNtNo, int fy)
        {
            return new AdminDataService_Go().Report_Outside_Credit(flag, fromdate, todate, GCNfNo, GCNtNo, fy);
        }

        public static DataSet Report_PackingDetails(DateTime fromDate, DateTime toDate, int fy, string flag)
        {
            return new AdminDataService_Go().Report_PackingDetails(fromDate, toDate, fy, flag);
        }

        public int Save(out int Doc_No_New)
        {
            return new AdminDataService_Go().SaveIdv_Chetana_G_GetPass_Main(this._Doc_ID, this._Local_Out, this._Doc_Date, this._Veh_ID, this._Driver_Name, this._Driver_ID, this._Area, this._Deliveruy_Boy, this._Deliveruy_Boy_ID, this._Cust_ID, this._Transporter_ID, this._No_Bundles, this._Value_Goods, this._Sent_By, this._Bill_Nos, this._LR_No, this._Pay_Paid, this._Amount, this._LR_Date, this._DC_No, this._DR_ID, this._DB_ID, this._Delivery, this._Created_By, this._Updated_By, this._Fy, this._remark1, this._remark2, out Doc_No_New);
        }

        public static DataSet Team_Productvity(DateTime fromDate, DateTime toDate, int fy, string flag)
        {
            return new AdminDataService_Go().Report_TeamProductvity(fromDate, toDate, fy, flag);
        }

        public int Doc_ID
        {
            get
            {
                return this._Doc_ID;
            }
            set
            {
                this._Doc_ID = value;
            }
        }

        public string Local_Out
        {
            get
            {
                return this._Local_Out;
            }
            set
            {
                this._Local_Out = value;
            }
        }

        public DateTime Doc_Date
        {
            get
            {
                return this._Doc_Date;
            }
            set
            {
                this._Doc_Date = value;
            }
        }

        public int Veh_ID
        {
            get
            {
                return this._Veh_ID;
            }
            set
            {
                this._Veh_ID = value;
            }
        }

        public string Driver_Name
        {
            get
            {
                return this._Driver_Name;
            }
            set
            {
                this._Driver_Name = value;
            }
        }

        public int Driver_ID
        {
            get
            {
                return this._Driver_ID;
            }
            set
            {
                this._Driver_ID = value;
            }
        }

        public string Area
        {
            get
            {
                return this._Area;
            }
            set
            {
                this._Area = value;
            }
        }

        public string Deliveruy_Boy
        {
            get
            {
                return this._Deliveruy_Boy;
            }
            set
            {
                this._Deliveruy_Boy = value;
            }
        }

        public int Deliveruy_Boy_ID
        {
            get
            {
                return this._Deliveruy_Boy_ID;
            }
            set
            {
                this._Deliveruy_Boy_ID = value;
            }
        }

        public int Cust_ID
        {
            get
            {
                return this._Cust_ID;
            }
            set
            {
                this._Cust_ID = value;
            }
        }

        public int Transporter_ID
        {
            get
            {
                return this._Transporter_ID;
            }
            set
            {
                this._Transporter_ID = value;
            }
        }

        public string No_Bundles
        {
            get
            {
                return this._No_Bundles;
            }
            set
            {
                this._No_Bundles = value;
            }
        }

        public decimal Value_Goods
        {
            get
            {
                return this._Value_Goods;
            }
            set
            {
                this._Value_Goods = value;
            }
        }

        public string Sent_By
        {
            get
            {
                return this._Sent_By;
            }
            set
            {
                this._Sent_By = value;
            }
        }

        public string Bill_Nos
        {
            get
            {
                return this._Bill_Nos;
            }
            set
            {
                this._Bill_Nos = value;
            }
        }

        public string LR_No
        {
            get
            {
                return this._LR_No;
            }
            set
            {
                this._LR_No = value;
            }
        }

        public string Pay_Paid
        {
            get
            {
                return this._Pay_Paid;
            }
            set
            {
                this._Pay_Paid = value;
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

        public DateTime LR_Date
        {
            get
            {
                return this._LR_Date;
            }
            set
            {
                this._LR_Date = value;
            }
        }

        public decimal DC_No
        {
            get
            {
                return this._DC_No;
            }
            set
            {
                this._DC_No = value;
            }
        }

        public int DR_ID
        {
            get
            {
                return this._DR_ID;
            }
            set
            {
                this._DR_ID = value;
            }
        }

        public int DB_ID
        {
            get
            {
                return this._DB_ID;
            }
            set
            {
                this._DB_ID = value;
            }
        }

        public bool Delivery
        {
            get
            {
                return this._Delivery;
            }
            set
            {
                this._Delivery = value;
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

        public int Is_Deleted
        {
            get
            {
                return this._Is_Deleted;
            }
            set
            {
                this._Is_Deleted = value;
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

        public string Remark1
        {
            get
            {
                return this._remark1;
            }
            set
            {
                this._remark1 = value;
            }
        }

        public string Remark2
        {
            get
            {
                return this._remark2;
            }
            set
            {
                this._remark2 = value;
            }
        }
    }
}

