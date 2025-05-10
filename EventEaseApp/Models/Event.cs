namespace EventEaseApp.Models {
public class Event
{
    public int Id { get; set; }  // Primary Key
    public string Name { get; set; } = string.Empty;  // Event Name
    public DateTime Date { get; set; }  // Event Date
    public string Location { get; set; } = string.Empty;  // Event Location
}
}
