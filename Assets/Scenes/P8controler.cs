using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class P8controler : MonoBehaviour
{

    public float Velocidad = 3;
    public int Monedas = 0;
    public int Puntos = 0;
    public int MasVidas = 0;
    public int Pocion = 0;
    public int Vidas = 5;
    int precioPocion = 1;
    public int DañoDeBala = 1;
    public float VelocidadBala = 1000f;
    Rigidbody2D Player_rb;
    Transform Player_Tr;
    Animator Player_anim;
    public GameObject Bala;
    public GameObject Enemigo;
    public int EnemigoBala = 10;
    public int DireccionBala = 1;
    private float staggerTime = 0;
    public float staggerTimeDelta;


    // Start is called before the first frame update
    void Start()
    {
        Player_rb = GetComponent<Rigidbody2D>();
        Player_Tr = GetComponent<Transform>();
        Player_anim = GetComponent<Animator>();

        Text SumarVidas = GameObject.FindWithTag("Vidas").GetComponent<Text>();
        SumarVidas.text = Vidas + "";

        //int VidaEnemigo = Enemigo.GetComponent<EnemigoControl>().VidasEnemigo;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Player_rb.velocity = new Vector2(Velocidad, Player_rb.velocity.y);
            Player_Tr.rotation = new Quaternion(0, 0, 0, 0);
            Player_anim.SetBool("Caminar", true);
            DireccionBala = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Player_rb.velocity = new Vector2(-Velocidad, Player_rb.velocity.y);
            Player_Tr.rotation = new Quaternion(0, 180f, 0, 0);
            Player_anim.SetBool("Caminar", true);
            DireccionBala = 2;
        }
        else
        {
            Player_anim.SetBool("Caminar", false);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Curar();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            GameObject Obj_bala = Instantiate(Bala, new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
            Obj_bala.GetComponent<Rigidbody2D>().velocity = new Vector2(VelocidadBala * Time.deltaTime, 0f);


            if (DireccionBala == 1)
            {
                Obj_bala.GetComponent<Rigidbody2D>().velocity = new Vector2(VelocidadBala * Time.deltaTime, 0f);
            }
            else
            {
                Obj_bala.GetComponent<Rigidbody2D>().velocity = new Vector2(-VelocidadBala * Time.deltaTime, 0f);
            }

            Destroy(Obj_bala, 5f);
        }


    }

    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Moneda")
        {
            Monedas = Monedas + 5;
            Destroy(collision.gameObject);
            RefreshUI();

        }

        else if (collision.gameObject.tag == "MasVidas")
        {
            Vidas++;
            Destroy(collision.gameObject);
            Text SumarVidas = GameObject.FindWithTag("Vidas").GetComponent<Text>();
            SumarVidas.text = Vidas + "";
        }

        else if (collision.gameObject.tag == "Pocion")
        {
            Pocion++;
            Destroy(collision.gameObject);
            Pocionn();
        }

        //int VidaEnemigoo = Enemigo.GetComponent<EnemigoMovimiento>().VidasEnemigo;
        
        if (collision.tag == "bala")
        {
            EnemigoBala++;
            
            print(EnemigoBala);

            if (EnemigoBala == 10)
            {
                Monedas = Monedas + 10;
                RefreshUI();

                Puntos = Puntos + 100;
                RefreshUIPuntos();


                print(" MUERTO :P ");
            }

            if (EnemigoBala > 10)
            {
                EnemigoBala = 0;
            }
        }

    }



    public void RefreshUI()
    {
        Text SumarMonedas = GameObject.FindWithTag("SumarMonedas").GetComponent<Text>();
        SumarMonedas.text = Monedas + "";
    }

    public void RefreshUIPuntos()
    {
        Text MasPUNTOS = GameObject.FindWithTag("PuntosDelJuego").GetComponent<Text>();
        MasPUNTOS.text = Puntos + "";
    }

    public void Pocionn()
    {
        Text SumarPocion = GameObject.FindWithTag("MasPociones").GetComponent<Text>();
        SumarPocion.text = Pocion + "";
    }

    public void Curar()
    {
        if (Pocion >= precioPocion)
        {
            Pocion -= precioPocion;

            Text SumarPocion = GameObject.FindWithTag("MasPociones").GetComponent<Text>();
            SumarPocion.text = Pocion + "";

            Vidas++;
            Text SumarVidas = GameObject.FindWithTag("Vidas").GetComponent<Text>();
            SumarVidas.text = Vidas + "";
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo" && staggerTime < Time.realtimeSinceStartup)
        {
            Vidas--;
            Text SumarVidas = GameObject.FindWithTag("Vidas").GetComponent<Text>();
            SumarVidas.text = Vidas + "";

            if (Vidas <= 0)
            {
                Player_anim.SetFloat("Morir", 2);
                Text HasmuertoColor = GameObject.FindWithTag("HasMuerto").GetComponent<Text>();
                Color colorOpa = HasmuertoColor.color;
                colorOpa.a = 1;
                HasmuertoColor.color = colorOpa;
                //Destroy(GameObject.FindWithTag("Player"), 3f);
            }

            staggerTime = Time.realtimeSinceStartup + staggerTimeDelta;
            print(staggerTime + "    " + Time.realtimeSinceStartup);
        }

        

    }


}
