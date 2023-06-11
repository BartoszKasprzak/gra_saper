using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gra_saper
{
    public partial class Form2 : Form
    {
        private int rozmiar, ilosc, czas;
        int licznik;
        private Button[,] buttons;
        private bool[,] bombs;
        private System.Windows.Forms.Timer timer;
        

        public Form2(int ilosckol, int iloscel)
        {
            InitializeComponent();
            rozmiar = ilosckol;
            ilosc = iloscel;
            Plansza();
            Stoper();
        }
        private void Plansza()
        {
            buttons = new Button[rozmiar, rozmiar];
            bombs = new bool[rozmiar, rozmiar];
            Random random = new Random();
            int bombCount = 0;

            for (int i = 0; i < rozmiar; i++)
            {
                for (int j = 0; j < rozmiar; j++)
                {
                    Button button = new Button
                    {
                        Size = new Size(40, 40),
                        Location = new Point(40 * j, 40 * i),
                        Tag = new Tuple<int, int>(i, j)
                    };
                    button.MouseUp += obsluga_gry;
                    Controls.Add(button);
                    buttons[i, j] = button;
                }
            }

            while (bombCount < ilosc)
            {
                int row = random.Next(rozmiar);
                int col = random.Next(rozmiar);
                if (!bombs[row, col])
                {
                    bombs[row, col] = true;
                    bombCount++;
                }
            }
        }

        private void Stoper()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (sender, e) =>
            {
                czas++;
                if (czas >= ilosc * 3)
                {
                    timer.Stop();
                    MessageBox.Show("Przegrałeś! Upłynął limit czasu.");
                    DisableButtons();
                }
            };
            czas = 0;
            timer.Start();
        }

        private void obsluga_gry(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            var position = (Tuple<int, int>)button.Tag;
            var row = position.Item1;
            var col = position.Item2;

            if (e.Button != MouseButtons.Left)
                return;

            if (bombs[row, col])
            {
                button.BackColor = Color.Green;
                licznik++;

                if (licznik == ilosc)
                {
                    timer.Stop();
                    MessageBox.Show("Wygrałeś! Odkryłeś wszystkie elementy.");
                    DisableButtons();
                }
            }
            else
            {
                button.Enabled = false;
                button.BackColor = Color.Red;
            }
        }

        private void DisableButtons()
        {
            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
