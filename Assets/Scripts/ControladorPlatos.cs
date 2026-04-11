using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPlatos : MonoBehaviour
{
    [SerializeField] private UIController controlador;

    public EventHandler PlatosMaximos;
    public EventHandler PlatosNoMaximos;
    public EventHandler CambioNumPLatos;

    private List<PlatoTexto> platos;

    public class PlatoTexto
    {
        public String platoNombre;
        public String textoPrecio;
        public String textoNumPlato;

        public PlatoTexto(String platoNombre, String textoPrecio, String textoNumPlato)    {
            this.platoNombre = platoNombre;
            this.textoPrecio = textoPrecio;
            this.textoNumPlato = textoNumPlato;
        }
    }



    private int numPlatos;

    void Awake()
    {
        platos = new List<PlatoTexto>();
        numPlatos = 0;
    }

    public bool ComprobarNumPlatos(int valor)
    {
        if (numPlatos + valor >= 0 && numPlatos + valor <= controlador.GetNumComensales())
        {
            return true;
        }
        return false;
    }

    public void CambiarNumPlatos(int valor, String platoNombre,
    String textoPrecio, String textoNumPlatos)
    {
        numPlatos += valor;
        platos.RemoveAll(t => t.platoNombre == platoNombre);
        foreach (PlatoTexto t in platos)
        {
            Debug.Log(t.textoNumPlato);
        }
        platos.Add(new PlatoTexto (platoNombre, textoPrecio, textoNumPlatos));
        if(numPlatos == controlador.GetNumComensales())
        {
            PlatosMaximos?.Invoke(this, EventArgs.Empty);
        }else if (numPlatos < controlador.GetNumComensales())
        {
            PlatosNoMaximos?.Invoke(this, EventArgs.Empty);
        }
        CambioNumPLatos?.Invoke(this, EventArgs.Empty);
    }

    public bool NumPlatosElegidosCorrecto()
    {
        return numPlatos == controlador.GetNumComensales();
    }

    public List<PlatoTexto> GetPlatos()
    {
        return platos;
    }
}
