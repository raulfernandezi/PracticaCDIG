using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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



    private int numPlatosint;

    private void Start()
    {
        numPlatosint = 0;
        controladorPlatos.PlatosMaximos += PlatosMaximos;
        controladorPlatos.PlatosNoMaximos += PlatosNoMaximos;
        ApagarBoton(botonDisminuir);
        if (noDisponible)
        {
            iconoDisponible.transform.gameObject.SetActive(true);
        }
        else
        {
            iconoDisponible.transform.gameObject.SetActive(false);
        }
    }

    private void PlatosMaximos(System.Object sender, EventArgs e) {
        ApagarBoton(botonAumentar);
    }

    private void PlatosNoMaximos(System.Object sender, EventArgs e)
    {
        EncenderBoton(botonAumentar);
    }

    private void CambiarNumPlatos(int valor)
    {
        if (controladorPlatos.ComprobarNumPlatos(valor) && numPlatosint + valor >= 0)
        {
            controladorPlatos.CambiarNumPlatos(valor, textoNombrePlato.text, textoPrecio.text, textoNumPlatos.text);
            numPlatosint += valor;
            textoNumPlatos.text = numPlatosint.ToString();
            if(numPlatosint == 0) {
                ApagarBoton(botonDisminuir);
            }
            else {
                EncenderBoton(botonDisminuir);
            }
        }
    }


    private void ApagarBoton(Button buton) {
        buton.enabled = false;
    }

    private void EncenderBoton(Button buton)
    {
        buton.enabled = true;
    }
}
