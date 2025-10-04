using UnityEngine;
using TMPro;

public class ResultadosUI : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject filaPrefab;
    public Transform contenedor;

    [Header("Resumen General")]
    public TextMeshProUGUI textoTiempoTotal;
    public TextMeshProUGUI textoScore;
    public TextMeshProUGUI textoGemas;
    public TextMeshProUGUI textoPergaminos;
    public TextMeshProUGUI textoPociones;
    public TextMeshProUGUI textoEnemigos;

    void OnEnable()
    {
        MostrarResultados();
    }

    public void MostrarResultados()
    {
        foreach (Transform child in contenedor)
        {
            Destroy(child.gameObject);
        }

        var lista = GameManager.Instance.GetTodosLosItems();

        if (lista == null || lista.Count == 0)
        {
            Debug.Log("? No hay items capturados para mostrar en el panelResultados.");
            return;
        }

        foreach (var cap in lista)
        {
            GameObject fila = Instantiate(filaPrefab, contenedor);
            TextMeshProUGUI[] textos = fila.GetComponentsInChildren<TextMeshProUGUI>();

            if (textos.Length >= 2)
            {
                textos[0].text = cap.tipo.ToString();

                int minutos = Mathf.FloorToInt(cap.tiempoCaptura / 60f);
                int segundos = Mathf.FloorToInt(cap.tiempoCaptura % 60f);
                int milisegundos = Mathf.FloorToInt((cap.tiempoCaptura * 100f) % 100f);

                textos[1].text = $"Tiempo: {minutos:00}:{segundos:00}:{milisegundos:00}";
            }
        }

        float tiempo = GameManager.Instance.TiempoTotal;
        int min = Mathf.FloorToInt(tiempo / 60f);
        int seg = Mathf.FloorToInt(tiempo % 60f);
        int ms = Mathf.FloorToInt((tiempo * 100f) % 100f);

        textoTiempoTotal.text = $" Tiempo total de juego: {min:00}:{seg:00}:{ms:00}";
        textoGemas.text = $"Gemas totales: {GameManager.Instance.ContarPorTipo(GameManager.ItemType.Gema)}";
        textoPergaminos.text = $"Pergaminos totales: {GameManager.Instance.ContarPorTipo(GameManager.ItemType.Pergamino)}";
        textoPociones.text = $"Pociones totales: {GameManager.Instance.ContarPorTipo(GameManager.ItemType.Pocion)}";
        textoScore.text = $"Puntuación por recolectar items: {GameManager.Instance.ScoreTotal}";
        textoEnemigos.text = $"Puntuación por eliminar enemigos: {GameManager.Instance.remainingLives}";
    }
}
