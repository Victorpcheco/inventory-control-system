using InventoryControlSystem.Domain.Enums;

namespace InventoryControlSystem.Domain.Models
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Matricula { get; private set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; private set; }
        public DateTime DataCadastro { get; private set; }
 
        public Usuario(string nome, string matricula, string senha)
        {
            //ValidarNome(nome);
            //ValidarMatricula(matricula);
            //ValidarSenha(senha);

            Nome = nome;
            Matricula = matricula;
            Senha = senha;
            DataCadastro = DateTime.Now;
        }

        public static Usuario Criar(string nome, string matricula, string senha)
        {
            ValidarNome(nome);
            ValidarMatricula(matricula);
            ValidarSenha(senha);

            return new Usuario(nome, matricula,senha);
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser vazio ou nulo.");
        }

        private static void ValidarMatricula(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula)) 
                throw new ArgumentException("Matrícula não pode ser vazia ou nula.");
            if (matricula.Length != 6)
                throw new ArgumentException("Matrícula deve ter exatamente 6 caracteres.");
        }

        private static void ValidarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Senha não pode ser vazia ou nula.");

            if (senha.Length < 6)
                throw new ArgumentException("Senha deve ter pelo menos 6 caracteres.");

            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$");
            if (!regex.IsMatch(senha))
                throw new ArgumentException("Senha deve conter pelo menos uma letra maiúscula, um número e um caractere especial.");
        
        }

        public void DefinirSenha(string senha)
        {
            ValidarSenha(senha);
            Senha = BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public void DefinirTipoUsuario(TipoUsuario tipoUsuario)
        {
            TipoUsuario = tipoUsuario;
        }

    }
}
