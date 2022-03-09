using System.Collections.Generic;
using System.Linq;
using Limbo.Umbraco.UserPermissions.Rules.Blocks.Models.Content;
using Limbo.Umbraco.UserPermissions.UserActions.Models;
using Umbraco.Core.Services;

namespace Limbo.Umbraco.UserPermissions.Rules.Blocks.Extensions {
    public static class BlockContentExtensions {
        public static ICollection<BlockContentAccessRule> AddRule(this ICollection<BlockContentAccessRule> rules, string name, IEnumerable<string> userGroupAliases, IEnumerable<ContentUserAction> userActions, IUserService userService) {
            rules.Add(new BlockContentAccessRule(
            name,
            userGroupAliases.Select(group => userService.GetUserGroupByAlias(group)),
            userActions));

            return rules;
        }

        public static ICollection<BlockContentAccessRule> AddRule(this ICollection<BlockContentAccessRule> rules, string name, IEnumerable<string> userGroupAliases, ContentUserAction userActions, IUserService userService) {
            return rules.AddRule(name, userGroupAliases, new List<ContentUserAction>() { userActions }, userService);
        }

        public static ICollection<BlockContentAccessRule> AddRule(this ICollection<BlockContentAccessRule> rules, string name, string userGroupAlias, IEnumerable<ContentUserAction> userActions, IUserService userService) {
            return rules.AddRule(name, new List<string>() { userGroupAlias }, userActions, userService);
        }

        public static ICollection<BlockContentAccessRule> AddRule(this ICollection<BlockContentAccessRule> rules, string name, string userGroupAlias, ContentUserAction userActions, IUserService userService) {
            return rules.AddRule(name, new List<string>() { userGroupAlias }, new List<ContentUserAction>() { userActions }, userService);
        }

        public static ICollection<BlockContentAccessRule> AddContentLevelRule(this ICollection<BlockContentAccessRule> rules, string name, IEnumerable<string> userGroupAliases, IEnumerable<ContentUserAction> userActions, int level, IUserService userService) {
            rules.Add(new BlockContentLevelAccessRule(
            name,
            userGroupAliases.Select(group => userService.GetUserGroupByAlias(group)),
            userActions,
            level));

            return rules;
        }

        public static ICollection<BlockContentAccessRule> AddContentLevelRule(this ICollection<BlockContentAccessRule> rules, string name, IEnumerable<string> userGroupAliases, ContentUserAction userActions, int level, IUserService userService) {
            return rules.AddContentLevelRule(name, userGroupAliases, new List<ContentUserAction>() { userActions }, level, userService);
        }

        public static ICollection<BlockContentAccessRule> AddContentLevelRule(this ICollection<BlockContentAccessRule> rules, string name, string userGroupAlias, IEnumerable<ContentUserAction> userActions, int level, IUserService userService) {
            return rules.AddContentLevelRule(name, new List<string>() { userGroupAlias }, userActions, level, userService);
        }

        public static ICollection<BlockContentAccessRule> AddContentLevelRule(this ICollection<BlockContentAccessRule> rules, string name, string userGroupAlias, ContentUserAction userActions, int level, IUserService userService) {
            return rules.AddContentLevelRule(name, new List<string>() { userGroupAlias }, new List<ContentUserAction>() { userActions }, level, userService);
        }

        public static ICollection<BlockContentAccessRule> AddContentTypeRule(this ICollection<BlockContentAccessRule> rules, string name, IEnumerable<string> userGroupAliases, IEnumerable<ContentUserAction> userActions, string contentTypeAlias, IUserService userService) {
            rules.Add(new BlockContentTypeAccessRule(
            name,
            userGroupAliases.Select(group => userService.GetUserGroupByAlias(group)),
            userActions,
            contentTypeAlias));

            return rules;
        }

        public static ICollection<BlockContentAccessRule> AddContentTypeRule(this ICollection<BlockContentAccessRule> rules, string name, IEnumerable<string> userGroupAliases, ContentUserAction userActions, string contentTypeAlias, IUserService userService) {
            return rules.AddContentTypeRule(name, userGroupAliases, new List<ContentUserAction>() { userActions }, contentTypeAlias, userService);
        }

        public static ICollection<BlockContentAccessRule> AddContentTypeRule(this ICollection<BlockContentAccessRule> rules, string name, string userGroupAlias, IEnumerable<ContentUserAction> userActions, string contentTypeAlias, IUserService userService) {
            return rules.AddContentTypeRule(name, new List<string>() { userGroupAlias }, userActions, contentTypeAlias, userService);
        }

        public static ICollection<BlockContentAccessRule> AddContentTypeRule(this ICollection<BlockContentAccessRule> rules, string name, string userGroupAlias, ContentUserAction userActions, string contentTypeAlias, IUserService userService) {
            return rules.AddContentTypeRule(name, new List<string>() { userGroupAlias }, new List<ContentUserAction>() { userActions }, contentTypeAlias, userService);
        }
    }
}
