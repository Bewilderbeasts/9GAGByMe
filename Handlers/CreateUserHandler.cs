using FunnyImages.Commands;
using FunnyImages.Commands.User;
using FunnyImages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;


        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;

        }

        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.Email, command.Username,
                command.Password, command.Role);
        }

    }
}
