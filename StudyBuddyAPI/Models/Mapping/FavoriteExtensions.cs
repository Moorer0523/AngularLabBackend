using StudyBuddyAPI.Models.DTO;

namespace StudyBuddyAPI.Models.Mapping
{
    public static class FavoritesExtensions
    {
        public static Favorites ToFavorites(this FavoritesDTO favoritesDTO) 
        {
            return new Favorites()
            {
                FavoriteQuestions = favoritesDTO.FavoriteQuestions
            };
        }

        public static void UpdateFavorites(this Favorites currentFavorites, FavoritesDTO updatedfavoritesDTO)
        {
            currentFavorites.FavoriteQuestions = updatedfavoritesDTO.FavoriteQuestions;
            currentFavorites.UserId = updatedfavoritesDTO.UserId;
        }
    }
}
