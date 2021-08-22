using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1021902222_HuynhThiKhanhLinh.DTO
{
    public class FoodMaterial
    {
        [Key]
        [StringLength(5)]
        public string Code { get; set; }
        public int quantity { get; set; }
        public string unit { get; set; }
        public int foodId { get; set; }
        public virtual Food food { get; set; }
        public int materialId { get; set; }
        public virtual Material material { get; set; }
    }
}
