```csharp
using System;
using System.Security.Principal;

namespace SoftwareForManagingPromptsAndCustomInstructions.Security
{
    public class AccessControl
    {
        public bool IsUserAuthorized()
        {
            // Get the current logged in user
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            // Check if the user is part of the Administrators group
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
```