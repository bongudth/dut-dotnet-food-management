using _1021902222_HuynhThiKhanhLinh.DTO;
using System;
using System.Data.Entity;
using System.Linq;

namespace _1021902222_HuynhThiKhanhLinh.DAL
{
    public class DBContext : DbContext
    {
        // Your context has been configured to use a 'DBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_1021902222_HuynhThiKhanhLinh.DAL.DBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DBContext' 
        // connection string in the application configuration file.
        public DBContext()
            : base("name=DBContext")
        {
            Database.SetInitializer<DBContext>(new CreateDB());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Food> foods { get; set; }
        public DbSet<Material> materials { get; set; }
        public DbSet<FoodMaterial> foodMaterials { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}