using DAMS.EventReminder;
using DAMS.EventReminder.Notifier;
using DAMS.Telegram;

namespace DAMS.NotificationSystems.All.Telegram
{ 
    public class TelegramNotifier : INotifier
    { private string MessageContent(EventInfo eventInfo)
        {
            string message = eventInfo.EventName + "  " + eventInfo.EventDate;
            return message;
        }
        public NotificationResult Notify(EventInfo eventInfo)
        {
            TextMessenger messenger = new TextMessenger();
            NotificationResult result = new NotificationResult();
            
            try
            {
                messenger.SendMyMessage(MessageContent(eventInfo)); 
                result.IsSuccess = true;
            }
            catch
            {
                result.Details = "Error";
            }
            return result;
        }
        public NotificationResult Notify(EventInfo eventInfo, string chat_id)
        {
            TextMessenger textMessange = new TextMessenger();
            NotificationResult result = new NotificationResult();
            try
            {
                textMessange.PushMessage(chat_id, MessageContent(eventInfo));

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
