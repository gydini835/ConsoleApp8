using System;
using System.Collections.Generic;
using System.Text;
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
    class CandlesOption:Class1
    {
		public async static void RunComand(TelegramBotClient client, long id, Class1 c)
		{
			var api = ExchangeAPI.GetExchangeAPI(c.ExshangeName);


			var candles = await api.GetCandlesAsync(
                c.MarketSymbol,
				1800,
				CryptoUtility.UtcNow.AddDays(-12),
				CryptoUtility.UtcNow
			);

			candles.ToList();

			foreach (var i in candles)
			{

				await client.SendTextMessageAsync(id, "Candle is "+i.ToString());

			}


		}
	}
}
