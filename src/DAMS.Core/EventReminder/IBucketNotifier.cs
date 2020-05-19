using DAMS.EventReminder.Scheduler;

namespace DAMS.EventReminder
{
    public interface IBucketNotifier
    {
        void NotifyForAll(NotificationBucket notificationBucket);
    }
}
