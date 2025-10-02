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

    [Header("Conteo de Ítems")]
    private Dictionary<ItemType, int> itemCounts = new Dictionary<ItemType, int>();

    [Header("Vidas")]
    public int remainingLives;

    private float tiempoTotal = 0f;

    public enum ItemType
    {
        Gema,
        Pergamino,
        Pocion,
        Enemigo
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

        foreach (ItemType tipo in System.Enum.GetValues(typeof(ItemType)))
        {
            itemCounts[tipo] = 0;
        }
    }

    public void SumarItem(ItemType item)
    {
        int valor = ObtenerValorItem(item);
        scoreTotal += valor;
        itemCounts[item]++;
        Debug.Log($"Recolectado: {item} | Total: {itemCounts[item]} | Puntuación: {scoreTotal}");
    }

    private int ObtenerValorItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.Gema: return valorGema;
            case ItemType.Pergamino: return valorPergamino;
            case ItemType.Pocion: return valorPocion;
            case ItemType.Enemigo: return valorEnemigo;
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

    public int GetItemCount(ItemType item)
    {
        return itemCounts.ContainsKey(item) ? itemCounts[item] : 0;
    }
}