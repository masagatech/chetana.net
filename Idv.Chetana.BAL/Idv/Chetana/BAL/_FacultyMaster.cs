namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class _FacultyMaster
    {
        private int _Fct_ID = Constants.NullInt;
        private string _Name = Constants.NullString;
        private string _Schl_Name = Constants.NullString;
        private string _Res_Add = Constants.NullString;
        private string _Pincode = Constants.NullString;
        private string _Contact = Constants.NullString;
        private string _Res_No = Constants.NullString;
        private string _Qualification = Constants.NullString;
        private string _Tch_Exp = Constants.NullString;
        private string _Spec_Sub = Constants.NullString;
        private string _Sub_Intrs_Wrt = Constants.NullString;
        private string _Prvs_Exp_Wrt = Constants.NullString;
        private string _Pls_Mnt_bk_Pub = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private string _CreatedBy = Constants.NullString;
        private string _Remark1 = Constants.NullString;
        private string _Remark2 = Constants.NullString;
        private int _Fy = Constants.NullInt;
        private int _SDZ = Constants.NullInt;
        private int _SZ = Constants.NullInt;
        private int _Z = Constants.NullInt;

        public static DataSet Faculty_DetailsBySuperZoneID(string flag, string show, string sdz, string sz, string z, int fy)
        {
            return new AdminDataService_DC().Faculty_DetailsBySuperZoneID(flag, show, sdz, sz, z, fy);
        }

        public static DataSet Get_FacultyApproval(string flag, string show, string sdz, string sz, string z, int fy)
        {
            return new AdminDataService_DC().Get_FacultyApproval(flag, show, sdz, sz, z, fy);
        }

        public void Reject()
        {
            new AdminDataService_DC().RejectFaculty(this._Name);
        }

        public void Save()
        {
            new AdminDataService_DC().SaveFaculty(this._Fct_ID, this._Name, this._Schl_Name, this._Res_Add, this._Pincode, this._Contact, this._Res_No, this._Qualification, this._Tch_Exp, this._Spec_Sub, this._Sub_Intrs_Wrt, this._Prvs_Exp_Wrt, this._Pls_Mnt_bk_Pub, this._CreatedBy, this._UpdatedBy, this._Fy, this._Remark1, this._Remark2, this._SDZ, this._SZ, this._Z);
        }

        public void Update()
        {
            new AdminDataService_DC().UpdateFaculty(this._Name);
        }

        public int SDZ
        {
            get
            {
                return this._SDZ;
            }
            set
            {
                this._SDZ = value;
            }
        }

        public int SZ
        {
            get
            {
                return this._SZ;
            }
            set
            {
                this._SZ = value;
            }
        }

        public int Z
        {
            get
            {
                return this._Z;
            }
            set
            {
                this._Z = value;
            }
        }

        public int Fct_ID
        {
            get
            {
                return this._Fct_ID;
            }
            set
            {
                this._Fct_ID = value;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        public string Schl_Name
        {
            get
            {
                return this._Schl_Name;
            }
            set
            {
                this._Schl_Name = value;
            }
        }

        public string Res_Add
        {
            get
            {
                return this._Res_Add;
            }
            set
            {
                this._Res_Add = value;
            }
        }

        public string Pincode
        {
            get
            {
                return this._Pincode;
            }
            set
            {
                this._Pincode = value;
            }
        }

        public string Contact
        {
            get
            {
                return this._Contact;
            }
            set
            {
                this._Contact = value;
            }
        }

        public string Res_No
        {
            get
            {
                return this._Res_No;
            }
            set
            {
                this._Res_No = value;
            }
        }

        public string Qualification
        {
            get
            {
                return this._Qualification;
            }
            set
            {
                this._Qualification = value;
            }
        }

        public string Tch_Exp
        {
            get
            {
                return this._Tch_Exp;
            }
            set
            {
                this._Tch_Exp = value;
            }
        }

        public string Spec_Sub
        {
            get
            {
                return this._Spec_Sub;
            }
            set
            {
                this._Spec_Sub = value;
            }
        }

        public string Sub_Intrs_Wrt
        {
            get
            {
                return this._Sub_Intrs_Wrt;
            }
            set
            {
                this._Sub_Intrs_Wrt = value;
            }
        }

        public string Prvs_Exp_Wrt
        {
            get
            {
                return this._Prvs_Exp_Wrt;
            }
            set
            {
                this._Prvs_Exp_Wrt = value;
            }
        }

        public string Pls_Mnt_bk_Pub
        {
            get
            {
                return this._Pls_Mnt_bk_Pub;
            }
            set
            {
                this._Pls_Mnt_bk_Pub = value;
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
    }
}

