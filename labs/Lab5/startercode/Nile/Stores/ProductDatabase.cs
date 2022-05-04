/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            ObjectValidator.ValidateObject(product);

            var existing = FindByName(product.Name);
            if (existing != null)
                throw new InvalidOperationException("Product must be unique");

            //Emulate database by storing copy
            try
            {
                var newProduct = AddCore(product);
                return newProduct;
            } catch( InvalidOperationException e)
            {
                throw;
            } catch(Exception e)
            {
                throw new Exception("Error adding movie");
            };
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0");

            return GetCore(id);
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll () => GetAllCore();
       
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0");
                 
            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product )
        {
            
            if (product.Id <= 0)
                throw new ArgumentOutOfRangeException(nameof(product.Id), "Id must be > 0");
            if (product.Name == null)
                throw new ArgumentNullException(nameof(product.Name));
            

            ObjectValidator.ValidateObject(product);

            var existing = FindByName(product.Name);
            if (existing != null && existing.Id != product.Id)
                throw new ArgumentException("Product must be unique", nameof(product));

            //Get existing product
            existing = GetCore(product.Id);
            if (existing == null)
                throw new ArgumentException("Product does not exist", nameof(product));

            return UpdateCore(existing, product);
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );
        protected abstract Product FindByName ( string name );
        
        #endregion
    }
}
