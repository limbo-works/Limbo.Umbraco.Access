using System.Collections.Generic;
using Limbo.Umbraco.UserPermissions.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.UserPermissions.Rules.Blocks.Models.Media {
    public class BlockMediaTypeAccessRule : BlockMediaAccessRule {
        public BlockMediaTypeAccessRule(string name, IEnumerable<IUserGroup> userGroups, IEnumerable<MediaUserAction> userActions, string mediaType) : base(name, userGroups, userActions) {
            MediaType = mediaType;
        }

        public string MediaType { get; set; }
    }
}
