using System.Collections.Generic;
using Limbo.Umbraco.Access.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.Access.Rules.Bases.Models {
    public abstract class ContentAccessRuleBase {
        protected ContentAccessRuleBase(string name, IEnumerable<IUserGroup> userGroups, IEnumerable<ContentUserAction> userActions) {
            Name = name;
            UserGroups = userGroups;
            UserActions = userActions;
        }

        public string Name { get; set; }
        public IEnumerable<IUserGroup> UserGroups { get; set; }
        public IEnumerable<ContentUserAction> UserActions { get; set; }
    }
}