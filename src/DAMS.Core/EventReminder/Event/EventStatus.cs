using System;
using System.Collections.Generic;
using System.Text;

namespace DAMS.EventReminder.Event
{
    public enum EventStatus
    {
        None,
        Active,
        Closed,
        OnRepetition,
        Failed
    }
}
