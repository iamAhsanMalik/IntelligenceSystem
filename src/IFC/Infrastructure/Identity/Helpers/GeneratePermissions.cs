using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IFC.Infrastructure.Identity.Helpers;

public static class GeneratePermissions
{
    public static List<string> GeneratePermissionsForModule(string module)
    {
        return new List<string>()
        {
            $"Permissions.{module}.Create",
            $"Permissions.{module}.View",
            $"Permissions.{module}.Edit",
            $"Permissions.{module}.Delete",
        };
    }
}
