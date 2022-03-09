using System.Collections.Generic;
using Limbo.Umbraco.UserPermissions.Rules.Bases.Models;
using Limbo.Umbraco.UserPermissions.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.UserPermissions.Rules.Blocks.Models.Content {
    public class BlockContentAccessRule : ContentAccessRuleBase {
        public BlockContentAccessRule(string name, IEnumerable<IUserGroup> userGroups, IEnumerable<ContentUserAction> userActions) : base(name, userGroups, userActions) {
        }
    }
}
