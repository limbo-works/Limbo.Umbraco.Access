using System.Collections.Generic;
using System.Linq;
using Limbo.Umbraco.UserPermissions.Rules.Bases.Models;
using Limbo.Umbraco.UserPermissions.UserActions.Models;
using Umbraco.Core.Events;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace Limbo.Umbraco.UserPermissions.Bases.Validators {
    public abstract class MediaValidatorBase : ValidatorBase, IMediaValidator {
        private readonly IEnumerable<MediaAccessRuleBase> _rules;

        protected MediaValidatorBase(IUmbracoContextAccessor umbracoContextAccessor, IEnumerable<MediaAccessRuleBase> rules, ILogger logger) : base(umbracoContextAccessor, logger) {
            _rules = rules;
        }
        protected abstract bool UserIsAllowedToDoAction(IEnumerable<MediaAccessRuleBase> rules, IUser user, IEnumerable<IMedia> mediaItems, IMediaService mediaService);

        protected bool IsActionValid(MediaUserAction userAction, IEnumerable<MediaAccessRuleBase> contentRules, IEnumerable<IMedia> mediaItems, IMediaService mediaService) {
            if (!HasRulesOfType(userAction, contentRules, out var rules)) {
                return true;
            }

            var user = GetCurrentUser();
            if (user == null) {
                return true;
            }

            return UserIsAllowedToDoAction(rules, user, mediaItems, mediaService);
        }

        protected bool HasRulesOfType(MediaUserAction userAction, IEnumerable<MediaAccessRuleBase> mediaRules, out IEnumerable<MediaAccessRuleBase> rules) {
            rules = mediaRules.Where(rule => (rule.UserActions?.Any(action => action == userAction)).GetValueOrDefault());
            if (!rules.Any()) {
                return true;
            }
            return false;
        }

        protected static bool HasMediaNameChanged(IMediaService sender, SaveEventArgs<IMedia> e) {
            var hasNameChanged = false;
            foreach (var entity in e.SavedEntities) {
                var previousState = sender.GetById(entity.Id);
                if (previousState != null) {
                    var previousName = previousState.Name;

                    if (entity.Name != previousName) {
                        hasNameChanged = true;
                    }
                }
            }

            return hasNameChanged;
        }

        public bool IsDeleteActionValid(IMediaService sender, DeleteEventArgs<IMedia> e) {
            return IsActionValid(MediaUserAction.Delete, _rules, e.DeletedEntities, sender);
        }

        public bool IsEmptyRecycleBinActionValid(IMediaService sender, RecycleBinEventArgs e) {
            if (e.IsMediaRecycleBin) {
                return IsActionValid(MediaUserAction.EmptyRecycleBin, _rules, Enumerable.Empty<IMedia>(), sender);
            } else {
                return true;
            }
        }

        public bool IsMoveActionValid(IMediaService sender, MoveEventArgs<IMedia> e) {
            return IsActionValid(MediaUserAction.Move, _rules, e.MoveInfoCollection?.Select(item => item.Entity), sender);
        }

        public bool IsRenameActionValid(IMediaService sender, SaveEventArgs<IMedia> e) {
            if (!HasRulesOfType(MediaUserAction.Rename, _rules, out var rules)) {
                return true;
            }

            var user = GetCurrentUser();
            if (user == null) {
                return true;
            }

            if (e.SavedEntities == null) {
                return true;
            }

            bool hasNameChanged = HasMediaNameChanged(sender, e);

            if (hasNameChanged) {
                return UserIsAllowedToDoAction(rules, user, e.SavedEntities, sender);
            } else {
                return true;
            }
        }

        public bool IsSaveActionValid(IMediaService sender, SaveEventArgs<IMedia> e) {
            return IsActionValid(MediaUserAction.Save, _rules, e.SavedEntities, sender);
        }

        public bool IsTrashActionValid(IMediaService sender, MoveEventArgs<IMedia> e) {
            return IsActionValid(MediaUserAction.Trash, _rules, e.MoveInfoCollection?.Select(item => item.Entity), sender);
        }

        protected static bool IsUserInUserGroups(IUser user, MediaAccessRuleBase rule) {
            return rule.UserGroups.Any(group => user.Groups.Any(userGroup => userGroup.Alias == group.Alias));
        }
    }
}
