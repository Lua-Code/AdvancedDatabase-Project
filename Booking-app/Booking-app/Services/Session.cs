using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Session
{
    public static IUser CurrentUser { get; private set; }

    public static void Login(IUser user)
    {
        CurrentUser = user;
    }

    public static void Logout()
    {
        CurrentUser = null;
    }

    public static bool IsLoggedIn => CurrentUser != null;

    public static bool IsMember => CurrentUser is Member;
    public static bool IsStaff => CurrentUser is Staff;
}


