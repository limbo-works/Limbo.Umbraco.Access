using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace Limbo.Umbraco.Access.Bases.Validators {
    public interface IContentValidator {
        bool IsCopyActionValid(IContentService sender, CopyEventArgs<IContent> e);
        bool IsDeleteActionValid(IContentService sender, DeleteEventArgs<IContent> e);
        bool IsEmptyRecycleBinActionValid(IContentService sender, RecycleBinEventArgs e);
        bool IsMoveActionValid(IContentService sender, MoveEventArgs<IContent> e);
        bool IsPublishActionValid(IContentService sender, ContentPublishingEventArgs e);
        bool IsRenameValid(IContentService sender, ContentSavingEventArgs e);
        bool IsRollBackActionValid(IContentService sender, RollbackEventArgs<IContent> e);
        bool IsSaveActionValid(IContentService sender, ContentSavingEventArgs e);
        bool IsSendToPublishActionValid(IContentService sender, SendToPublishEventArgs<IContent> e);
        bool IsSortActionValid(IContentService sender, SaveEventArgs<IContent> e);
        bool IsTrashActionValid(IContentService sender, MoveEventArgs<IContent> e);
        bool IsUnPublishActionValid(IContentService sender, PublishEventArgs<IContent> e);
    }
}