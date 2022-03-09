using Limbo.Umbraco.UserPermissions.Rules.Allow.Validators;
using Limbo.Umbraco.UserPermissions.Rules.Blocks.Validators;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;
using Umbraco.Web;

namespace Limbo.Umbraco.UserPermissions.Rules.Components {
    public class ContentRulesComponent : RulesComponentBase, IComponent {
        private readonly AllowContentValidator _allowContentValidator;
        private readonly BlockContentValidator _limitContentValidator;

        public ContentRulesComponent(AllowContentValidator allowContentValidator,
                                     BlockContentValidator limitContentValidator,
                                     ILocalizationService localizationService,
                                     IProfilingLogger logger,
                                     IUmbracoContextAccessor umbracoContextAccessor) : base(umbracoContextAccessor, logger, localizationService) {
            _allowContentValidator = allowContentValidator;
            _limitContentValidator = limitContentValidator;
        }

        public void Initialize() {
            ContentService.Copying += Coping;
            ContentService.Deleting += Deleting;
            ContentService.EmptyingRecycleBin += EmptyingRecycleBin;
            ContentService.Moving += Moving;
            ContentService.Publishing += Publishing;
            ContentService.RollingBack += RollingBack;
            ContentService.Saving += Saving;
            ContentService.SendingToPublish += SendingToPublish;
            ContentService.Sorting += Sorting;
            ContentService.Trashing += Trashing;
            ContentService.Unpublishing += Unpublishing;
        }

        private void Unpublishing(IContentService sender, PublishEventArgs<IContent> e) {
            CheckActionValid(() => _allowContentValidator.IsUnPublishActionValid(sender, e), e);
            CheckActionValid(() => _limitContentValidator.IsUnPublishActionValid(sender, e), e);
        }

        private void Trashing(IContentService sender, MoveEventArgs<IContent> e) {
            CheckActionValid(() => _allowContentValidator.IsTrashActionValid(sender, e), e);
            CheckActionValid(() => _limitContentValidator.IsTrashActionValid(sender, e), e);
        }

        private void Sorting(IContentService sender, SaveEventArgs<IContent> e) {
            CheckActionValid(() => _allowContentValidator.IsSortActionValid(sender, e), e);
            CheckActionValid(() => _limitContentValidator.IsSortActionValid(sender, e), e);
        }

        private void SendingToPublish(IContentService sender, SendToPublishEventArgs<IContent> e) {
            CheckActionValid(() => _allowContentValidator.IsSendToPublishActionValid(sender, e), e);
            CheckActionValid(() => _limitContentValidator.IsSendToPublishActionValid(sender, e), e);
        }

        private void Saving(IContentService sender, ContentSavingEventArgs e) {
            CheckActionValid(() => _allowContentValidator.IsSaveActionValid(sender, e), e);
            CheckActionValid(() => _limitContentValidator.IsSaveActionValid(sender, e), e);


            CheckActionValid(() => _allowContentValidator.IsRenameValid(sender, e), e);
            CheckActionValid(() => _limitContentValidator.IsRenameValid(sender, e), e);
        }

        private void RollingBack(IContentService sender, RollbackEventArgs<IContent> e) {
            CheckActionValid(() => _allowContentValidator.IsRollBackActionValid(sender, e), e);
            CheckActionValid(() => _limitContentValidator.IsRollBackActionValid(sender, e), e);
        }

        private void Publishing(IContentService sender, ContentPublishingEventArgs e) {
            CheckActionValid(() => _allowContentValidator.IsPublishActionValid(sender, e), e);
            CheckActionValid(() => _limitContentValidator.IsPublishActionValid(sender, e), e);
        }

        private void Moving(IContentService sender, MoveEventArgs<IContent> e) {
            CheckActionValid(() => _allowContentValidator.IsMoveActionValid(sender, e), e);
            CheckActionValid(() => _limitContentValidator.IsMoveActionValid(sender, e), e);
        }

        private void EmptyingRecycleBin(IContentService sender, RecycleBinEventArgs e) {
            CheckActionValid(() => _allowContentValidator.IsEmptyRecycleBinActionValid(sender, e), e);
            CheckActionValid(() => _limitContentValidator.IsEmptyRecycleBinActionValid(sender, e), e);
        }

        private void Deleting(IContentService sender, DeleteEventArgs<IContent> e) {
            CheckActionValid(() => _allowContentValidator.IsDeleteActionValid(sender, e), e);
            CheckActionValid(() => _limitContentValidator.IsDeleteActionValid(sender, e), e);
        }

        private void Coping(IContentService sender, CopyEventArgs<IContent> e) {
            CheckActionValid(() => _allowContentValidator.IsCopyActionValid(sender, e), e);
            CheckActionValid(() => _limitContentValidator.IsCopyActionValid(sender, e), e);
        }

        public void Terminate() {
            ContentService.Copying -= Coping;
            ContentService.Deleting -= Deleting;
            ContentService.EmptyingRecycleBin -= EmptyingRecycleBin;
            ContentService.Moving -= Moving;
            ContentService.Publishing -= Publishing;
            ContentService.RollingBack -= RollingBack;
            ContentService.Saving -= Saving;
            ContentService.SendingToPublish -= SendingToPublish;
            ContentService.Sorting -= Sorting;
            ContentService.Trashing -= Trashing;
            ContentService.Unpublishing -= Unpublishing;
        }
    }
}
