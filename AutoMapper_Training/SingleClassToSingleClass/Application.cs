namespace AutoMapper_Training.SingleClassToSingleClass;

public class Application
{
    public string UniqueId { get; set; } = string.Empty;
    public long? JobApplicationId { get; set; } = null;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public long? PhoneNumber { get; set; } = null;
    public DateTime? StartDate { get; set; } = null;
}
