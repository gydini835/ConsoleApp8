using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;
using System.Collections.Generic;

namespace ConsoleApp8
{

    public static class Program
    {
        private static TelegramBotClient Bot;

        public static async Task Main()
        {

            Bot = new TelegramBotClient(Configuration.BotToken);
            await Bot.DeleteWebhookAsync();
            var me = await Bot.GetMeAsync();
            Console.Title = me.Username;

            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnMessageEdited += BotOnMessageReceived;
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;



            Bot.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($"Start listening for @{me.Username}");

            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            if (message == null || message.Type != MessageType.Text)
                return;

            switch (message.Text.Split(' ').First())
            {

                case "/inline":
                    await SendInlineKeyboard(message);
                    break;
                default:
                    await Usage(message);
                    break;
            }


            static async Task SendInlineKeyboard(Message message)
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                await Task.Delay(500);

                var inlineKeyboard = new InlineKeyboardMarkup(new[]
                {

                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Kraken", "Kraken"),
                        InlineKeyboardButton.WithCallbackData("Binance", "Binance"),
                    }
                });
                await Bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Choose",
                    replyMarkup: inlineKeyboard
                );
            }

            


            static async Task Usage(Message message)
            {
                const string usage = "Usage:\n" +
                                        
                                        "/keyboard - send custom keyboard\n" 
                                        ;
                await Bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: usage,
                    replyMarkup: new ReplyKeyboardRemove()
                );
            }
        }

       
        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;

            string[] words = callbackQuery.Data.Split(new char[] { ' ' });

            Class1 option = new Class1();

            var chatId = callbackQuery.Message.Chat.Id;
            if (words[0] == "Binance")
            {
                option.ExshangeName = "Binance";
                MarkenSymbolOption.RunComand(Bot, chatId, option);


                if (words[0] == "Kraken")
                {
                    option.ExshangeName = "Kraken";
                    MarkenSymbolOption.RunComand(Bot, chatId, option);

                }

                if (words[1] == "3")
                {
                    var inlineKeyboard = new InlineKeyboardMarkup(new[]
                     {

                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Trade", "Trade"+ " 4"),
                        InlineKeyboardButton.WithCallbackData("Candels", "Candels" + " 4"),
                    }
                });
                    await Bot.SendTextMessageAsync(
                       chatId: chatId,
                       text: "Choose",
                       replyMarkup: inlineKeyboard
                   );
                }
                if (words[0] == "Trade")
                {
                    option.Method = "Trade";
                    TradeOptional.RunComand(Bot, chatId, option);
                 
                }

                if (words[0] == "Candels")
                {
                    option.Method = "Candels";
                    CandlesOption.RunComand(Bot, chatId, option);
                    while (words[1] == "4")
                    {

                    }

                }

            }




        }
    }
}
