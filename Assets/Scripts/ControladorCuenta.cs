using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ControladorPlatos;

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
    {   /*
        platos = controlador.getListaPlatos();
        posicion = posInicial.position;

        foreach (PlatoTexto p in platos)
        {
            GameObject plato = (GameObject)Instantiate(prefabPlatoCuenta, posicion, Quaternion.identity, scrollViewContent);
            //plato.getChild("TextoNombre").text = p.platoNombre;
            posicion.y -= 65;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
