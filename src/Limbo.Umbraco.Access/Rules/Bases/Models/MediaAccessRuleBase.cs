using System.Collections.Generic;
using Limbo.Umbraco.Access.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.Access.Rules.Bases.Models {
    public abstract class MediaAccessRuleBase {
        public string Name { get; set; }
        public IEnumerable<IUserGroup> UserGroups { get; set; }
        public IEnumerable<MediaUserAction> UserActions { get; set; }
    }
}