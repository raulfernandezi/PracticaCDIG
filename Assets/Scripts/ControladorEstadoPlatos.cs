using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Utilidades;

public class ControladorEstadoPlatos : MonoBehaviour
{
    [SerializeField] private EstadoPlato[] platos;

    [SerializeField] private Button botonAvanzar;

    [SerializeField] private UIController controlador;

    private const float ProporcionSolicitado = 0.2f;
    private const float ProporcionCocinado = 0.9f;
    private const float ProporcionFin = 1f;

    private List<EstadoPlato> platosPedidos;
    private EstadoPlato progresante;
    private int numClicksCambioBoton;
    private int numClicks;
    private float contador;
    private int posPrimero = 0;
    private int posSegundo = 1;
    private int posPostre = 2;
    private int posCafe = 3;
    private void Awake()
    {
        numClicks = 0;
        platosPedidos = new List<EstadoPlato>();
        platos[posPostre].gameObject.SetActive(false);
        platos[posCafe].gameObject.SetActive(false);
        progresante = platos[numClicks];
        DeshabilitarBoton(botonAvanzar);
        botonAvanzar.onClick.AddListener(PedirSiguientePLato);
    }
    private void Update()
    {
        contador += Time.deltaTime;
        ActualizarProgreso(contador / progresante.GetSegundosElaboracion(), progresante);
    }

    public void Inicializar()
    {
        contador = 0.0f;
        numClicksCambioBoton = 1;
        platosPedidos.Add(platos[posPrimero]);
        platosPedidos.Add(platos[posSegundo]);
        if (controlador.TienePostre())
        {
            platos[posPostre].gameObject.SetActive(true);
            numClicksCambioBoton += 1;
            platosPedidos.Add(platos[posPostre]);
        }
        if (controlador.TieneCafe())
        {
            platos[posCafe].gameObject.SetActive(true);
            numClicksCambioBoton += 1;
            platosPedidos.Add(platos[posCafe]);
        }


    }

    public void PedirSiguientePLato() {
        numClicks++;
        if (numClicks >= numClicksCambioBoton)
        {
            botonAvanzar.onClick.RemoveListener(PedirSiguientePLato);
            botonAvanzar.onClick.AddListener(controlador.AvanzarPantalla);
            botonAvanzar.GetComponentInChildren<TextMeshProUGUI>().text = "CONTINUAR";
        }
        progresante = platosPedidos.ElementAt<EstadoPlato>(numClicks);
        contador = 0.0f;
        DeshabilitarBoton(botonAvanzar);
    }

    private void ActualizarProgreso(float progresoNormalizado,EstadoPlato e)
    {
        e.GetBarraProgreso().MostrarProgreso(progresoNormalizado);
        switch (progresoNormalizado)
        {
            case var p when p < ProporcionSolicitado:
                e.GetTextoProgreso().text = "Su " + e.GetTextoPlato().text.ToLower() + " está solicitado";
                break;
            case var p when p < ProporcionCocinado:
                e.GetTextoProgreso().text = "Su " + e.GetTextoPlato().text.ToLower() + " está cocinandose";
                break;
            case var p when p <= ProporcionFin:
                e.GetTextoProgreso().text = "Su " + e.GetTextoPlato().text.ToLower() + " está servido";
                break;
            default:
                HabilitarBoton(botonAvanzar);
                break;
        }
    }
}
