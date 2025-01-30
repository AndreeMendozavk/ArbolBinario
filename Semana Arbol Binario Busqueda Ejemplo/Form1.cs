using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semana_Arbol_Binario_Busqueda_Ejemplo
{
    public partial class Form1 : Form
    {
        Arbol a = new Arbol();
        Nodo raiz;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
           if(int.TryParse(textBoxNumero.Text,out int num))
           {
                if (raiz == null)
                    raiz = a.Insertar(null, num);
                else
                    a.Insertar(raiz, num);

                treeView1.Nodes.Clear();
                a.Mostrar(raiz, treeView1, null);
                treeView1.ExpandAll();
               
           }
           else
           {
                MessageBox.Show("Ingrese un numero entero valido");    
           }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBoxNumero.Text,out int num))
            {
                if (a.Buscar(raiz, num) != null)
                    MessageBox.Show($"El numero {num} existe");
                else
                    MessageBox.Show($"El numero {num} no existe");
            }
            else
            {
                MessageBox.Show("Ingrese un numero valido!");
            }
        }

        private void btnRecorrido_Click(object sender, EventArgs e)
        {
            if(raiz!=null)
            {
                textPre.Clear();
                textIn.Clear();
                textPost.Clear();

                a.pre(raiz, textPre);
                a.ino(raiz, textIn);
                a.post(raiz, textPost);


            }
            else
            {
                MessageBox.Show("Arbol vacio!");
            }


        }
    }
}
