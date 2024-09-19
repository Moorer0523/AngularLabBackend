namespace StudyBuddyAPI.Models.DTO;

public class FavoritesDTO
{
    public int UserId { get; set; }
    public int[] FavoriteQuestions { get; set; }
}
