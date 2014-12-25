using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcordyaPayee.Data.Entity
{
    public enum RecurringRepeatBy
    {
        Weekly=1,
        Monthly,
        Annually
    }

    public enum RecurringEndsBy
	{
	    NeverStop=1,
        AfterNTimes,
        OnParticularDate
	}

    public enum RepeatOnTypes
	{
        DayOfWeek=1,
        DayOfMonth
	}

    public class RecurringSetting
    {
        public string Id { get; set; }
        public RecurringRepeatBy RepeatBy{ get; set; }
        //every .. month/week
        public int Interval { get; set; }
        public RepeatOnTypes RepeatOn { get; set; }
        public DateTime StartDate { get; set; }
        public RecurringEndsBy EndsBy { get; set; }
        //end on a particular date
        public DateTime EndDate { get; set; }
        //end on N instance of recurrence.
        public int EndOnTimes { get; set; }

    }
}
