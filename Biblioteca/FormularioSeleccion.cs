using System;
using System.Windows.Forms;

namespace Inicio_Bliblioteca
{
    public class FormularioSeleccion<T> : Form where T : class
    {
        T elemento = null;
        bool esSeleccion;

        protected virtual void OnEsSeleccionCambio(bool pEsSeleccion)
        {

        }


        public bool GetEsSeleccion()
        {
            return esSeleccion;
        }

        public void SetEsSeleccion(bool pEsSeleccion)
        {
            elemento = null;
            esSeleccion = pEsSeleccion;
            OnEsSeleccionCambio(esSeleccion);
        }

        public void SetElementoSeleccionado(T pElemento)
        {
            elemento = pElemento;
        }

        public bool SeleccionoElemento()
        {
            return esSeleccion && elemento != null;
        }

        public T ObtenerElementoSeleccionado()
        {
            return elemento;
        }
    }
}