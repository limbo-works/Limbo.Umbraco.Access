using System.Collections.Generic;
using Limbo.Umbraco.UserPermissions.Rules.Allow.Models.Content;
using Limbo.Umbraco.UserPermissions.Rules.Allow.Models.Media;
using Limbo.Umbraco.UserPermissions.Rules.Blocks.Models.Content;
using Limbo.Umbraco.UserPermissions.Rules.Blocks.Models.Media;

namespace Limbo.Umbraco.UserPermissions.Rules {
    public class RuleCollection {
        public ICollection<AllowContentAccessRule> ContentAllows { get; set; } = new List<AllowContentAccessRule>();
        public ICollection<BlockContentAccessRule> ContentLimits { get; set; } = new List<BlockContentAccessRule>();
        public ICollection<AllowMediaAccessRule> MediaAllows { get; set; } = new List<AllowMediaAccessRule>();
        public ICollection<BlockMediaAccessRule> MediaLimits { get; set; } = new List<BlockMediaAccessRule>();
    }
}
