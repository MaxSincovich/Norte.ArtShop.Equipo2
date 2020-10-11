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
            return bis.List();
        }


        public Artist Get(int id)
        {
            return bis.Get(id);
        }

        public Artist Set(Artist artist)
        {
            return bis.Add(artist);
        }

        public void Edit(Artist artist)
        {
            bis.Edit(artist);
        }

    }
}
