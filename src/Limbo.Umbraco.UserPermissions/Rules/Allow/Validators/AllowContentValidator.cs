using System.Collections.Generic;
using System.Linq;
using Limbo.Umbraco.UserPermissions.Bases.Validators;
using Limbo.Umbraco.UserPermissions.Rules.Allow.Models.Content;
using Limbo.Umbraco.UserPermissions.Rules.Bases.Models;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace Limbo.Umbraco.UserPermissions.Rules.Allow.Validators {
    public class AllowContentValidator : ContentValidatorBase {
        public AllowContentValidator(RuleCollection rules, IUmbracoContextAccessor umbracoContextAccessor, ILogger logger) : base(umbracoContextAccessor, rules.ContentAllows, logger) { }

        protected override bool UserIsAllowedToDoAction(IEnumerable<ContentAccessRuleBase> rules, IUser user, IEnumerable<IContent> contentItems, IContentService contentService) {
            var isAllowed = true;
            foreach (var rule in rules) {
                if (rule is AllowContentLevelAccessRule contentLevelAccessRule) {
                    if (!IsUserInUserGroups(user, rule) && !contentItems.All(item => item.Level == contentLevelAccessRule.Level)) {
                        isAllowed = false;
                    }
                } else if (rule is AllowContentTypeAccessRule contentContentTypeAccessRule) {
                    if (!IsUserInUserGroups(user, rule) && !contentItems.All(item => item.ContentType.Alias == contentContentTypeAccessRule.ContentTypeAlias)) {
                        isAllowed = false;
                    }
                } else if (rule is AllowContentAccessRule) {
                    if (!IsUserInUserGroups(user, rule)) {
                        isAllowed = false;
                    }
                }
            }
            return isAllowed;
        }
    }
}
