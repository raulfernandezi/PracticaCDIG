using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EstadoPlato : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoPlato;
    [SerializeField] private TextMeshProUGUI textoProgreso;
    [SerializeField] private BarraProgreso barraProgreso;
    [SerializeField] private int segundosElaboracion;
    [SerializeField] private TipoPlato tipoPlato;

    public enum TipoPlato { 
        Primero,Segundo,Postre,Café
    }

    private void Start()
    {
        textoPlato.text = tipoPlato.ToString().Normalize();
    }

    public TextMeshProUGUI GetTextoPlato()
    {
        return textoPlato;
    }
    public TextMeshProUGUI GetTextoProgreso() { 
        return textoProgreso;
    }
    public int GetSegundosElaboracion()
    {
        return segundosElaboracion;
    }
    public BarraProgreso GetBarraProgreso()
    {
        return barraProgreso;
    }
}
