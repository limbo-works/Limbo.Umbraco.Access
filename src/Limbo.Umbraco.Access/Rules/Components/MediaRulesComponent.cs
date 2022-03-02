using Limbo.Umbraco.Access.Rules.Allow.Validators;
using Limbo.Umbraco.Access.Rules.Blocks.Validators;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;
using Umbraco.Web;

namespace Limbo.Umbraco.Access.Rules.Components {
    public class MediaRulesComponent : RulesComponentBase, IComponent {
        private readonly AllowMediaValidator _allowMediaValidator;
        private readonly BlockMediaValidator _limitMediaValidator;

        public MediaRulesComponent(AllowMediaValidator allowMediaValidator,
                                   BlockMediaValidator limitMediaValidator,
                                   IUmbracoContextAccessor umbracoContextAccessor,
                                   IProfilingLogger logger,
                                   ILocalizationService localizationService) : base(umbracoContextAccessor, logger, localizationService) {
            _allowMediaValidator = allowMediaValidator;
            _limitMediaValidator = limitMediaValidator;
        }

        public void Initialize() {
            MediaService.Deleting += Deleting;
            MediaService.EmptyingRecycleBin += EmptyingRecycleBin;
            MediaService.Moving += Moving;
            MediaService.Saving += Saving;
            MediaService.Trashing += Trashing;
        }

        private void Trashing(IMediaService sender, MoveEventArgs<IMedia> e) {
            CheckActionValid(() => _allowMediaValidator.IsTrashActionValid(sender, e), e);
            CheckActionValid(() => _limitMediaValidator.IsTrashActionValid(sender, e), e);
        }

        private void Saving(IMediaService sender, SaveEventArgs<IMedia> e) {
            CheckActionValid(() => _allowMediaValidator.IsSaveActionValid(sender, e), e);
            CheckActionValid(() => _limitMediaValidator.IsSaveActionValid(sender, e), e);

            CheckActionValid(() => _allowMediaValidator.IsRenameActionValid(sender, e), e);
            CheckActionValid(() => _limitMediaValidator.IsRenameActionValid(sender, e), e);
        }

        private void Moving(IMediaService sender, MoveEventArgs<IMedia> e) {
            CheckActionValid(() => _allowMediaValidator.IsMoveActionValid(sender, e), e);
            CheckActionValid(() => _limitMediaValidator.IsMoveActionValid(sender, e), e);
        }

        private void EmptyingRecycleBin(IMediaService sender, RecycleBinEventArgs e) {
            CheckActionValid(() => _allowMediaValidator.IsEmptyRecycleBinActionValid(sender, e), e);
            CheckActionValid(() => _limitMediaValidator.IsEmptyRecycleBinActionValid(sender, e), e);
        }

        private void Deleting(IMediaService sender, DeleteEventArgs<IMedia> e) {
            CheckActionValid(() => _allowMediaValidator.IsDeleteActionValid(sender, e), e);
            CheckActionValid(() => _limitMediaValidator.IsDeleteActionValid(sender, e), e);
        }

        public void Terminate() {
            MediaService.Deleting -= Deleting;
            MediaService.EmptyingRecycleBin -= EmptyingRecycleBin;
            MediaService.Moving -= Moving;
            MediaService.Saving -= Saving;
            MediaService.Trashing -= Trashing;
        }
    }
}
