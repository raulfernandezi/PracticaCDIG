using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ControladorPlatos;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorCuenta : MonoBehaviour
{
    [SerializeField] private UIController controlador;
    private List<PlatoTexto> platos;

    [SerializeField] private GameObject prefabPlatoCuenta;
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private Transform posInicial;
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
        Debug.Log("Pito");
        platos = controlador.getListaPlatos();
        posicion = posInicial.position;

        foreach (PlatoTexto p in platos)
        {
            GameObject plato = (GameObject)Instantiate(prefabPlatoCuenta, posicion, Quaternion.identity, scrollViewContent);
            //plato.GetComponentInChildren("TextoNombre").text = p.platoNombre;
            TextMeshProUGUI testo = plato.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            testo.text = p.platoNombre;
            Debug.Log(testo.text);
            posicion.y -= 65;
        }
    }
}
