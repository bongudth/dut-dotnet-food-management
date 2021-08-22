using _1021902222_HuynhThiKhanhLinh.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1021902222_HuynhThiKhanhLinh.DAL
{
    public class CreateDB : CreateDatabaseIfNotExists<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            //context.foods.AddRange(new Food[]
            //{
            //    new Food(){name = "Cút xào me"},
            //    new Food(){name = "Ốc xào sả ớt"},
            //    new Food(){name = "Gà chiên nước nắm"},
            //    new Food(){name = "Bún đậu mắm tôm"}
            //});
            //context.materials.AddRange(new Material[]
            //{
            //    new Material(){name = "Gà", status = true},
            //    new Material(){name = "Ốc", status = true},
            //    new Material(){name = "Cua", status = false},
            //    new Material(){name = "Thịt lợn", status = false},
            //    new Material(){name = "Tôm", status = false},
            //    new Material(){name = "Trứng cút", status = true},
            //});
            //context.foodMaterials.AddRange(new FoodMaterial[]
            //{
            //    new FoodMaterial()
            //    {
            //        Code = "1",
            //        quantity = 12,
            //        unit = "kg",
            //        foodId = 1,
            //        materialId = 1,
            //    },
            //    new FoodMaterial()
            //    {
            //        Code = "2",
            //        quantity = 13,
            //        unit = "kg",
            //        foodId = 2,
            //        materialId = 3,
            //    },
            //    new FoodMaterial()
            //    {
            //        Code = "3",
            //        quantity = 11,
            //        unit = "kg",
            //        foodId = 4,
            //        materialId = 6,
            //    },
            //    new FoodMaterial()
            //    {
            //        Code = "4",
            //        quantity = 10,
            //        unit = "kg",
            //        foodId = 1,
            //        materialId = 4,
            //    },
            //    new FoodMaterial()
            //    {
            //        Code = "5",
            //        quantity = 12,
            //        unit = "kg",
            //        foodId = 2,
            //        materialId = 5,
            //    },
            //    new FoodMaterial()
            //    {
            //        Code = "6",
            //        quantity = 14,
            //        unit = "kg",
            //        foodId = 3,
            //        materialId = 2,
            //    },
            //});
        }
    }
}
