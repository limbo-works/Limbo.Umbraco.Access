using System.Collections.Generic;
using Limbo.Umbraco.UserPermissions.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.UserPermissions.Rules.Allow.Models.Media {
    public class AllowMediaLevelAccessRule : AllowMediaAccessRule {
        public AllowMediaLevelAccessRule(string name, IEnumerable<IUserGroup> userGroups, IEnumerable<MediaUserAction> userActions, int level) : base(name, userGroups, userActions) {
            Level = level;
        }

        public int Level { get; set; }
    }
}
