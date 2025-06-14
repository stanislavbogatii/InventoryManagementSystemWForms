﻿using Application.Builders;
using Application.DTOs.Product;
using Application.Interfaces;
using Domain.Entitites;

namespace Presentation.Forms
{
    public partial class ViewProductForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWarehouseService _warehouseService;
        private readonly ProductDto? _product;

        public ViewProductForm(IProductService productService, ICategoryService categoryService, IWarehouseService warehouseService)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;
            _warehouseService = warehouseService;
            this.AcceptButton = btnSaveProduct;
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            await LoadCategories();
            await LoadWarehouses();
        }

        public ViewProductForm(IProductService productService, ICategoryService categoryService, ProductDto product, IWarehouseService warehouseService)
            : this(productService, categoryService, warehouseService)
        {
            _product = product;
            if (product is not null)
            {
                populateForm(product);
                CheckMemento();
            }
        }

        private void CheckMemento()
        {
            if (_product is null) return;
            btnRestoreProduct.Enabled = _productService.HasMemento(_product.Id);
        }

        private async Task LoadCategories()
        {
            var categories = await _categoryService.GetAll();
            var categoryTree = CategoryCompositeBuilder.Build(categories);
            cmbCategory.Items.Clear();

            cmbCategory.Items.Add(new ComboBoxItem { Id = null, DisplayName = "No category" });

            AddCategoriesToComboBox(categoryTree, 0);

            cmbCategory.DisplayMember = "DisplayName";
            cmbCategory.ValueMember = "Id";
            cmbCategory.SelectedIndex = 0;

            if (_product.CategoryId.HasValue)
            {
                foreach (ComboBoxItem item in cmbCategory.Items)
                {
                    if (item.Id.HasValue && item.Id.Value == _product.CategoryId.Value)
                    {
                        cmbCategory.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void AddCategoriesToComboBox(CategoryComponent component, int level)
        {
            if (component is CategoryLeaf leaf)
            {
                cmbCategory.Items.Add(new ComboBoxItem
                {
                    Id = leaf.Id,
                    DisplayName = new string('-', level * 2) + leaf.Title
                });
            }
            else if (component is CategoryComposite composite)
            {
                if (composite.Title != "Root")
                    cmbCategory.Items.Add(new ComboBoxItem
                    {
                        Id = composite.Id,
                        DisplayName = new string('-', level * 2) + composite.Title
                    });
                foreach (var child in composite.GetChildren())
                {
                    AddCategoriesToComboBox(child, level + 1);
                }
            }
        }

        private async Task LoadWarehouses()
        {
            var warehouses = await _warehouseService.GetAll();
            cmbWarehouse.Items.Clear();

            cmbWarehouse.Items.Add(new ComboBoxItem { Id = null, DisplayName = "No warehouse" });

            foreach (var warehouse in warehouses)
            {
                cmbWarehouse.Items.Add(new ComboBoxItem { Id = warehouse.Id, DisplayName = warehouse.Name });
            }

            cmbWarehouse.DisplayMember = "DisplayName";
            cmbWarehouse.ValueMember = "Id";
            cmbWarehouse.SelectedIndex = 0;

            if (_product.WarehouseId.HasValue)
            {
                foreach (ComboBoxItem item in cmbWarehouse.Items)
                {
                    if (item.Id.HasValue && item.Id.Value == _product.WarehouseId.Value)
                    {
                        cmbWarehouse.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        public void populateForm(ProductDto product)
        {
            txtTitle.Text = product.Title;
            txtCode.Text = product.Code;
            txtArticle.Text = product.Article;
            txtDescription.Text = product.Description;
            txtPrice.Text = product.Price.ToString();
            txtOldPrice.Text = product.OldPrice.ToString();
            txtQuantity.Text = product.Quantity.ToString();
        }

        public async void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            try
            {
                var categoryItem = cmbCategory.SelectedItem as ComboBoxItem;
                var categoryId = categoryItem?.Id;
                var warehouseItem = cmbWarehouse.SelectedItem as ComboBoxItem;
                var warehouseId = warehouseItem?.Id;
                var dto = new UpdateProductDto
                {
                    Title = txtTitle.Text,
                    Code = txtCode.Text,
                    Article = txtArticle.Text,
                    Description = txtDescription.Text,
                    Price = Int32.Parse(txtPrice.Text),
                    Quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : int.Parse(txtQuantity.Text),
                    OldPrice = string.IsNullOrEmpty(txtOldPrice.Text) ? 0 : int.Parse(txtOldPrice.Text),
                    CategoryId = categoryId,
                    WarehouseId = warehouseId,
                };

                if (dto is not null)
                {
                    await _productService.Update(_product.Id, dto);
                }

                MessageBox.Show($"Product '{dto.Title}' success saved");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message);
            }
        }

        public bool validateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Please enter product code .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtArticle.Text))
            {
                MessageBox.Show("Please enter product article .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtArticle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please enter product price .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
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

        private async void btnRestoreProduct_Click(object sender, EventArgs e)
        {
            if (_product is null)
            {
                MessageBox.Show("No product");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to restore this product?", "Confirm Restore", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                await _productService.RestoreFromMemento(_product.Id);
                MessageBox.Show("Product restored successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Restore cancelled.");
            }
        }
    }
}
