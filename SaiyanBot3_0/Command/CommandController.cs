using System;
using System.Linq;
using System.Collections.Generic;

namespace SaiyanBot3_0.Command
{
    public class CommandController
    {
        private List<Command> commands;

        public List<Command> DiscordCommands
        {
            get
            {
                return commands.Where(x => x.IsDiscord);
            }
        }
        public List<Command> TwitchCommands
        {
            get
            {
                return commands.Where(x => x.IsTwitch);
            }
        }

        public CommandController()
        {
            
        }
    }
}