using System.Net;
using System.Net.Http.Json;
using Microsoft.VisualBasic;
using Xunit;

public class Tests1
{
    string baseUrl = "https://api.restful-api.dev/objects";
    private readonly HttpClient _httpClient = new HttpClient();

    private static string productId;

    [Fact]
    public async Task Test1_GetAllProducts_ReturnsProducts()
    {
        // Act
        var response = await _httpClient.GetAsync(baseUrl);
        var items = await response.Content.ReadFromJsonAsync<List<Item>>();

        // Assert
        Assert.NotNull(items);
    }

    [Fact]
    public async Task MainTest()
    {
        Test2_AddProduct_ShouldReturnAddProduct();
        Test3_GetProductById_ReturnsProduct();
        Test4_UpdateProduct_ShouldModifyProductData();
        Test5_DeleteProductById_ShouldSucceed();
        Test6_AddProduct_ShouldNotReturnAddProduct();
    }

    private async Task Test2_AddProduct_ShouldReturnAddProduct()
    {
        // Arrange
        var newItem = new ItemPost
        {
            Name = "Samsung Galaxy S23",
            Data = new Dictionary<string, object>
            {
                { "color", "Black" },
                { "price", 999.99 }
            }
        };

        // Act
        var response = await _httpClient.PostAsJsonAsync(baseUrl, newItem);
        var responseBody = await response.Content.ReadFromJsonAsync<Item>();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            productId = responseBody.Id;
        }

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    private async Task Test3_GetProductById_ReturnsProduct()
    {
        // Act
        var url = $"{baseUrl}/{productId}";
        var response = await _httpClient.GetAsync(url);
        var items = await response.Content.ReadFromJsonAsync<ItemResponse>();

        // Assert
        Assert.NotNull(items);
    }

    private async Task Test4_UpdateProduct_ShouldModifyProductData()
    {
        var updatedItem = new Item
        {
            Name = "Apple MacBook Pro 16 (Updated)",
            Data = new Dictionary<string, object>
        {
            { "year", 2020 },
            { "price", 1999.99 },
            { "CPU model", "Intel Core i9" },
            { "Hard disk size", "2 TB" }
        }
        };

        var url = $"{baseUrl}/{productId}";

        // Act
        var responseUpdate = await _httpClient.PutAsJsonAsync(url, updatedItem);

        // Assert
        var updatedResponse = await responseUpdate.Content.ReadFromJsonAsync<ItemUpdate>();
        Assert.NotNull(updatedResponse);
        Assert.Equal(updatedItem.Name, updatedResponse.Name);
    }

    private async Task Test5_DeleteProductById_ShouldSucceed()
    {
        // Arrange
        var url = $"{baseUrl}/{productId}";

        // Act
        var response = await _httpClient.DeleteAsync(url);

        // Assert: HTTP status
        Assert.True(response.IsSuccessStatusCode);

        var responseBody = await response.Content.ReadFromJsonAsync<DeleteResponse>();

        // Assert: content
        Assert.NotNull(responseBody);
        Assert.Contains($"id = {productId}", responseBody.Message);
    }

    private async Task Test6_AddProduct_ShouldNotReturnAddProduct()
    {
        // Arrange
        var newItem = new ItemPost { };

        // Act
        var response = await _httpClient.PostAsJsonAsync(baseUrl, newItem);
        var responseBody = await response.Content.ReadFromJsonAsync<Item>();

        Assert.True(responseBody.Name == null);

    }
}