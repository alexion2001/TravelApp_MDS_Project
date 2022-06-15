using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Application.Common.Exceptions;
using TravelApp.Application.Features.Auth.EmailConfirmation;
using TravelApp.Application.Features.Auth.Login;
using TravelApp.Application.Features.Auth.PasswordRecovery;
using TravelApp.Application.Features.Auth.RefreshLoginToken;
using TravelApp.Application.Features.Auth.Register;

namespace TravelApp.Controllers
{
    public class AccountsController : BaseApplicationController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            try
            {
                var result = await Mediator.Send(registerCommand);
                return Ok(result);
            }
            catch (UserAlreadyRegisteredException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            try
            {
                var result = await Mediator.Send(loginCommand);
                return Ok(result);

            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (IncorrectPasswordException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (ExceededMaximumAmountOfLoginAttemptsException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (AccountStillLockedException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("email-confirm")]

        public async Task<IActionResult> EmailConfirmation([FromBody] EmailConfirmationCommand confirmEmailCommand)
        {
            try
            {
                var result = await Mediator.Send(confirmEmailCommand);

                return Ok(result);
            }
            catch (ResendingEmailConfirmationException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshLoginToken([FromBody] RefreshTokenCommand refreshTokenCommand)
        {
            try
            {
                var result = await Mediator.Send(refreshTokenCommand);
                return Ok(result);
            }
            catch (IntervalOfRefreshTokenExpiredException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (MaximumRefreshesExceededException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("forgot-password")]
        public async Task<IActionResult> RecoverPassword([FromBody] PasswordRecoveryCommand passwordRecoveryCommand)
        {
            try
            {
                var result = await Mediator.Send(passwordRecoveryCommand);
                return Ok(result);
            }
            catch (UserNotFoundException ex)
            {

                Console.WriteLine(ex.Message);
                return NotFound(ex.Message);
            }
            catch (CouldNotConfirmEmailException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (EmailConfirmationException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("password-recovery")]
        public async Task<IActionResult> UpdateUserPassword([FromBody] UpdateUserPasswordCommand updateUserPasswordCommand)
        {
            try
            {
                var result = await Mediator.Send(updateUserPasswordCommand);
                return Ok(result);
            }
            catch (UserNotFoundException ex)
            {

                Console.WriteLine(ex.Message);
                return NotFound(ex.Message);
            }
            catch (PasswordRecoveryTokenAlreadyUsedException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (IncorrectPasswordException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
