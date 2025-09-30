using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Referencias de los textos en el PanelScore")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI monedasText;
    public TextMeshProUGUI pergaminosText;
    public TextMeshProUGUI pocionesText;

    private int totalPuntos = 0;
    private int totalMonedas = 0;
    private int totalPergaminos = 0;
    private int totalPociones = 0;

    void Start()
    {
        ActualizarUI();
    }

    public void SumarItem(string tipoItem, int valor)
    {
        if (tipoItem == "Moneda")
        {
            totalMonedas += 1;    
            totalPuntos += valor; 
        }
        else if (tipoItem == "Pergamino")
        {
            totalPergaminos += 1;
            totalPuntos += valor;
        }
        else if (tipoItem == "Pocion")
        {
            totalPociones += 1;
            totalPuntos += valor;
        }

        ActualizarUI();
    }

    private void ActualizarUI()
    {
        scoreText.text = "Puntos: " + totalPuntos;
        monedasText.text = "Monedas: " + totalMonedas;
        pergaminosText.text = "Pergaminos: " + totalPergaminos;
        pocionesText.text = "Pociones: " + totalPociones;
    }
}