using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPlatos : MonoBehaviour
{
    [SerializeField] private UIController controlador;

    public EventHandler PlatosMaximos;
    public EventHandler PlatosNoMaximos;

    private int numPlatos;

    void Start()
    {
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

    public void CambiarNumPlatos(int valor)
    {
        numPlatos += valor;
        if(numPlatos == controlador.GetNumComensales())
        {
            PlatosMaximos?.Invoke(this, EventArgs.Empty);
        }else if (numPlatos < controlador.GetNumComensales())
        {
            PlatosNoMaximos?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool Platos()
    {
        return numPlatos == controlador.GetNumComensales();
    }
}
