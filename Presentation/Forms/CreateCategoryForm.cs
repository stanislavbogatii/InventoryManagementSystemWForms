using Application.DTOs.Category;
using Application.Interfaces;
using Infrastructure.Data;

namespace Presentation.Forms
{
    public partial class CreateCategoryForm : Form
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryForm(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            LoadCategories();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            try
            {
                string title = txtTitle.Text;
                string categoryCode = txtCategoryCode.Text;
                var parentItem = cmbParentCategory.SelectedItem as ComboBoxItem;
                var parentId = parentItem?.Id;

                CreateCategoryDto dto = new()
                {
                    Title = title,
                    CategoryCode = categoryCode,
                    ParentId = parentId,
                };
                await _categoryService.Create(dto);

                MessageBox.Show("Category saved successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void LoadCategories()
        {
            var categories = await _categoryService.GetAll();
            cmbParentCategory.Items.Clear();

            cmbParentCategory.Items.Add(new ComboBoxItem { Id = null, DisplayName = "No Parent" });

            foreach (var category in categories)
            {
                cmbParentCategory.Items.Add(new ComboBoxItem { Id = category.Id, DisplayName = category.Title });
            }

            cmbParentCategory.DisplayMember = "DisplayName";
            cmbParentCategory.ValueMember = "Id";
            cmbParentCategory.SelectedIndex = 0;
        }



        private bool validateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCategoryCode.Text))
            {
                MessageBox.Show("Please enter title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryCode.Focus();
                return false;
            }
            return true;
        }

        private class ComboBoxItem
        {
            public int? Id { get; set; }
            public string DisplayName { get; set; }

            public override string ToString() => DisplayName;
        }

    }
}
