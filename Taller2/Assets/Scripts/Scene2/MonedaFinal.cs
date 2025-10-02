using UnityEngine;

public class MonedaFinal : MonoBehaviour
{
    private GameController2 controlador;

    void Start()
    {
        controlador = FindObjectOfType<GameController2>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            controlador.MonedaRecogida();
            Destroy(gameObject); // Opcional: eliminar la moneda
        }
    }
}
