using DAMS.EventReminder.Notifier;

namespace DAMS.EventReminder
{
    public interface INotifier
    {
        public NotificationResult Notify(NotificationInfo eventInfo);
    }
}