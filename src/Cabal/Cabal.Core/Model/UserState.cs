using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cabal.Core.Model
{
    [Serializable]
    public class UserState
    {

        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }



        public bool IsInRole(string roleName)
        {
            return Roles.Contains(roleName);
        }


        public string Serialize()
        {
            string roleNames = Roles == null ? string.Empty : string.Join(",", Roles.ToArray());
            return string.Format("{0}|{1}",
                                 UserName ?? string.Empty,
                                 roleNames);
        }

        public static UserState Deserialize(string value)
        {
            var values = value.Split('|');
            return new UserState
                       {
                           UserName = values[0],
                           Roles = values[1].Split(',').Where(s => s.Length > 0)
                       };
        }
    }
}
