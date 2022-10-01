
using Core.Entities;

namespace UnitTest
{
    public class ProductTest
    {
        private ProductCategory productCategory;
        public ProductTest()
        {
            productCategory = new ProductCategory() { Id=4,Name="Test ProductCategory"};
        }
        [Fact]
        public void name_cannot_be_null()
        {
            try
            {
                var product = new Product() { Id = 1, ProductCategoryId = productCategory.Id,Price=100 };

            }
            catch (Exception ex)
            {
                Assert.Equal("The string cannot be empty.", ex.Message);
            }
        }
    }
}