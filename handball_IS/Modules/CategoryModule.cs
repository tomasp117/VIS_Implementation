using handball_IS.Gateways;
using handball_IS.Objects;

namespace handball_IS.Modules
{
    public class CategoryModule
    {
        private readonly CategoryTableGateway categoryTableGateway;

        public CategoryModule(CategoryTableGateway categoryTableGateway)
        {
            this.categoryTableGateway = categoryTableGateway;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await categoryTableGateway.GetCategories();
        }

    }
}
