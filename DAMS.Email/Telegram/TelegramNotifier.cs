using DAMS.EventReminder;
using DAMS.EventReminder.Notifier;
using DAMS.Telegram;

namespace DAMS.NotificationSystems.All.Telegram
{
    public class TelegramNotifier : INotifier
    {
        private string GetMessageContent(NotificationInfo eventInfo)
        {
            string message = eventInfo.EventName + "  " + eventInfo.EventDate;
            return message;
        }

        public NotificationResult Notify(NotificationInfo notificationInfo)
        {
            TextMessenger messenger = new TextMessenger();
            NotificationResult result = new NotificationResult();

            try
            {
                messenger.SendMessage(GetMessageContent(notificationInfo));
                result.IsSuccess = true;
            }
            catch
            {
                result.Details = "Error";
            }
            return result;
        }

        public NotificationResult Notify(NotificationInfo eventInfo, string chat_id)
        {
            TextMessenger textMessange = new TextMessenger();
            NotificationResult result = new NotificationResult();
            try
            {
                textMessange.PushMessage(chat_id, GetMessageContent(eventInfo));

                result.IsSuccess = true;
            }
            catch
            {
                result.Details = "Error";
            }
            return result;
        }
    }
}
