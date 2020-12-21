using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;


namespace ArtShop.Data
{
    public partial class CartItemDAC : DataAccessComponent
    {

        public CartItem Create(CartItem cartitem)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.CartItem ([Price], [Quantity], [CartId], [ProductId],  CreatedOn, CreatedBy, ChangedOn, ChangedBy ) " +
                "VALUES(@Price, @Quantity,@CartId, @ProductId, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Price", DbType.Double, cartitem.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.Int32, cartitem.Quantity);
                db.AddInParameter(cmd, "@CartId", DbType.Int32, cartitem.CartId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, cartitem.ProductId);

                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime, cartitem.CreatedOn != DateTime.MinValue ? cartitem.CreatedOn : DateTime.Now);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, String.IsNullOrEmpty(cartitem.CreatedBy) ? "ApiUser" : cartitem.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime, cartitem.ChangedOn != DateTime.MinValue ? cartitem.CreatedOn : DateTime.Now);
                db.AddInParameter(cmd, "@ChangedBy", DbType.String, String.IsNullOrEmpty(cartitem.ChangedBy) ? "ApiUser" : cartitem.ChangedBy);

                cartitem.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return cartitem;
        }

        public void UpdateById(CartItem cartitem)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.CartItem " +
                "SET " +
                    "[Cookie]=@Price, " +
                    "[CartDate]=@Quantity, " +
                    "[ItemCount]=@CartId, " +
                    "[ItemCount]=@ProductId, " +
                    "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Price", DbType.Double, cartitem.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.Int32, cartitem.Quantity);
                db.AddInParameter(cmd, "@CartId", DbType.Int32, cartitem.CartId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, cartitem.ProductId);
                db.AddInParameter(cmd, "@Id", DbType.Int32, cartitem.Id);

                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime, cartitem.CreatedOn != DateTime.MinValue ? cartitem.CreatedOn : DateTime.Now);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, String.IsNullOrEmpty(cartitem.CreatedBy) ? "ApiUser" : cartitem.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime, cartitem.ChangedOn != DateTime.MinValue ? cartitem.CreatedOn : DateTime.Now);
                db.AddInParameter(cmd, "@ChangedBy", DbType.String, String.IsNullOrEmpty(cartitem.ChangedBy) ? "ApiUser" : cartitem.ChangedBy);


                db.ExecuteNonQuery(cmd);
            }
        }


        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE FROM dbo.CartItem " +
                                         "WHERE [ProductId]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
        public CartItem SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Price], [Quantity], [CartId], [ProductId] " +
                "FROM dbo.CartItem  " +
                //"WHERE [Id]=@Id ";
                 "WHERE [cartId]=@Id ";

            CartItem cartItem = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        cartItem = LoadCartItem(dr);
                    }
                }
            }

            return cartItem;
        }


        public List<CartItem> Select(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Price], [Quantity], [CartId], [ProductId] " +
                "FROM dbo.CartItem "+
                "WHERE [cartId]=@Id ";

            List<CartItem> result = new List<CartItem>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        CartItem cartitem = LoadCartItem(dr);
                        result.Add(cartitem);
                    }
                }
            }

            return result;
        }

        public void AddImage(byte[] imageBytes, string name)
        {
            using (var ms = new MemoryStream(imageBytes))
            {
                using (var fs = new FileStream("/images/" + name, FileMode.Create))
                {
                    ms.WriteTo(fs);
                }
            }
        }


        private CartItem LoadCartItem(IDataReader dr)
        {
            CartItem cartitem = new CartItem();

            cartitem.Id = GetDataValue<int>(dr, "Id");
            cartitem.Price = GetDataValue<double>(dr, "Price");
            cartitem.Quantity = GetDataValue<Int32>(dr, "Quantity");
            cartitem.CartId = GetDataValue<Int32>(dr, "CartId");
            cartitem.ProductId = GetDataValue<Int32>(dr, "ProductId");


            return cartitem;
        }
    }
}
