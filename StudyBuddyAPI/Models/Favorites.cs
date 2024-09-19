namespace StudyBuddyAPI.Models;

public class Favorites
{
    public int FavoriteId { get; set; }
    public Question[] Questions { get; set; }
    public int UserId { get; set; }
}