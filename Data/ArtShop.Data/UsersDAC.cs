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
    public class UsersDAC : DataAccessComponent
    {
        public Users Create(Users user)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Users ([NombreUsuario], [Contraseña], [Nombre], [Apellido],[DNI], [FechaNacimiento], [FechaCreacion], IdTipoUsuario) " +
                "VALUES(@NombreUsuario, @Contraseña,@Nombre, @Apellido, @DNI, @FechaNacimiento, @FechaCreacion, @IdTipoUsuario); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@NombreUsuario", DbType.String, user.NombreUsuario);
                db.AddInParameter(cmd, "@Contraseña", DbType.String, user.Contraseña);
                db.AddInParameter(cmd, "@Nombre", DbType.String, user.Nombre);
                db.AddInParameter(cmd, "@Apellido", DbType.String, user.Apellido );
                db.AddInParameter(cmd, "@DNI", DbType.String, user.DNI);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, user.FechaNacimiento != DateTime.MinValue ? user.FechaNacimiento : DateTime.Now);
                db.AddInParameter(cmd, "@FechaCreacion", DbType.DateTime, user.FechaCreacion != DateTime.MinValue ? user.FechaCreacion : DateTime.Now);
                db.AddInParameter(cmd, "@IdTipoUsuario", DbType.Int32, user.IdTipoUsuario);

                user.IdUsuario = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return user;
        }

        public void UpdateById(Users user)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Users " +
                "SET " +
                    "[NombreUsuario]=@NombreUsuario, " +
                    "[Contraseña]=@Contraseña, " +
                    "[Nombre]=@Nombre, " +
                    "[Apellido]=@Apellido, " +
                    "[DNI]=@DNI, " +
                    "[FechaNacimiento]=@FechaNacimiento, " +
                    "[FechaCreacion] = @FechaCreacion, "+
                    "[IdTipoUsuario] = @IdTipoUsuario, " +
                    "[UserName]=@UserName, " +
                " WHERE [IdUsuario]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@NombreUsuario", DbType.String, user.NombreUsuario);
                db.AddInParameter(cmd, "@Contraseña", DbType.String, user.Contraseña);
                db.AddInParameter(cmd, "@Nombre", DbType.String, user.Nombre);
                db.AddInParameter(cmd, "@Apellido", DbType.String, user.Apellido);
                db.AddInParameter(cmd, "@DNI", DbType.String, user.DNI);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, user.FechaNacimiento);
                db.AddInParameter(cmd, "@FechaCreacion", DbType.DateTime, user.FechaCreacion);
                db.AddInParameter(cmd, "@IdTipoUsuario", DbType.Int32, user.IdTipoUsuario);
                db.AddInParameter(cmd, "@Id", DbType.Int32, user.IdUsuario);

                db.ExecuteNonQuery(cmd);
            }
        }


        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.Users " +
                                         "WHERE [IdUsuario]=@Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public Users SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [IdUsuario], [NombreUsuario], [Contraseña], [Nombre], [Apellido],[DNI], [FechaNacimiento], [FechaCreacion], IdTipoUsuario " +
                "FROM dbo.Users "+
                "WHERE [IdUsuario]=@Id ";

            Users user = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        user = LoadUser(dr);
                    }
                }
            }

            return user;
        }


        public List<Users> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [IdUsuario], [NombreUsuario], [Contraseña], [Nombre], [Apellido],[DNI], [FechaNacimiento], [FechaCreacion], IdTipoUsuario " +
                "FROM dbo.Users ";

            List<Users> result = new List<Users>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Users user = LoadUser(dr);
                        result.Add(user);
                    }
                }
            }
            return result;
        }



        private Users LoadUser(IDataReader dr)
        {
            Users user = new Users();
            user.IdUsuario = GetDataValue<int>(dr, "IdUsuario");
            user.NombreUsuario = GetDataValue<string>(dr, "NombreUsuario");
            user.Contraseña = GetDataValue<string>(dr, "Contraseña");
            user.Nombre = GetDataValue<string>(dr, "Nombre");
            user.DNI = GetDataValue<string>(dr, "DNI");
            user.Apellido = GetDataValue<string>(dr, "Apellido");
            user.FechaNacimiento = GetDataValue<DateTime>(dr, "FechaNacimiento");
            user.FechaCreacion = GetDataValue<DateTime>(dr, "FechaCreacion");
            user.IdTipoUsuario = GetDataValue<int>(dr, "IdTipoUsuario");
            return user;
        }

    }
}
