namespace Models
{
    public abstract class BaseModel
    {
        public DateTime DtCadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime DtModificado { get; set; }
        public string ModificadoPor { get; set; }
        public bool IsDeleted { get; set; }
    }
}
