using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_
{
    internal class Model
    {
        //Ablegen der Texte in eine einfache lineare Liste

        //Deklaration der Liste
        List<string> AbgelegteTexte = new List<string>();

        //Methode zum Befüllen der Liste
        public void AblegenTexte(string t_text)
        {
            AbgelegteTexte.Add(t_text);
        }
    }
}
