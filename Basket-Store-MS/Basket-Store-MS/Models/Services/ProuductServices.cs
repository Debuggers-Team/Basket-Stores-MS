using Basket_Store_MS.Data;
using Basket_Store_MS.Models.DTO;
using Basket_Store_MS.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Services
{
    public class ProuductServices : IProuduct
    {
            private readonly BasketStoreDBContext _context;

            public ProuductServices(BasketStoreDBContext context)
            {
                _context = context;
            }

        public async Task<ProductDto> Create(Products products)
        {
            _context.Entry(products).State = EntityState.Added;
            await _context.SaveChangesAsync();

            ProductDto productDto = new ProductDto()
            {
                Id = products.Id,
                Name = products.Name,
                Price = products.Price,
                ProductDescription = products.ProductDescription,
                Discount = products.Discount
            };

            return productDto;
        }

        public async Task Delete(int id)
        {
            Products product = await _context.Products.FindAsync(id);
                _context.Entry(product).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }
        public async Task <ProductDto> GetProduct(int Id)
        {
            return await _context.Products.Select(X => new ProductDto
            {
                Id = X.Id,
                Name = X.Name,
                Price = X.Price,
                ProductDescription = X.ProductDescription,
                Discount = X.Discount,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == X.CategoryId).Name,
                FeedBacks = X.FeedBack
                              .Select(Y => new FeedBackDto
                              {
                                  Id = Y.Id,
                                  FeedBackDescription = Y.FeedBackDescription,
                                  Rating = Y.Rating,
                                  ProductsName = X.Name
                              }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            return await _context.Products.Select(X => new ProductDto
            {
                Id = X.Id,
                Name = X.Name,
                Price = X.Price,
                ProductDescription = X.ProductDescription,
                Discount = X.Discount,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == X.CategoryId).Name,
                FeedBacks = X.FeedBack
                              .Select(Y => new FeedBackDto
                              {   Id = Y.Id,
                                  FeedBackDescription = Y.FeedBackDescription,
                                  Rating = Y.Rating,
                                  ProductsName = X.Name
                              }).ToList()
            }).ToListAsync();
        }

        //Order By Ascending
        public async Task<List<ProductDto>> GetProductsAsc()
        {
            return await _context.Products.Select(X => new ProductDto
            {
                Id = X.Id,
                Name = X.Name,
                Price = X.Price,
                ProductDescription = X.ProductDescription,
                Discount = X.Discount,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == X.CategoryId).Name,
                FeedBacks = X.FeedBack
                              .Select(Y => new FeedBackDto
                              {
                                  Id = Y.Id,
                                  FeedBackDescription = Y.FeedBackDescription,
                                  Rating = Y.Rating,
                                  ProductsName = X.Name
                              }).ToList()
            }).OrderBy(des => des.Name).ToListAsync();
        }

        //Order By Descending 
        public async Task<List<ProductDto>> GetProductsDes()
        {
            return await _context.Products.Select(X => new ProductDto
            {
                Id = X.Id,
                Name = X.Name,
                Price = X.Price,
                ProductDescription = X.ProductDescription,
                Discount = X.Discount,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == X.CategoryId).Name,
                FeedBacks = X.FeedBack
                              .Select(Y => new FeedBackDto
                              {
                                  Id = Y.Id,
                                  FeedBackDescription = Y.FeedBackDescription,
                                  Rating = Y.Rating,
                                  ProductsName = X.Name
                              }).ToList()
            }).OrderByDescending(des => des.Name).ToListAsync();
        }

        //Order By Min To Max
        public async Task<List<ProductDto>> GetProductsMinToMax()
        {
            return await _context.Products.Select(X => new ProductDto
            {
                Id = X.Id,
                Name = X.Name,
                Price = X.Price,
                ProductDescription = X.ProductDescription,
                Discount = X.Discount,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == X.CategoryId).Name,
                FeedBacks = X.FeedBack
                              .Select(Y => new FeedBackDto
                              {
                                  Id = Y.Id,
                                  FeedBackDescription = Y.FeedBackDescription,
                                  Rating = Y.Rating,
                                  ProductsName = X.Name
                              }).ToList()
            }).OrderBy(des => des.Price).ToListAsync();
        }

        //Order By Max To Min
        public async Task<List<ProductDto>> GetProductsMaxToMin()
        {
            return await _context.Products.Select(X => new ProductDto
            {
                Id = X.Id,
                Name = X.Name,
                Price = X.Price,
                ProductDescription = X.ProductDescription,
                Discount = X.Discount,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == X.CategoryId).Name,
                FeedBacks = X.FeedBack
                              .Select(Y => new FeedBackDto
                              {
                                  Id = Y.Id,
                                  FeedBackDescription = Y.FeedBackDescription,
                                  Rating = Y.Rating,
                                  ProductsName = X.Name
                              }).ToList()
            }).OrderByDescending(des => des.Price).ToListAsync();
        }

        //Get Prouducts From To Price
        public async Task<List<ProductDto>> GetProductsFromTo(int from, int to)
        {
            return await _context.Products.Select(X => new ProductDto
            {
                Id = X.Id,
                Name = X.Name,
                Price = X.Price,
                ProductDescription = X.ProductDescription,
                Discount = X.Discount,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == X.CategoryId).Name,
                FeedBacks = X.FeedBack
                              .Select(Y => new FeedBackDto
                              {
                                  Id = Y.Id,
                                  FeedBackDescription = Y.FeedBackDescription,
                                  Rating = Y.Rating,
                                  ProductsName = X.Name
                              }).ToList()
            }).Where(pro => pro.Price >= from && pro.Price <= to).ToListAsync();
        }

        //Search for a specific product by name and description
        public async Task<List<ProductDto>> SearchForProduct(string name)
        {
            return await _context.Products.Select(X => new ProductDto
            {
                Id = X.Id,
                Name = X.Name,
                Price = X.Price,
                ProductDescription = X.ProductDescription,
                Discount = X.Discount,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == X.CategoryId).Name,
                FeedBacks = X.FeedBack
                              .Select(Y => new FeedBackDto
                              {
                                  Id = Y.Id,
                                  FeedBackDescription = Y.FeedBackDescription,
                                  Rating = Y.Rating,
                                  ProductsName = X.Name
                              }).ToList()
            }).Where(pro => pro.Name.Contains(name.ToLower()) || pro.Name.Contains(name.ToUpper())
                                                              || pro.ProductDescription.Contains(name.ToLower())
                                                              || pro.ProductDescription.Contains(name.ToUpper())).ToListAsync();
        }

        public async Task<ProductDto> UpdateProduct(int Id, Products product)
        {
            ProductDto productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Discount = product.Discount,
                ProductDescription = product.ProductDescription,
                Price = product.Price
            };
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return productDto;
        }

        public async Task<List<ExcelSheet>> GetExcelSheetsData()
        {
            List<Products> products = await _context.Products.ToListAsync();

            List<ExcelSheet> excelSheets = new List<ExcelSheet>();

            foreach (var item in products)
            {
                ExcelSheet sheet = new ExcelSheet
                {
                    No = item.Id,
                    ProductName = item.Name,
                    InStock = item.InStock,
                    Discount = item.Discount
                };

                excelSheets.Add(sheet);
            }

            return excelSheets;
        }
    }
}
