using ArtShop.Data;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Business
{
    public class ArtistBusiness
    {

        public List<Artist> List()
        {
            List<Artist> result = default(List<Artist>);
            var artistDAC = new ArtistDAC();
            result = artistDAC.Select();
            return result;
        }

        public void Edit(Artist artist)
        {
            var artistDAC = new ArtistDAC();
            artistDAC.UpdateById(artist);
        }


        public Artist Get(int id)
        {
            var artistDAC = new ArtistDAC();
            var result = artistDAC.SelectById(id);
            return result;
        }

        public Artist Add(Artist artist)
        {
            Artist result = default(Artist);
            var artistDAC = new ArtistDAC();

            result = artistDAC.Create(artist);
            return result;
        }


        public void Remove(int id)
        {
            var artistDAC = new ArtistDAC();
            artistDAC.DeleteById(id);
        }

    }
}
