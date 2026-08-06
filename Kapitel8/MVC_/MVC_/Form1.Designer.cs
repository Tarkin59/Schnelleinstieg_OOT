namespace MVC_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Interaktion = new Button();
            Label_1 = new Label();
            Ein_Ausgabe = new TextBox();
            SuspendLayout();
            // 
            // Interaktion
            // 
            Interaktion.Location = new Point(141, 274);
            Interaktion.Name = "Interaktion";
            Interaktion.Size = new Size(223, 64);
            Interaktion.TabIndex = 0;
            Interaktion.Text = "Interaktion";
            Interaktion.UseVisualStyleBackColor = true;
            Interaktion.Click += Interaktion_Click;
            // 
            // Label_1
            // 
            Label_1.AutoSize = true;
            Label_1.Location = new Point(209, 133);
            Label_1.Name = "Label_1";
            Label_1.Size = new Size(112, 25);
            Label_1.TabIndex = 1;
            Label_1.Text = "Ein/Ausgabe";
            Label_1.Click += Label_1_Click;
            // 
            // Ein_Ausgabe
            // 
            Ein_Ausgabe.Location = new Point(141, 192);
            Ein_Ausgabe.Name = "Ein_Ausgabe";
            Ein_Ausgabe.Size = new Size(222, 31);
            Ein_Ausgabe.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 450);
            Controls.Add(Ein_Ausgabe);
            Controls.Add(Label_1);
            Controls.Add(Interaktion);
            Name = "Form1";
            Text = "MVC_Beispiel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Interaktion;
        private Label Label_1;
        private TextBox Ein_Ausgabe;
    }
}
