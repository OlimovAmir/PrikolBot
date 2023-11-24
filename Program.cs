
using PRTelegramBot.Core;

const string EXIT_COMMAND = "exit";

var telegram = new PRBot(option =>
{
    option.Token = "6596108797:AAEYt947sJtftpQeiFI-QuVEM8UEatzB6vM";
    option.ClearUpdatesOnStart = true;
    option.WhiteListUsers = new List<long>() {};
    option.Admins = new List<long>() {};
    option.BotId = 0;
});

while (true)
{
    var result = Console.ReadLine();
    if (result.ToLower() == EXIT_COMMAND)
    {
        Environment.Exit(0);
    }
}
