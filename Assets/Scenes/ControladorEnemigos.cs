using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControladorEnemigos : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform []puntos;
    [SerializeField] private GameObject [] enemigo;
    [SerializeField] private float Tiempoenemi;
    private float tiemposiguiente;

    // Start is called before the first frame update
    void Start()
    {
        maxX = puntos.Max(puntos => puntos.position.x);
        minX = puntos.Min(puntos => puntos.position.x);
        maxY = puntos.Max(puntos => puntos.position.y);
        minY = puntos.Min(puntos => puntos.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        tiemposiguiente += Time.deltaTime;
        if(tiemposiguiente >= Tiempoenemi)
        {
            tiemposiguiente = 0;
            CrearEnemi();
        }
    }

    private void CrearEnemi()
    {
        int numEnem = Random.Range(0, enemigo.Length);
        Vector2 posicion = new Vector2 (Random.Range(minX,maxX), Random.Range(minY,maxY));
        Instantiate(enemigo[numEnem], posicion, Quaternion.identity);
    }

}
