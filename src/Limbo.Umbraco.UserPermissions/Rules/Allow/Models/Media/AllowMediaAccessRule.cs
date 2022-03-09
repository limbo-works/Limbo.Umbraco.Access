using System.Collections.Generic;
using Limbo.Umbraco.UserPermissions.Rules.Bases.Models;
using Limbo.Umbraco.UserPermissions.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.UserPermissions.Rules.Allow.Models.Media {
    public class AllowMediaAccessRule : MediaAccessRuleBase {
        public AllowMediaAccessRule(string name, IEnumerable<IUserGroup> userGroups, IEnumerable<MediaUserAction> userActions) : base(name, userGroups, userActions) {
        }
    }
}
