using System;

namespace Game.Core
{
    public class CommandBus
    {
        private static class CommandHandler<T> where T : ICommand
        {
            public static Action<T> Handler;
        }

        public static void Register<T>(Action<T> handler) where T : ICommand
        {
            CommandHandler<T>.Handler = handler;
        }

        public static void Send<T>(T command) where T : ICommand
        {
            CommandHandler<T>.Handler?.Invoke(command);
        }

        public static void Unregister<T>(Action<T> handler) where T : ICommand
        {
            if (CommandHandler<T>.Handler == handler)
                CommandHandler<T>.Handler = null;
        }
    }
}
