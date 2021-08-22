using _1021902222_HuynhThiKhanhLinh.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1021902222_HuynhThiKhanhLinh.DAL
{
    public class AppDal
    {
        private static AppDal _Instance;
        public static AppDal Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new AppDal();
                return _Instance;
            }
        }
        private DBContext db;
        private AppDal()
        {
            db = new DBContext();
        }
        public List<FoodMaterial> getAllFoodMaterials()
        {
            return db.foodMaterials.ToList();
        }
        public List<Food> GetAllFoods()
        {
            return db.foods.ToList();
        }
        public List<Material> GetAllMaterials()
        {
            return db.materials.ToList();
        }
        public FoodMaterial GetFoodMaterialById(string code)
        {
            return db.foodMaterials.FirstOrDefault(p => p.Code == code);
        }
        public Material GetMaterialById(int Id)
        {
            return db.materials.Find(Id);
        }
        public void AddFoodMaterial(FoodMaterial foodMaterial)
        {
            db.foodMaterials.Add(foodMaterial);
            db.SaveChanges();
        }
        public bool UpdateFoodMaterial(string code, FoodMaterial foodMaterial)
        {
            var fm = db.foodMaterials.FirstOrDefault(p => p.Code == code);
            fm.foodId = foodMaterial.foodId;
            fm.materialId = foodMaterial.materialId;
            fm.quantity = foodMaterial.quantity;
            fm.unit = foodMaterial.unit;
            try
            {
                db.SaveChanges();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        public List<FoodMaterial> GetListFoodMaterials(int foodId, string search)
        {
            return db.foodMaterials.Where(p => (foodId == 0 || p.foodId == foodId) && (string.IsNullOrEmpty(search) || p.material.name.ToLower().Contains(search.ToLower()) || p.quantity.ToString().Contains(search) || p.unit.ToLower().Contains(search.ToLower()))).ToList();
        }
        public void DeleteFoodMaterials(List<string> code)
        {
            foreach(var item in code)
            {
                var fm = db.foodMaterials.FirstOrDefault(p => p.Code == item);
                db.foodMaterials.Remove(fm);
            }
            db.SaveChanges();
        }
    }
}
