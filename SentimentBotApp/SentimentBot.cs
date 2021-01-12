using Microsoft.Bot.Builder;
using Microsoft.Bot;
using Microsoft.Bot.Schema;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SentimentBotApp
{
    public class SentimentBot : IBot
    {
		/*
        public async Task OnTurnAsync(ITurnContext context, CancellationToken cancellationToken = default)
        {
            ConversationContext.userMsg = context.Activity.Text;

            if (context.Activity.Type is ActivityTypes.Message)
            {
                if (string.IsNullOrEmpty(ConversationContext.userName))
                {
                    ConversationContext.userName = ConversationContext.userMsg;
                    await context.SendActivityAsync($"Hello {ConversationContext.userName}. Looks like today it is going to rain. \nLuckily I have umbrellas and waterproof jackets to sell!");
                }
                else
                {
                    if (ConversationContext.userMsg.Contains("how much"))
                    {
                        if (ConversationContext.userMsg.Contains("umbrella")) await context.SendActivityAsync($"Umbrellas are $13.");
                        else if (ConversationContext.userMsg.Contains("jacket")) await context.SendActivityAsync($"Waterproof jackets are $30.");
                        else await context.SendActivityAsync($"Umbrellas are $13. \nWaterproof jackets are $30.");
                    }
                    else if (ConversationContext.userMsg.Contains("color") || ConversationContext.userMsg.Contains("colour"))
                    {
                        await context.SendActivityAsync($"Umbrellas are black. \nWaterproof jackets are yellow.");
                    }
                    else
                    {
                        await context.SendActivityAsync($"Sorry {ConversationContext.userName}. I did not understand the question");
                    }
                }
            }
            else
            {

                ConversationContext.userMsg = string.Empty;
                ConversationContext.userName = string.Empty;
                await context.SendActivityAsync($"Welcome! \nI am the Weather Shop Bot \nWhat is your name?");
            }
        }
		*/
		
		public async Task OnTurnAsync(ITurnContext context, CancellationToken cancellationToken = default)
        {
            ConversationContext.userMsg = context.Activity.Text;
             
			if (ConversationContext.userMsg.Contains("how much"))
			{
				if (ConversationContext.userMsg.Contains("umbrella")) await context.SendActivityAsync($"Umbrellas are $13.");
				else if (ConversationContext.userMsg.Contains("jacket")) await context.SendActivityAsync($"Waterproof jackets are $30.");
				else await context.SendActivityAsync($"Umbrellas are $13. \nWaterproof jackets are $30.");
			}
			else if (ConversationContext.userMsg.Contains("color") || ConversationContext.userMsg.Contains("colour"))
			{
				await context.SendActivityAsync($"Umbrellas are black. \nWaterproof jackets are yellow.");
			}
			else
			{
				await context.SendActivityAsync($"Sorry {ConversationContext.userName}. I did not understand the question");
			}
                
           
        }
    }
}
