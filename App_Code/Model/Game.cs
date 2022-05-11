﻿using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace M05_UF3_P2_Template.App_Code.Model
{
    public class Game 
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
       
        public Product product { get; set; }
        public float Rating { get; set; }
        public string Version { get; set; }

        public Game()
        {

        }
        public Game(DataRow row)
        {
            UpdateContructor(row);
        }
        public void UpdateContructor(DataRow row)
        {
            try
            {
                Id = int.Parse(row[0].ToString());
            }
            catch
            {

                Id = 0;
            }
            try
            {
                Product_Id = int.Parse(row[1].ToString());
            }
            catch
            {

                Product_Id = 0;
            }
            try
            {
                Rating = float.Parse(row[2].ToString());
            }
            catch
            {

                Rating = 0;
            }
            Version = row[3].ToString();
            if (Product_Id > 0)
            {
                product = new Product(DatabaseManager.Select("Product", null, "Id = " + Product_Id + " ").Rows[0]);
            }
        }
        
        
        public Game(int Id) : this(DatabaseManager.Select("Game", null, "Id = " + Id + " ").Rows[0]) { }

        public bool Update()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {
                new DatabaseManager.DB_Field("Product_id", Product_Id),
                new DatabaseManager.DB_Field("Rating", Rating),
                new DatabaseManager.DB_Field("Version", Version)

            };
            return DatabaseManager.Update("Game", fields, "Id = " + Id + " ") > 0 ? true : false;
        }


        public bool Add()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {

                new DatabaseManager.DB_Field("Product_id", Product_Id),
                new DatabaseManager.DB_Field("Rating", Rating),
                new DatabaseManager.DB_Field("Version", Version)
                

            };
            return DatabaseManager.Insert("Game", fields) > 0 ? true : false;
        }

    }
}
