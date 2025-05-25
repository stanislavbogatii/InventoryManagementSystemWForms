using Application.DTOs.Product;
using Application.Interfaces;
using Domain.Filters;
using System.Text;

public class ProductServiceDecorator : IProductService
{
    private readonly IProductService _inner;
    private readonly string _logFilePath;

    public ProductServiceDecorator(IProductService inner, string logFilePath = "product_service_log.txt")
    {
        _inner = inner;
        _logFilePath = logFilePath;
    }

    private async Task LogAsync(string message)
    {
        var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
        await File.AppendAllTextAsync(_logFilePath, logMessage, Encoding.UTF8);
    }

    public async Task Create(CreateProductDto dto)
    {
        await LogAsync($"Create called with Title={dto.Title}, Code={dto.Code}, Article={dto.Article}, Price={dto.Price}");

        // Проверка уникальности Code и Article
        var allProducts = await _inner.GetAll();
        bool isCodeDuplicate = false;
        bool isArticleDuplicate = false;

        foreach (var p in allProducts)
        {
            if (string.Equals(p.Code, dto.Code, StringComparison.OrdinalIgnoreCase))
                isCodeDuplicate = true;
            if (string.Equals(p.Article, dto.Article, StringComparison.OrdinalIgnoreCase))
                isArticleDuplicate = true;
        }

        if (isCodeDuplicate || isArticleDuplicate)
        {
            var errorMessage = $"Validation failed: " +
                $"{(isCodeDuplicate ? "Code already exists. " : "")}" +
                $"{(isArticleDuplicate ? "Article already exists." : "")}";
            await LogAsync(errorMessage);
            throw new InvalidOperationException(errorMessage);
        }

        await _inner.Create(dto);
        await LogAsync("Create finished");
    }

    public async Task Delete(int id)
    {
        await LogAsync($"Delete called with Id={id}");
        await _inner.Delete(id);
        await LogAsync("Delete finished");
    }

    public async Task<ProductDto?> GetById(int id)
    {
        await LogAsync($"GetById called with Id={id}");
        var result = await _inner.GetById(id);
        await LogAsync(result != null
            ? $"GetById result: {result.Title}"
            : "GetById result: null");
        return result;
    }

    public async Task<IEnumerable<ProductDto>> GetAll(ProductFilters? filters = null)
    {
        await LogAsync($"GetAll called with filters: minPrice={filters?.minPrice}, maxPrice={filters?.maxPrice}, title={filters?.title}");
        var results = await _inner.GetAll(filters);
        await LogAsync($"GetAll returned {results?.ToList().Count ?? 0} products");
        return results;
    }

    public async Task Update(int id, UpdateProductDto dto)
    {
        await LogAsync($"Update called with Id={id}, Title={dto.Title}, Code={dto.Code}, Article={dto.Article}");

        var allProducts = await _inner.GetAll();
        bool isCodeDuplicate = false;
        bool isArticleDuplicate = false;

        foreach (var p in allProducts)
        {
            if (p.Id != id)
            {
                if (string.Equals(p.Code, dto.Code, StringComparison.OrdinalIgnoreCase))
                    isCodeDuplicate = true;
                if (string.Equals(p.Article, dto.Article, StringComparison.OrdinalIgnoreCase))
                    isArticleDuplicate = true;
            }
        }

        if (isCodeDuplicate || isArticleDuplicate)
        {
            var errorMessage = $"Validation failed: " +
                $"{(isCodeDuplicate ? "Code already exists. " : "")}" +
                $"{(isArticleDuplicate ? "Article already exists." : "")}";
            await LogAsync(errorMessage);
            throw new InvalidOperationException(errorMessage);
        }

        await _inner.Update(id, dto);
        await LogAsync("Update finished");
    }
}
