namespace Aulas.Jogos
{
    public class Jogo
    {
        public Jogo()
        {

        }

        public virtual string Titulo()
        {
            return "Título não definido.";
        }

        public virtual string Descricao()
        {
            return "Descrição não definida.";
        }

        public virtual string Pergunta()
        {
            return "Pergunta não definida.";
        }

        public virtual string Resposta()
        {
            return "Resposta não definida.";
        }

    }
}
