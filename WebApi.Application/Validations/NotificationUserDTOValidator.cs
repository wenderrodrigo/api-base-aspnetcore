using FluentValidation;
using WebApi.Application.DTOs;

namespace WebApi.Application.Validations
{
    public class NotificationUserDTOValidator : AbstractValidator<NotificationUserDTO>
    {
        public NotificationUserDTOValidator()
        {
        }
    }

}
