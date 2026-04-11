

using UnityEngine;
using UnityEngine.UI;

public class BarraProgreso : MonoBehaviour {

    [SerializeField] private Image imagenProgreso;

    public void MostrarProgreso(float progresoNormalizado)
    {
        imagenProgreso.fillAmount = progresoNormalizado;
    }
}