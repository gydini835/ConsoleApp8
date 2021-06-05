using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using ExchangeSharp;
using System.Diagnostics;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;
namespace ConsoleApp8
{
    class MarkenSymbolOption 
    {
		public async static void RunComand(TelegramBotClient client, long id, Class1 e)
		{
			var api = ExchangeAPI.GetExchangeAPI(e.ExshangeName);


			var marketSymbols = await api.GetMarketSymbolsAsync();
			List<string> list = new List<string>();

			foreach (var i in marketSymbols)
			{

				var inlineKeyboard = new InlineKeyboardMarkup(new[] { new[] { InlineKeyboardButton.WithCallbackData(i, i + " 3" + " " + e) } });
				await client.SendTextMessageAsync(id, "-->", replyMarkup: inlineKeyboard);

			}


		}
	
	}
}
