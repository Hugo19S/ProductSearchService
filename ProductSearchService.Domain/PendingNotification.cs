namespace ProductSearchService.Domain;

public class PendingNotification
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public string Avatar { get; set; }
    public string Username { get; set; }
}
