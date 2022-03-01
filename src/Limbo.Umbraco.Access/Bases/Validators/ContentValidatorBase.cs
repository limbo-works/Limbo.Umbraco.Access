using Limbo.Umbraco.Access.Rules.Bases.Models;
using Limbo.Umbraco.Access.UserActions.Models;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace Limbo.Umbraco.Access.Bases.Validators {
    public abstract class ContentValidatorBase : ValidatorBase, IContentValidator {
        private readonly IEnumerable<ContentAccessRuleBase> _rules;

        public ContentValidatorBase(IUmbracoContextAccessor umbracoContextAccessor, IEnumerable<ContentAccessRuleBase> rules) : base(umbracoContextAccessor) {
            _rules = rules;
        }

        protected abstract bool UserIsAllowedToDoAction(IEnumerable<ContentAccessRuleBase> rules, IUser user, IEnumerable<IContent> contentItems, IContentService contentService);

        protected bool IsActionValid(ContentUserAction userAction, IEnumerable<ContentAccessRuleBase> contentRules, IEnumerable<IContent> contentItems, IContentService contentService) {
            if (!HasRulesOfType(userAction, contentRules, out var rules)) {
                return true;
            }

            var user = GetCurrentUser();
            if (user == null) {
                return true;
            }

            return UserIsAllowedToDoAction(rules, user, contentItems, contentService);
        }

        protected bool HasRulesOfType(ContentUserAction userAction, IEnumerable<ContentAccessRuleBase> contentRules, out IEnumerable<ContentAccessRuleBase> rules) {
            rules = contentRules.Where(rule => (rule.UserActions?.Any(action => action == userAction)).GetValueOrDefault());
            if (!rules.Any()) {
                return false;
            }
            return true;
        }

        protected static bool HasContentNameChanged(IContentService sender, ContentSavingEventArgs e) {
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

        public bool IsCopyActionValid(IContentService sender, CopyEventArgs<IContent> e) {
            return IsActionValid(ContentUserAction.Copy, _rules, new List<IContent>() { e.Copy }, sender);
        }

        public bool IsDeleteActionValid(IContentService sender, DeleteEventArgs<IContent> e) {
            return IsActionValid(ContentUserAction.Delete, _rules, e.DeletedEntities, sender);
        }

        public bool IsEmptyRecycleBinActionValid(IContentService sender, RecycleBinEventArgs e) {
            if (e.IsContentRecycleBin) {
                return IsActionValid(ContentUserAction.EmptyRecycleBin, _rules, Enumerable.Empty<IContent>(), sender);
            } else {
                return true;
            }
        }

        public bool IsMoveActionValid(IContentService sender, MoveEventArgs<IContent> e) {
            return IsActionValid(ContentUserAction.Move, _rules, e.MoveInfoCollection?.Select(item => item.Entity), sender);
        }

        public bool IsPublishActionValid(IContentService sender, ContentPublishingEventArgs e) {
            return IsActionValid(ContentUserAction.Publish, _rules, e.PublishedEntities, sender);
        }

        public bool IsRenameValid(IContentService sender, ContentSavingEventArgs e) {
            if (!HasRulesOfType(ContentUserAction.Rename, _rules, out var rules)) {
                return true;
            }

            var user = GetCurrentUser();
            if (user == null) {
                return true;
            }

            if (e.SavedEntities == null) {
                return true;
            }

            bool hasNameChanged = HasContentNameChanged(sender, e);

            if (hasNameChanged) {
                return UserIsAllowedToDoAction(rules, user, e.SavedEntities, sender);
            } else {
                return true;
            }
        }

        public bool IsRollBackActionValid(IContentService sender, RollbackEventArgs<IContent> e) {
            return IsActionValid(ContentUserAction.RollBack, _rules, new List<IContent>() { e.Entity }, sender);
        }

        public bool IsSaveActionValid(IContentService sender, ContentSavingEventArgs e) {
            return IsActionValid(ContentUserAction.Save, _rules, e.SavedEntities, sender);
        }

        public bool IsSendToPublishActionValid(IContentService sender, SendToPublishEventArgs<IContent> e) {
            return IsActionValid(ContentUserAction.SendToPublish, _rules, new List<IContent>() { e.Entity }, sender);
        }

        public bool IsSortActionValid(IContentService sender, SaveEventArgs<IContent> e) {
            return IsActionValid(ContentUserAction.Sort, _rules, e.SavedEntities, sender);
        }

        public bool IsTrashActionValid(IContentService sender, MoveEventArgs<IContent> e) {
            return IsActionValid(ContentUserAction.Trash, _rules, e.MoveInfoCollection?.Select(item => item.Entity), sender);
        }

        public bool IsUnPublishActionValid(IContentService sender, PublishEventArgs<IContent> e) {
            return IsActionValid(ContentUserAction.Unpublish, _rules, e.PublishedEntities, sender);
        }
    }
}
