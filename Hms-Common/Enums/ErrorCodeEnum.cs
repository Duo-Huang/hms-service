using System.ComponentModel;

namespace Hms_Common.Enums;

/**
 * 业务错误统一使用422 http status
 * 统一定义错误码[response.data.code]
 * 错误码规范
 * 统一在一个文件中定义错误码；
 * 错误码长度为 4 位；
 * 第 1 位表示错误是哪种级别？例如：1 为系统级错误，2 为业务模块错误，可标记 9 种错误级别。
 * 第 2 位表示错误是哪个业务模块？例如：1 为用户模块，2 为家庭模块，3 为财务模块, 可标记 9 个业务模块。
 * 第 3 位和第 4 位表示具体是什么错误？例如：01 为手机号不合法，02 为验证码输入错误，可标记 99 个错误。
 */
public enum ErrorCodeEnum
{
    // 系统级错误 1xxx (发生在全局范围内或者不确定具体地方)
    [Description("未知错误")]
    SystemError001 = 1001,
    
    [Description("请求出错了")]
    SystemError002 = 1002,
    
    [Description("请求参数错误")]
    SystemError003 = 1003,
    
    [Description("业务异常")]
    SystemError004 = 1004,

    // 用户模块
    [Description("用户未认证")]
    UserError101 = 2101,
    
    [Description("此用户无权限, 请联系家庭管理员")]
    UserError102 = 2102,
    
    [Description("用户已存在")]
    UserError103 = 2103,
    
    [Description("用户名或密码格式错误")]
    UserError104 = 2104,
    
    [Description("用户名或密码错误")]
    UserError105 = 2105,
    
    [Description("用户信息格式错误")]
    UserError106 = 2106,
    
    [Description("更新密码信息错误")]
    UserError107 = 2107,
    
    [Description("密码错误")]
    UserError108 = 2108,
    
    [Description("新密码不能和旧密码相同")]
    UserError109 = 2109,
    

    // 家庭模块
    [Description("该家庭已存在")]
    HomeError201 = 2201,
    
    [Description("家庭信息格式错误")]
    HomeError202 = 2202,
    
    [Description("该家庭不存在")]
    HomeError203 = 2203,
    
    [Description("该用户不存在")]
    HomeError204 = 2204,
    
    [Description("该家庭成员已存在")]
    HomeError205 = 2205,
    
    [Description("该家庭成员不存在")]
    HomeError206 = 2206,
    
    [Description("家庭成员信息格式错误")]
    HomeError207 = 2207,
    
    [Description("家庭管理员角色不存在")]
    HomeError208 = 2208,
    
    [Description("用户名格式错误")]
    HomeError209 = 2209,
    
    [Description("该角色已存在")]
    HomeError210 = 2210,
    
    [Description("该家庭中无此角色")]
    HomeError211 = 2211,
    
    [Description("角色信息格式错误")]
    HomeError212 = 2212,
    
    [Description("该用户无权访问此家庭")]
    HomeError213 = 2213,
    
    [Description("权限信息格式错误")]
    HomeError214 = 2214,
    
    [Description("邀请码格式错误")]
    HomeError215 = 2215,
    
    [Description("邀请信息不存在")]
    HomeError216 = 2216,
    
    [Description("邀请已过期")]
    HomeError217 = 2217,
    
    [Description("家庭成员角色不存在")]
    HomeError218 = 2218,
    
    [Description("无操作权限, 请联系家庭管理员")]
    HomeError219 = 2219,
    
    [Description("无法更改自己的角色, 需要其他家庭管理员修改")]
    HomeError220 = 2220,
    
    
    // 财务模块错误 23xx
}

