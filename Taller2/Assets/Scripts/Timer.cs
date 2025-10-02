using UnityEngine;

public class ControladorTiempo : MonoBehaviour
{
    private float tiempoInicio;
    private bool tiempoFinalizado = false;

    void Start()
    {
        tiempoInicio = Time.time; 
    }

    /// <summary>
    /// Finaliza el conteo de tiempo y lo guarda en el GameManager.
    /// Solo se ejecuta una vez.
    /// </summary>
    public void FinalizarTiempo()
    {
        if (tiempoFinalizado) return;

        float duracion = Time.time - tiempoInicio;
        GameManager.Instance.AddTime(duracion);
        tiempoFinalizado = true;

        Debug.Log($"Tiempo de esta escena: {duracion:F2} segundos");
        Debug.Log($"Tiempo total acumulado: {GameManager.Instance.TiempoTotal:F2} segundos");
    }
}