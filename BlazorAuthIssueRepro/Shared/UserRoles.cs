using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAuthIssueRepro.Shared
{
    public class UserRoles
    {
        public const string Role1 = "Administrator";
        public const string Role1ID = "B6E32223-FA3A-4D0D-8E48-622601BBD044";

        public const string Role2 = "Standard";
        public const string Role2ID = "9340A34A-70ED-4DC0-8EE6-580B2198C088";

        public static List<string> GetUserRoles()
        {
            return new List<string>() { Role1, Role2 };
        }

        public static string GetRoleID(string role)
        {
            switch (role)
            {
                case Role1:
                    return Role1ID;
                case Role2:
                    return Role2ID;
            }

            return null;
        }
    }
}
