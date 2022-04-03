using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class authForm : Form
    {
        auth a = new auth();
        public authForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f;
            foreach(auth.Info info in a.workerList)
            {
                if(info.login == textBox1.Text)
                {
                    if(info.password == textBox2.Text)
                    {
                        if (info.role == "admin")
                            f = new Form1();
                        else
                            f = new Form2();
                        f.FormClosing += new FormClosingEventHandler(authForm_FormClosing);
                        this.Hide();
                        f.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Пароль не совпадает");
                    }
                }
                else
                {
                    MessageBox.Show("Логин не найден");
                }
            }
        }
        private void authForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.DBC.closeConnection();
            Application.Exit();
        }
    }
}
