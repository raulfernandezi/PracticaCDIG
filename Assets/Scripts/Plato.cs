using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static EstadoPlato;
using static Utilidades;
public class Plato : MonoBehaviour
{
    [SerializeField] private ControladorPlatos controladorPlatos;
    [SerializeField] private TextMeshProUGUI textoNumPlatos;
    [SerializeField] private TextMeshProUGUI textoPrecio;
    [SerializeField] private TextMeshProUGUI textoNombrePlato;
    [SerializeField] private Button botonAumentar;
    [SerializeField] private Button botonDisminuir;
    [SerializeField] private Image iconoDisponible;
    [SerializeField] private bool noDisponible;
    [SerializeField] private TipoPlato tipoPlato;

    private int numPlatosint;

    private void Start()
    {
        numPlatosint = 0;
        controladorPlatos.PlatosMaximos += PlatosMaximos;
        controladorPlatos.PlatosNoMaximos += PlatosNoMaximos;
        DeshabilitarBoton(botonDisminuir);
        if (noDisponible)
        {
            iconoDisponible.transform.gameObject.SetActive(true);
            DeshabilitarBoton(botonAumentar);
        }
        else
        {
            iconoDisponible.transform.gameObject.SetActive(false);
        }
    }

    private void PlatosMaximos(System.Object sender, EventArgs e) {
        DeshabilitarBoton(botonAumentar);
    }

    private void PlatosNoMaximos(System.Object sender, EventArgs e)
    {
        if (EstaDisponible())
        {
            HabilitarBoton(botonAumentar);
        }
    }

    private void CambiarNumPlatos(int valor)
    {
        if (controladorPlatos.ComprobarNumPlatos(valor) && numPlatosint + valor >= 0)
        {
            numPlatosint += valor;
            textoNumPlatos.text = numPlatosint.ToString();
            controladorPlatos.CambiarNumPlatos(valor, textoNombrePlato.text, textoPrecio.text, textoNumPlatos.text,tipoPlato);
            if (numPlatosint == 0) {
                DeshabilitarBoton(botonDisminuir);
            }
            else { 
                HabilitarBoton(botonDisminuir);
            }
        }
    }

    private bool EstaDisponible()
    {
        return !noDisponible;
    }
}
