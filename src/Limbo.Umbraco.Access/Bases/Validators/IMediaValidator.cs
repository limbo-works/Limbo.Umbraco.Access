using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace Limbo.Umbraco.Access.Bases.Validators {
    public interface IMediaValidator {
        bool IsDeleteActionValid(IMediaService sender, DeleteEventArgs<IMedia> e);
        bool IsEmptyRecycleBinActionValid(IMediaService sender, RecycleBinEventArgs e);
        bool IsMoveActionValid(IMediaService sender, MoveEventArgs<IMedia> e);
        bool IsRenameActionValid(IMediaService sender, SaveEventArgs<IMedia> e);
        bool IsSaveActionValid(IMediaService sender, SaveEventArgs<IMedia> e);
        bool IsTrashActionValid(IMediaService sender, MoveEventArgs<IMedia> e);
    }
}