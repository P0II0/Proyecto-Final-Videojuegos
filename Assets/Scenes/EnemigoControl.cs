using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class EnemigoControl : MonoBehaviour
{

    public float VelocidadEnemigo = 1f;
    public int VidasEnemigo = 10;
    public int Puntos = 0;
    public int Daño = 1;
    public int muerto = 10;
    public Transform Player;
    GameObject Jugador;
    public float Distancia;
    Transform Enemigo_Tr;

    public int bajarvida = 1;
    public TMP_Text health;
    Animator Enemi_anim;

    // Start is called before the first frame update
    void Start()
    {
        Enemi_anim = GetComponent<Animator>();
        Enemigo_Tr = GetComponent<Transform>();
        Jugador = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == "bala")
        {
            Destroy(collision.gameObject);

            AumentarDaño();

        }

        

        if (VidasEnemigo <= 0)
        {
            //sumarPuntosyMonedas();

            Enemi_anim.SetFloat("Morir", 2);
            Destroy(GameObject.FindWithTag("Enemigo"), 0.5f);
            health.text = " ";

        }

        if (VidasEnemigo == 0)
        {
            sumarPuntosyMonedas();
        }


        if (collision.tag == "Player")
        {
            Enemi_anim.SetTrigger("pegarrr");

        }

    }

    


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Enemi_anim.SetTrigger("pegarrr");
        }
    }

    private void Girar()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        VelocidadEnemigo *= -1;
    }

    public void AumentarDaño()
    {
        int dañoo = Player.GetComponent<P8controler>().DañoDeBala;

        VidasEnemigo = VidasEnemigo - dañoo;
        health.text = VidasEnemigo + " ";
    }

    public void sumarPuntosyMonedas()
    {
        int MasMonedas = Player.GetComponent<P8controler>().Monedas;
        int MasPuntos = Player.GetComponent<P8controler>().Puntos;
        
        MasPuntos = MasPuntos + 100;
        Player.GetComponent<P8controler>().Puntos = MasPuntos;
        Player.GetComponent<P8controler>().RefreshUIPuntos();

        MasMonedas = MasMonedas + 10;
        Player.GetComponent<P8controler>().Monedas = MasMonedas;
        Player.GetComponent<P8controler>().RefreshUI();
            
        
        
    }

    public void MoverEnemigo()
    {

        Distancia = Player.position.x - transform.position.x;

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.position.x, Player.position.y), VelocidadEnemigo * Time.deltaTime);

        if (Distancia < 0)
        {
            //Girar
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Distancia > 0)
        {
            //Girar
            transform.localScale = new Vector3(-1, 1, 1);
        }


    }

}
