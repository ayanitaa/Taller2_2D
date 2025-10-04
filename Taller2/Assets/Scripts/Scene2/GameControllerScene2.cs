using UnityEngine;

public class GameControllerScene2 : MonoBehaviour
{
    private float tiempoInicio;
    private bool nivelFinalizado = false;

    void Start()
    {
        tiempoInicio = Time.time; 
    }

    public void MonedaRecogida()
    {
        if (nivelFinalizado) return; 

        float duracionEscena2 = Time.time - tiempoInicio;
        GameManager.Instance.AddTime(duracionEscena2);
        nivelFinalizado = true;

        Debug.Log($"Tiempo en Escena 2: {duracionEscena2:F2} segundos");
        Debug.Log($"Tiempo Total Jugado: {GameManager.Instance.TiempoTotal:F2} segundos");

    }
}