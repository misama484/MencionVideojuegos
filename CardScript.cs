using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        //averiguamos posicion del GO
        Vector3 pos = transform.position;
        //Creamos nueva posicion
        Vector3 newPos = new Vector3(-1.79f, 2.44f, 0f);
        //asignamos nueva posicion
        transform.position = newPos;
        //ROTACIONES
        //aplicamos constructor creando un nuevo vector3,
        //le pasamos los grados que deseamos que rote en el eje que queramos y        
        //aplicamos la rotacion
        Debug.Log("La posicion de la carta es " + pos);
        */

        //Ejercicio1

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 15) * Time.deltaTime);
    }
}
