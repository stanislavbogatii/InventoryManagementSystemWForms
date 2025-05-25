namespace Domain.Entitites
{
    public class CategoryComposite : CategoryComponent
    {
        private readonly List<CategoryComponent> _children = new();

        public CategoryComposite(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public override void Add(CategoryComponent component) => _children.Add(component);
        public override void Remove(CategoryComponent component) => _children.Remove(component);
        public override List<CategoryComponent> GetChildren() => _children;
    }

}
