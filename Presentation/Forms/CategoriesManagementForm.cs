using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Forms
{
    public partial class CategoriesManagementForm : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly IServiceProvider _serviceProvider;
        public CategoriesManagementForm(ICategoryService categoryService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _categoryService = categoryService;
        }



        private async void dgvCategories_CellDeleteClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategories.Columns[e.ColumnIndex].Name == "deleteButtonColumn" && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnID"].Value);
                var confirm = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    await _categoryService.Delete(id);
                    dgvCategories.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private async void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnID"].Value);
            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                MessageBox.Show("Category not found!");
                return;
            }

            var editCategoryForm = ActivatorUtilities.CreateInstance<ViewCategoryForm>(_serviceProvider, category);
            if (editCategoryForm.ShowDialog() == DialogResult.OK)
            {
                LoadCategories();
            }
        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<CreateCategoryForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCategories();
            }
        }

        private void btnCloneCategory_Click(object sender, EventArgs e)
        {
            // Здесь обработка кнопки клонирования выбранной категории
        }

        private void CategoryManagementForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private async void LoadCategories()
        {
            var categories = await _categoryService.GetAll();
            dgvCategories.Rows.Clear();

            foreach (var category in categories)
            {
                dgvCategories.Rows.Add(
                    category.Id,
                    category.Title,
                    category.CategoryCode,
                    category.Parent?.Title ?? null,
                    category.Products?.Count()
                );
            }
        }
    }
}
