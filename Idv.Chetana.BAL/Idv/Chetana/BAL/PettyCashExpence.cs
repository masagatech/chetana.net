namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class PettyCashExpence
    {
        private int _Voucher_Detail = Constants.NullInt;
        private int _VoucherNo = Constants.NullInt;
        private string _ExpenseCode = Constants.NullString;
        private DateTime _Date = Constants.NullDateTime;
        private decimal _Amount = Constants.NullDecimal;
        private string _Remark = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private string _ExpenceName = Constants.NullString;

        public static DataSet Idv_Chetana_Get_Petty_Expence_View_by_VoucherNo(int VoucherNo)
        {
            return new AdminDataService_DC().Idv_Chetana_Get_Petty_Expence_View_by_VoucherNo(VoucherNo);
        }

        public void Save()
        {
            new AdminDataService_DC().SaveIdv_Chetana_PettyCashExpences(this._Voucher_Detail, this._VoucherNo, this._ExpenseCode, this._Date, this._Amount, this._Remark, this._CreatedOn, this._CreatedBy, this._UpdatedOn, this._UpdatedBy, this._IsActive, this._ExpenceName);
        }

        public int Voucher_Detail
        {
            get
            {
                return this._Voucher_Detail;
            }
            set
            {
                this._Voucher_Detail = value;
            }
        }

        public int VoucherNo
        {
            get
            {
                return this._VoucherNo;
            }
            set
            {
                this._VoucherNo = value;
            }
        }

        public string ExpenseCode
        {
            get
            {
                return this._ExpenseCode;
            }
            set
            {
                this._ExpenseCode = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                this._Date = value;
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

        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this._Remark = value;
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

        public string ExpenceName
        {
            get
            {
                return this._ExpenceName;
            }
            set
            {
                this._ExpenceName = value;
            }
        }
    }
}

