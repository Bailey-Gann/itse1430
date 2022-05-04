/*
 * Bailey Gann
 * ITSE 1430
 * Spring 2022
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _gridProducts.AutoGenerateColumns = false;

            UpdateList();
        }

        #region Event Handlers
        
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var child = new ProductDetailForm("Product Details");
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    //Save product
                    _database.Add(child.Product);
                    UpdateList();
                    return;
                } catch (InvalidOperationException ex)
                {
                    MessageBox.Show(this, "Please enter a unique product name.", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (ValidationException ex)
                {
                    var msg = ex.ValidationResult.ErrorMessage;
                    MessageBox.Show(this, msg, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };
            } while (true);

            
            
            
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            };

            EditProduct(product);
        }        

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            DeleteProduct(product);
        }        
                
        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);
			
			//Don't continue with key
            e.SuppressKeyPress = true;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var form = new AboutBox();
            form.ShowDialog(this);
        }

        #endregion

        #region Private Members

        private void DeleteProduct ( Product product )
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                _bsProducts.Remove(product.Id);
                UpdateList();
            } catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Delete product
            _database.Remove(product.Id);
            UpdateList();
        }

        private void EditProduct ( Product product )
        {
            var child = new ProductDetailForm("Product Details");
            child.Product = product;
                        
           
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;
                try
                {
                    //Save product
                    _database.Update(child.Product);
                    UpdateList();
                } catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };
            } while (true);
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList ()
        {
            //TODO: Handle Errors
            _bsProducts.DataSource = _database.GetAll();
        }

        private string GetConnectionString ( string name )
                => Program.Configuration.GetConnectionString(name);        

        private readonly IProductDatabase _database = new Nile.Stores.Sql(Program.GetConnectionString("ProductDatabase"));
        #endregion
    }
}
