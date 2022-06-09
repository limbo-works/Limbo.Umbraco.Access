using Limbo.Umbraco.UserPermissions.Rules.Components;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Limbo.Umbraco.UserPermissions.Rules.Composers {
    [RuntimeLevel(MinLevel = RuntimeLevel.Boot)]
    public class ContentRulesComposer : ComponentComposer<ContentRulesComponent> { }
}
