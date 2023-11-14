using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class EnemigoMovimiento : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private float velocidad;
    [SerializeField] private float diatancia;
    [SerializeField] private LayerMask Suelo;
    public int VidasEnemigo = 10;
    //public Transform Player;
    Animator Enemi_anim;
    public TMP_Text health;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Enemi_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = new Vector2 (velocidad * transform.right.x, rb2D.velocity.y);
        RaycastHit2D infoSuelo = Physics2D.Raycast(transform.position, transform.right, diatancia, Suelo);
        

        if (infoSuelo)
        {
            Girar();
        }
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

        /*if (VidasEnemigo == 0)
        {
            sumarPuntosyMonedas();
        }*/


        if (collision.tag == "Player")
        {
            Enemi_anim.SetTrigger("pegarrr");

        }

    }


    private void Girar()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y +180, 0);
        //velocidad *= -1;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine (transform.position, transform.position + transform.right * diatancia);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Enemi_anim.SetTrigger("pegarrr");
        }
    }

    public void AumentarDaño()
    {
        
        VidasEnemigo--;
        health.text = VidasEnemigo + " ";

    }

    

    public void sumarPuntosyMonedas()
    {
        /*int MasMonedas = Player.GetComponent<P8controler>().Monedas;
        int MasPuntos = Player.GetComponent<P8controler>().Puntos;

        MasPuntos = MasPuntos + 100;
        Player.GetComponent<P8controler>().Puntos = MasPuntos;
        Player.GetComponent<P8controler>().RefreshUIPuntos();

        MasMonedas = MasMonedas + 10;
        Player.GetComponent<P8controler>().Monedas = MasMonedas;
        Player.GetComponent<P8controler>().RefreshUI();*/



    }

}
