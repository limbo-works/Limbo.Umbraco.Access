﻿using Limbo.Umbraco.UserPermissions.Rules.Allow.Validators;
using Limbo.Umbraco.UserPermissions.Rules.Composers;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Limbo.Umbraco.UserPermissions.Rules.Allow.Composers {
    [RuntimeLevel(MinLevel = RuntimeLevel.Boot)]
    [ComposeAfter(typeof(RuleCollectionComposer))]
    public class ValidatorComposers : IUserComposer {
        public void Compose(Composition composition) {
            composition.Register(typeof(AllowContentValidator));
            composition.Register(typeof(AllowMediaValidator));
        }
    }
}
