namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class ExpenseHead
    {
        private int _AutoId = Constants.NullInt;
        private string _ExpenseCode = Constants.NullString;
        private string _ExpenseName = Constants.NullString;
        private int _ExpenseType = Constants.NullInt;
        private int _ExpenseGroup = Constants.NullInt;
        private string _Description = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDelete = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private string _Type = Constants.NullString;
        private string _Group = Constants.NullString;

        public static DataSet GetExpenseHead()
        {
            return new AdminDataService().GetExpenseHead();
        }

        public void Save()
        {
            new AdminDataService().SaveExpenseHead(this._AutoId, this._ExpenseCode, this._ExpenseName, this._ExpenseType, this._ExpenseGroup, this._Description, this._IsActive, this._IsDelete, this._CreatedBy, this._Type, this._Group);
        }

        public int AutoId
        {
            get
            {
                return this._AutoId;
            }
            set
            {
                this._AutoId = value;
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

        public string ExpenseName
        {
            get
            {
                return this._ExpenseName;
            }
            set
            {
                this._ExpenseName = value;
            }
        }

        public int ExpenseType
        {
            get
            {
                return this._ExpenseType;
            }
            set
            {
                this._ExpenseType = value;
            }
        }

        public int ExpenseGroup
        {
            get
            {
                return this._ExpenseGroup;
            }
            set
            {
                this._ExpenseGroup = value;
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

        public bool IsDelete
        {
            get
            {
                return this._IsDelete;
            }
            set
            {
                this._IsDelete = value;
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

        public string Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                this._Type = value;
            }
        }

        public string Group
        {
            get
            {
                return this._Group;
            }
            set
            {
                this._Group = value;
            }
        }
    }
}

