using System.Collections.Generic;
using Limbo.Umbraco.UserPermissions.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.UserPermissions.Rules.Blocks.Models.Content {
    public class BlockContentLevelAccessRule : BlockContentAccessRule {
        public BlockContentLevelAccessRule(string name, IEnumerable<IUserGroup> userGroups, IEnumerable<ContentUserAction> userActions, int level) : base(name, userGroups, userActions) {
            Level = level;
        }

        public int Level { get; set; }
    }
}
