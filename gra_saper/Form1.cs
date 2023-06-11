namespace gra_saper
{
    public partial class Form1 : Form
    {

        public int kol, el;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string text = textBox2.Text;
            el = Int32.Parse(textBox2.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            kol = Int32.Parse(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(kol, el);
            form2.ShowDialog();
        }
    }
}