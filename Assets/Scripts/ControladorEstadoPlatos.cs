using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorEstadoPlatos : MonoBehaviour
{
    [SerializeField] private EstadoPlato primero;
    [SerializeField] private EstadoPlato segundo;
    [SerializeField] private EstadoPlato postre;
    [SerializeField] private EstadoPlato cafe;

    [SerializeField] private Button botonAvanzar;

    private const float ProporcionSolicitado = 0.2f;
    private const float ProporcionCocinado = 0.9f;
    

    private float progresoNormalizado;
    private void Start()
    {
        progresoNormalizado = 0.0f;
    }
    private void Update()
    {
        progresoNormalizado += Time.deltaTime;
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
