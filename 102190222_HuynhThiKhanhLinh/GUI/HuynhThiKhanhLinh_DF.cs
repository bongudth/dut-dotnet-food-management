using _1021902222_HuynhThiKhanhLinh.BLL;
using _1021902222_HuynhThiKhanhLinh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1021902222_HuynhThiKhanhLinh.GUI
{
    public partial class HuynhThiKhanhLinh_DF : Form
    {
        public delegate void MyDel();
        public MyDel del;
        private string foodMaterialCode;
        private int foodId;
        private bool isEdit;
        public void SetCbb()
        {
            foreach (var item in AppBll.Instance.GetAllMaterials())
            {
                MaterialCbb.Items.Add(item);
            }
            StatusCbb.Items.Add("Đã nhập hàng");
            StatusCbb.Items.Add("Chưa nhập hàng");
        }
        public void SetData()
        {
            var fm = AppBll.Instance.GetFoodMaterialById(foodMaterialCode);
            Code.Text = fm.Code;
            Quantity.Text = fm.quantity.ToString();
            Unit.Text = fm.unit;
            MaterialCbb.SelectedIndex = MaterialCbb.Items.IndexOf(AppBll.Instance.GetMaterialById(fm.materialId));
            if (fm.material.status)
                StatusCbb.SelectedIndex = 0;
            else
                StatusCbb.SelectedIndex = 1;
        }
        public HuynhThiKhanhLinh_DF(int foodId)
        {
            InitializeComponent();
            this.foodId = foodId;
            SetCbb();
        }
        public HuynhThiKhanhLinh_DF(int foodId, string code)
        {
            InitializeComponent();
            foodMaterialCode = code;
            isEdit = true;
            SetCbb();
            SetData();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Code.Text))
            {
                MessageBox.Show("Mã không hợp lệ!");
                return;
            }
            if (isEdit == false && AppBll.Instance.GetFoodMaterialById(Code.Text) != null)
            {
                MessageBox.Show("Mã đã tồn tại!");
                return;
            }
            if (string.IsNullOrEmpty(Quantity.Text) || !Quantity.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }
            if (MaterialCbb.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn nguyên liệu!");
                return;
            }
            if (string.IsNullOrEmpty(Unit.Text) || Unit.Text.All(char.IsDigit))
            {
                MessageBox.Show("Đơn vị ko hợp lệ!");
                return;
            }
            var fm = new FoodMaterial()
            {
                Code = Code.Text,
                materialId = ((Material)MaterialCbb.SelectedItem).Id,
                foodId = foodId,
                quantity = Convert.ToInt32(Quantity.Text),
                unit = Unit.Text,
            };
            if (isEdit)
            {
                AppBll.Instance.UpdateFoodMaterial(fm.Code, fm);
            }
            else
            {
                AppBll.Instance.AddFoodMaterial(fm);
            }
            del();
            this.Dispose();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MaterialCbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = ((Material)MaterialCbb.SelectedItem).Id;
            bool status = AppBll.Instance.GetMaterialById(Id).status;
            if (status)
            {
                StatusCbb.SelectedIndex = 0;
            }
            else
            {
                StatusCbb.SelectedIndex = 1;
            }
        }
    }
}
