using Limbo.Umbraco.Access.Rules.Composers;
using Limbo.Umbraco.Access.Rules.Limits.Validators;
using Umbraco.Core.Composing;

namespace Limbo.Umbraco.Access.Rules.Limits.Composers {
    [ComposeAfter(typeof(RuleCollectionComposer))]
    public class ValidatorComposers : IUserComposer {
        public void Compose(Composition composition) {
            composition.Register(typeof(LimitContentValidator));
            composition.Register(typeof(LimitMediaValidator));
        }
    }
}
