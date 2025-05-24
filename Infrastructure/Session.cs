using Domain.Entitites;

namespace Infrastructure
{
    public static class Session
    {
        public static User? CurrentUser { get; set; }
    }
}
