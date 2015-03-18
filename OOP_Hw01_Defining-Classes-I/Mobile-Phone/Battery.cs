using System;

namespace MobilePhone
{
    class Battery
    {
        private string model;
        private BatteryType type;
        //in order to successfully return the time intervals being busy and idle, any phone should store its
        //last boot/start-up time, busy time and whether the phone is switched on or not
        private DateTime lastBoot;      //session-static data
        private bool switchedOn;        //session flag
        private TimeSpan talkTime;      //session-dynamic data
        

        //read-write
        public string Model
        {
            get { return this.model; }
            set
            {
                if (value == null)
                {
                    throw new FormatException
                        ("'Model' property value can not be null");
                }
                this.model = value;
            }
        }

        //read-write
        public BatteryType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        //read-only
        public bool SwitchedOn
        {
            get { return this.switchedOn; }
        }

        //write-protected
        public DateTime LastBoot
        {
            get
            {
                //state validation
                if (!switchedOn)
                {
                    throw new InvalidOperationException
                        ("The 'LastBoot' value can not be retrieved on a switched-off system");
                }
                return this.lastBoot;
            }
            //setter is targetted to the inner logic
            private set
            {
                //state validation
                if (!switchedOn)
                {
                    throw new InvalidOperationException
                        ("The 'LastBoot' value can not be set on a switched-off system");
                }
                this.lastBoot = value;
            }
        }

        //read-only
        public TimeSpan SessionTime
        {
            get
            {
                //state validation
                if (!switchedOn)
                {
                    throw new InvalidOperationException
                        ("The 'SessionTime' value can not be retrieved on a switched-off system");
                }
                //direct field access after state validation
                return DateTime.Now - this.lastBoot;
            }
        }

        //write-protected
        public TimeSpan TalkTime
        {
            get
            {
                //state validation
                if (!switchedOn)
                {
                    throw new InvalidOperationException
                        ("The 'TaklTime' value can not be retrieved on a switched-off system");
                }
                return this.talkTime;
            }
            //setter is targetted to the inner logic, thus the presence of bound checks is not critical, but is recommended
            private set
            {
                if (!switchedOn)
                {
                    throw new InvalidOperationException
                        ("The 'TaklTime' value can not be set on a switched-off system");
                }
                //direct field access after state validation
                if (value < this.talkTime || value > (DateTime.Now - this.lastBoot))
                {
                    throw new InvalidOperationException
                        ("The value to be set must be greater than the current 'TalkTime' value," +
                        "still not exceeding the total session time");
                }
                this.talkTime = value;
            }
        }

        //read-only
        public TimeSpan IdleTime
        {
            get
            {
                //state validation
                if (!switchedOn)
                {
                    throw new InvalidOperationException
                        ("The 'IdleTime' value can not be retrieved on a switched-off system");
                }
                //indirect field access via properties = redundant state validations
                return this.SessionTime - this.TalkTime;
            }
        }

        //default (opt params) constructor
        public Battery(string model = GSM.NA, BatteryType type = BatteryType.NA) : this(false, model, type)
        { }

        //full constructor (switch-on the battery)
        public Battery(bool switchOn, string model = GSM.NA, BatteryType type = BatteryType.NA)
        {
            if (switchOn)
            {
                this.SwitchOn();
            }
            this.Model = model;
            this.Type = type;
        }

        public void SwitchOn()
        {
            //if already switched-on - break
            if (this.SwitchedOn)
            {
                throw new InvalidOperationException
                    ("The system is already switched-on. " +
                    "Make sure you perform explicit check of the system state before switching on or off");
            }
            this.switchedOn = true;         //switchedOn field is directly manipulated
            this.LastBoot = DateTime.Now;
            this.TalkTime = new TimeSpan(0);
        }

        public void SwitchOff()
        {
            //if already switched-off - break; non-critical check - can be omitted
            if (!this.SwitchedOn)
            {
                throw new InvalidOperationException
                    ("The system is already switched-off. " +
                    "Make sure you perform explicit check of the system state before switching on or off");
            }
            //all fields manipulated directly due to switch-off operation
            this.switchedOn = false;
            this.lastBoot = DateTime.MinValue;
            this.talkTime = new TimeSpan(0);
        }
    }

    public enum BatteryType
    {
        NA,                 //no type
        LithiumIon,         //LiIon
        LithiumPolymer,     //LiPoly
        NickelCadmium,      //NiCd
        NickelMetalHydrid   //NiMH
    }
}
