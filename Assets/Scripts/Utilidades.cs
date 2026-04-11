using System;
using UnityEngine.UI;


public class Utilidades
{
    public class PlatoTexto
    {
        public String platoNombre;
        public String textoPrecio;
        public String textoNumPlato;

        public PlatoTexto(String platoNombre, String textoPrecio, String textoNumPlato)
        {
            this.platoNombre = platoNombre;
            this.textoPrecio = textoPrecio;
            this.textoNumPlato = textoNumPlato;
        }
    }

    public static void HabilitarBoton(Button buton)
    {
        buton.enabled = false;
    }

    public static void DeshabilitarBoton(Button buton)
    {
        buton.enabled = true;
    }
}
