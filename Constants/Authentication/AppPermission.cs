/*
 * Copyright © 2026 Blue Wolf Enterprises LLC
 * Author: Thomas M Tetsi
 * Created: 2026-02-04
 * All rights reserved.
 */

using System.Collections.ObjectModel;


namespace AuthLibrary.Constants.Authentication
{
    public record AppPermission(string Service, string Feature, string action, string Action, string Group, string Description, bool IsBasic = false)
    {
        public string Name => NameFor(Service, Feature, Action);
        public static string NameFor(string service, string feature, string action)
        {
                       return $"Permission.{service}.{feature}.{action}"; // Permission.Identity.Users.Create
        }

    }
    public class AppPermissions
    {
        private static readonly AppPermission[] _all =
            [
                new (AppService.Identity, AppFeature.Users, AppAction.Create, "Create", AppRoleGroup.SystemAccess, "Create Users"), // R1
                new (AppService.Identity, AppFeature.Users, AppAction.Read,   "Read", AppRoleGroup.SystemAccess, "Read Users"),       // R1
                new (AppService.Identity, AppFeature.Users, AppAction.Update, "Update", AppRoleGroup.SystemAccess, "Update Users"), // R1
                new (AppService.Identity, AppFeature.Users, AppAction.Delete, "Delete", AppRoleGroup.SystemAccess, "Delete Users"), // R1

                new (AppService.Identity, AppFeature.Roles, AppAction.Create, "Create", AppRoleGroup.SystemAccess, "Create Roles"), // R1
                new (AppService.Identity, AppFeature.Roles, AppAction.Read, "Read", AppRoleGroup.SystemAccess, "Read Roles"),       // R1
                new (AppService.Identity, AppFeature.Roles, AppAction.Update, "Update", AppRoleGroup.SystemAccess, "Update Roles"), // R1
                new (AppService.Identity, AppFeature.Roles, AppAction.Delete, "Delete", AppRoleGroup.SystemAccess, "Delete Roles"), // R1

                new (AppService.Identity, AppFeature.UserRoles, AppAction.Read, "Read", AppRoleGroup.SystemAccess, "Read User Roles"),       // R1
                new (AppService.Identity, AppFeature.UserRoles, AppAction.Update, "Update", AppRoleGroup.SystemAccess, "Update User Roles"), // R1

                new (AppService.Identity, AppFeature.RoleClaims, AppAction.Read, "Read", AppRoleGroup.SystemAccess, "Read Role Claims/Permissions"),       // R1
                new (AppService.Identity, AppFeature.RoleClaims, AppAction.Update, "Update", AppRoleGroup.SystemAccess, "Update Claims/Permissions"), // R1


            ];

        public static IReadOnlyList<AppPermission> AllPermissions { get; } =
            new ReadOnlyCollection<AppPermission>(_all);

        public static IReadOnlyList<AppPermission> AdminPermissions { get; } =
            new ReadOnlyCollection<AppPermission>(_all.Where(static p => !p.IsBasic).ToArray());

        public static IReadOnlyList<AppPermission> BasicPermissions { get; } =
            new ReadOnlyCollection<AppPermission>(_all.Where(static p => !p.IsBasic).ToArray());

    }
}
