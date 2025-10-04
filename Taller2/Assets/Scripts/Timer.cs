using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textoMinutos;
    public TextMeshProUGUI textoSegundos;
    public TextMeshProUGUI textoMilisegundos;

    private bool tiempoActivo = true;

    void Update()
    {
        if (tiempoActivo && GameManager.Instance != null)
        {
            GameManager.Instance.AddTime(Time.deltaTime);

            float tiempo = GameManager.Instance.TiempoTotal;

            int minutos = Mathf.FloorToInt(tiempo / 60f);
            int segundos = Mathf.FloorToInt(tiempo % 60f);
            int milisegundos = Mathf.FloorToInt((tiempo * 100f) % 100f);

            textoMinutos.text = minutos.ToString("00");
            textoSegundos.text = segundos.ToString("00");
            textoMilisegundos.text = milisegundos.ToString("00");
        }
    }

    public void DetenerTiempo()
    {
        tiempoActivo = false;
    }
}