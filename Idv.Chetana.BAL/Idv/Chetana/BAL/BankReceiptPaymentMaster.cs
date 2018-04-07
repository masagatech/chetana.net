namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class BankReceiptPaymentMaster
    {
        private int _AccDocumentNo = Constants.NullInt;
        private DateTime _AccDocumentDate = Constants.NullDateTime;
        private string _ReceiptPayment = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private int _DocNo = Constants.NullInt;

        public void Save(out int _DocNo)
        {
            this.Save(null, out _DocNo);
        }

        public void Save(IDbTransaction txn, out int _DocNo)
        {
            new AdminDataService_DC().SaveBankReceiptPaymentMaster(this._AccDocumentNo, this._AccDocumentDate, this._ReceiptPayment, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy, out _DocNo);
        }

        public int AccDocumentNo
        {
            get
            {
                return this._AccDocumentNo;
            }
            set
            {
                this._AccDocumentNo = value;
            }
        }

        public DateTime AccDocumentDate
        {
            get
            {
                return this._AccDocumentDate;
            }
            set
            {
                this._AccDocumentDate = value;
            }
        }

        public string ReceiptPayment
        {
            get
            {
                return this._ReceiptPayment;
            }
            set
            {
                this._ReceiptPayment = value;
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
    }
}

