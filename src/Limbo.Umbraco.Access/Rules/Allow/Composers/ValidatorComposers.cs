using Limbo.Umbraco.Access.Rules.Allow.Validators;
using Limbo.Umbraco.Access.Rules.Composers;
using Umbraco.Core.Composing;

namespace Limbo.Umbraco.Access.Rules.Allow.Composers {
    [ComposeAfter(typeof(RuleCollectionComposer))]
    public class ValidatorComposers : IUserComposer {
        public void Compose(Composition composition) {
            composition.Register(typeof(AllowContentValidator));
            composition.Register(typeof(AllowMediaValidator));
        }
    }
}
