namespace AutoMapper_Training.ClassWithConstructor;

public class CostCenter(string name)
{
    public string CostCenterName { get; set; } = name;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
