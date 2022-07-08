using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Services
{
    public interface IEncrypter
    {
        string GetSalt(string value);
        string GetPassword(string salt, string password);
        string GetHash(string value, string salt);
    }
}
