using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance{ get; private set; }

    public Transform Player;
    public float VelocidadEnemigo = 1f;
    public float Distancia;


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
