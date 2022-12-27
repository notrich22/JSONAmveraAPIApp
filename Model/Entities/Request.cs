namespace JSONAmveraAPIApp.Model.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public int KnownHostId { get; set; }
        public KnownHost KnownHost { get; set; }
        public bool isHttps { get; set; }
        public string Path { get; set; }
    }
}
