using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int scoreTotal = 0;
    private int monedas = 0;
    private int pergaminos = 0;
    private int pociones = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SumarItem(string item, int valor)
    {
        scoreTotal += valor;

        if (item == "Moneda")
        {
            monedas++;
        }
        else if (item == "Pergamino")
        {
            pergaminos++;
        }
        else if (item == "Pocion")
        {
            pociones++;
        }

        Debug.Log($"Score: {scoreTotal} | Monedas: {monedas} | Pergaminos: {pergaminos} | Pociones: {pociones}");
    }

    public int ScoreTotal => scoreTotal;
    public int Monedas => monedas;
    public int Pergaminos => pergaminos;
    public int Pociones => pociones;
}