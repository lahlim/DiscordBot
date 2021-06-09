using System;
using System.IO;
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

            System.Console.WriteLine();
            MainAsync().GetAwaiter().GetResult();
        }
        internal static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = GetToken(),
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

        /**
        Gets token from file that is gitignored
        */
        public static string GetToken()
        {
            // Create a file called "token.txt" and insert token in that file.
            // REMEMBER TO ADD IT TO GITIGNORE
            return File.ReadAllText(@"token.txt");
        }

    }
}
