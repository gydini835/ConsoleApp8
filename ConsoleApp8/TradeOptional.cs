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
	class TradeOptional
	{
		public async static void RunComand(TelegramBotClient client, long id, Class1 e)
		{
			var api = ExchangeAPI.GetExchangeAPI(e.ExshangeName);

			IEnumerable<KeyValuePair<string, ExchangeTicker>> tickers;
			if (!string.IsNullOrWhiteSpace(e.MarketSymbol))
			{
				var ticker = await api.GetTickerAsync(e.MarketSymbol);
				tickers = new List<KeyValuePair<string, ExchangeTicker>>
					{
						new KeyValuePair<string, ExchangeTicker>(e.MarketSymbol, ticker)
					};
			}
			else
			{
				tickers = await api.GetTickersAsync();
			}

			foreach (var ticker in tickers)
			{

				await client.SendTextMessageAsync(id,"Trade is" ticker.ToString());
			}



		}
	}
}
