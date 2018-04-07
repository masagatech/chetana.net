namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Other
    {
        public DataSet Get_Codes_Customer_By_Employee_Code(string code, string flag)
        {
            return new AdminDataService().Get_Codes_Customer_By_Employee_Code(code, flag);
        }

        public DataSet Get_Codes_ForPettyCash(string code, string flag)
        {
            return new AdminDataService().Get_Codes_ForPettyCash(code, flag);
        }

        public static bool Get_UserAccess(string Access, string RoleID)
        {
            DataTable table = new DataTable();
            table = new AdminDataService().Get_UserAccess(Access, RoleID).Tables[0];
            return (table.Rows.Count > 0);
        }

        public static DataSet GetIDByCode(string code, string flag)
        {
            return new AdminDataService().GetIDByCode(code, flag);
        }

        public DataSet GetNameByCode(string code, string flag)
        {
            return new AdminDataService().GetNameByCode(code, flag);
        }

        public DataSet GetNameHelp(string flag)
        {
            return new AdminDataService().GetNameHelp(flag);
        }

        public static DataSet GetSalesHierarchy()
        {
            return new AdminDataService().get_Target_validateh_valid();
        }

        public static DataSet GetZonemaster(int ZoneID, int flag)
        {
            return new AdminDataService().GetZonemaster(ZoneID, flag);
        }

        public static DataSet Idv_Chetana_Dc_Status(string Flag, string DcNo, string Flag1, string Fy)
        {
            return new AdminDataService_DC().Idv_Chetana_Dc_Status(Flag, DcNo, Flag1, Fy);
        }

        public static DataSet IdvChetana_EmailSms(int CustId, string flag, string flag1)
        {
            return new AdminDataService_DC().IdvChetana_EmailSms(CustId, flag, flag1);
        }

        public class Dashboard
        {
            public static DataSet Get_Dasboard_ForOrderValuation(DateTime Fromdate, DateTime Todate, int Superzone)
            {
                return new AdminDataService().Get_Dasboard_ForOrderValuation(Fromdate, Todate, Superzone);
            }

            public static DataSet Get_Dasboard_ForOrderValuation(DateTime Fromdate, DateTime Todate, int Superzone, int FY)
            {
                return new AdminDataService().Get_Dasboard_ForOrderValuation(Fromdate, Todate, Superzone, FY);
            }

            public static DataSet Get_MultiYear_SalesAnalysis(int SuperZone, int FY, int Zone, int Customer, string flag1, string flag2, string flag3)
            {
                return new AdminDataService().Get_MultiYear_SalesAnalysis(SuperZone, FY, Zone, Customer, flag1, flag2, flag3);
            }

            public static DataSet Get_OrderValuation(int SuperZone, int FY, int Zone)
            {
                return new AdminDataService().Get_OrderValuation(SuperZone, FY, Zone);
            }

            public static DataSet Get_OrderValuation(int SuperZone, int FY, int Zone, DateTime FromDate, DateTime ToDate)
            {
                return new AdminDataService().Get_OrderValuation(SuperZone, FY, Zone, FromDate, ToDate);
            }

            public static DataSet Get_OrderValuation(int SuperZone, int FY, int Zone, DateTime FromDate, DateTime ToDate, string flag, string CustCateID)
            {
                return new AdminDataService().Get_OrderValuation(SuperZone, FY, Zone, FromDate, ToDate, flag, CustCateID);
            }

            public static DataSet Get_Report_SalesPerformance(int EmployeeID, int SZid)
            {
                return new AdminDataService().Get_Report_SalesPerformance(EmployeeID, SZid);
            }

            public static DataSet Get_Report_SalesPerformance(int EmployeeID, int SZid, int FY)
            {
                return new AdminDataService().Get_Report_SalesPerformance(EmployeeID, SZid, FY);
            }

            public static DataSet Get_Report_SalesPerformance(int EmployeeID, int SZid, int FY, DateTime FromDate, DateTime ToDate)
            {
                return new AdminDataService().Get_Report_SalesPerformance(EmployeeID, SZid, FY, FromDate, ToDate);
            }

            public static DataSet Get_Report_SalesPerformance(int EmployeeID, int SZid, int FY, DateTime FromDate, DateTime ToDate, int CustCateID)
            {
                return new AdminDataService().Get_Report_SalesPerformance(EmployeeID, SZid, FY, FromDate, ToDate, CustCateID);
            }

            public static DataSet Get_Report_SalesPerformance_Customer1(int EmployeeID, int FY)
            {
                return new AdminDataService().Get_Report_SalesPerformance_Customer1(EmployeeID, FY);
            }

            public static DataSet Get_Report_SalesPerformance_OnCustomer(int empid)
            {
                return new AdminDataService().Get_Report_SalesPerformance_OnCustomer(empid);
            }

            public static DataSet Get_Report_SalesPerformance_OnCustomer(int empid, int FY)
            {
                return new AdminDataService().Get_Report_SalesPerformance_OnCustomer(empid, FY);
            }

            public static DataSet Get_Report_SalesPerformance_OnCustomer(int empid, int FY, DateTime FromDate, DateTime ToDate)
            {
                return new AdminDataService().Get_Report_SalesPerformance_OnCustomer(empid, FY, FromDate, ToDate);
            }

            public static DataSet Get_Report_SalesPerformance_OnEmployee(int Zid)
            {
                return new AdminDataService().Get_Report_SalesPerformance_OnEmployee(Zid);
            }

            public static DataSet Get_Report_SalesPerformanceForBookSet(int SZID, int FY)
            {
                return new AdminDataService().Get_Report_SalesPerformanceForBookSet(SZID, FY);
            }

            public static DataSet Get_Report_SalesPerformanceForBookSet(int SZID, int FY, DateTime FromDate, DateTime ToDate)
            {
                return new AdminDataService().Get_Report_SalesPerformanceForBookSet(SZID, FY, FromDate, ToDate);
            }

            public static DataSet Get_Report_SalesPerformanceForDiscountParties(int SZID, int FY)
            {
                return new AdminDataService().Get_Report_SalesPerformanceForDiscountParties(SZID, FY);
            }

            public static DataSet Get_Report_SalesPerformanceForDiscountParties(int SZID, int FY, DateTime FromDate, DateTime ToDate)
            {
                return new AdminDataService().Get_Report_SalesPerformanceForDiscountParties(SZID, FY, FromDate, ToDate);
            }

            public static DataSet Get_Report_TargetAchievement(int SZID, int FY, DateTime FromDate, DateTime ToDate)
            {
                return new AdminDataService().Get_Report_TargetAchievement(SZID, FY, FromDate, ToDate);
            }

            public static DataSet Get_Report_TargetAchievement(int SZID, int FY, DateTime FromDate, DateTime ToDate, string Flag)
            {
                return new AdminDataService().Get_Report_TargetAchievement(SZID, FY, FromDate, ToDate, Flag);
            }

            public static DataSet Get_SalesAnalysis_PART_II(int SuperZone, int FY, DateTime fromdate, DateTime todate, int Zone, string flag, int SDZone)
            {
                return new AdminDataService().Get_SalesAnalysis_PART_II(SuperZone, FY, fromdate, todate, Zone, flag, SDZone);
            }

            public static DataSet Get_SalesAnalysisReport(int SuperZone)
            {
                return new AdminDataService().Get_SalesAnalysisReport(SuperZone);
            }

            public static DataSet Get_SalesAnalysisReport(int SuperZone, int FY)
            {
                return new AdminDataService().Get_SalesAnalysisReport(SuperZone, FY);
            }

            public static DataSet Get_SalesAnalysisReport(int SuperZone, int FY, DateTime fromdate, DateTime todate)
            {
                return new AdminDataService().Get_SalesAnalysisReport(SuperZone, FY, fromdate, todate);
            }

            public static DataSet Get_SalesAnalysisReport(int SuperZone, int FY, DateTime fromdate, DateTime todate, int Zone)
            {
                return new AdminDataService().Get_SalesAnalysisReport(SuperZone, FY, fromdate, todate, Zone);
            }

            public static DataSet Get_SalesAnalysisReport(int SuperZone, int FY, DateTime fromdate, DateTime todate, int Zone, string flag)
            {
                return new AdminDataService().Get_SalesAnalysisReport(SuperZone, FY, fromdate, todate, Zone, flag);
            }

            public static DataSet Get_SalesAnalysisReport(int SuperZone, int FY, DateTime fromdate, DateTime todate, int Zone, string flag, int SDZone, string CustCateID)
            {
                return new AdminDataService().Get_SalesAnalysisReport(SuperZone, FY, fromdate, todate, Zone, flag, SDZone, CustCateID);
            }

            public static DataSet Get_Summary_SalesAnalysis(int SuperZone, int FY, int Zone, string flag)
            {
                return new AdminDataService().Get_Summary_SalesAnalysis(SuperZone, FY, Zone, flag);
            }

            public static DataTable GetDashboard()
            {
                return new AdminDataService().GetDashboard();
            }

            public static DataTable GetDashboardgrid()
            {
                return new AdminDataService().GetDashboardgrid();
            }

            public static DataTable GetDashboardhelpdesk(string flag)
            {
                return new AdminDataService().GetDashboardhelpdesk2(flag);
            }

            public static DataTable GetDashboardhelpdesk2(string flag)
            {
                return new AdminDataService().GetDashboardhelpdesk2(flag);
            }

            public static DataSet GetDashboardRemarks(InquiryDetail eq)
            {
                string tktNumber = eq.TktNumber;
                return new AdminDataService().GetRemarksDashBoard(tktNumber);
            }

            public static DataSet TempData(int SZID, int FY, DateTime FromDate, DateTime ToDate)
            {
                return new AdminDataService().TempData(SZID, FY, FromDate, ToDate);
            }
        }
    }
}

