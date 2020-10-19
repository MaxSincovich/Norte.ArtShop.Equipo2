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
        //private BaseDataService<Artist> db = new BaseDataService<Artist>();
        //public List<Artist> GetArtist()
        //{
        //    return db.Get();
        //}
        //public Artist EditArtist(Artist artist)
        //{
        //    return db.Update(artist, artist.Id);
        //}
        //public Artist GetById(int id)
        //{
        //    return db.GetById(id);
        //}
        //public Artist Create(Artist artist)
        //{
        //    return db.Create(artist);
        //}
        //public void Delete (int id)
        //{
        //    db.Delete(id);
        //}
    }
}
