using DAMS.EventReminder;
using DAMS.EventReminder.Notifier;
using DAMS.Telegram;


namespace DAMS.NotificationSystems.All.Telegram
{ 
    public class TelegramNotifier : INotifier
    { 
        public NotificationResult Notify(EventInfo eventInfo)
        {
            TextMessenger textMessange = new TextMessenger();
            NotificationResult result = new NotificationResult();
            try
            { 
                textMessange.SendMyMessage(eventInfo.EventName + "  " + eventInfo.EventDate);
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
                textMessange.BotFirstWriteMessage(chat_id, eventInfo.EventName + "  " + eventInfo.EventDate);

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
