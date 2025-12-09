using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

public interface IUser
{
    ObjectId Id { get; }
    string name { get; }
    string email { get; }
    string password { get; }
}

