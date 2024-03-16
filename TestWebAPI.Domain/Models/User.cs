namespace TestWebApi.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;
        public List<FriendShip> FriendShips { get; set; } = [];
        public IReadOnlyCollection<Picture> Pictures => pictureList;

        private List<Picture> pictureList = [];
        public void AddPictrure(Picture picture)
            => pictureList.Add(picture);

    }
}
