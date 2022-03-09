using System.Collections.Generic;
using Limbo.Umbraco.UserPermissions.Rules.Bases.Models;
using Limbo.Umbraco.UserPermissions.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.UserPermissions.Rules.Allow.Models.Content {
    public class AllowContentAccessRule : ContentAccessRuleBase {
        public AllowContentAccessRule(string name, IEnumerable<IUserGroup> userGroups, IEnumerable<ContentUserAction> userActions) : base(name, userGroups, userActions) {
        }
    }
}