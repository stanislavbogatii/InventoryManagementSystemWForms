namespace Domain.Entitites
{
    public abstract class CategoryComponent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual void Add(CategoryComponent component) { }
        public virtual void Remove(CategoryComponent component) { }
        public virtual List<CategoryComponent> GetChildren() => new();
    }

}
