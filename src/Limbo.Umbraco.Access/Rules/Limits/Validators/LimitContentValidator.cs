using System.Collections.Generic;
using System.Linq;
using Limbo.Umbraco.Access.Bases.Validators;
using Limbo.Umbraco.Access.Rules.Bases.Models;
using Limbo.Umbraco.Access.Rules.Limits.Models.Content;
using Umbraco.Core.Models;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace Limbo.Umbraco.Access.Rules.Limits.Validators {
    public class LimitContentValidator : ContentValidatorBase {
        public LimitContentValidator(RuleCollection rules, IUmbracoContextAccessor umbracoContextAccessor) : base(umbracoContextAccessor, rules.ContentLimits) { }

        protected override bool UserIsAllowedToDoAction(IEnumerable<ContentAccessRuleBase> rules, IUser user, IEnumerable<IContent> contentItems, IContentService contentService) {
            var isAllowed = true;
            foreach (var rule in rules) {
                if (rule is LimitContentLevelAccessRule contentLevelAccessRule) {
                    if (contentItems.Any(item => item.Level == contentLevelAccessRule.Level)) {
                        isAllowed = false;
                    }
                } else if (rule is LimitContentTypeAccessRule contentContentTypeAccessRule) {
                    if (contentItems.Any(item => item.ContentType.Alias == contentContentTypeAccessRule.ContentTypeAlias)) {
                        isAllowed = false;
                    }
                } else if (rule is LimitContentAccessRule) {
                    if (rule.UserGroups.Any(group => user.Groups.Any(userGroup => userGroup == group))) {
                        isAllowed = false;
                    }
                }
            }
            return isAllowed;
        }
    }
}
