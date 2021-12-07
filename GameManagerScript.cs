using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //Declaramos un GO donde asignaremos el prefab(en unity)
    public GameObject myPrefab;

    //EJ2 creamos la lista que almacenara las cartas
    List<GameObject> cards = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
