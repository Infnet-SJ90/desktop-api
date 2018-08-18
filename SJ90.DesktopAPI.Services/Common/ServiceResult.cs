using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SJ90.DesktopAPI.Services.Common
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }

        public IList<ValidationFailure> Errors { get; set; }
    }
}
