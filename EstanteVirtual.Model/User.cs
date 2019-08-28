using System.Collections.Generic;

namespace EstanteVirtual.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Login Login { get; set; }
        public List<UserBook> Books { get; set; }
        public string Token { get; set; }
    }
}
