using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ControladorPlatos;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;

public class ControladorCuenta : MonoBehaviour
{
    [SerializeField] private UIController controlador;
    private List<PlatoTexto> platos;

    [SerializeField] private GameObject prefabPlatoCuenta;
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private Transform posInicial;

    [SerializeField] private TextMeshProUGUI textoPrecioTotal;
    [SerializeField] private TextMeshProUGUI textoPrecioIva;
    [SerializeField] private TextMeshProUGUI textoPrecioTotalSinIva;


    private Vector3 posicion;
    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void calcularCuenta()
    {
        platos = controlador.getListaPlatos();
        posicion = posInicial.position;
        TextMeshProUGUI texto;
        string nombrePlato;
        string cantidadPlato;
        string precioPlato;
        double precio;
        double precioTotalSinIva;
        double precioIva;
        double precioTotal = 0;
        double porcentajeIva = 0.21;
        char simboloEuro = '€';

        foreach (PlatoTexto p in platos)
        {
            GameObject plato = (GameObject)Instantiate(prefabPlatoCuenta, posicion, Quaternion.identity, scrollViewContent);

            nombrePlato = p.platoNombre.Split(".")[0];
            cantidadPlato = p.textoNumPlato;
            precioPlato = p.textoPrecio.Split("€")[0];

            texto = plato.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            texto.text = nombrePlato;
            texto = plato.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            texto.text = cantidadPlato;

            precio = double.Parse(precioPlato) * int.Parse(cantidadPlato);
            precioTotal += precio;

            texto = plato.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            texto.text = precio.ToString() + simboloEuro;

            posicion.y -= 65;
        }

        precioIva = Math.Round(precioTotal * porcentajeIva, 2);
        precioTotalSinIva = Math.Round(precioTotal - precioIva,2);

        textoPrecioTotalSinIva.text = precioTotalSinIva.ToString() + simboloEuro;
        textoPrecioIva.text = precioIva.ToString() + simboloEuro;
        textoPrecioTotal.text = precioTotal.ToString() + simboloEuro;
    }
}
