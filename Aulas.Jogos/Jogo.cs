namespace Aulas.Jogos
{
    public class Jogo
    {
        public virtual string Pergunta { 
            get { 
                return "Pergunta não definida."; 
            } 
        }

        public virtual string Resposta { 
            get { 
                return "Resposta não definida."; 
            } 
        }

        public virtual string Titulo { 
            get { 
                return "Título não definida."; 
            } 
        }

        public virtual string Descricao { 
            get { 
                return "Descrição não definida."; 
            } 
        }

        public Jogo()
        {

        }

    }
}
