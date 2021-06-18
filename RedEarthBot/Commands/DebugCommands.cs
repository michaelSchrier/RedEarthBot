using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace RedEarthBot.Commands
{
    public class DebugCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("Pings the bot.")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

        [Command("refresh")]
        [Description("Reloads the bot's Database.")]
        public async Task Refresh(CommandContext ctx)
        {
            Catalogue.InitializeCatalogue();
            var embed = new DiscordEmbedBuilder();
            embed.WithDescription("Moves have been refreshed.");

            embed.Build();
            await ctx.Channel.SendMessageAsync(embed).ConfigureAwait(false);
        }
    }
}
