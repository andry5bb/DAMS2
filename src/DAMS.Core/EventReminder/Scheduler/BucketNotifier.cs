namespace DAMS.EventReminder.Scheduler
{
    public class BucketNotifier :  IBucketNotifier
    {
        public void NotifyForAll(NotificationBucket notificationBucket) 
        {
            foreach(var item in notificationBucket.NextEvents)
            {
                item.Notify();
                PostProcessNotification(item);
            }
        }
        private void PostProcessNotification(IEvent eventas) 
        {
        }
    }
}
