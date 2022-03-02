using System.Collections.Generic;
using Limbo.Umbraco.Access.Rules.Allow.Models.Content;
using Limbo.Umbraco.Access.Rules.Allow.Models.Media;
using Limbo.Umbraco.Access.Rules.Blocks.Models.Content;
using Limbo.Umbraco.Access.Rules.Blocks.Models.Media;

namespace Limbo.Umbraco.Access.Rules {
    public class RuleCollection {
        public ICollection<AllowContentAccessRule> ContentAllows { get; set; } = new List<AllowContentAccessRule>();
        public ICollection<LimitContentAccessRule> ContentLimits { get; set; } = new List<LimitContentAccessRule>();
        public ICollection<AllowMediaAccessRule> MediaAllows { get; set; } = new List<AllowMediaAccessRule>();
        public ICollection<LimitMediaAccessRule> MediaLimits { get; set; } = new List<LimitMediaAccessRule>();
    }
}
