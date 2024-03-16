namespace TestWebApi.Domain.Models
{
    public class FriendShip
    {
        public int Id { get; set; }
        //чел котоырй отправли запрос в друзья
        public int UserFromId { get; set; }
        public User UserFrom { get; set; } = null!;

        // Второй ключ в отношении "многие ко многим"
        //чел кому пришел запрос в друзья
        
        public int UserToId { get; set; }
        public User UserTo { get; set; } = null!;
        public FriendShipStastus Status { get; set;}
        public DateTime DateTimeCreate { get; set; }

        public FriendShip()
        {
            DateTimeCreate = DateTime.Now;
        }
    }
}
