using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonPausa : MonoBehaviour
{
    [SerializeField] private GameObject Botonpausa;
    [SerializeField] private GameObject Menupausa;

    public  void Pausa()
    {
        Time.timeScale = 0f;
        Botonpausa.SetActive(false);
        Menupausa.SetActive(true);
    }

    public void SeguiJugando()
    {
        Time.timeScale = 1f;
        Botonpausa.SetActive(true);
        Menupausa.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Salir()
    {
        Debug.Log("Cerrar juego");
        Application.Quit();
    }
}
