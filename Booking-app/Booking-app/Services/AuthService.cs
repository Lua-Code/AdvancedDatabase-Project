using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
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
            Session.Login(member);
            return member;
        }


        var staff = _staffService.GetByEmailAndPassword(email,password);
        if (staff != null)
        {
            Session.Login(staff);
            return staff;
        }

        return null; //login failed :(
    }

    public bool DeleteUser(ObjectId userId)
    { 
        Member member = _memberService.GetById(userId);
        if (member != null) { 
            _memberService.DeleteMember(member);
            return true;
        }
        Staff staff = _staffService.GetById(userId);
        if (staff != null) {
            _staffService.DeleteStaff(staff);
            return true;
        }
        return false;

    }

    public bool Signup(Member member)
    { 
        return _memberService.AddMember(member);
    
    }

    public void Logout()
    {
        Session.Logout();
    }
}
