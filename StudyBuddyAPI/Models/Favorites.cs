namespace StudyBuddyAPI.Models;

public class Favorites
{
    public int FavoriteId { get; set; }
    public int UserId { get; set; }
    public int[] FavoriteQuestions { get; set; }

}
