using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPlatos : MonoBehaviour
{
    [SerializeField] private UIController controlador;

    private int numPlatos;
    // Update is called once per frame
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
    }

    public bool Platos()
    {
        return numPlatos == controlador.GetNumComensales();
    }
}
