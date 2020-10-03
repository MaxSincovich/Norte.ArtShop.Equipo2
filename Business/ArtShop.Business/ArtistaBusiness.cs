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
        private BaseDataService<Artist> db = new BaseDataService<Artist>();
        public List<Artist> ListarTodosLosArtistas()
        {
            return db.Get();
        }

        public Artist EditarArtista(Artist artist)
        {
            return db.Update(artist, artist.Id);
        }


        public Artist Seleccionar(int id)
        {
            var producto = this.ListarTodosLosArtistas().Where(l => l.Id == id).FirstOrDefault();
            return producto;
        }

        public Artist Get(int id)
        {
            return db.GetById(id);
        }
        public Artist Agregar(Artist artist)
        {
            return db.Create(artist);
        }
               
    }
}
