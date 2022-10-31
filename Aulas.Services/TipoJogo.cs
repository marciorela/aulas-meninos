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
        private static List<Type> ListTypes(List<string> filter)
        {
            var ass = Assembly.GetAssembly(typeof(Jogo))!;
            var list = ass.GetTypes()
                .Where(x => x.IsClass && typeof(Jogo).IsAssignableFrom(x) && x != typeof(Jogo) && (filter.Count == 0 || filter.Any(f => f == x.ToString())))
                .OrderBy(x => x.FullName)
                .ToList();

            return list;
        }

        public static List<Jogo> ListInstances(List<string> filter)
        {
            var list = ListTypes(filter);

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

        public static Jogo Random(List<string> filter)
        {
            var list = ListTypes(filter);

            Jogo jogo;
            do
            {
                var randomGame = new Random().Next(list.Count);
                jogo = (Jogo)Activator.CreateInstance(list[randomGame])!;

            } while (!jogo.Enabled);

            return jogo;
        }

    }
}
