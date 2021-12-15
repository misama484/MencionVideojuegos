using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //Declaramos un GO donde asignaremos el prefab(en unity)
    public GameObject myPrefab;

    //EJ2 creamos la lista que almacenara las cartas
    List<GameObject> cards = new List<GameObject>();

    //EJ5 lista que contendra el frontal de las cartas(imagenes)
    //la lista tiene 10 imagenes, 5 imagenes 2 veces, para asi salgan 2 de cada.
    public List<Sprite> imagenesFrente;
    //contendra el nuemro aleatorio
    private int valor;
    //EJ5 Este array contiene los nombre de las cartas, coinciden con la posicion de cada una de ellas en la lista de gamemanager
    // en la lista de imagenes de unity tenemos las 5 cartas 2 veces en orden, por lo que repetimos los nombres
    string[] tipo = { "Bruja", "Guarda", "Asesino", "Ovispo", "Contable", "Bruja", "Guarda", "Asesino", "Ovispo", "Contable" };



    /*void Start()
    {
        //instanciamos el prefab en tiempo de ejecucion en la posicion indicada
        //Instantiate(myPrefab, new Vector3(-8, 3, 0), Quaternion.identity);

        //EJERCICIO2
       
        //declaramos el bucle que creara los 5 primeros GO en la parte superior
        //indicamos en vector3 la posicion y le anyadimos i * 4 para que la mueva hacia la derecha
        for(int i=1; i<=5; i++)
        {
            GameObject card = Instantiate(myPrefab, new Vector3((-10 + i*4), 5, 0), Quaternion.identity);
            card.name = "carta" + i;
            
            cards.Add(card);
        }

        //este segundo for, crea los siguientes 5 GO en la parte inferior (modificamos vector Y)
        for (int i = 6; i <= 10; i++)
        {
            GameObject card = Instantiate(myPrefab, new Vector3((-10 + i * 4), -5, 0), Quaternion.identity);
            card.name = "carta" + i;
            
            cards.Add(card);
        }
        
        foreach(GameObject card in cards)
        {
            Debug.Log(card.name);
        }
        
    }
    */

    

    void Start()
    {
        float posX = -8;
        float posY = 3;

        GameObject nuevaCarta;

        for (int i = 0; i < 10; i++)
        {
            nuevaCarta = Instantiate(myPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
            //metodo que anyade la imagen aleatoria
            anyadeImagen(nuevaCarta);
            nuevaCarta.name = "card" + i;

            //para asignar la imagen de frente aleatoria, usamos la funcion RandomRange de unity(devuelve un int entre minValor y maxValor-1)
                //int valor = Random.Range(0, 5);
            //accedemos a la prop fontal del GO nuevaCarta y le asignamos la posicion valor de la lista de imagenes
                //nuevaCarta.GetComponent<CardScript>().frontal = imagenesFrente[valor];
            cards.Add(nuevaCarta);

            posX += 3;
            if (i == 4)
            {
                posX = -8;
                posY = -2;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void anyadeImagen(GameObject nuevaCarta)
    {
        //generamos un nuemero aleatorio entre 0 y la longitud de la lista
        valor = Random.Range(0, imagenesFrente.Count);
        //le asignamos la imagen perteneciente al valor de la lista
        nuevaCarta.GetComponent<CardScript>().frontal = imagenesFrente[valor];
        //EJ6 Asignamos el tipo de carta a la carta generada
        nuevaCarta.GetComponent<CardScript>().tipo = tipo[valor];
        //eliminamos el elemento de la lista para que no se repita
        imagenesFrente.RemoveAt(valor);
    }

    public void clickOnCard(string tipo)
    {
        Debug.Log("clickOnCard " + tipo);
    }
}
