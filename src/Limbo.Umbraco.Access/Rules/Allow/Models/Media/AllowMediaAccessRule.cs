using System.Collections.Generic;
using Limbo.Umbraco.Access.Rules.Bases.Models;
using Limbo.Umbraco.Access.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.Access.Rules.Allow.Models.Media {
    public class AllowMediaAccessRule : MediaAccessRuleBase {
        public AllowMediaAccessRule(string name, IEnumerable<IUserGroup> userGroups, IEnumerable<MediaUserAction> userActions) : base(name, userGroups, userActions) {
        }
    }
}
