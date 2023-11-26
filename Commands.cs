using PRTelegramBot.Attributes;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using PRTelegramBot.Attributes;

namespace PrikolBot
{
    public class Commands

    {
        [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
        public sealed class CallbackQueryHandlerAttribute : Attribute
        {
            public string Command { get; }

            public CallbackQueryHandlerAttribute(string command)
            {
                Command = command;
            }
        }
        [ReplyMenuHandler(true, "Привет", "Салом", "hi", "Салам")]
        public static async Task Excample(ITelegramBotClient botClient, Update update)
        {
            long chatId = update.Message.Chat.Id;
            string senderName = GetFirstName(update.Message.From);

            var greetingText = $"Салам алейкум, как я могу помочь вам сегодня, {senderName}?";

            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Как дела?", "how_are_you"),
                InlineKeyboardButton.WithCallbackData("Пока", "goodbye"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Контакты", "contacts"),
                InlineKeyboardButton.WithCallbackData("Разделы", "sections"),
            },
        });

            var message = await botClient.SendTextMessageAsync(chatId, greetingText, replyMarkup: inlineKeyboard);
        }

        [CallbackQueryHandler("how_are_you")]
        public static async Task HowAreYouCallback(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            string senderName = GetFirstName(callbackQuery.From);
            var message = $"Нормально, у тебя как, {senderName}?";
            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, message);
        }

        [CallbackQueryHandler("goodbye")]
        public static async Task GoodbyeCallback(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            string senderName = GetFirstName(callbackQuery.From);
            var message = $"До свидания, {senderName}! Если у вас есть еще вопросы, не стесняйтесь задавать.";
            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, message);
        }

        // Добавьте обработчики для "contacts" и "sections" по аналогии

        private static string GetFirstName(User user)
        {
            return user.FirstName;
        }
    }
}
