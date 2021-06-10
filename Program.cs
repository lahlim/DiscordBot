using System.Threading.Tasks;
using DSharpPlus;
using Microsoft.Extensions.Logging;
using DSharpPlus.CommandsNext;


namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Services.WatherService.GetWeather();
            MainAsync().GetAwaiter().GetResult();
        }
        internal static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = DiscordBot.Services.AppServices.GetAppSetting("token"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged,
                MinimumLogLevel = LogLevel.Debug
            });
            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!" }
            });

            commands.RegisterCommands<BasicCommandModule>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }




    }
}
