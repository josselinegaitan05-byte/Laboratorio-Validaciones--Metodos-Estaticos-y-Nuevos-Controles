namespace MDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirFormHijo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var existente = Application.OpenForms.OfType<Form2>().FirstOrDefault();

            if (existente != null)
            {
                existente.BringToFront();
            }
            else
            {
                Form2 hijo = new Form2();
                hijo.MdiParent = this;
                hijo.Show();
            }
        }
    }
}