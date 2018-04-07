namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using System;

    public class SetDDLVisibility
    {
        private bool _ddlSDZone = Constants.NullBoolean;
        private bool _ddlSZone = Constants.NullBoolean;
        private bool _ddlZone = Constants.NullBoolean;
        private int _DDlSdzIDValue = Constants.NullInt;
        private int _DDlSzIDValue = Constants.NullInt;
        private int _DDlZIDValue = Constants.NullInt;

        public void fillProp(string level, string values)
        {
            this._DDlSdzIDValue = Convert.ToInt32(values.Split(new char[] { '~' })[0].ToString());
            this._DDlSzIDValue = Convert.ToInt32(values.Split(new char[] { '~' })[1].ToString());
            this._DDlZIDValue = Convert.ToInt32(values.Split(new char[] { '~' })[2].ToString());
            if (level == "1")
            {
                this._ddlSDZone = true;
                this._ddlSZone = true;
                this._ddlZone = true;
            }
            else if (level == "2")
            {
                this._ddlSDZone = false;
                this._ddlSZone = true;
                this._ddlZone = true;
            }
            else if (level == "3")
            {
                this._ddlSDZone = false;
                this._ddlSZone = false;
                this._ddlZone = true;
            }
            else if (level == "4")
            {
                this._ddlSDZone = false;
                this._ddlSZone = false;
                this._ddlZone = false;
            }
            else
            {
                this._ddlSDZone = true;
                this._ddlSZone = true;
                this._ddlZone = true;
            }
        }

        public bool DdlSDZone
        {
            get
            {
                return this._ddlSDZone;
            }
            set
            {
                this._ddlSDZone = value;
            }
        }

        public bool DdlSZone
        {
            get
            {
                return this._ddlSZone;
            }
            set
            {
                this._ddlSZone = value;
            }
        }

        public bool DdlZone
        {
            get
            {
                return this._ddlZone;
            }
            set
            {
                this._ddlZone = value;
            }
        }

        public int DDlSdzIDValue
        {
            get
            {
                return this._DDlSdzIDValue;
            }
            set
            {
                this._DDlSdzIDValue = value;
            }
        }

        public int DDlSzIDValue
        {
            get
            {
                return this._DDlSzIDValue;
            }
            set
            {
                this._DDlSzIDValue = value;
            }
        }

        public int DDlZIDValue
        {
            get
            {
                return this._DDlZIDValue;
            }
            set
            {
                this._DDlZIDValue = value;
            }
        }
    }
}

