using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public string tipoItem; // "Moneda", "Pergamino" o "Pocion"
    public int valor = 10;  // valor en puntos

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Busca el UIController en la escena
            UIController ui = FindObjectOfType<UIController>();
            if (ui != null)
            {
                ui.SumarItem(tipoItem, valor);
            }

            Destroy(gameObject);
        }
    }
}