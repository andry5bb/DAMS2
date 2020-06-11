using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Threading;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using System.Net;
using RestSharp;
using DAMS.NotificationSystems.All;
using System.Configuration;

namespace DAMS.Telegram
{
    public class TextMessenger
    {
        static ITelegramBotClient client = new TelegramBotClient(ConfigurationManager.AppSettings["TelegramBotToken"]);
        public void SendMessage(string mytext)
        {
            client.OnMessage += BotClient_OnMessage;
            client.StartReceiving();

            async void BotClient_OnMessage(object sender, MessageEventArgs e)
            {
                var keyboard = new ReplyKeyboardMarkup();
                var buttons = new List<KeyboardButton[]>();
                var button = new List<KeyboardButton>();
                button.Add(new KeyboardButton(DefaultNames.one_time_event));
                button.Add(new KeyboardButton(DefaultNames.custom_event));
                button.Add(new KeyboardButton(DefaultNames.period_event));
                buttons.Add(button.ToArray());
                keyboard.Keyboard = buttons.ToArray();
                if (e.Message.Text != null)
                {
                    if (e.Message.Text == DefaultNames.one_time_event)
                    {
                        await client.SendTextMessageAsync
                        (
                        chatId: e.Message.Chat,
                        text: mytext,
                        replyMarkup: keyboard
                        );
                    }
                    if (e.Message.Text == DefaultNames.custom_event)
                    {
                        await client.SendTextMessageAsync
                        (
                        chatId: e.Message.Chat,
                        text: mytext,
                        replyMarkup: keyboard
                        );
                    }
                    if (e.Message.Text == DefaultNames.period_event)
                    {
                        await client.SendTextMessageAsync
                            (chatId: e.Message.Chat,
                            text: mytext,
                            replyMarkup: keyboard
                            );

                    }
                    await client.SendTextMessageAsync
                            (chatId: e.Message.Chat,
                            text: "Go!!!",
                            replyMarkup: keyboard
                            );
                }
            }
        }

        /// <summary>
        ///  Method that performs notifications via Telegram.
        /// </summary>
        /// <param name="chat_id">The ID of the chat to which the bot will send notifications. </param>
        /// <param name="text_message">Notification text.</param>
        public void PushMessage(string chat_id, string text_message)
        {
            var client = new RestClient(ConfigurationManager.AppSettings["RestClient"]);
            var request = new RestRequest(ConfigurationManager.AppSettings["Reguest"] + chat_id + "&text=" + text_message);
            client.Execute(request);
        }
    }
}
