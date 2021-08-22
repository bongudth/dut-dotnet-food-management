using _1021902222_HuynhThiKhanhLinh.DAL;
using _1021902222_HuynhThiKhanhLinh.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1021902222_HuynhThiKhanhLinh.BLL
{
    public class AppBll
    {
        private static AppBll _Instance;
        public static AppBll Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new AppBll();
                return _Instance;
            }
        }
        public List<Food> GetAllFoods()
        {
            return AppDal.Instance.GetAllFoods();
        }
        public List<Material> GetAllMaterials()
        {
            return AppDal.Instance.GetAllMaterials();
        }
        public FoodMaterial GetFoodMaterialById(string Id)
        {
            return AppDal.Instance.GetFoodMaterialById(Id);
        }
        public Material GetMaterialById(int Id)
        {
            return AppDal.Instance.GetMaterialById(Id);
        }
        public void AddFoodMaterial(FoodMaterial foodMaterial)
        {
            AppDal.Instance.AddFoodMaterial(foodMaterial);
        }
        public bool UpdateFoodMaterial(string code, FoodMaterial foodMaterial)
        {
            return AppDal.Instance.UpdateFoodMaterial(code, foodMaterial);
        }
        public List<FoodMaterial> GetListFoodMaterials(int foodId, string search)
        {
            return AppDal.Instance.GetListFoodMaterials(foodId, search);
        }
        public int CompareMaterialName(FoodMaterial f1, FoodMaterial f2)
        {
            return f1.material.name.CompareTo(f2.material.name);
        }
        public int CompareQuantity(FoodMaterial f1, FoodMaterial f2)
        {
            if (f1.quantity > f2.quantity)
                return 1;
            if (f1.quantity < f2.quantity)
                return -1;
            return 0;
        }
        public int CompareUnit(FoodMaterial f1, FoodMaterial f2)
        {
            return f1.unit.CompareTo(f2.unit);
        }
        public int CompareStatus(FoodMaterial f1, FoodMaterial f2)
        {
            return f1.material.status.CompareTo(f2.material.status);
        }
        public void DeleteFoodMaterials(List<string> code)
        {
            AppDal.Instance.DeleteFoodMaterials(code);
        }
    }
}
