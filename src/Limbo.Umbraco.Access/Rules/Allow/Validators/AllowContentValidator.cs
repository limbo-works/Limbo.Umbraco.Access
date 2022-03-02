﻿using System.Collections.Generic;
using System.Linq;
using Limbo.Umbraco.Access.Bases.Validators;
using Limbo.Umbraco.Access.Rules.Allow.Models.Content;
using Limbo.Umbraco.Access.Rules.Bases.Models;
using Umbraco.Core.Models;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace Limbo.Umbraco.Access.Rules.Allow.Validators {
    public class AllowContentValidator : ContentValidatorBase {
        public AllowContentValidator(RuleCollection rules, IUmbracoContextAccessor umbracoContextAccessor) : base(umbracoContextAccessor, rules.ContentAllows) { }

        protected override bool UserIsAllowedToDoAction(IEnumerable<ContentAccessRuleBase> rules, IUser user, IEnumerable<IContent> contentItems, IContentService contentService) {
            var isAllowed = true;
            foreach (var rule in rules) {
                if (rule is AllowContentLevelAccessRule contentLevelAccessRule) {
                    if (!contentItems.All(item => item.Level == contentLevelAccessRule.Level)) {
                        isAllowed = false;
                    }
                } else if (rule is AllowContentTypeAccessRule contentContentTypeAccessRule) {
                    if (!contentItems.All(item => item.ContentType.Alias == contentContentTypeAccessRule.ContentTypeAlias)) {
                        isAllowed = false;
                    }
                } else if (rule is AllowContentAccessRule) {
                    if (!rule.UserGroups.Any(group => user.Groups.Any(userGroup => userGroup == group))) {
                        isAllowed = false;
                    }
                }
            }
            return isAllowed;
        }
    }
}