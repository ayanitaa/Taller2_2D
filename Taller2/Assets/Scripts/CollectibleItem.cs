using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [Header("Tipo de Item")]
    public GameManager.ItemType tipoItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.SumarItem(tipoItem);
            Destroy(gameObject);
        }
    }
}