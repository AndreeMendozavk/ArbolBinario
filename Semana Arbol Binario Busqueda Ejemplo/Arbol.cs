using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semana_Arbol_Binario_Busqueda_Ejemplo
{
    internal class Arbol
    {
        public Nodo Insertar(Nodo actual, int num)
        {
            Nodo nuevo = new Nodo(num);

            if(actual==null)
            {
                return nuevo;
            }
            if(num<actual.numero)
            {
                actual.izquierda = Insertar(actual.izquierda, num);
            }
            else if(num>actual.numero)
            {
                actual.derecha = Insertar(actual.derecha, num);
            }
            else
            {
                MessageBox.Show("No se puede insertar nodos iguales");
            }
            return actual;

        }

        public void Mostrar(Nodo actual, TreeView tree, TreeNode padre)
        {
            TreeNode cabe = new TreeNode(actual.numero.ToString());

            if (padre == null)
                tree.Nodes.Add(cabe);

            else
                padre.Nodes.Add(cabe);

            if (actual.izquierda != null)
                Mostrar(actual.izquierda, tree, cabe);
            if (actual.derecha != null)
                Mostrar(actual.derecha, tree, cabe);

        }

        public Nodo Buscar(Nodo actual, int num)
        {
            while(actual!=null)
            {
                if (actual.numero == num)
                    return actual;
                else if (num < actual.numero)
                    actual = actual.izquierda;
                else
                    actual = actual.derecha;
            }
            return null;
        }

        public void pre(Nodo actual, TextBox text)
        {
            if (actual == null)
                return;


            text.Text += actual.numero + " ";  //raiz               
            pre(actual.izquierda,text);  //izquierda
            pre(actual.derecha,  text);    //derecha

        }
        public void ino(Nodo actual, TextBox text)
        {
            if (actual == null)
                return;          

            ino(actual.izquierda, text);  //izquierda
            text.Text += actual.numero + " ";  //raiz
            ino(actual.derecha, text);    //derecha

        }
        public void post(Nodo actual, TextBox text)
        {
            if (actual == null)
                return;

           post(actual.izquierda, text);  //izquierda
            post(actual.derecha, text);    //derecha
            text.Text += actual.numero + " ";  //raiz
        }

    }
}
