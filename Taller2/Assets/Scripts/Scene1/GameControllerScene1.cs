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
        float duracionEscena1 = Time.time - tiempoInicio;
        GameManager.Instance.AddTime(duracionEscena1);
        Debug.Log($"Tiempo en Escena 1: {duracionEscena1:F2} segundos");

        Object.FindFirstObjectByType<Timer>()?.DetenerTiempo();

        SceneManager.LoadScene("Scene2"); 
    }
}
