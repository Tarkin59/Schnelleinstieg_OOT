using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_
{
    internal class Control
    {
        //Instanz der Model-Klasse
        Model my_model = new Model();

        //Methode zu Validierung von Eingaben
        public bool ValidateText(TextBox t_box)
        {
            if (t_box.Text == "")
            {
                return false;
            }
            else
            {
                ValidateInhalt(t_box);
                return true;
            }
        }

        //Methode zur fachlichen Prüfung
        void ValidateInhalt(TextBox t_box)
        {
            //Statusvariable für Erfolg des Workflow
            bool status = true;

            //Prüfen auf Niemand
            if (t_box.Text != "Niemand")
            {
                try
                {
                    // Weitergabe an Model zur Speicherung
                    my_model.AblegenTexte(t_box.Text);
                }
                catch
                {
                    //Hier fangen wir Fehler bei der Ablage der Texte ab
                    status = false;
                }
            }
            else
            {
                status = false;
            }

            AbschlussWorkflow(t_box, status);
        }


        //Methode zum Abschluss des "Workflows"
        TextBox AbschlussWorkflow(TextBox t_box, bool status)
        {
            if (status)
            {
                //Setzen des Textes der Textbox auf positives Resultat
                t_box.Text = "gelungen";
            }
            else
            {
                //Setzen des Textes der Textbox auf negatives Resultat
                t_box.Text = "misslungen";
            }

            return t_box;
        }
    }
}
