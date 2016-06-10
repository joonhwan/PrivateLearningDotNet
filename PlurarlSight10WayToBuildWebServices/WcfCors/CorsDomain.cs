namespace WcfCors
{
    public class CorsDomain
    {
        public string Filter { get; set; }

        public string AllowMethods { get; set; }

        public string AllowHeaders { get; set; }

        public bool AllowCredentials { get; set; }
    }
}