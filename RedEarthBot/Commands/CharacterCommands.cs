using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using RedEarthBot.Models;
using System.Linq;

namespace RedEarthBot.Commands
{
    public class CharacterCommands : BaseCommandModule
    {
        [Command("tessa")]
        [Description("Displays all Tessa moves. Specify move name to show specific move data instead. " +
            "Write 'codes' after the name instead to view codes.")]
        public async Task TessaMoves(CommandContext ctx, params string[] args)
        {
            await CommandCheck(ctx, CharName.Tessa, args);
        }

        [Command("leo")]
        [Description("Displays all Leo moves. Specify move name to show specific move data instead.")]
        public async Task LeoMoves(CommandContext ctx, params string[] args)
        {
            await CommandCheck(ctx, CharName.Leo, args);
        }

        [Command("mai")]
        [Description("Displays all Mai Ling moves. Specify move name to show specific move data instead.")]
        public async Task MaiLingMoves(CommandContext ctx, params string[] args)
        {
            await CommandCheck(ctx, CharName.MaiLing, args);
        }


        [Command("kenji")]
        [Description("Displays all Kenji moves. Specify move name to show specific move data instead.")]
        public async Task KenjiMoves(CommandContext ctx, params string[] args)
        {
            await CommandCheck(ctx, CharName.Kenji, args);
        }

        public async Task CommandCheck(CommandContext ctx, CharName charName, params string[] args)
        {
            if (args.Length == 1 && args[0].Equals("codes", StringComparison.CurrentCultureIgnoreCase))
            {
                await ShowCode(ctx, charName);
            }
            else if (args.Length > 0)
            {
                await ShowMove(ctx, charName, args);
            }
            else
            {
                await ShowAllMoves(ctx, charName);
            }
        }


        public async Task ShowMove(CommandContext ctx, CharName charName, params string[] moveNames)
        {
            var name = string.Join(" ", moveNames);
            var character = Catalogue.characters[charName];

            if (character.Moves.TryGetValue(name, out var moveData))
            {
                var embed = new DiscordEmbedBuilder();

                embed.WithTitle(charName.ToString() + " [" + moveData.MoveName + "]");
                embed.AddField("Damage: ", DiscordFormat(moveData.Damage));
                embed.AddField("Startup: ", FrameFormatting(moveData.StartUp), true);
                embed.AddField("Active: ", FrameFormatting(moveData.Active), true);
                embed.AddField("Recovery: ", FrameFormatting(moveData.Recovery), true);
                embed.AddField("Hit Adv: ", AdvantageFormatting(moveData.HitAdvantage), true);
                embed.AddField("Block Adv: ", AdvantageFormatting(moveData.BlockAdvantage), true);
                AddFieldEmptySafe(embed, "Properties: ", moveData.Properties);
                AddFieldEmptySafe(embed, "Notes: ", moveData.Notes);

                embed.WithImageUrl(moveData.ImageUrl);
                embed.WithThumbnail(character.FaceURL);
                embed.WithColor(character.Color);

                embed.Build();
                await ctx.Channel.SendMessageAsync(embed).ConfigureAwait(false);
            }
            else
            {
                var embed = new DiscordEmbedBuilder();
                embed.WithTitle("Error:");
                embed.WithDescription("No move for " + charName.ToString() + " with that name found.");

                embed.Build();
                await ctx.Channel.SendMessageAsync(embed).ConfigureAwait(false);
            }
        }

        public async Task ShowAllMoves(CommandContext ctx, CharName charName)
        {
            var embed = new DiscordEmbedBuilder();
            var character = Catalogue.characters[charName];

            embed.WithTitle(charName + " Moves:");
            foreach(MoveType moveType in Enum.GetValues(typeof(MoveType)))
            {
                var moveString = Environment.NewLine;

                foreach (var move in character.Moves.Values)
                {
                    if(move.moveType == moveType)
                    {
                        moveString += move.MoveName + Environment.NewLine;
                    }
                }

                embed.AddField(moveType.ToString(), DiscordFormat(moveString), true);
            }

            embed.WithImageUrl(character.FaceURL);
            embed.WithColor(character.Color);
            embed.Build();
            await ctx.Channel.SendMessageAsync(embed).ConfigureAwait(false);
        }

        async Task ShowCode(CommandContext ctx, CharName charName)
        {
            var embed = new DiscordEmbedBuilder();
            var character = Catalogue.characters[charName];
            embed.WithTitle(charName + ": Codes");

            foreach (var code in character.Codes)
            {
                AddFieldCodeSafe(embed, DiscordFormat(code.Password), code.Notes);
            }

            embed.WithImageUrl(character.FaceURL);
            embed.WithColor(character.Color);
            embed.Build();
            await ctx.Channel.SendMessageAsync(embed).ConfigureAwait(false);
        }

        string DiscordFormat(string val)
        {
            return "```" + val + "```";
        }

        string FrameFormatting(string val)
        {
            if (int.TryParse(val, out var result))
            {
                val += "f";
            }

            return DiscordFormat(val);
        }

        string AdvantageFormatting(string val)
        {
            if (int.TryParse(val, out var result))
            {
                val += "f";

                if (val.Length > 1 && val[0] != '-')
                {
                    val = val.Insert(0, "+");
                }
            }

            return DiscordFormat(val);
        }

        void AddFieldEmptySafe(DiscordEmbedBuilder embed, string fieldName, string val)
        {
            if (val.Length != 1 && val[0] != '0')
            {
                embed.AddField(fieldName, DiscordFormat(val));
            }
        }

        void AddFieldCodeSafe(DiscordEmbedBuilder embed, string fieldName, string val)
        {
            if (val.Length != 1 && val[0] != '0')
            {
                embed.AddField(fieldName, val);
            }
            else
            {
                embed.AddField(fieldName, "N/A");
            }
        }
    }
}
