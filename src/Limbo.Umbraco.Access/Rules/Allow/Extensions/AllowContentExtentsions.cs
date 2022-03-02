using System.Collections.Generic;
using System.Linq;
using Limbo.Umbraco.Access.Rules.Allow.Models.Content;
using Limbo.Umbraco.Access.UserActions.Models;
using Umbraco.Core.Services;

namespace Limbo.Umbraco.Access.Rules.Allow.Extensions {
    public static class AllowContentExtentsions {
        public static ICollection<AllowContentAccessRule> AddRule(this ICollection<AllowContentAccessRule> rules, string name, IEnumerable<string> userGroupAliases, IEnumerable<ContentUserAction> userActions, IUserService userService) {
            rules.Add(new AllowContentAccessRule(
            name,
            userGroupAliases.Select(group => userService.GetUserGroupByAlias(group)),
            userActions));

            return rules;
        }

        public static ICollection<AllowContentAccessRule> AddRule(this ICollection<AllowContentAccessRule> rules, string name, IEnumerable<string> userGroupAliases, ContentUserAction userActions, IUserService userService) {
            return rules.AddRule(name, userGroupAliases, new List<ContentUserAction>() { userActions }, userService);
        }

        public static ICollection<AllowContentAccessRule> AddRule(this ICollection<AllowContentAccessRule> rules, string name, string userGroupAlias, IEnumerable<ContentUserAction> userActions, IUserService userService) {
            return rules.AddRule(name, new List<string>() { userGroupAlias }, userActions, userService);
        }

        public static ICollection<AllowContentAccessRule> AddRule(this ICollection<AllowContentAccessRule> rules, string name, string userGroupAlias, ContentUserAction userActions, IUserService userService) {
            return rules.AddRule(name, new List<string>() { userGroupAlias }, new List<ContentUserAction>() { userActions }, userService);
        }

        public static ICollection<AllowContentAccessRule> AddContentLevelRule(this ICollection<AllowContentAccessRule> rules, string name, IEnumerable<string> userGroupAliases, IEnumerable<ContentUserAction> userActions, int level, IUserService userService) {
            rules.Add(new AllowContentLevelAccessRule(
            name,
            userGroupAliases.Select(group => userService.GetUserGroupByAlias(group)),
            userActions,
            level));

            return rules;
        }

        public static ICollection<AllowContentAccessRule> AddContentLevelRule(this ICollection<AllowContentAccessRule> rules, string name, IEnumerable<string> userGroupAliases, ContentUserAction userActions, int level, IUserService userService) {
            return rules.AddContentLevelRule(name, userGroupAliases, new List<ContentUserAction>() { userActions }, level, userService);
        }

        public static ICollection<AllowContentAccessRule> AddContentLevelRule(this ICollection<AllowContentAccessRule> rules, string name, string userGroupAlias, IEnumerable<ContentUserAction> userActions, int level, IUserService userService) {
            return rules.AddContentLevelRule(name, new List<string>() { userGroupAlias }, userActions, level, userService);
        }

        public static ICollection<AllowContentAccessRule> AddContentLevelRule(this ICollection<AllowContentAccessRule> rules, string name, string userGroupAlias, ContentUserAction userActions, int level, IUserService userService) {
            return rules.AddContentLevelRule(name, new List<string>() { userGroupAlias }, new List<ContentUserAction>() { userActions }, level, userService);
        }

        public static ICollection<AllowContentAccessRule> AddContentTypeRule(this ICollection<AllowContentAccessRule> rules, string name, IEnumerable<string> userGroupAliases, IEnumerable<ContentUserAction> userActions, string contentTypeAlias, IUserService userService) {
            rules.Add(new AllowContentTypeAccessRule(
            name,
            userGroupAliases.Select(group => userService.GetUserGroupByAlias(group)),
            userActions,
            contentTypeAlias));

            return rules;
        }

        public static ICollection<AllowContentAccessRule> AddContentTypeRule(this ICollection<AllowContentAccessRule> rules, string name, IEnumerable<string> userGroupAliases, ContentUserAction userActions, string contentTypeAlias, IUserService userService) {
            return rules.AddContentTypeRule(name, userGroupAliases, new List<ContentUserAction>() { userActions }, contentTypeAlias, userService);
        }

        public static ICollection<AllowContentAccessRule> AddContentTypeRule(this ICollection<AllowContentAccessRule> rules, string name, string userGroupAlias, IEnumerable<ContentUserAction> userActions, string contentTypeAlias, IUserService userService) {
            return rules.AddContentTypeRule(name, new List<string>() { userGroupAlias }, userActions, contentTypeAlias, userService);
        }

        public static ICollection<AllowContentAccessRule> AddContentTypeRule(this ICollection<AllowContentAccessRule> rules, string name, string userGroupAlias, ContentUserAction userActions, string contentTypeAlias, IUserService userService) {
            return rules.AddContentTypeRule(name, new List<string>() { userGroupAlias }, new List<ContentUserAction>() { userActions }, contentTypeAlias, userService);
        }
    }
}
