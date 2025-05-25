using Application.DTOs.Category;
using Application.Interfaces;

namespace Presentation.Forms
{
    public partial class ViewCategoryForm : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryDto _category;

        public ViewCategoryForm(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            LoadCategories();
        }

        public ViewCategoryForm(ICategoryService categoryService, CategoryDto category)
            : this(categoryService)
        {
            _category = category;
            if (category is not null)
            {
                populateForm(category);
            }
        }

        private void populateForm(CategoryDto category)
        {
            txtCategoryCode.Text = category.CategoryCode.ToString();
            txtTitle.Text = category.Title.ToString();
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

                UpdateCategoryDto dto = new()
                {
                    Title = title,
                    CategoryCode = categoryCode,
                    ParentId = parentId,
                };
                if (_category is not null)
                {
                    await _categoryService.Update(_category.Id, dto);
                }

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

            if (_category.ParentId.HasValue)
            {
                foreach (ComboBoxItem item in cmbParentCategory.Items)
                {
                    if (item.Id.HasValue && item.Id.Value == _category.ParentId.Value)
                    {
                        cmbParentCategory.SelectedItem = item;
                        break;
                    }
                }
            }
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
