using UnityEngine;

public class MonedaFinal : MonoBehaviour
{
    private GameControllerScene2 controlador;

    void Start()
    {
        controlador = FindObjectOfType<GameControllerScene2>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            controlador.MonedaRecogida();
            Destroy(gameObject); 
        }
    }
}
