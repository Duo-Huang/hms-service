using Hms_Common.Enums;
using Hms_Common.Model;

namespace Hms_Common.Services;

public interface ICommonService
{
    User GetUserById(int userId);

    User GetUserByName(String username);

    Home GetHomeById(int homeId);

    bool IsUserInHome(int homeId, int userId);

    SystemRole GetSystemRoleByName(SystemRoleEnum systemRoleEnum);

    List<SystemRole> GetSystemRoles();

    bool IsSystemRole(int roleId);

    List<int> GetHomeMemberUserIds(int homeId);
}