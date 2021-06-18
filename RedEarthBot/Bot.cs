using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using RedEarthBot.Models;
using RedEarthBot.Commands;

namespace RedEarthBot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAync()
        {
            var prefix = Environment.GetEnvironmentVariable("REDEARTH_BOT_PREFIX");
            var token = Environment.GetEnvironmentVariable("REDEARTH_BOT_TOKEN");

            var configData = new BotConfigData() { Prefix = prefix, Token = token };

            var discordConfig = SetDiscordConfiguration(configData);
            Client = new DiscordClient(discordConfig);

            var commandsConfig = SetCommandsConfiguration(configData);
            Commands = Client.UseCommandsNext(commandsConfig);
            LoadCommands();

            Catalogue.InitializeCatalogue();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private DiscordConfiguration SetDiscordConfiguration(BotConfigData configData)
        {
            var discordConfig = new DiscordConfiguration()
            {
                Token = configData.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug
            };

            return discordConfig;
        }

        private CommandsNextConfiguration SetCommandsConfiguration(BotConfigData configData)
        {
            var commandConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configData.Prefix },
                EnableMentionPrefix = true,
                EnableDms = false,
                DmHelp = true
            };

            return commandConfig;
        }

        private void LoadCommands()
        {
            Commands.RegisterCommands<DebugCommands>();
            Commands.RegisterCommands<CharacterCommands>();
            Commands.RegisterCommands<MemeCommands>();
        }
    }
}
