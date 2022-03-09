using System.Collections.Generic;
using Limbo.Umbraco.UserPermissions.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.UserPermissions.Rules.Bases.Models {
    public abstract class MediaAccessRuleBase {
        protected MediaAccessRuleBase(string name, IEnumerable<IUserGroup> userGroups, IEnumerable<MediaUserAction> userActions) {
            Name = name;
            UserGroups = userGroups;
            UserActions = userActions;
        }

        public string Name { get; set; }
        public IEnumerable<IUserGroup> UserGroups { get; set; }
        public IEnumerable<MediaUserAction> UserActions { get; set; }
    }
}