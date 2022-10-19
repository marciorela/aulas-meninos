using Aulas.Domain.Models;
using Aulas.Jogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Services
{
    public static class TipoJogo
    {
        private static readonly List<string> _filter = new();

        private static List<Type> ListTypes()
        {
            var ass = Assembly.GetAssembly(typeof(Jogo))!;
            var list = ass.GetTypes().Where(x => x.IsClass && typeof(Jogo).IsAssignableFrom(x) && x != typeof(Jogo) && (_filter.Count == 0 || _filter.Any(f => f == x.ToString()))).ToList();

            return list;
        }

        public static List<Jogo> ListInstances()
        {
            var list = ListTypes();

            var instances = new List<Jogo>();
            foreach (var type in list)
            {
                var jogo = (Jogo)Activator.CreateInstance(type)!;
                if (jogo.Enabled)
                {
                    instances.Add(jogo);
                }
            }

            return instances;
        }

        public static Jogo Random()
        {
            var list = ListTypes();

            Jogo jogo;
            do
            {
                var randomGame = new Random().Next(list.Count);
                jogo = (Jogo)Activator.CreateInstance(list[randomGame])!;

            } while (!jogo.Enabled);

            return jogo;
        }

        public static void Filter(List<string> listOpcoes)
        {
            _filter.Clear();
            _filter.AddRange(listOpcoes);
        }
    }
}
