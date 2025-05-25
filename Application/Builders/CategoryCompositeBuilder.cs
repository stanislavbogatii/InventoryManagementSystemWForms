using Application.DTOs.Category;
using Domain.Entitites;

namespace Application.Builders
{
    public class CategoryCompositeBuilder
    {
        public static CategoryComponent Build(IEnumerable<CategoryDto> categories)
        {
            var lookup = categories.ToLookup(c => c.ParentId);

            CategoryComponent BuildNode(CategoryDto category)
            {
                var children = lookup[category.Id];
                if (!children.Any())
                {
                    return new CategoryLeaf(category.Id, category.Title);
                }
                else
                {
                    var composite = new CategoryComposite(category.Id, category.Title);
                    foreach (var child in children)
                    {
                        composite.Add(BuildNode(child));
                    }
                    return composite;
                }
            }

            var rootComposite = new CategoryComposite(0, "Root");

            foreach (var rootCategory in lookup[null])
            {
                rootComposite.Add(BuildNode(rootCategory));
            }

            return rootComposite;
        }
    }
}
