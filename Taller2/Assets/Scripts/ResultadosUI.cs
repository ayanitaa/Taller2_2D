using UnityEngine;
using TMPro;  // Necesario para TextMeshPro

public class ResultadosUI : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject filaPrefab;
    public Transform contenedor;  

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
                textos[1].text = "Tiempo: " + cap.tiempoCaptura.ToString("F2") + "s";
            }
        }
    }
}
