using System.Collections.Generic;
using System.Linq;
using Limbo.Umbraco.UserPermissions.Rules.Blocks.Models.Media;
using Limbo.Umbraco.UserPermissions.UserActions.Models;
using Umbraco.Core.Services;

namespace Limbo.Umbraco.UserPermissions.Rules.Blocks.Extensions {
    public static class BlockMediaExtensions {
        public static ICollection<BlockMediaAccessRule> AddRule(this ICollection<BlockMediaAccessRule> rules, string name, IEnumerable<string> userGroupAliases, IEnumerable<MediaUserAction> userActions, IUserService userService) {
            rules.Add(new BlockMediaAccessRule(
            name,
            userGroupAliases.Select(group => userService.GetUserGroupByAlias(group)),
            userActions));

            return rules;
        }

        public static ICollection<BlockMediaAccessRule> AddRule(this ICollection<BlockMediaAccessRule> rules, string name, IEnumerable<string> userGroupAliases, MediaUserAction userActions, IUserService userService) {
            return rules.AddRule(name, userGroupAliases, new List<MediaUserAction>() { userActions }, userService);
        }

        public static ICollection<BlockMediaAccessRule> AddRule(this ICollection<BlockMediaAccessRule> rules, string name, string userGroupAlias, IEnumerable<MediaUserAction> userActions, IUserService userService) {
            return rules.AddRule(name, new List<string>() { userGroupAlias }, userActions, userService);
        }

        public static ICollection<BlockMediaAccessRule> AddRule(this ICollection<BlockMediaAccessRule> rules, string name, string userGroupAlias, MediaUserAction userActions, IUserService userService) {
            return rules.AddRule(name, new List<string>() { userGroupAlias }, new List<MediaUserAction>() { userActions }, userService);
        }

        public static ICollection<BlockMediaAccessRule> AddMediaLevelRule(this ICollection<BlockMediaAccessRule> rules, string name, IEnumerable<string> userGroupAliases, IEnumerable<MediaUserAction> userActions, int level, IUserService userService) {
            rules.Add(new BlockMediaLevelAccessRule(
            name,
            userGroupAliases.Select(group => userService.GetUserGroupByAlias(group)),
            userActions,
            level));

            return rules;
        }

        public static ICollection<BlockMediaAccessRule> AddMediaLevelRule(this ICollection<BlockMediaAccessRule> rules, string name, IEnumerable<string> userGroupAliases, MediaUserAction userActions, int level, IUserService userService) {
            return rules.AddMediaLevelRule(name, userGroupAliases, new List<MediaUserAction>() { userActions }, level, userService);
        }

        public static ICollection<BlockMediaAccessRule> AddMediaLevelRule(this ICollection<BlockMediaAccessRule> rules, string name, string userGroupAlias, IEnumerable<MediaUserAction> userActions, int level, IUserService userService) {
            return rules.AddMediaLevelRule(name, new List<string>() { userGroupAlias }, userActions, level, userService);
        }

        public static ICollection<BlockMediaAccessRule> AddMediaLevelRule(this ICollection<BlockMediaAccessRule> rules, string name, string userGroupAlias, MediaUserAction userActions, int level, IUserService userService) {
            return rules.AddMediaLevelRule(name, new List<string>() { userGroupAlias }, new List<MediaUserAction>() { userActions }, level, userService);
        }

        public static ICollection<BlockMediaAccessRule> AddMediaTypeRule(this ICollection<BlockMediaAccessRule> rules, string name, IEnumerable<string> userGroupAliases, IEnumerable<MediaUserAction> userActions, string MediaTypeAlias, IUserService userService) {
            rules.Add(new BlockMediaTypeAccessRule(
            name,
            userGroupAliases.Select(group => userService.GetUserGroupByAlias(group)),
            userActions,
            MediaTypeAlias));

            return rules;
        }

        public static ICollection<BlockMediaAccessRule> AddMediaTypeRule(this ICollection<BlockMediaAccessRule> rules, string name, IEnumerable<string> userGroupAliases, MediaUserAction userActions, string MediaTypeAlias, IUserService userService) {
            return rules.AddMediaTypeRule(name, userGroupAliases, new List<MediaUserAction>() { userActions }, MediaTypeAlias, userService);
        }

        public static ICollection<BlockMediaAccessRule> AddMediaTypeRule(this ICollection<BlockMediaAccessRule> rules, string name, string userGroupAlias, IEnumerable<MediaUserAction> userActions, string MediaTypeAlias, IUserService userService) {
            return rules.AddMediaTypeRule(name, new List<string>() { userGroupAlias }, userActions, MediaTypeAlias, userService);
        }

        public static ICollection<BlockMediaAccessRule> AddMediaTypeRule(this ICollection<BlockMediaAccessRule> rules, string name, string userGroupAlias, MediaUserAction userActions, string MediaTypeAlias, IUserService userService) {
            return rules.AddMediaTypeRule(name, new List<string>() { userGroupAlias }, new List<MediaUserAction>() { userActions }, MediaTypeAlias, userService);
        }
    }
}
