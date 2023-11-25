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
            // Получаем имя отправителя
            string senderName = GetFirstName(update.Message.From);

            // Формируем сообщение с именем отправителя
            var message = $"Салам алейкум, {senderName}";

            // Отправляем сообщение
            var senMessage = await PRTelegramBot.Helpers.Message.Send(botClient,update, message);
        }

        [ReplyMenuHandler(true, "Как дела?", "Как дела", "Как ты?", "Как ты")]
        public static async Task HowAreYou(ITelegramBotClient botClient, Update update)
        {
            // Получаем имя отправителя
            string senderName = GetFirstName(update.Message.From);

            // Формируем сообщение с вопросом о делах
            var message = $"Нормально, у тебя как, {senderName}?";

            // Отправляем вопрос
            var senMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message);
        }

        [ReplyMenuHandler(true, "Пока", "До свидания", "Goodbye")]
        public static async Task Goodbye(ITelegramBotClient botClient, Update update)
        {
            // Получаем имя отправителя
            string senderName = GetFirstName(update.Message.From);

            // Формируем сообщение с прощанием
            var message = $"До свидания, {senderName}! Если у вас есть еще вопросы, не стесняйтесь задавать.";

            // Отправляем прощание
            var senMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message);
        }

        // Метод для получения имени отправителя
        private static string GetFirstName(User user)
        {
            return user.FirstName;
        }
    }
}
