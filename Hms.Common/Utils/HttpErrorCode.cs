using Microsoft.AspNetCore.Http;

namespace Hms.Common.Utils;

public static class HttpErrorCode
{
    private static readonly Dictionary<int, string> ErrorMessagesMap = new()
    {
        { StatusCodes.Status422UnprocessableEntity, "业务异常" },
        { StatusCodes.Status400BadRequest, "错误的请求" },
        { StatusCodes.Status401Unauthorized, "未认证的用户" },
        { StatusCodes.Status403Forbidden, "拒绝访问" },
        { StatusCodes.Status404NotFound, "请求的资源未找到" },
        { StatusCodes.Status409Conflict, "请求冲突" },
        { StatusCodes.Status500InternalServerError, "服务出错, 请稍后再试" },
        { StatusCodes.Status502BadGateway, "网关错误, 请稍后再试" },
        { StatusCodes.Status406NotAcceptable, "请求的内容类型不被接受" },
        { StatusCodes.Status405MethodNotAllowed, "请求方法不支持" },
        { StatusCodes.Status415UnsupportedMediaType, "不支持的媒体类型" },
    };

    public static string GetMessageByHttpCode(int statusCode)
    {
        return ErrorMessagesMap.GetValueOrDefault(statusCode, "未知错误");
    }
}