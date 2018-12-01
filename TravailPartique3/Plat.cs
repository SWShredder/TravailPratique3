using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravailPartique3
{
    [Serializable]
    class Plat
    {
        public List<Plat> ListePlats;
        public int Index { get; }
        public string Nom { get; }

        public Plat(string p_nom, int p_index)
        {
            Index = p_index;
            Nom = p_nom;
        }

        public override string ToString() => String.Format("{0}. {1}", Index, Nom);
    }
}
