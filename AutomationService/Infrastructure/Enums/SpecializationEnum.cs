using System.ComponentModel;

namespace AutomationService.Infrastructure.Enums
{
    public enum SpecializationEnum
    {
        [Description("QA")]
        QA = 1,

        [Description("Software Developer")]
        SoftwareDeveloper = 2,

        [Description("Manager")]
        Manager = 3
    }
}
