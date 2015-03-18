using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MobilePhone
{
    class GSM
    {
        private string manufacturer;
        private string model;
        private decimal price;
        private Person owner;
        private Battery battery;
        private Display display;
        //'Not Available' constant string value
        public const string NA = "[n/a]";
        private static GSM iPhone4S;

        #region call history block
        private List<Call> callHistory = new List<Call>();
        private BigInteger totalCallDuration = BigInteger.Zero;     //in seconds, like in this.CallDuration
        #endregion

        //read-write
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (value == null)
                {
                    throw new FormatException
                        ("'Manufacturer' property value can not be null");
                }
                this.manufacturer = value;
            }
        }

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
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("'Price' property value must be non-negative value");
                }
                this.price = value;
            }
        }

        //read-write
        public Person Owner
        {
            get { return this.owner; }
            set
            {
                if (value == null)
                {
                    throw new FormatException
                        ("'Owner' property value can not be null");
                }
                this.owner = value;
            }
        }

        //read-write
        public Battery Battery
        {
            get { return this.battery; }
            set
            {
                if (value == null)
                {
                    throw new FormatException
                        ("'Battery' property value can not be null");
                }
                this.battery = value;
            }
        }

        //read-write
        public Display Display
        {
            get { return this.display; }
            set
            {
                if (value == null)
                {
                    throw new FormatException
                        ("'Display' property value can not be null");
                }
                this.display = value;
            }
        }

        //read-write
        public static GSM IPhone4S
        {
            get { return GSM.iPhone4S; }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException
                        ("'IPhone4S' property value can not be null");
                }
                GSM.iPhone4S = value;
            }
        }

        //read-only (what's the idea of setting a call history as a whole? exploit?)
        public List<Call> CallHistory
        {
            get { return this.callHistory; }
        }

        //read-only
        public BigInteger TotalCallDuration
        {
            get { return this.totalCallDuration; }
        }

        //default (paramless) constructor
        public GSM()
            : this(GSM.NA, GSM.NA)
        { }

        //full constructor
        public GSM(string manufacturer, string model, decimal price = default(decimal),
            Person owner = null, Battery battery = null, Display display = null)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.Owner = owner ?? new Person();
            this.Battery = battery ?? new Battery();
            this.Display = display ?? new Display();
        }

        //append a call to the history
        public void AddCall(Call givenCall)
        {
            if (Call.inCall)
            {
                throw new InvalidOperationException
                    ("New calls can not be stored until they are closed (are you missing a method call?)");
            }
            this.callHistory.Add(givenCall);
            //update total duration
            this.totalCallDuration += givenCall.CallDuration;
        }

        //remove a call from history
        public void DeleteCall(int index)
        {
            if (this.callHistory.Count == 0)
            {
                throw new InvalidOperationException("The call history is empty");
            }
            if (index < 0 || index > (this.callHistory.Count - 1))
            {
                throw new ArgumentOutOfRangeException("The index is out of range");
            }
            //update total duration
            this.totalCallDuration -= this.callHistory[index].CallDuration;
            this.callHistory.RemoveAt(index);
        }

        //purge the history
        public void ClearAllCalls()
        {
            this.callHistory.Clear();
        }

        //calculate the total price
        public decimal CalculateCallPriceTotal(decimal pricePerMinute)
        {
            decimal price = ((decimal)this.totalCallDuration / 60m) * pricePerMinute;
            return decimal.Round(price, 3);
        }

        //retrieve the longest call index in history (if any)
        public int GetLongestCallIndex()
        {
            if (this.callHistory.Count == 0)
            {
                throw new InvalidOperationException("The call history is empty");
            }

            int longestCallIndex = 0;
            for (int i = 0; i < this.callHistory.Count; i++)
            {
                if (this.callHistory[i].CallDuration > this.callHistory[longestCallIndex].CallDuration)
                {
                    longestCallIndex = i;
                }
            }
            return longestCallIndex;
        }

        //ToString() override
        public override string ToString()
        {
            StringBuilder infoDump = new StringBuilder();
            string formatString = "Phone {0}: {1}\n";

            infoDump.AppendFormat(formatString, "manufacturer", this.Manufacturer);
            infoDump.AppendFormat(formatString, "model", this.Model);
            infoDump.AppendFormat(formatString, "price", this.Price + " Euro");

            Person phoneOwner = this.Owner;

            infoDump.AppendFormat(formatString, "owner name", phoneOwner.FirstName);
            infoDump.AppendFormat(formatString, "owner surname", phoneOwner.LastName);
            infoDump.AppendFormat(formatString, "owner company", phoneOwner.Company);

            Display phoneDisplay = this.Display;

            infoDump.AppendFormat(formatString, "display width", phoneDisplay.Width);
            infoDump.AppendFormat(formatString, "display height", phoneDisplay.Height);
            infoDump.AppendFormat(formatString, "display colors", phoneDisplay.NumberOfColors);
            infoDump.AppendFormat(formatString, "display pixels", phoneDisplay.PixelArea);

            Battery phoneBattery = this.Battery;

            infoDump.AppendFormat(formatString, "battery model", phoneBattery.Model);
            infoDump.AppendFormat(formatString, "battery type", string.Format("{0} ({1})", phoneBattery.Type, (int)phoneBattery.Type));

            if (phoneBattery.SwitchedOn)
            {
                infoDump.AppendFormat(formatString, "start-up", string.Format("{0:yyyy.MM.dd HH:mm:ss}", phoneBattery.LastBoot));
                infoDump.AppendFormat(formatString, "total uptime", phoneBattery.SessionTime);
                infoDump.AppendFormat(formatString, "time busy", phoneBattery.TalkTime);
                infoDump.AppendFormat(formatString, "time idle", phoneBattery.IdleTime);
            }
            else
            {
                infoDump.AppendLine("Phone switched-off");
            }
            return infoDump.ToString().Trim();
        }
    }
}
