using System.Collections.Generic;
using System.Linq;
using Limbo.Umbraco.Access.Bases.Validators;
using Limbo.Umbraco.Access.Rules.Allow.Models.Media;
using Limbo.Umbraco.Access.Rules.Bases.Models;
using Umbraco.Core.Models;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace Limbo.Umbraco.Access.Rules.Allow.Validators {
    public class AllowMediaValidator : MediaValidatorBase {
        public AllowMediaValidator(RuleCollection rules, IUmbracoContextAccessor umbracoContextAccessor) : base(umbracoContextAccessor, rules.MediaAllows) { }

        protected override bool UserIsAllowedToDoAction(IEnumerable<MediaAccessRuleBase> rules, IUser user, IEnumerable<IMedia> mediaItems, IMediaService mediaService) {
            var isAllowed = true;
            foreach (var rule in rules) {
                if (rule is AllowMediaLevelAccessRule mediaLevelAccessRule) {
                    if (!mediaItems.All(item => item.Level == mediaLevelAccessRule.Level)) {
                        isAllowed = false;
                    }
                } else if (rule is AllowMediaTypeAccessRule contentContentTypeAccessRule) {
                    if (!IsUserInUserGroups(user, rule) && !mediaItems.All(item => item.ContentType.Alias == contentContentTypeAccessRule.MediaType)) {
                        isAllowed = false;
                    }
                } else if (rule is AllowMediaAccessRule) {
                    if (!IsUserInUserGroups(user, rule)) {
                        isAllowed = false;
                    }
                }
            }
            return isAllowed;
        }
    }
}
