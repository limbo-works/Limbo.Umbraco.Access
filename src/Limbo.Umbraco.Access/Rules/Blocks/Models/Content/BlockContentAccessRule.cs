using System.Collections.Generic;
using Limbo.Umbraco.Access.Rules.Bases.Models;
using Limbo.Umbraco.Access.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.Access.Rules.Blocks.Models.Content {
    public class BlockContentAccessRule : ContentAccessRuleBase {
        public BlockContentAccessRule(string name, IEnumerable<IUserGroup> userGroups, IEnumerable<ContentUserAction> userActions) : base(name, userGroups, userActions) {
        }
    }
}
