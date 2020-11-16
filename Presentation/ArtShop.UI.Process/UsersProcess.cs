using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Business;
using ArtShop.Entities.Model;

namespace ArtShop.UI.Process
{
    public class UsersProcess : ProcessComponent
    {
        private UsersBusiness uBis = new UsersBusiness();

        public List<Users> List()
        {
            return uBis.List();
        }
        public Users Get(int id)
        {
            return uBis.Get(id);
        }

        public Users Create(Users users)
        {
            return uBis.Create(users);
        }

        public void Update(Users user)
        {
            uBis.Update(user);
        }

        public void Remove(int id)
        {
            uBis.Remove(id);
        }

        public List<TipoUsuarios> GetTipoUsuarios()
        {
            return uBis.GetTipoUsuarios();
        }

        public Users LogIn(Users user)
        {
            return uBis.Login(user);
        }

    }
}
