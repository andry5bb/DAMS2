using System;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using RestSharp;


namespace DAMS.Telegram
{
    class Program
    {
        static ITelegramBotClient botClient;//Оголошуємо телеграм клієнта
        //

        static void Main(string[] args)
        {//ініціалізуємо нашого бота, та в якості параметра передаємо конструктору токен бота DAMSbot
            botClient = new TelegramBotClient("1203508145:AAFYSqqz66zVYJ9xP5MU_kr0JwZDprIhiQE");

            MyMessage myMessage = new MyMessage();
            myMessage.BotFirstWriteMessage("BotFirstWrite");
            myMessage.SendMyMessage(botClient, "ghhghgh");
            Console.ReadKey();
            
        }

       
    }
       
    }

