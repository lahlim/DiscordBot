using System;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;
using Microsoft.Extensions.Logging;


namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine();
            MainAsync().GetAwaiter().GetResult();
        }
        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = GetToken(),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged,
                MinimumLogLevel = LogLevel.Debug
            });
            CurseFeature(discord);

            await discord.ConnectAsync();
            await Task.Delay(-1);

        }

        /**
        Coursing feature for the bot
        */
        public static void CurseFeature(DiscordClient discord)
        {
            discord.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.ToLower().StartsWith("!kiroile"))
                {
                    await e.Message.RespondAsync(GetCurseword() + "!");
                }
            };
        }
        /**
        Returns random curseword from hardcoded list
        */
        public static string GetCurseword()
        {
            string[] curses = { "Vittu", "Saatana", "Helvetti", "Paska", "Perse" };
            Random rd = new Random();
            int index = rd.Next(curses.Length);
            string curese = curses[index];
            index = rd.Next(curses.Length);
            return curese;
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
