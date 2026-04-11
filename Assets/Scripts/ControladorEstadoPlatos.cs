using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorEstadoPlatos : MonoBehaviour
{
    [SerializeField] private EstadoPlato[] platos;

    [SerializeField] private Button botonAvanzar;

    [SerializeField] private UIController controlador;

    private const float ProporcionSolicitado = 0.2f;
    private const float ProporcionCocinado = 0.9f;

    private EstadoPlato progresante;
    private int numClicksCambioBoton;
    private int numClicks;
    private float contador;
    private int posPostre = 2;
    private int posCafe = 3;
    private void Awake()
    {
        numClicks = 0;
        platos[posPostre].gameObject.SetActive(false);
        platos[posCafe].gameObject.SetActive(false);
        progresante = platos[numClicks];
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
        if (controlador.TienePostre())
        {
            platos[posPostre].gameObject.SetActive(true);
            numClicksCambioBoton += 1;
        }
        if (controlador.TieneCafe())
        {
            platos[posCafe].gameObject.SetActive(true);
            numClicksCambioBoton += 1;
        }
    }

    public void PedirSiguientePLato() {
        numClicks++;
        if(numClicks < numClicksCambioBoton)
        {
            progresante = platos[numClicks];
            contador = 0.0f;
        }
        else
        {
            botonAvanzar.onClick.RemoveAllListeners();
            botonAvanzar.onClick.AddListener(controlador.AvanzarPantalla);
            botonAvanzar.GetComponent<TextMeshProUGUI>().text = "CONTINUAR";
        }
            
    }

    private void ActualizarProgreso(float progresoNormalizado,EstadoPlato e)
    {
        e.GetBarraProgreso().MostrarProgreso(progresoNormalizado);
        switch (progresoNormalizado)
        {
            case var p when p < ProporcionSolicitado:
                e.GetTextoProgreso().text = "Su " + e.GetTextoPlato().text + "está solicitado";
                break;
            case var p when p < ProporcionCocinado:
                e.GetTextoProgreso().text = "Su " + e.GetTextoPlato().text + "está cocinandose";
                break;
            default:
                e.GetTextoProgreso().text = "Su " + e.GetTextoPlato().text + "está servido";
                break;
        }
    }
}
