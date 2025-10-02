using UnityEngine;
using System.Collections.Generic;

public class CollectibleItem : MonoBehaviour
{
    private static int score = 0;
    private static List<string> inventario = new List<string>();

    [Header("Config del Ítem")]
    public string tipoItem;
    public int valor = 1;

    [Header("UI")]
    public GameObject panelResultados; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            score += valor;
            inventario.Add(tipoItem);

            Debug.Log("Has recogido: " + tipoItem + " (+" + valor + ")");
            Debug.Log("Score total: " + score);
            Debug.Log("Inventario: " + string.Join(", ", inventario));

            if (gameObject.CompareTag("Moneda") && panelResultados != null)
            {
                panelResultados.SetActive(true);
                Debug.Log("✅ Panel de resultados abierto");
            }

            Destroy(gameObject);
        }
    }
}

