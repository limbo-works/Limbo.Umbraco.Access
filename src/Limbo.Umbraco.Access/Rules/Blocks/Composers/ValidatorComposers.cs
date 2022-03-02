using Limbo.Umbraco.Access.Rules.Blocks.Validators;
using Limbo.Umbraco.Access.Rules.Composers;
using Umbraco.Core.Composing;

namespace Limbo.Umbraco.Access.Rules.Blocks.Composers {
    [ComposeAfter(typeof(RuleCollectionComposer))]
    public class ValidatorComposers : IUserComposer {
        public void Compose(Composition composition) {
            composition.Register(typeof(LimitContentValidator));
            composition.Register(typeof(LimitMediaValidator));
        }
    }
}
