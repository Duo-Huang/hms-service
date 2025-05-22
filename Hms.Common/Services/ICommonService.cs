using Hms.Common.Enums;
using Hms.Common.Model;

namespace Hms.Common.Services;

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