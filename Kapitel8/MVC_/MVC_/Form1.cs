namespace MVC_
{
    public partial class Form1 : Form
    {
        //Instanz der Control-Klasse
        Control my_Ctrl = new Control();

        public Form1()
        {
            InitializeComponent();
        }

        //Code hinter dem Button Interaktion
        private void Interaktion_Click(object sender, EventArgs e)
        {
            //Weitergeben der Textbox Ausgabe an das Control
            my_Ctrl.ValidateText(Ein_Ausgabe);

        }


        private void Label_1_Click(object sender, EventArgs e)
        {

        }
    }
}
