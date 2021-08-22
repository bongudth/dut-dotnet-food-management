using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1021902222_HuynhThiKhanhLinh.DTO
{
    public class Material
    {
        public Material()
        {
            foodMaterials = new HashSet<FoodMaterial>();
        }
        public int Id { get; set; }
        public string name { get; set; }
        public bool status { get; set; }
        public virtual HashSet<FoodMaterial> foodMaterials { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
