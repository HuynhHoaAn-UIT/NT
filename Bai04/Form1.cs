namespace Bai04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            FormServer a = new FormServer();
            a.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            FormClient b=new FormClient();
            b.Show();
        }
    }
}
