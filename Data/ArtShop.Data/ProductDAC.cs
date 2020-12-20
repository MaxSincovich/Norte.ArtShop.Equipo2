﻿using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;


namespace ArtShop.Data
{
    public partial class ProductDAC : DataAccessComponent
    {

        public Product Create(Product product)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Product ([Title], [Description], [Image], [Price], [QuantitySold], [AvgStars],[ArtistId], CreatedOn, CreatedBy, ChangedOn, ChangedBy ) " +
                "VALUES(@Title, @Description,@Image, @Price, @QuantitySold, @AvgStars, @ArtistId, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Title", DbType.String, product.Title);
                db.AddInParameter(cmd, " @Description", DbType.String, product.Description);
                db.AddInParameter(cmd, "@Image", DbType.String, product.Image);
                db.AddInParameter(cmd, "@Price", DbType.Double, product.Price);
                db.AddInParameter(cmd, " @QuantitySold", DbType.Int32, product.QuantitySold);
                db.AddInParameter(cmd, "@AvgStars", DbType.Double, product.AvgStars);
                db.AddInParameter(cmd, "@ArtistId", DbType.Int32, product.ArtistId);

                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime, product.CreatedOn != DateTime.MinValue ? product.CreatedOn : DateTime.Now);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, String.IsNullOrEmpty(product.CreatedBy) ? "ApiUser" : product.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime, product.ChangedOn != DateTime.MinValue ? product.CreatedOn : DateTime.Now);
                db.AddInParameter(cmd, "@ChangedBy", DbType.String, String.IsNullOrEmpty(product.ChangedBy) ? "ApiUser" : product.ChangedBy);

                product.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return product;
        }

        public void UpdateById(Product product)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Product " +
                "SET " +
                    "[Title]=@Title, " +
                    "[Description]= @Description, " +
                    "[Image]=@Image, " +
                    "[Price]=@Price, " +
                    "[QuantitySold]=@QuantitySold, " +
                    "[AvgStars]=@AvgStars " +
                    "[ArtistId]=@ArtistId" +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Title", DbType.String, string.IsNullOrEmpty(product.Title) ? "" : product.Title);
                db.AddInParameter(cmd, "@Description", DbType.String, string.IsNullOrEmpty(product.Description) ? "" : product.Description);
                db.AddInParameter(cmd, "@Image", DbType.String, string.IsNullOrEmpty(product.Image) ? "" : product.Image);
                db.AddInParameter(cmd, "@Price", DbType.Double, product.Price);
                db.AddInParameter(cmd, "@QuantitySold", DbType.Int32, product.QuantitySold);
                db.AddInParameter(cmd, "@AvgStars", DbType.Double, product.AvgStars);
                db.AddInParameter(cmd, "@Id", DbType.Int32, product.Id);

                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime, product.CreatedOn != DateTime.MinValue ? product.CreatedOn : DateTime.Now);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, String.IsNullOrEmpty(product.CreatedBy) ? "ApiUser" : product.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime, product.ChangedOn != DateTime.MinValue ? product.CreatedOn : DateTime.Now);
                db.AddInParameter(cmd, "@ChangedBy", DbType.String, String.IsNullOrEmpty(product.ChangedBy) ? "ApiUser" : product.ChangedBy);


                db.ExecuteNonQuery(cmd);
            }
        }


        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.Product " +
                                         "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public Product SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Title], [Description], [Image], [Price], [QuantitySold], [AvgStars],[ArtistId] " +
                "FROM dbo.Product  " +
                "WHERE [Id]=@Id ";

            Product product = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        product = LoadProducts(dr);
                    }
                }
            }

            return product;
        }


        public List<Product> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Title], [Description], [Image], [Price], [QuantitySold], [AvgStars],[ArtistId] " +
                "FROM dbo.Product ";

            List<Product> result = new List<Product>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Product product = LoadProducts(dr);
                        result.Add(product);
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


        private Product LoadProducts(IDataReader dr)
        {
            Product product = new Product();

            product.Id = GetDataValue<int>(dr, "Id");
            product.Title = GetDataValue<string>(dr, "Title");
            product.Description = GetDataValue<string>(dr, "Description");
            product.Image = GetDataValue<string>(dr, "Image");
            product.Price = GetDataValue<double>(dr, "Price");
            product.QuantitySold = GetDataValue<Int32>(dr, "QuantitySold");
            product.AvgStars = GetDataValue<double>(dr, "AvgStars");
            product.ArtistId = GetDataValue<Int32>(dr, "ArtistId");


            return product;
        }
    }
}