namespace Conference.Domain.Entities
{
    public class SponsorPhoto
    {
        public int SponsorId { get; set; }
        public int Id { get; set; }
        public string ImageMimeType { get; set; }
        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }

        public virtual Sponsors Sponsor { get; set; }
    }
}