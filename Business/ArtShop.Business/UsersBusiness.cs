using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Data;
using ArtShop.Entities.Model;

namespace ArtShop.Business
{
    public class UsersBusiness
    {
        public List<Users> List()
        {
            List<Users> result = default(List<Users>);
            var userDac = new UsersDAC();
            result = userDac.Select();
            return result;
        }

        public void Update(Users artist)
        {
            var userDac = new UsersDAC();
            userDac.UpdateById(artist);
        }


        public Users Get(int id)
        {
            var userDac = new UsersDAC();
            var result = userDac.SelectById(id);
            return result;
        }

        public Users Create(Users artist)
        {
            Users result = default(Users);
            var userDac = new UsersDAC();

            result = userDac.Create(artist);
            return result;
        }


        public void Remove(int id)
        {
            var userDac = new UsersDAC();
            userDac.DeleteById(id);
        }

        public List<TipoUsuarios> GetTipoUsuarios()
        {
            var TuserDac = new TipoUsuariosDAC();
            return TuserDac.GetTipoUsuarios();
        }

        public Users Login (Users users)
        {
            var userDac = new UsersDAC();
            return userDac.Login(users.NombreUsuario, users.Contraseña);
        }
    }
}
