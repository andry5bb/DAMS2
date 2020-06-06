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

namespace DAMS.Telegram
{
    public class TextMessenger
    {
        static ITelegramBotClient client = new TelegramBotClient("1203508145:AAFYSqqz66zVYJ9xP5MU_kr0JwZDprIhiQE");

        public void SendMyMessage(string mytext)
        {
            client.OnMessage += BotClient_OnMessage;
            client.StartReceiving();
            Thread.Sleep(int.MaxValue);
            client.OnMessage += BotClient_OnMessage;

            async void BotClient_OnMessage(object sender, MessageEventArgs e)
            {
                var keyboard = new ReplyKeyboardMarkup();
                var buttons = new List<KeyboardButton[]>();
                var button = new List<KeyboardButton>();
                button.Add(new KeyboardButton("My one time event"));
                button.Add(new KeyboardButton("My custon event"));
                button.Add(new KeyboardButton("My period event"));
                buttons.Add(button.ToArray());
                keyboard.Keyboard = buttons.ToArray();
                if (e.Message.Text != null)
                {
                    if (e.Message.Text == "My one time event")
                    {
                        await client.SendTextMessageAsync
                        (
                        chatId: e.Message.Chat,
                        text: mytext,
                        replyMarkup: keyboard
                        );
                    }
                    if (e.Message.Text == "My custon event")
                    {
                        await client.SendTextMessageAsync
                        (
                        chatId: e.Message.Chat,
                        text: mytext,
                        replyMarkup: keyboard
                        );
                    }
                    if (e.Message.Text == "My period event")
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
        public void BotFirstWriteMessage(string chat_id, string text_message)
        {
            var client = new RestClient("https://api.telegram.org");
            var request = new RestRequest("https://api.telegram.org/bot1203508145:AAFYSqqz66zVYJ9xP5MU_kr0JwZDprIhiQE/sendMessage?chat_id=" + chat_id + "&text=" + text_message);
            client.Execute(request);

        }

    }
}
