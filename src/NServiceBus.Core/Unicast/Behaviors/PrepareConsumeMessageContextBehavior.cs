﻿namespace NServiceBus
{
    using System;
    using NServiceBus.Pipeline.Contexts;
    using NServiceBus.Unicast.Behaviors;

    class PrepareConsumeMessageContextBehavior : HandlingStageBehavior
    {
        public override void Invoke(Context context, Action next)
        {
            var messageHandler = context.MessageHandler;
            if (messageHandler.HandlerKind == HandlerKind.Message)
            {
                context.Set("InvocationContext", new ConsumeMessageContext());
            }

            next();
        }
    }
}