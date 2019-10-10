namespace Conference.Domain.Entities
{
    public class Photos
    {
        public int Id { get; set; }
        public int ImageType { get; set; }
        public int SpeakerId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public virtual Speakers Speaker { get; set; }
    }
}