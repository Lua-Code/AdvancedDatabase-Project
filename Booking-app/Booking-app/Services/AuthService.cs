using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

public class AuthService
{
    private readonly MemberService _memberService;
    private readonly StaffService _staffService;

    public AuthService()
    {
        var db = MongoDBClient.GetDatabase();
        _memberService = new MemberService();
        _staffService = new StaffService();
    }

    public IUser Login(string email, string password)
    {
        var member = _memberService.GetByEmailAndPassword(email, password);
        if (member != null)
        {
            return member;
        }


        var staff = _staffService.GetByEmailAndPassword(email,password);
        if (staff != null)
        {
            return staff;
        }

        return null; //login failed :(
    }

    public void Logout()
    {
        Session.Logout();
    }
}
