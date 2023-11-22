using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;

namespace WebApi.Application.Validations
{
    public class UserCondominiumDTOValidator : AbstractValidator<UserCondominiumDTO>
    {
        public UserCondominiumDTOValidator()
        {
        }
    }

}
