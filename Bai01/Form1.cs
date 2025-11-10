namespace Bai01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSever_Click(object sender, EventArgs e)
        {
            new FormServer().Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            new FormClient().Show();
        }
    }
}
