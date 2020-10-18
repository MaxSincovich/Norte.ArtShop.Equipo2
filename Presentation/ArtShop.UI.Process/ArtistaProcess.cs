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
            return bis.GetArtist();
        }
        public Artist Get(int id)
        {
            return bis.GetById(id);
        }

        public Artist Set(Artist artist)
        {
            return bis.Create(artist);
        }

        public void Edit(Artist artist)
        {
            bis.EditArtist(artist);
        }

    }
}
