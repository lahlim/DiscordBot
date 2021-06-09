using System;

using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

public class TestCommandModule : BaseCommandModule
{
    [Command("greet")]
    public async Task GreedCommand(CommandContext ctx)
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

}




