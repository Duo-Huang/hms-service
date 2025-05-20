using Hms_Common.Enums;

namespace Hms_Common.Extensions;

public static class ErrorMessages
{
    private static readonly Dictionary<ErrorCodeEnum, string> ErrorMessagesMap = new()
    {
        { ErrorCodeEnum.SystemError001, "未知错误" },
        { ErrorCodeEnum.SystemError002, "请求出错了" },
        { ErrorCodeEnum.SystemError003, "请求参数错误" },
        { ErrorCodeEnum.SystemError004, "业务异常" },

        { ErrorCodeEnum.UserError101, "用户未认证" },
        { ErrorCodeEnum.UserError102, "此用户无权限, 请联系家庭管理员" },
        { ErrorCodeEnum.UserError103, "用户已存在" },
        { ErrorCodeEnum.UserError104, "用户名或密码格式错误" },
        { ErrorCodeEnum.UserError105, "用户名或密码错误" },
        { ErrorCodeEnum.UserError106, "用户信息格式错误" },
        { ErrorCodeEnum.UserError107, "更新密码信息错误" },
        { ErrorCodeEnum.UserError108, "密码错误" },
        { ErrorCodeEnum.UserError109, "新密码不能和旧密码相同" },

        { ErrorCodeEnum.HomeError201, "该家庭已存在" },
        { ErrorCodeEnum.HomeError202, "家庭信息格式错误" },
        { ErrorCodeEnum.HomeError203, "该家庭不存在" },
        { ErrorCodeEnum.HomeError204, "该用户不存在" },
        { ErrorCodeEnum.HomeError205, "该家庭成员已存在" },
        { ErrorCodeEnum.HomeError206, "该家庭成员不存在" },
        { ErrorCodeEnum.HomeError207, "家庭成员信息格式错误" },
        { ErrorCodeEnum.HomeError208, "家庭管理员角色不存在" },
        { ErrorCodeEnum.HomeError209, "用户名格式错误" },
        { ErrorCodeEnum.HomeError210, "该角色已存在" },
        { ErrorCodeEnum.HomeError211, "该家庭中无此角色" },
        { ErrorCodeEnum.HomeError212, "角色信息格式错误" },
        { ErrorCodeEnum.HomeError213, "该用户无权访问此家庭" },
        { ErrorCodeEnum.HomeError214, "权限信息格式错误" },
        { ErrorCodeEnum.HomeError215, "邀请码格式错误" },
        { ErrorCodeEnum.HomeError216, "邀请信息不存在" },
        { ErrorCodeEnum.HomeError217, "邀请已过期" },
        { ErrorCodeEnum.HomeError218, "家庭成员角色不存在" },
        { ErrorCodeEnum.HomeError219, "无操作权限, 请联系家庭管理员" },
        { ErrorCodeEnum.HomeError220, "无法更改自己的角色, 需要其他家庭管理员修改" },
    };

    public static string GetMessage(this ErrorCodeEnum errorCodeEnum)
    {
        return ErrorMessagesMap.GetValueOrDefault(errorCodeEnum, "未知错误");
    }
}