using System;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;


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
                Intents = DiscordIntents.AllUnprivileged
            });

            discord.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.ToLower().StartsWith("julle"))
                    await e.Message.RespondAsync("on tosi gei");
                if (e.Message.Content.ToLower().StartsWith("vompa"))
                    await e.Message.RespondAsync("Vompalla on naisen kädet");
            };


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
