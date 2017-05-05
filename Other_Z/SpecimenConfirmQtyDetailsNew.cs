using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Other_Z
{
   public class SpecimenConfirmQtyDetailsNew: Idv.Chetana.DAL.DataServiceBase
    {
        public int Doc_no { get; set; }
        public decimal SubDocNo { get; set; }
        public string EmpId { get; set; }
        public string Createdby { get; set; }
        public string XML { get; set; }
        public string R1 { get; set; }

        public void Save()
        {
            ExecuteDataSet("Idv_Chetana_Save_SpecimenConfirmQtyDetails_by_xml",
                  CreateParameter("@Doc_no", SqlDbType.Int, Doc_no),
                  CreateParameter("@SubDocNo", SqlDbType.Decimal, SubDocNo),
                  CreateParameter("@EmpID", SqlDbType.NVarChar, EmpId),
                  CreateParameter("@Createdby", SqlDbType.NVarChar, Createdby),
                  CreateParameter("@XML", SqlDbType.Xml, XML),
                  CreateParameter("@R1", SqlDbType.NVarChar,R1));
        }



    }
}
