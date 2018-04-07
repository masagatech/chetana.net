namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Mappings
    {
        private int _AutoId = Constants.NullInt;
        private int _MenuId = Constants.NullInt;
        private int _RoleId = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private int _UserMenuMappId = Constants.NullInt;
        private string _GroupId = Constants.NullString;
        private bool _Add = Constants.NullBoolean;
        private bool _View = Constants.NullBoolean;
        private bool _Edit = Constants.NullBoolean;
        private bool _Delete = Constants.NullBoolean;
        private bool _Show = Constants.NullBoolean;

        public static DataSet Get_MenudisplayAndRole(int RoleId)
        {
            return new AdminDataService().GetMenudisplayAndRole(RoleId);
        }

        public static DataSet Get_MenuFunctions(int GroupId, int RoleID)
        {
            return new AdminDataService().GetMenuFunctions(GroupId, RoleID);
        }

        public static DataSet Get_MenuRoleMapping()
        {
            return new AdminDataService().GetMenuRoleMapping();
        }

        public static DataSet Get_MenuUsermapping(int RoleId)
        {
            return new AdminDataService().GetMenuUserMapping(RoleId);
        }

        public void Save()
        {
            new AdminDataService().Saverolemapping(this._AutoId, this._MenuId, this._RoleId, this._IsActive);
        }

        public void SaveMenu()
        {
            new AdminDataService().SaveMenuusermapping(this._UserMenuMappId, this._GroupId, this._MenuId, this._RoleId, this._Add, this._View, this._Edit, this._Delete, this._Show);
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

        public int RoleId
        {
            get
            {
                return this._RoleId;
            }
            set
            {
                this._RoleId = value;
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

        public int UserMenuMappId
        {
            get
            {
                return this._UserMenuMappId;
            }
            set
            {
                this._UserMenuMappId = value;
            }
        }

        public string GroupId
        {
            get
            {
                return this._GroupId;
            }
            set
            {
                this._GroupId = value;
            }
        }

        public bool Add
        {
            get
            {
                return this._Add;
            }
            set
            {
                this._Add = value;
            }
        }

        public bool View
        {
            get
            {
                return this._View;
            }
            set
            {
                this._View = value;
            }
        }

        public bool Edit
        {
            get
            {
                return this._Edit;
            }
            set
            {
                this._Edit = value;
            }
        }

        public bool Delete
        {
            get
            {
                return this._Delete;
            }
            set
            {
                this._Delete = value;
            }
        }

        public bool Show
        {
            get
            {
                return this._Show;
            }
            set
            {
                this._Show = value;
            }
        }
    }
}

