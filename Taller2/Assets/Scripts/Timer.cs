using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textoMinutos;
    public TextMeshProUGUI textoSegundos;
    public TextMeshProUGUI textoMilisegundos;

    void Update()
    {

        GameManager.Instance.AddTime(Time.deltaTime);

        if (GameManager.Instance != null)
        {
            float tiempo = GameManager.Instance.TiempoTotal;

            int minutos = Mathf.FloorToInt(tiempo / 60f);
            int segundos = Mathf.FloorToInt(tiempo % 60f);
            int milisegundos = Mathf.FloorToInt((tiempo * 100f) % 100f);

            textoMinutos.text = minutos.ToString("00");
            textoSegundos.text = segundos.ToString("00");
            textoMilisegundos.text = milisegundos.ToString("00");
        }
    }
}