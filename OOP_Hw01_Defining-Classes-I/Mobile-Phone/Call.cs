using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MobilePhone
{
    class Call
    {
        private DateTime timeOfCall;
        private string dialledNumber;
        private uint callDuration = 0;              //in seconds
        internal static bool inCall;

        //write-protected
        public DateTime TimeOfCall
        {
            get { return this.timeOfCall; }
            private set { this.timeOfCall = value; }
        }

        //write-protected
        public string DialledNumber
        {
            get { return this.dialledNumber; }
            private set
            {
                if (!Regex.Match(value.Trim(), @"^\+?\d+([\-/ \.]?\d+)*$").Success)
                {
                    throw new FormatException
                        ("Phone number value is not a valid phone number. " +
                        "Valid phone number begins with an optional '+' (plus) and consists of groups of digits, " +
                        "optionally delimited by ' ' (space), '.' (dot), '-' (hyphen) or '/' (slash)");
                }
                this.dialledNumber = value.Trim();
            }
        }

        //write-protected
        public uint CallDuration
        {
            get { return this.callDuration; }
            private set
            {
                if (value == 0)
                {
                    throw new InvalidOperationException("The call duration can not be 0");
                }
                this.callDuration = value;
            }
        }

        //default constructor (phone number required)
        public Call(string number)
        {
            if (Call.inCall)
            {
                throw new InvalidOperationException
                    ("New call can not be made until the current call ends (are you missing a method call?)");
            }
            Call.inCall = true;
            this.TimeOfCall = DateTime.Now;
            this.DialledNumber = number;
        }

        //restricted access full constructor
        internal Call(string number, DateTime timeOfCall, uint callDuration)
        {
            this.TimeOfCall = timeOfCall;
            this.DialledNumber = number;
            this.CallDuration = callDuration;
            //don't need to check/alter anything - it creates a finished call object
        }

        //call finalizing method
        public void EndCall()
        {
            if (!Call.inCall)
            {
                throw new InvalidOperationException("The call was already finalized");
            }
            Call.inCall = false;
            this.CallDuration = (uint)(DateTime.Now - this.TimeOfCall).TotalSeconds;
            //note that uint type is smaller than the double type, which TotalSeconds return
            //for the pruposes of the mobile phone, though, assume that a uint call duration is enaugh
            //a BigInteger struct can be used if desired
        }

        //ToString() override
        public override string ToString()
        {
            StringBuilder infoDump = new StringBuilder();
            string formatString = "{0}: {1}\n";

            infoDump.AppendFormat(formatString, "Dialled number", this.DialledNumber);
            infoDump.AppendFormat(formatString, "Start time of call", this.TimeOfCall);
            infoDump.AppendFormat(formatString, "Call duration", this.CallDuration + " secs");

            return infoDump.ToString().Trim();
        }
    }
}
