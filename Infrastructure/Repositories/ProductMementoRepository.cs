using Domain.Entitites;

namespace Infrastructure.Repositories;
public class ProductMementoRepository
{
    private readonly Dictionary<int, ProductMemento> _mementos = new();

    public void SaveMemento(Product product)
    {
        var memento = product.SaveToMemento();
        _mementos[product.Id] = memento;  
    }

    public ProductMemento? GetMemento(int productId)
    {
        _mementos.TryGetValue(productId, out var memento);
        return memento;
    }

    public void RemoveMemento(int productId)
    {
        _mementos.Remove(productId);
    }

    public bool HasMemento(int productId)
    {
        return _mementos.ContainsKey(productId);
    }
}
