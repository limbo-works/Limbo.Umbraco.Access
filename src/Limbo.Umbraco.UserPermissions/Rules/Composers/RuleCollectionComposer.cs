using Umbraco.Core.Composing;

namespace Limbo.Umbraco.UserPermissions.Rules.Composers {
    public class RuleCollectionComposer : IUserComposer {
        public void Compose(Composition composition) {
            composition.Register(typeof(RuleCollection), Lifetime.Singleton);
        }
    }
}
