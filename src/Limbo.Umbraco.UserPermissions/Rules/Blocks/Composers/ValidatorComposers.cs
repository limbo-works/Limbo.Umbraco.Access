using Limbo.Umbraco.UserPermissions.Rules.Blocks.Validators;
using Limbo.Umbraco.UserPermissions.Rules.Composers;
using Umbraco.Core.Composing;

namespace Limbo.Umbraco.UserPermissions.Rules.Blocks.Composers {
    [ComposeAfter(typeof(RuleCollectionComposer))]
    public class ValidatorComposers : IUserComposer {
        public void Compose(Composition composition) {
            composition.Register(typeof(BlockContentValidator));
            composition.Register(typeof(BlockMediaValidator));
        }
    }
}
