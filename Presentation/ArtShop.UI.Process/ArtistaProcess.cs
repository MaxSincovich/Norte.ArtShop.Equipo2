using ArtShop.Business;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.UI.Process
{
    public class ArtistaProcess
    {
        private ArtistBusiness bis = new ArtistBusiness();
        public List<Artist> GetAll()
        {
            return bis.ListarTodosLosArtistas();
        }


        public Artist Get(int id)
        {
            return bis.Get(id);
        }

        public Artist Set(Artist artist)
        {
            return bis.Agregar(artist);
        }

        public Artist Edit(Artist artist)
        {
            return bis.EditarArtista(artist);
        }

    }
}
