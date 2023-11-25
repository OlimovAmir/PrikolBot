using PRTelegramBot.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PrikolBot
{
    public class Commands
    {
        [ReplyMenuHandler(true, "Привет", "Салом", "hi", "Салам")]
        public static async Task Excample(ITelegramBotClient botClient, Update update)
        {
            var message = "Салам алейкум ";
            var senMessage = await PRTelegramBot.Helpers.Message.Send(botClient,update, message);
        }
    }
}
