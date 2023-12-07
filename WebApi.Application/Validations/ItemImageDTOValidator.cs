using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Validations
{
    public class ItemImageDTOValidator : AbstractValidator<ItemImageDTO>
    {
        public ItemImageDTOValidator()
        {
        }
    }

}
