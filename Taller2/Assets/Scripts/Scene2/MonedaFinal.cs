using UnityEngine;

public class MonedaFinal : MonoBehaviour
{
    public GameObject PanelResultados;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.Instance != null)
        {
            GameManager.Instance.AddTime(Time.deltaTime); 

            PanelResultados.SetActive(true);

            Time.timeScale = 0f;

            Destroy(gameObject);
        }
    }
}