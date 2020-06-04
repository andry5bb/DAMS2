﻿using DAMS.EventReminder.Notifier;

namespace DAMS.EventReminder
{
    public interface INotifier
    {
        NotificationResult Notify(EventInfo eventInfo);
    }
}