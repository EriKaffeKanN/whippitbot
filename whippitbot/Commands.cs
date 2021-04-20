using DSharpPlus.CommandsNext;
using DSharpPlus;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext.Attributes;

namespace whippitbot
{
    class Commands: BaseCommandModule
    {
        [Command("advice")]
        public async Task GiveAdvice(CommandContext ctx)
        {
            string advice = Advice.get();
            await ctx.Channel.SendMessageAsync(advice).ConfigureAwait(false);
        }

        [Command("motivate")]
        [Hidden]
        public async Task Motivate(CommandContext ctx)
        {
            string message = Advice.getImage();
            await ctx.Channel.SendMessageAsync(message).ConfigureAwait(false);
        }

        [Command("uprising")]
        public async Task Uprising(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("error osv").ConfigureAwait(false);
        }
    }
}
