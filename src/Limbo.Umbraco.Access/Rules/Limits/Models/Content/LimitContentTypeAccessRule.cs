using System.Collections.Generic;
using Limbo.Umbraco.Access.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.Access.Rules.Limits.Models.Content {
    public class LimitContentTypeAccessRule : LimitContentAccessRule {
        public LimitContentTypeAccessRule(string name, IEnumerable<IUserGroup> userGroups, IEnumerable<ContentUserAction> userActions, string contentTypeAlias) : base(name, userGroups, userActions) {
            ContentTypeAlias = contentTypeAlias;
        }

        public string ContentTypeAlias { get; set; }
    }
}
