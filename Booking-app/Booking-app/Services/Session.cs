using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

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

    public static ObjectId GetUserId => CurrentUser.Id;

    public static string getMembershipLevel()
    {
        if (CurrentUser is Member member)
            return member.membershipLevel;
        return null; //staff basically
    }

}


