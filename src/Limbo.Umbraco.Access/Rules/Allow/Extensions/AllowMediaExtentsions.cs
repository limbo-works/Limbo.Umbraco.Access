using System.Collections.Generic;
using System.Linq;
using Limbo.Umbraco.Access.Rules.Allow.Models.Media;
using Limbo.Umbraco.Access.UserActions.Models;
using Umbraco.Core.Services;

namespace Limbo.Umbraco.Access.Rules.Allow.Extensions {
    public static class AllowMediaExtentsions {
        public static ICollection<AllowMediaAccessRule> AddRule(this ICollection<AllowMediaAccessRule> rules, string name, IEnumerable<string> userGroupAliases, IEnumerable<MediaUserAction> userActions, IUserService userService) {
            rules.Add(new AllowMediaAccessRule(
            name,
            userGroupAliases.Select(group => userService.GetUserGroupByAlias(group)),
            userActions));

            return rules;
        }

        public static ICollection<AllowMediaAccessRule> AddRule(this ICollection<AllowMediaAccessRule> rules, string name, IEnumerable<string> userGroupAliases, MediaUserAction userActions, IUserService userService) {
            return rules.AddRule(name, userGroupAliases, new List<MediaUserAction>() { userActions }, userService);
        }

        public static ICollection<AllowMediaAccessRule> AddRule(this ICollection<AllowMediaAccessRule> rules, string name, string userGroupAlias, IEnumerable<MediaUserAction> userActions, IUserService userService) {
            return rules.AddRule(name, new List<string>() { userGroupAlias }, userActions, userService);
        }

        public static ICollection<AllowMediaAccessRule> AddRule(this ICollection<AllowMediaAccessRule> rules, string name, string userGroupAlias, MediaUserAction userActions, IUserService userService) {
            return rules.AddRule(name, new List<string>() { userGroupAlias }, new List<MediaUserAction>() { userActions }, userService);
        }

        public static ICollection<AllowMediaAccessRule> AddMediaLevelRule(this ICollection<AllowMediaAccessRule> rules, string name, IEnumerable<string> userGroupAliases, IEnumerable<MediaUserAction> userActions, int level, IUserService userService) {
            rules.Add(new AllowMediaLevelAccessRule(
            name,
            userGroupAliases.Select(group => userService.GetUserGroupByAlias(group)),
            userActions,
            level));

            return rules;
        }

        public static ICollection<AllowMediaAccessRule> AddMediaLevelRule(this ICollection<AllowMediaAccessRule> rules, string name, IEnumerable<string> userGroupAliases, MediaUserAction userActions, int level, IUserService userService) {
            return rules.AddMediaLevelRule(name, userGroupAliases, new List<MediaUserAction>() { userActions }, level, userService);
        }

        public static ICollection<AllowMediaAccessRule> AddMediaLevelRule(this ICollection<AllowMediaAccessRule> rules, string name, string userGroupAlias, IEnumerable<MediaUserAction> userActions, int level, IUserService userService) {
            return rules.AddMediaLevelRule(name, new List<string>() { userGroupAlias }, userActions, level, userService);
        }

        public static ICollection<AllowMediaAccessRule> AddMediaLevelRule(this ICollection<AllowMediaAccessRule> rules, string name, string userGroupAlias, MediaUserAction userActions, int level, IUserService userService) {
            return rules.AddMediaLevelRule(name, new List<string>() { userGroupAlias }, new List<MediaUserAction>() { userActions }, level, userService);
        }

        public static ICollection<AllowMediaAccessRule> AddMediaTypeRule(this ICollection<AllowMediaAccessRule> rules, string name, IEnumerable<string> userGroupAliases, IEnumerable<MediaUserAction> userActions, string MediaTypeAlias, IUserService userService) {
            rules.Add(new AllowMediaTypeAccessRule(
            name,
            userGroupAliases.Select(group => userService.GetUserGroupByAlias(group)),
            userActions,
            MediaTypeAlias));

            return rules;
        }

        public static ICollection<AllowMediaAccessRule> AddMediaTypeRule(this ICollection<AllowMediaAccessRule> rules, string name, IEnumerable<string> userGroupAliases, MediaUserAction userActions, string MediaTypeAlias, IUserService userService) {
            return rules.AddMediaTypeRule(name, userGroupAliases, new List<MediaUserAction>() { userActions }, MediaTypeAlias, userService);
        }

        public static ICollection<AllowMediaAccessRule> AddMediaTypeRule(this ICollection<AllowMediaAccessRule> rules, string name, string userGroupAlias, IEnumerable<MediaUserAction> userActions, string MediaTypeAlias, IUserService userService) {
            return rules.AddMediaTypeRule(name, new List<string>() { userGroupAlias }, userActions, MediaTypeAlias, userService);
        }

        public static ICollection<AllowMediaAccessRule> AddMediaTypeRule(this ICollection<AllowMediaAccessRule> rules, string name, string userGroupAlias, MediaUserAction userActions, string MediaTypeAlias, IUserService userService) {
            return rules.AddMediaTypeRule(name, new List<string>() { userGroupAlias }, new List<MediaUserAction>() { userActions }, MediaTypeAlias, userService);
        }
    }
}
