using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjetoTienda : MonoBehaviour, IPointerDownHandler
{
    public int precio = 1;
    int cantidad = 1;
    public GameObject ObjetoUsable;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        int MonedasDisponibles = Player.GetComponent<P8controler>().Monedas;
        int Pociones = Player.GetComponent<P8controler>().Pocion;

        if (MonedasDisponibles >= precio)
        {
            MonedasDisponibles -= precio;
            Pociones++;
            Player.GetComponent<P8controler>().Pocion = Pociones;
            Player.GetComponent<P8controler>().Monedas = MonedasDisponibles;
            Player.GetComponent<P8controler>().RefreshUI();
            Player.GetComponent<P8controler>().Pocionn();

            //GameObject PanelPlayer = GameObject.Find("PanelPlayer");

            /*for (int a = 0; a < 10; a++)
            {
                if (PanelPlayer.transform.GetChild(a).childCount < 1)
                {
                    GameObject Objetocomprado = Instantiate(ObjetoUsable, new Vector2(0, 0), transform.rotation);
                    Objetocomprado.transform.SetParent(PanelPlayer.transform.GetChild(a).gameObject.transform, false);
                    Player.GetComponent<P8controler>().RefreshUI();
                    break;
                }
            }*/
        }
    }
}
