public class ItemUpdate
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Dictionary<string, object> Data { get; set; }
    public DateTime? UpdatedAt { get; set; }
}


public class ProductDataUpdate
{
    public int Year { get; set; }
    public double Price { get; set; }

    public string CpuModel { get; set; }

    public string HardDiskSize { get; set; }
    public string Color { get; set; }
}


