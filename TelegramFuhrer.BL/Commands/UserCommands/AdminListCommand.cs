﻿using System.Threading.Tasks;
using TelegramFuhrer.BL.Services;

namespace TelegramFuhrer.BL.Commands.UserCommands
{
    public class AdminListCommand : ICommand
    {
        private readonly IUserService _userService;

        public AdminListCommand(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CommandResult> Execute(string args)
        {
            return new CommandResult
            {
                Message = await _userService.GetListOfAdminsAsync(),
                Success = true
            };
        }
    }
}
