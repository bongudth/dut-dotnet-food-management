using _1021902222_HuynhThiKhanhLinh.BLL;
using _1021902222_HuynhThiKhanhLinh.DTO;
using _1021902222_HuynhThiKhanhLinh.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102190222_HuynhThiKhanhLinh
{
    public partial class HuynhThiKhanhLinh_MF : Form
    {
        private int foodId;
        private string search;
        private List<string> codes;
        public void SetCbb()
        {
            FoodCbb.Items.Add(new Food() { Id = 0, name = "Tất cả" });
            FoodCbb.SelectedIndex = 0;
            foreach (var item in AppBll.Instance.GetAllFoods())
            {
                FoodCbb.Items.Add(item);
            }
            SortCbb.Items.Add("Tên nguyên liệu");
            SortCbb.Items.Add("Số lượng");
            SortCbb.Items.Add("Đơn vị tính");
            SortCbb.Items.Add("Tình trạng");
        }
        public HuynhThiKhanhLinh_MF()
        {
            InitializeComponent();
            SetCbb();
        }
        public void Show()
        {
            foodId = ((Food)FoodCbb.SelectedItem).Id;
            search = Search.Text;
            var data = AppBll.Instance.GetListFoodMaterials(foodId, search);
            codes = data.Select(p => p.Code).ToList();
            int i = 1;
            dataGridView1.DataSource = data.Select(p => new { STT = i++, TenNguyenLieu = p.material.name, SoLuong = p.quantity, DonViTinh = p.unit, TinhTrang = p.material.status }).ToList();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {

            if (foodId != 0)
            {
                HuynhThiKhanhLinh_DF f = new HuynhThiKhanhLinh_DF(foodId);
                f.del = Show;
                f.Show();
            }
            else
            {
                MessageBox.Show("Chọn một món ăn muốn thêm nguyên liệu!");
                return;
            }
        }

        private void FoodCbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show();
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            Show();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var index = dataGridView1.SelectedRows[0].Index;
                var code = codes[index];
                HuynhThiKhanhLinh_DF f = new HuynhThiKhanhLinh_DF(foodId, code);
                f.del = Show;
                f.Show();
            }
        }

        private void SortBtn_Click(object sender, EventArgs e)
        {
            if (SortCbb.SelectedIndex >= 0)
            {
                var option = SortCbb.SelectedItem.ToString();
                var data = AppBll.Instance.GetListFoodMaterials(foodId, search);
                switch (option)
                {
                    case "Tên nguyên liệu":
                        data.Sort(AppBll.Instance.CompareMaterialName);
                        break;
                    case "Số lượng":
                        data.Sort(AppBll.Instance.CompareQuantity);
                        break;
                    case "Đơn vị tính":
                        data.Sort(AppBll.Instance.CompareUnit);
                        break;
                    case "Tình trạng":
                        data.Sort(AppBll.Instance.CompareStatus);
                        break;
                }
                int i = 1;
                dataGridView1.DataSource = data.Select(p => new { STT = i++, TenNguyenLieu = p.material.name, SoLuong = p.quantity, DonViTinh = p.unit, TinhTrang = p.material.status }).ToList();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                List<string> codes = new List<string>();
                foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                {
                    codes.Add(this.codes[r.Index]);
                }
                AppBll.Instance.DeleteFoodMaterials(codes);
                Show();
            }
        }
    }
}
