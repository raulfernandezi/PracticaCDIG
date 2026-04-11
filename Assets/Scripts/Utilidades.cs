using System;
using UnityEngine.UI;
using static EstadoPlato;


public class Utilidades
{
    public class PlatoTexto
    {
        public String platoNombre;
        public String textoPrecio;
        public String textoNumPlato;
        public TipoPlato tipoPlato;

        public PlatoTexto(String platoNombre, String textoPrecio, String textoNumPlato, TipoPlato tipoPlato)
        {
            this.platoNombre = platoNombre;
            this.textoPrecio = textoPrecio;
            this.textoNumPlato = textoNumPlato;
            this.tipoPlato = tipoPlato;
        }
    }

    public static void HabilitarBoton(Button buton)
    {
        buton.enabled = true;
    }

    public static void DeshabilitarBoton(Button buton)
    {
        buton.enabled = false;
    }
}
