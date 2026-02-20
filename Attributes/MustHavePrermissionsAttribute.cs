/*
 * Copyright © 2026 Blue Wolf Enterprises LLC
 * Author: Thomas M Tetsi
 * Created: 2026-02-04
 * All rights reserved.
 */

using AuthLibrary.Constants.Authentication;
using Microsoft.AspNetCore.Authorization;   

namespace AuthLibrary.Attributes
{
    public class MustHavePrermissionsAttribute : AuthorizeAttribute
    {
        public MustHavePrermissionsAttribute(string service,string feature, string action)
        {
            Policy = AppPermission.NameFor(service, feature, action);
        }
    }
}
