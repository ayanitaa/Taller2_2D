using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoaderScenes : MonoBehaviour
{
    [Header("Menú UI")]
    public GameObject menuPanel;
    public Button ButtonIniciar;
    public Button ButtonInstrucciones;
    public Button ButtonSalir;
    public Button ButtonRegresar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IniciarJuego()
    {
        SceneManager.LoadScene("Scene1", LoadSceneMode.Additive);
        menuPanel.SetActive(false);

    }

    public void MostrarInstrucciones()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("InstructionsScene");
    }

    public void RegresarMenu()
        {
        SceneManager.LoadScene("Menu");
        }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
