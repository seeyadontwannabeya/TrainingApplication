using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Trening.Models;

namespace Trening.Library
{
    public class LoginUtility
    {
        private TreningEntities db = new TreningEntities();

        public string Login(string username, string password)
        {
            //        db.Registration.Where
            var user = db.Login.Where(u => u.Email == username).FirstOrDefault<Login>();

            if (user != null)
            {
                if (user.Pasword == password)
                {
                    return CreateTokenString(username);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public string CreateTokenString(string uid)
        {
            var guid = Guid.NewGuid();
            var ret = uid + ":" + guid.ToString();
            return Utilities.Base64.Encode(ret);
        }
    }
}