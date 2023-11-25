using PRTelegramBot.Attributes;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace PrikolBot
{
    public class Commands
    {
        [ReplyMenuHandler(true, "Привет", "Салом", "hi", "Салам")]
        public static async Task Excample(ITelegramBotClient botClient, Update update)
        {
            // Получаем идентификатор чата
            long chatId = update.Message.Chat.Id;
            string senderName = GetFirstName(update.Message.From);
            // Формируем сообщение с приветствием
            var greetingText = $"Салам алейкум, как я могу помочь вам сегодня? {senderName}";

            // Создаем объект ReplyKeyboardMarkup для клавиатуры
            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
               {
                    new KeyboardButton[] { "Как дела?", "Пока" },
                        // Дополнительные кнопки могут быть добавлены по аналогии
                });
            replyKeyboardMarkup.ResizeKeyboard = true;

            // Отправляем сообщение с клавиатурой
            await botClient.SendTextMessageAsync(chatId, greetingText, replyMarkup: replyKeyboardMarkup);

            // Получаем имя отправителя
            //string senderName = GetFirstName(update.Message.From);

            // Формируем сообщение с именем отправителя
            ///var personalMessage = $"Салам алейкум, {senderName}";

            // Отправляем персональное сообщение
            //var senMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, personalMessage);
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
            var farewellMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message);
        }

        // Метод для получения имени отправителя
        private static string GetFirstName(User user)
        {
            return user.FirstName;
        }
    }
}
