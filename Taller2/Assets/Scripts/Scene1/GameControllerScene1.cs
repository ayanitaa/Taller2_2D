using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScene1 : MonoBehaviour
{
    private float tiempoInicio;

    void Start()
    {
        tiempoInicio = Time.time;
    }

    public void TocarBandera()
    {
        Object.FindFirstObjectByType<Timer>()?.DetenerTiempo();

        float duracionEscena1 = Time.time - tiempoInicio;

        Debug.Log($"Tiempo en Escena 1: {duracionEscena1:F2} segundos");

        SceneManager.LoadScene("Scene2");
    }
}