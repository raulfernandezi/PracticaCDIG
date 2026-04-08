using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject[] Paneles;
    [SerializeField] private TextMeshProUGUI textoNumComensales;

    private int posicion;
    private int numComensales;
    private const int MAX_COMENSALES = 4;
    // Start is called before the first frame update
    void Start()
    {
        posicion = 0;
        numComensales = 1;
        foreach (GameObject panele in Paneles) {
            panele.SetActive(false);
        }
        Paneles[posicion].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Avanzar()
    {
        Paneles[posicion].SetActive(false);
        posicion++;
        Paneles[posicion].SetActive(true);
    }

    public void CambiarNumComensales(int valor) {
        if (numComensales + valor > 0 && numComensales + valor <= MAX_COMENSALES) {
            numComensales += valor;
            textoNumComensales.text = numComensales.ToString();
        }
    }

    public int GetNumComensales()
    {
        return numComensales;
    }
}
