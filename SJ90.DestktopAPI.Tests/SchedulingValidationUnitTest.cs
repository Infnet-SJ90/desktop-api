using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using SJ90.DesktopAPI.Services.Validation;
using Xunit;

namespace SJ90.DesktopAPI.Tests
{
    public class SchedulingValidationUnitTest
    {
        readonly SchedulingValidator schedulingValidator = new SchedulingValidator();

        [Fact]
        public void Given_When_SchedulingValidatorConstructing_Then_2PropertiesShouldHaveRules()
        {
            schedulingValidator.ShouldHaveRulesCount(2);
        }

        [Fact]
        public void Given_When_SchedulingValidatorConstructing_Then_RulesForDayAreConfigured()
        {
            schedulingValidator.ShouldHaveRules(x => x.Day,
                BaseVerifiersSetComposer.Build()
                    .AddPropertyValidatorVerifier<NotNullValidator>()
                    .AddPropertyValidatorVerifier<GreaterThanOrEqualValidator>()
                    .Create());
        }

        [Fact]
        public void Given_When_SchedulingValidatorConstructing_Then_RulesForSchedulingRequestIdAreConfigured()
        {
            schedulingValidator.ShouldHaveRules(x => x.SchedulingRequestId,
                BaseVerifiersSetComposer.Build()
                    .AddPropertyValidatorVerifier<NotNullValidator>()
                    .Create());
        }
    }
}
