using ArtShop.Business;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.UI.Process
{
    public class ArtistaProcess : ProcessComponent
    {
        public List<Artist> List()
        {
            var response = HttpGet<List<Artist>>("api/artist/listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }
        public Artist Get(int id)
        {
            var response = HttpGet<Artist>("api/artist/buscar", new List<object>() {id}, MediaType.Json);
            return response;
        }

        public Artist Add(Artist artist)
        {
            var response = HttpPost<Artist>("api/artist/agregar", artist, MediaType.Json);
            return response;
        }

        public void Edit(Artist artist)
        {
            HttpPost<Artist>("api/artist/editar", artist, MediaType.Json);
        }

        public void Remove(int artistId)
        {
            HttpDelete<Artist>("api/artist/Eliminar", artistId, MediaType.Json);
        }

    }
}
