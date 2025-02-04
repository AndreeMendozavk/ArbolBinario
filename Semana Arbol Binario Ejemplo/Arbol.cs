using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semana_Arbol_Binario_Ejemplo
{
    internal class Arbol
    {

        public Nodo Insertar(Nodo actual, int num)
        {
            Nodo nuevo = new Nodo(num);

            if (actual == null)    //raiz
                return nuevo;

            if (num < actual.numero)
                actual.izquierda = Insertar(actual.izquierda, num);  //rama izquierda
            else if (num > actual.numero)
                actual.derecha = Insertar(actual.derecha, num);      //rama derecha
            else
                MessageBox.Show("No se permite duplicados ");

            return actual;

        }
        public void Mostrar(Nodo actual, TreeView tree, TreeNode padre)
        {
            if (actual == null)  return;

            TreeNode cabe = new TreeNode(actual.numero.ToString());  //raiz
                      
            if(padre==null)               //tallo
                tree.Nodes.Add(cabe);
            else                         //hoja
                padre.Nodes.Add(cabe);

            if (actual.izquierda != null)
                Mostrar(actual.izquierda, tree, cabe);    //izquierda
            if (actual.derecha != null)
                Mostrar(actual.derecha, tree, cabe);       //derecha

        }

        public Nodo Eliminar(Nodo actual,int num)
        {
            if (actual == null)
                return null;
            if (num < actual.numero)
                actual.izquierda = Eliminar(actual.izquierda, num);
            else if (num > actual.numero)
                actual.derecha = Eliminar(actual.derecha, num);
            else
            {
                //caso 1: nodo con 0 hijos o con 1 hijo
                if (actual.izquierda == null)
                    return actual.derecha;
                else if (actual.derecha == null)
                    return actual.izquierda;

                //caso 2: 
                actual.numero = minimorecursivo(actual.derecha);

                actual.derecha = Eliminar(actual.derecha, actual.numero);
            }

            return actual;

        }

        public int minimorecursivo(Nodo actual)
        {
            while (actual.izquierda != null)
            {
                actual = actual.izquierda;
            }
            return actual.numero;
        }
        public int maximorecursivo(Nodo actual)
        {
            while(actual.derecha!=null)
            {
                actual = actual.derecha;
            }
            return actual.numero;
        }

    }
}
