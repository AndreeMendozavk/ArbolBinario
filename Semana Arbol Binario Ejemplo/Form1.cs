using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semana_Arbol_Binario_Ejemplo
{
    public partial class Form1 : Form
    {
        Arbol a=new Arbol();
        Nodo raiz;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBoxNumero.Text, out int num))
            {
                if (raiz == null)
                    raiz = a.Insertar(null, num);

                else
                    a.Insertar(raiz, num);

                treeView1.Nodes.Clear();
                a.Mostrar(raiz, treeView1, null);
                treeView1.ExpandAll();
                textBoxNumero.Clear();

            }

            else
            {
                MessageBox.Show("Ingrese un número entero válido! ");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBoxNumero.Text,out int num))
            {
                raiz = a.Eliminar(raiz,num);
                treeView1.Nodes.Clear();
                a.Mostrar(raiz, treeView1, null);
                treeView1.ExpandAll();
               

            }

            else
            {
                MessageBox.Show("Ingrese un número válido!");
            }
        }

        private void btnMinimo_Click(object sender, EventArgs e)
        {
            if (raiz != null)
            {
                MessageBox.Show("El valor Minimo:" + a.minimorecursivo(raiz));
            }
            else
                MessageBox.Show("Arbol vacio");
        }

        private void btnMaximo_Click(object sender, EventArgs e)
        {

            if (raiz != null)
            {
                MessageBox.Show("El valor maximo:" + a.maximorecursivo(raiz));
            }
            else
                MessageBox.Show("Arbol vacio");
        }
    }
}
