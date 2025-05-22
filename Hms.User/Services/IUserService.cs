using Hms.User.Model;

namespace Hms.User.Services;

public interface IUserService
{
    /**
     * 注册用户, 接收user业务对象而不是username, 方便以后使用邮箱或手机号登录
     *
     * @param user     要注册的用户信息
     * @param password 要注册的用户密码
     * @return 注册成功的用户id
     * @throws UserAlreadyExistsException 用户已存在
     */
    int Register(Common.Model.User user, string password);

    /**
     * 用户登录, 接收user业务对象而不是username, 方便以后使用邮箱或手机号登录
     *
     * @param user 登录的用户信息
     * @return jwt token
     * @throws IllegalArgumentException 用户名或密码错误
     */
    string Login(Common.Model.User user, string password);

    void Logout(UserToken token);

    /**
     * 修改用户密码
     *
     * @param user        当前用户
     * @param oldPassword 旧密码
     * @param newPassword 新密码
     * @return 是否修改成功
     * @throws IllegalArgumentException 如果输入的参数无效
     */
    void ChangePassword(Common.Model.User user, UserToken userToken, string oldPassword, string newPassword);

    Common.Model.User GetProfile(int userId);

    void UpdateProfile(Common.Model.User user);
}