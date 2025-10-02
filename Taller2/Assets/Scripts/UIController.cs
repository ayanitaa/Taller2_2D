using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Referencias de Texto TMP")]
    public TextMeshProUGUI textoGemas;
    public TextMeshProUGUI textoPergaminos;
    public TextMeshProUGUI textoPociones;
    public TextMeshProUGUI textoScore;
    //public TextMeshProUGUI textoVidas;

    void Update()
    {
        // Actualiza los textos cada frame con datos del GameManager
        textoGemas.text = $"Gemas: {GameManager.Instance.GetItemCount(GameManager.ItemType.Gema)}";
        textoPergaminos.text = $"Pergaminos: {GameManager.Instance.GetItemCount(GameManager.ItemType.Pergamino)}";
        textoPociones.text = $"Pociones: {GameManager.Instance.GetItemCount(GameManager.ItemType.Pocion)}";
        textoScore.text = $"Puntuación: {GameManager.Instance.ScoreTotal}";
        //textoVidas.text = $"Vidas: {GameManager.Instance.remainingLives}";
    }
}