﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramFuhrer.Data.Repositories;

namespace TelegramFuhrer.BL.Commands.ChatCommands
{
    public class ChatEditCommand : ICommand
    {
        private readonly ChatRepository _chatRepository;

        public ChatEditCommand(ChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<CommandResult> Execute(string args)
        {
            var values = args.Split(' ');
            if (values.Length != 3)
                throw new ArgumentException("Incorrect command parameters. Should contains chat id, autokick");
            var id = int.Parse(values[0]);
            var authoKick = ParseBool(values[1]);
            var autoAdd = ParseBool(values[2]);
            var chat = await _chatRepository.GetAsync(id);
            chat.AutoKick = authoKick;
            chat.AutoAdd = autoAdd;
            await _chatRepository.SaveChangesAsync();
            return new CommandResult
            {
                Message = "Done",
                Success = true
            };
        }

        private bool ParseBool(string value)
        {
            bool result;
            if (!bool.TryParse(value, out result))
                result = value == "1";
            return result;
        }
    }
}
