using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteKanban
{
    internal class Projecte
    {
        private int _id;
        private string _nom;
        private List<Tasca> _tasques;
        private List<Usuari> _usuaris;
        private List<string> _estats;


        public Projecte(string nom)
        {
            _nom = nom;
            _estats = new List<string> { "Per començar", "En curs", "Finalitzat" };
        }

        public void afegirTasca(Tasca tasca)
        {
            _tasques.Add(tasca);
        }

        public List<string> getEstats()
        {
            return _estats;
        }
    }
}
