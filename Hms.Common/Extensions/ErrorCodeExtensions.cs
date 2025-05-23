using System.ComponentModel;
using System.Reflection;
using Hms.Common.Enums;

namespace Hms.Common.Extensions;

public static class ErrorCodeExtensions
{
    public static int GetCode(this ErrorCodeEnum errorCodeEnum)
    {
        return (int)errorCodeEnum;
    }

    public static string GetMessage(this ErrorCodeEnum errorCodeEnum) =>
        GetErrorCodeDescription(errorCodeEnum).Description;

    private static DescriptionAttribute GetErrorCodeDescription(ErrorCodeEnum errorCodeEnum)
    {
        if (typeof(ErrorCodeEnum).GetField(errorCodeEnum.ToString())?.GetCustomAttribute<DescriptionAttribute>() is
            { } descriptionAttribute)
        {
            return descriptionAttribute;
        }

        throw new ArgumentException("Invalid ErrorCodeEnum value");
    }
}