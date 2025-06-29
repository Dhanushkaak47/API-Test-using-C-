using System.Text.Json.Serialization;

public class ItemResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ProductData Data { get; set; }
}

public class ProductData
{
    public int Year { get; set; }
    public double Price { get; set; }

    public string CpuModel { get; set; }

    public string HardDiskSize { get; set; }
}