using UnityEngine;

public class GameControllerScene2 : MonoBehaviour
{
    private bool nivelFinalizado = false;

    void Start()
    {
        Object.FindFirstObjectByType<Timer>()?.ReiniciarVisual();
    }

    public void MonedaRecogida()
    {
        if (nivelFinalizado) return;

        float duracionEscena2 = Time.timeSinceLevelLoad;

        nivelFinalizado = true;

        Debug.Log($"Tiempo en Escena 2: {duracionEscena2:F2} segundos");
        Debug.Log($"Tiempo Total Jugado: {GameManager.Instance.TiempoTotal:F2} segundos");
    }
}