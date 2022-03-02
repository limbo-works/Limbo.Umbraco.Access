# Documentation

## Getting started
To get started you need to add a component where you add the rules of your Umbraco installation.

Example:
```csharp
public class AccessRulesComposer : ComponentComposer<AccessRulesComponent>
{ }

public class AccessRulesComponent : IComponent
{
    private readonly RuleCollection _ruleCollection;
    private readonly IUserService _userService;
    public AccessRulesComponent(RuleCollection ruleCollection, IUserService userService)
    {
        _ruleCollection = ruleCollection;
        _userService = userService;
    }
    public void Initialize()
    {
        _ruleCollection.ContentAllows.Add(new AllowContentLevelAccessRule(
            "Limit to level 2 - Rename",
            new List<IUserGroup> { userService.GetUserGroupByAlias("admin") },
            new List<ContentUserAction> { ContentUserAction.Rename },
            2));
    }
    public void Terminate()
    { }
}

```

This example shows how to Block a user group to only being able to rename item on level 2 in the content tree.

## Reference
In this project `Allow` means that a user is allowed to perfome one or more action on the selected items and not on anything other.
`Block` therefore means the opposite. When you use a Block you're only dening access to the selected items.

The following rule types exsists:

- `AllowContentAccessRule`
- `AllowContentLevelAccessRule`
- `AllowContentTypeAccessRule`

- `AllowMediaAccessRule`
- `AllowMediaLevelAccessRule`
- `AllowMediaTypeAccessRule`

- `BlockContentAccessRule`
- `BlockContentLevelAccessRule`
- `BlockContentTypeAccessRule`

- `BlockMediaAccessRule`
- `BlockMediaLevelAccessRule`
- `BlockMediaTypeAccessRule`