﻿using System.Collections.Generic;
using Limbo.Umbraco.UserPermissions.UserActions.Models;
using Umbraco.Core.Models.Membership;

namespace Limbo.Umbraco.UserPermissions.Rules.Blocks.Models.Content {
    public class BlockContentTypeAccessRule : BlockContentAccessRule {
        public BlockContentTypeAccessRule(string name, IEnumerable<IUserGroup> userGroups, IEnumerable<ContentUserAction> userActions, string contentTypeAlias) : base(name, userGroups, userActions) {
            ContentTypeAlias = contentTypeAlias;
        }

        public string ContentTypeAlias { get; set; }
    }
}
