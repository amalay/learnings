using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amalay.FoodOrder.Enumerations
{
    public class Enumerations
    {
    }

    public enum SignInStatus
    {
        Success,
        LockedOut,
        RequiresTwoFactorAuthentication,
        Failure
    }
}