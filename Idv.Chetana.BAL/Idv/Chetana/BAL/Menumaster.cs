namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Menumaster
    {
        private int _MenuId = Constants.NullInt;
        private string _MenuName = Constants.NullString;
        private string _Link = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;

        public static DataSet Get_Menu_By_Level_and_ParentID(int level, int parentID)
        {
            return new AdminDataService().Get_Menu_By_Level_and_ParentID(level, parentID);
        }

        public static DataTable Get_MenuList()
        {
            DataSet set = new DataSet();
            set = new AdminDataService().Get_MenuList();
            DataTable table = new DataTable();
            return set.Tables[0];
        }

        public static DataSet Get_MenuMaster()
        {
            return new AdminDataService().GetMenuMaster();
        }

        public static DataSet getMenu_By_RoleId(int Roleid, int MenuLevel, int ParentId)
        {
            return new AdminDataService().getMenu_By_RoleId(Roleid, MenuLevel, ParentId);
        }

        public void Save()
        {
            new AdminDataService().Savemenumaster(this._MenuId, this._MenuName, this._Link, this._IsActive, this._IsDeleted);
        }

        public int MenuId
        {
            get
            {
                return this._MenuId;
            }
            set
            {
                this._MenuId = value;
            }
        }

        public string MenuName
        {
            get
            {
                return this._MenuName;
            }
            set
            {
                this._MenuName = value;
            }
        }

        public string Link
        {
            get
            {
                return this._Link;
            }
            set
            {
                this._Link = value;
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
    }
}

