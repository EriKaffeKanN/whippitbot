using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace whippitbot
{
    class Bot
    {
        public DiscordClient client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            string json = String.Empty;
            using(var fs = File.OpenRead("config.json"))
            {
                using(var sr = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    json = await sr.ReadToEndAsync().ConfigureAwait(false);
                }
            }

            ConfigJSON configJson = JsonConvert.DeserializeObject<ConfigJSON>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug
            };

            client = new DiscordClient(config);

            client.Ready += OnClientReady;

            var commansConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.CommandPrefix },
                EnableMentionPrefix = true,
                EnableDms = false,
                IgnoreExtraArguments = true
            };

            Commands = client.UseCommandsNext(commansConfig);

            Commands.RegisterCommands<Commands>();

            await client.ConnectAsync();

            await Task.Delay(-1);
        }

        private Task OnClientReady(object sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
