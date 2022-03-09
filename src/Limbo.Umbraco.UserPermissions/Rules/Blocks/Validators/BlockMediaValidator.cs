using System.Collections.Generic;
using System.Linq;
using Limbo.Umbraco.UserPermissions.Bases.Validators;
using Limbo.Umbraco.UserPermissions.Rules.Bases.Models;
using Limbo.Umbraco.UserPermissions.Rules.Blocks.Models.Media;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace Limbo.Umbraco.UserPermissions.Rules.Blocks.Validators {
    public class BlockMediaValidator : MediaValidatorBase {
        public BlockMediaValidator(RuleCollection rules, IUmbracoContextAccessor umbracoContextAccessor, ILogger logger) : base(umbracoContextAccessor, rules.MediaBlocks, logger) { }

        protected override bool UserIsAllowedToDoAction(IEnumerable<MediaAccessRuleBase> rules, IUser user, IEnumerable<IMedia> mediaItems, IMediaService mediaService) {
            var isAllowed = true;
            foreach (var rule in rules) {
                if (rule is BlockMediaLevelAccessRule meidaLevelAccessRule) {
                    if (IsUserInUserGroups(user, rule) && mediaItems.Any(item => item.Level == meidaLevelAccessRule.Level)) {
                        isAllowed = false;
                    }
                } else if (rule is BlockMediaTypeAccessRule mediaTypeAccessRule) {
                    if (IsUserInUserGroups(user, rule) && mediaItems.Any(item => item.ContentType.Alias == mediaTypeAccessRule.MediaType)) {
                        isAllowed = false;
                    }
                } else if (rule is BlockMediaAccessRule) {
                    if (IsUserInUserGroups(user, rule)) {
                        isAllowed = false;
                    }
                }
            }
            return isAllowed;
        }
    }
}
