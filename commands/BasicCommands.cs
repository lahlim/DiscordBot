using System;

using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext.Attributes;

public class BasicCommandModule : BaseCommandModule
{
    [Command("greet")]
    public async Task GreetCommand(CommandContext ctx)
    {
        await ctx.RespondAsync("Greetings! Thank you for executing me!");
    }
    [Command("kiroile")]
    public async Task CurseCommand(CommandContext ctx)
    {
        await ctx.RespondAsync(GetCurseword() + "!");
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

    [Command("moi")]
    public async Task TestCommand(CommandContext ctx)
    {
        await ctx.RespondAsync("No terve " + ctx.User.Username + "!");
    }

    [Command("motivoi")]
    public async Task MotivateCommand(CommandContext ctx)
    {
        await ctx.RespondAsync(GetMotivation(ctx.User.Username));
    }
    /**
    Returns random curseword from hardcoded list
    */
    public static string GetMotivation(string name)
    {
        string[] motivations = {
         $"Hyvää työtä {name}",
         $"On varmasti olemassa huonompia videopelaajia kuin {name}!",
         $"Kyllä vielä joskus löydät itsellesi jotain pelaamista järkevämpää tekemistä :)",
         $"Jaksaa jaksaa {name}!",
         $"No aina voisi olla asiat huonomminkin!"
         };
        Random rd = new Random();
        int index = rd.Next(motivations.Length);
        string motivation = motivations[index];
        index = rd.Next(motivations.Length);
        return motivation;
    }
}




