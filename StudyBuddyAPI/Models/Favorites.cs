using Microsoft.EntityFrameworkCore;

namespace StudyBuddyAPI.Models;

public class Favorites
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int[] FavoriteQuestions { get; set; }

}

