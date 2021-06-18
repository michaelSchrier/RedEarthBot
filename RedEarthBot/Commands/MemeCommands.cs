using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace RedEarthBot.Commands
{
    public class MemeCommands : BaseCommandModule
    {
        [Command("bestkenji")]
        [Description("Shows who is the best Kenji player.")]
        public async Task BestKenji(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder();
            embed.WithDescription("Double is the best Kenji.");

            embed.Build();
            await ctx.Channel.SendMessageAsync(embed).ConfigureAwait(false);
        }

        [Command("minus")]
        [Description("Idk some meme shit.")]
        public async Task Minus(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder();
            embed.WithImageUrl("https://wiki.gbl.gg/images/6/64/RE_Kenji_Not_Minus_Ten.png");

            embed.Build();
            await ctx.Channel.SendMessageAsync(embed).ConfigureAwait(false);
        }

        [Command("spin")]
        [Description("Idk some meme shit.")]
        public async Task Spin(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder();
            embed.WithImageUrl("https://cdn.discordapp.com/attachments/827333440516390924/827441851693924422/spin.gif");

            embed.Build();
            await ctx.Channel.SendMessageAsync(embed).ConfigureAwait(false);
        }

        [Command("tin")]
        [Description("Idk some meme shit.")]
        public async Task Tin(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder();
            embed.WithImageUrl("https://wiki.gbl.gg/images/0/0b/RE_Tin.png");

            embed.Build();
            await ctx.Channel.SendMessageAsync(embed).ConfigureAwait(false);
        }

        [Command("assemble")]
        [Description("Idk some meme shit.")]
        public async Task Assemble(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("https://streamable.com/hieprt").ConfigureAwait(false);
        }

        [Command("setup")]
        [Description("Shows setup video.")]
        public async Task Setup(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("https://youtu.be/-6dmK7ZHr8A").ConfigureAwait(false);
        }
    }
}
