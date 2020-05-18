using System;
using System.Collections.Generic;
using System.Text;

namespace DAMS.EventReminder.Notifier
{
    public struct NotificationResult
    {
        public bool IsSuccess { get; set; }
        public string Details { get; set; }
    }
}
