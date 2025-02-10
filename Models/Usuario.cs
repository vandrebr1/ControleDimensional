namespace Models
{
    public class Usuario : BaseModel
    {

        public Usuario()
        {

        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public TipoAcesso TipoAcesso { get; set; }

    }

    public enum TipoAcesso
    {
        Admin,
        User
    }
}
