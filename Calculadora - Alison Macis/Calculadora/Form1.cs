using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Calculadora : Form
    {
        double num1 = 0, num2 = 0;
        char operador;

        public Calculadora()
        {
            InitializeComponent();
        }

        private void agregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            if (txtResultado.Text == "0")
                txtResultado.Text = "";

            txtResultado.Text += boton.Text;
        
        }

        private void ClickOperador(object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            num1 = Convert.ToDouble(txtResultado.Text);
            operador = Convert.ToChar(boton.Tag);

            if (operador == '²')
            {
                num1 = Math.Pow(num1, 2);
                txtResultado.Text = num1.ToString();
            }

            else if (operador == '√')
            {
                num1 = Math.Sqrt(num1);
                txtResultado.Text = num1.ToString();
            }

            else
            {
                txtResultado.Text = "0";
            }
            
        }

        private void bttn_borrar_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 1)
            {
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }

            else
            {
                txtResultado.Text = "0";
            }
        }

        private void bttn_C_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            operador = '\0';
            txtResultado.Text = "0";
        }

        private void bttn_CE_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }   
        private void bttn_masmenos_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(txtResultado.Text);
            num1 *= -1;
            txtResultado.Text = num1.ToString();
        }

        private void bttn_coma_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains("."))
            {
                txtResultado.Text += ".";
            }
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttn_igual_Click(object sender, EventArgs e)
        {
            num2 = Convert.ToDouble(txtResultado.Text);

            if (operador == '+')
            {
                txtResultado.Text = (num1 + num2).ToString();
                num1 = Convert.ToDouble(txtResultado.Text);
            }

            else if (operador == '-')
            {
                txtResultado.Text = (num1 - num2).ToString();
                num1 = Convert.ToDouble(txtResultado.Text);
            }

            else if (operador == 'x')
            {
                txtResultado.Text = (num1 * num2).ToString();
                num1 = Convert.ToDouble(txtResultado.Text);
            }

            else if (operador == '/')
            {
                if (txtResultado.Text != "0")
                {
                    txtResultado.Text = (num1 / num2).ToString();
                    num1 = Convert.ToDouble(txtResultado.Text);
                }

                else
                {
                    MessageBox.Show("ERROR!");
                }
            }

            else if (operador == '¹')
            {
                txtResultado.Text = (1/num1).ToString();
                num1 = Convert.ToDouble(txtResultado.Text);
            }

            else if (operador == '%')
            {
                txtResultado.Text = ((num1 / num2) * 100).ToString();
                num1 = Convert.ToDouble(txtResultado.Text);
            }
        }
    }
}
