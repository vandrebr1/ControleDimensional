using Common.Models.Interfaces;

namespace Common.Models
{
    public abstract class BaseModel : IModel
    {
        public DateTime DtCadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime DtModificado { get; set; }
        public string ModificadoPor { get; set; }
        public bool IsDeleted { get; set; }
    }
}
