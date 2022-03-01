using System.Collections.Generic;
using Limbo.Umbraco.Access.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.Access.Rules.Allow.Models.Content {
    public class AllowContentTypeAccessRule : AllowContentAccessRule {
        public AllowContentTypeAccessRule(string name, IEnumerable<IUserGroup> userGroups, IEnumerable<ContentUserAction> userActions, string contentTypeAlias) : base(name, userGroups, userActions) {
            ContentTypeAlias = contentTypeAlias;
        }

        public string ContentTypeAlias { get; set; }
    }
}
