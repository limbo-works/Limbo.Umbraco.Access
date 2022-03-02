using System.Collections.Generic;
using System.Linq;
using Limbo.Umbraco.Access.Bases.Validators;
using Limbo.Umbraco.Access.Rules.Bases.Models;
using Limbo.Umbraco.Access.Rules.Blocks.Models.Media;
using Umbraco.Core.Models;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace Limbo.Umbraco.Access.Rules.Blocks.Validators {
    public class BlockMediaValidator : MediaValidatorBase {
        public BlockMediaValidator(RuleCollection rules, IUmbracoContextAccessor umbracoContextAccessor) : base(umbracoContextAccessor, rules.MediaLimits) { }

        protected override bool UserIsAllowedToDoAction(IEnumerable<MediaAccessRuleBase> rules, IUser user, IEnumerable<IMedia> mediaItems, IMediaService mediaService) {
            var isAllowed = true;
            foreach (var rule in rules) {
                if (rule is BlockMediaLevelAccessRule meidaLevelAccessRule) {
                    if (mediaItems.Any(item => item.Level == meidaLevelAccessRule.Level)) {
                        isAllowed = false;
                    }
                } else if (rule is BlockMediaTypeAccessRule mediaTypeAccessRule) {
                    if (mediaItems.Any(item => item.ContentType.Alias == mediaTypeAccessRule.MediaType)) {
                        isAllowed = false;
                    }
                } else if (rule is BlockMediaAccessRule) {
                    if (rule.UserGroups.Any(group => user.Groups.Any(userGroup => userGroup == group))) {
                        isAllowed = false;
                    }
                }
            }
            return isAllowed;
        }
    }
}
