using System.Collections.Generic;
using System.Linq;
using Limbo.Umbraco.Access.Bases.Validators;
using Limbo.Umbraco.Access.Rules.Bases.Models;
using Limbo.Umbraco.Access.Rules.Blocks.Models.Content;
using Umbraco.Core.Models;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace Limbo.Umbraco.Access.Rules.Blocks.Validators {
    public class BlockContentValidator : ContentValidatorBase {
        public BlockContentValidator(RuleCollection rules, IUmbracoContextAccessor umbracoContextAccessor) : base(umbracoContextAccessor, rules.ContentLimits) { }

        protected override bool UserIsAllowedToDoAction(IEnumerable<ContentAccessRuleBase> rules, IUser user, IEnumerable<IContent> contentItems, IContentService contentService) {
            var isAllowed = true;
            foreach (var rule in rules) {
                if (rule is BlockContentLevelAccessRule contentLevelAccessRule) {
                    if (IsUserInUserGroups(user, rule) && contentItems.Any(item => item.Level == contentLevelAccessRule.Level)) {
                        isAllowed = false;
                    }
                } else if (rule is BlockContentTypeAccessRule contentContentTypeAccessRule) {
                    if (IsUserInUserGroups(user, rule) && contentItems.Any(item => item.ContentType.Alias == contentContentTypeAccessRule.ContentTypeAlias)) {
                        isAllowed = false;
                    }
                } else if (rule is BlockContentAccessRule) {
                    if (IsUserInUserGroups(user, rule)) {
                        isAllowed = false;
                    }
                }
            }
            return isAllowed;
        }
    }
}
