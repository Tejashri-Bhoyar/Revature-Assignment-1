using Core;

namespace Infrastructure
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
