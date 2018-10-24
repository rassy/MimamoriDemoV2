using System.Windows.Forms;

namespace jp.co.brycen.MimamoriDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnPcdMenu_Click(object sender, System.EventArgs e)
        {
            PcdFrom pcd = new PcdFrom();
            pcd.Show();
        }

        private void OnLcdMenu_Click(object sender, System.EventArgs e)
        {
            LCDForm pcd = new LCDForm();
            pcd.Show();
        }

        private void OnPctMenu_Click(object sender, System.EventArgs e)
        {
            PctForm pct = new PctForm();
            pct.Show();
        }
    }
}
