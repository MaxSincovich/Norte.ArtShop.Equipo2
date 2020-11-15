using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ArtShop.Data
{
    public class TipoUsuariosDAC : DataAccessComponent
    {

        public List<TipoUsuarios> GetTipoUsuarios()
        {
            const string SQL_STATEMENT =
                "SELECT [IdTipoUsuario], [Descripcion] " +
                "FROM dbo.TipoUsuarios ";

            List<TipoUsuarios> result = new List<TipoUsuarios>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoUsuarios tipoUsuarios = LoadTipoUsuarios(dr);
                        result.Add(tipoUsuarios);
                    }
                }
            }
            return result;

        }

        private TipoUsuarios LoadTipoUsuarios(IDataReader dr)
        {
            TipoUsuarios tu = new TipoUsuarios();
            tu.IdTipoUsuario = GetDataValue<int>(dr, "IdTipoUsuario");
            tu.Descripcion = GetDataValue<string>(dr, "Descripcion");

            return tu;
        }

    }
}
