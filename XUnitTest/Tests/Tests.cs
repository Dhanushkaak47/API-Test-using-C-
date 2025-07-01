using System.Net;
using System.Net.Http.Json;
using Microsoft.VisualBasic;
using Xunit;

public class Tests
{
    string baseUrl = "https://api.restful-api.dev/objects";
    private readonly HttpClient _httpClient = new HttpClient();

    private static string productId;

    [Fact]
    public async Task Test1_CreateProduct_ShouldReturnCreatedProduct()
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

        // Assert: HTTP status (validates successful creation)
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // Assert: object structure
        Assert.NotNull(responseBody);
        Assert.False(string.IsNullOrWhiteSpace(responseBody.Id));
        Assert.False(string.IsNullOrWhiteSpace(responseBody.Name));
        Assert.NotNull(responseBody.Data);

        // Assert: data matches input
        Assert.Equal(newItem.Name, responseBody.Name);
        Assert.True(responseBody.Data.ContainsKey("color"));
        Assert.True(responseBody.Data.ContainsKey("price"));

    }

    [Fact]
    public async Task Test2_GetAllProducts_ReturnsProducts()
    {
        // Act
        var response = await _httpClient.GetAsync(baseUrl);
        var items = await response.Content.ReadFromJsonAsync<List<Item>>();

        // Assert: response structure
        Assert.NotNull(response);
        Assert.True(response.IsSuccessStatusCode);
        Assert.NotNull(items);

        // Assert: non-empty list
        Assert.NotEmpty(items);

        // Assert: object properties
        foreach (var item in items)
        {
            Assert.False(string.IsNullOrWhiteSpace(item.Id));
            Assert.False(string.IsNullOrWhiteSpace(item.Name));
        }
    }

    [Fact]
    public async Task Test3_GetProductById_ReturnsProduct()
    {
        // Act
        var url = $"{baseUrl}/{productId}";
        var response = await _httpClient.GetAsync(url);
        var itemResponse = await response.Content.ReadFromJsonAsync<ItemResponse>();

        // Assert: response structure and status
        Assert.NotNull(response);
        Assert.True(response.IsSuccessStatusCode);
        Assert.NotNull(itemResponse);

        // Assert: gets object by ID
        Assert.False(string.IsNullOrWhiteSpace(itemResponse.Id));
        Assert.Equal(productId, itemResponse.Id);

        // Assert: validates object properties
        Assert.False(string.IsNullOrWhiteSpace(itemResponse.Name));
        Assert.NotNull(itemResponse.Data);

    }

    [Fact]
    public async Task Test4_UpdateProduct_ShouldModifyProductData()
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

        // Assert: validates response
        Assert.NotNull(responseUpdate);
        Assert.True(responseUpdate.IsSuccessStatusCode);

        var updatedResponse = await responseUpdate.Content.ReadFromJsonAsync<ItemUpdate>();
        Assert.NotNull(updatedResponse);

        // Assert: updates object properties
        Assert.Equal(updatedItem.Name, updatedResponse.Name);
        Assert.NotNull(updatedResponse.Data);

        // Confirm changes applied by fetching the product again
        var getResponse = await _httpClient.GetAsync(url);
        Assert.NotNull(getResponse);

    }

    [Fact]
    public async Task Test5_DeleteProductById_ShouldSucceed()
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

        var getResponse = await _httpClient.GetAsync(url);
        var itemResponse = await getResponse.Content.ReadFromJsonAsync<ItemResponse>();

        Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

}