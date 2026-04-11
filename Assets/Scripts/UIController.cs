using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ControladorPlatos;
using static Utilidades;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject[] Paneles;
    [SerializeField] private TextMeshProUGUI textoNumComensales;

    [SerializeField] private ControladorPlatos controladorPlatosPrimeros;
    [SerializeField] private ControladorPlatos controladorPlatosSegundos;
    [SerializeField] private ControladorPlatos controladorPlatosBebida;
    [SerializeField] private ControladorPlatos controladorPlatosPostre;
    [SerializeField] private ControladorPlatos controladorPlatosCafe;

    [SerializeField] private ControladorCuenta controladorCuenta;

    [SerializeField] private GameObject[] pestaniasPlatos;

    [SerializeField] private Button botonSeleccionPlatos;

    private List<PlatoTexto> platos;

    private int posicion;
    private int numComensales;
    private int numPestaniaPlatos; // entre 0 y 4 de primeros a cafe
    private const int MAX_COMENSALES = 4;
    private const int NUM_PESTANIAS_PLATOS = 5;
    void Start()
    {
        platos = new List<PlatoTexto>();
        posicion = 0;
        numComensales = 1;
        DeshabilitarBoton(botonSeleccionPlatos);
        for (int i = 1; i < NUM_PESTANIAS_PLATOS; i++)
        {
            pestaniasPlatos[i].SetActive(false);
        }
        foreach (GameObject panele in Paneles) {
            panele.SetActive(false);
        }
        Paneles[posicion].SetActive(true);
        controladorPlatosPrimeros.CambioNumPLatos += CambioNumPlatos;
        controladorPlatosSegundos.CambioNumPLatos += CambioNumPlatos;
        controladorPlatosBebida.CambioNumPLatos += CambioNumPlatos;
        controladorPlatosPostre.CambioNumPLatos += CambioNumPlatos;
        controladorPlatosCafe.CambioNumPLatos += CambioNumPlatos;
    }

    public void AvanzarPantalla()
    {
        switch (posicion) {
            case 2:
                platos.AddRange(controladorPlatosPrimeros.GetPlatos());
                platos.AddRange(controladorPlatosSegundos.GetPlatos());
                platos.AddRange(controladorPlatosBebida.GetPlatos());
                platos.AddRange(controladorPlatosPostre.GetPlatos());
                platos.AddRange(controladorPlatosCafe.GetPlatos());
                AvanzarASiguientePanel();
                break;
            case 3:
                controladorCuenta.calcularCuenta();
                AvanzarASiguientePanel();
                break;
            default:
                AvanzarASiguientePanel();
                break;
        }
    }

    private void AvanzarASiguientePanel()
    {
        Paneles[posicion].SetActive(false);
        posicion++;
        Paneles[posicion].SetActive(true);
    }

    public List<PlatoTexto> getListaPlatos() {
        return platos;
    }
    public void CambiarNumComensales(int valor) {
        if (numComensales + valor > 0 && numComensales + valor <= MAX_COMENSALES) {
            numComensales += valor;
            textoNumComensales.text = numComensales.ToString();
        }
    }

    private void CambioNumPlatos(System.Object sender, EventArgs e) {
        if (controladorPlatosPrimeros.NumPlatosElegidosCorrecto() &&
            controladorPlatosSegundos.NumPlatosElegidosCorrecto())
        {
            HabilitarBoton(botonSeleccionPlatos);
        }
        else {
            DeshabilitarBoton(botonSeleccionPlatos);
        }
    }

    public void CambiarPestañaPlatos(int pestania)
    {
        pestaniasPlatos[numPestaniaPlatos].SetActive(false);
        pestaniasPlatos[pestania].SetActive(true);
        numPestaniaPlatos = pestania;
    }

    public int GetNumComensales()
    {
        return numComensales;
    }
}
