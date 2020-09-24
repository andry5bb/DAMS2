using DAMS.EventReminder;
using DAMS.EventReminder.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAMS.Models
{
    public class CustomEventDate
    {
        public int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual EventStatus Status { get; set; }
        public virtual int CustomEventModelId { get; set; } // зовнішній ключ
       // [ForeignKey("CustomEventFk")]
        public virtual CustomEventModel CustomEventModel { get; set; } // навігаційне властивість
    }
}
