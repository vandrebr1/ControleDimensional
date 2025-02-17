using Common.Attribute;

namespace Common.Models
{
    public class Equipment : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        [Ignore]
        public IEnumerable<Padrao> Padroes { get; set; } = new List<Padrao>();

    }
}
