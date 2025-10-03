using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Configuración Inicial")]
    [SerializeField] private int vidasIniciales = 3;

    [Header("Valores por Tipo de Ítem")]
    [SerializeField] private int valorGema = 3;
    [SerializeField] private int valorPergamino = 1;
    [SerializeField] private int valorPocion = 2;
    [SerializeField] private int valorEnemigo = 5;

    [Header("Puntaje Total")]
    [SerializeField] private int scoreTotal = 0;

    [Header("Vidas")]
    public int remainingLives;

    private float tiempoTotal = 0f;

    private List<CapturaItem> itemsCapturados = new List<CapturaItem>();

    public enum ItemType
    {
        Gema,
        Pergamino,
        Pocion,
        Enemigo,
        MonedaFinal
    }

    public class CapturaItem
    {
        public ItemType tipo;
        public float tiempoCaptura;

        public CapturaItem(ItemType tipo, float tiempo)
        {
            this.tipo = tipo;
            this.tiempoCaptura = tiempo;
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        remainingLives = vidasIniciales;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void AutoCrearGameManager()
    {
        if (Instance == null)
        {
            GameObject gm = new GameObject("GameManager");
            gm.AddComponent<GameManager>();
        }
    }

    public void SumarItem(ItemType item)
    {
        int valor = ObtenerValorItem(item);
        scoreTotal += valor;

        itemsCapturados.Add(new CapturaItem(item, tiempoTotal));

        Debug.Log($"Recolectado: {item} | Total: {ContarPorTipo(item)} | Puntuación: {scoreTotal}");
    }

    private int ObtenerValorItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.Gema: return valorGema;
            case ItemType.Pergamino: return valorPergamino;
            case ItemType.Pocion: return valorPocion;
            case ItemType.Enemigo: return valorEnemigo;
            case ItemType.MonedaFinal: return 0;
            default: return 0;
        }
    }

    public void LoseLife()
    {
        remainingLives = Mathf.Max(remainingLives - 1, 0);
        Debug.Log($"¡Vida perdida! Vidas restantes: {remainingLives}");
    }

    public void AddTime(float tiempo)
    {
        tiempoTotal += tiempo;
    }

    public float TiempoTotal => tiempoTotal;
    public int ScoreTotal => scoreTotal;

    public int ContarPorTipo(ItemType tipo)
    {
        return itemsCapturados.FindAll(i => i.tipo == tipo).Count;
    }

    public List<CapturaItem> GetTodosLosItems()
    {
        return itemsCapturados;
    }
}