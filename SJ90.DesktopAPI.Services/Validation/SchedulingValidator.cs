using FluentValidation;
using SJ90.DesktopAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SJ90.DesktopAPI.Services.Validation
{
    public class SchedulingValidator : AbstractValidator<Scheduling>
    {
        public SchedulingValidator()
        {
            RuleFor(x => x.Day)
                .NotNull().WithMessage("O dia do agendamento deve ser informado")
                .GreaterThanOrEqualTo(DateTime.Today);

            RuleFor(x => x.SchedulingRequestId)
                .NotNull().WithMessage("O identificador do requerimento deve ser informado");
        }
    }
}
