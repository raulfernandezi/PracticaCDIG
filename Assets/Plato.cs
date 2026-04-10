using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Plato : MonoBehaviour
{
    //[SerializeField] private GameObject panel;
    [SerializeField] private ControladorPlatos controladorPlatos;
    [SerializeField] private TextMeshProUGUI numPlatos;

    private int numPlatosint;

    private void Start()
    {
        numPlatosint = 0;
        //controladorPlatos = panel.GetComponent<ControladorPlatos>();
    }

    public void CambiarNumPlatos(int valor)
    {
        if (controladorPlatos.ComprobarNumPlatos(valor) && numPlatosint + valor >= 0)
        {
            controladorPlatos.CambiarNumPlatos(valor);
            numPlatosint += valor;
            numPlatos.text = numPlatosint.ToString();
        }
    }
}
