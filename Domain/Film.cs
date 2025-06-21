namespace MovieApi.Domain
{

    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Style { get; set; }
        public string Description { get; set; }
        public List<Session> Sessions { get; set; } = new List<Session>();
    }

    public class Session
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
