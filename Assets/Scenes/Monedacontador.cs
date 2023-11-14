using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Monedacontador : MonoBehaviour
{
    public int monedas = 0;
    GameObject texto;

    // Start is called before the first frame update
    void Start()
    {
        texto = GameObject.Find("SumarMonedas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag  == "Moneda")
        {
            monedas++;
            texto.GetComponent<TextMeshProUGUI>().SetText(monedas + "");
        }
    }
}
