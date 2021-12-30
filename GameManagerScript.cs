using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    //Declaramos un GO donde asignaremos el prefab(en unity)
    public GameObject myPrefab;
    //Ej9, creamos un contador de parejas con un GO-UI text desde Unity
    //IMPORTANTE asignar el contCartas a GameManagerScrip en unity, arrastrar ContCartas a la variable text creada en GameManager
    //creamos un objeto GO para manejar el GameObject creado en Unity
    public GameObject contCartas;
    //contador de parejas encontradas
    public int contParejas = 0;
    //EJ2 creamos la lista que almacenara las cartas
    List<GameObject> cards = new List<GameObject>();

    //EJ5 lista que contendra el frontal de las cartas(imagenes)
    //la lista tiene 10 imagenes, 5 imagenes 2 veces, para asi salgan 2 de cada.
    public List<Sprite> imagenesFrente;
    //contendra el nuemro aleatorio
    private int valor;
    //EJ5 Este array contiene los nombre de las cartas, coinciden con la posicion de cada una de ellas en la lista de gamemanager
    // en la lista de imagenes de unity tenemos las 5 cartas 2 veces en orden, por lo que repetimos los nombres
    //string[] tipo = { "Bruja", "Guarda", "Asesino", "Ovispo", "Contable", "Bruja", "Guarda", "Asesino", "Ovispo", "Contable" };
    //tipo con el numero de las cartas
    int[] tipo = { 7, 1, 0, 9 ,6 };
    int[] contador = { 0, 0, 0, 0, 0, };
    //variable estado, definira en que estado esta la carta (Ej6)
    int state = 1;
    int cartaArriba;
    int cartaIndex;



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
            //anyadeImagen(nuevaCarta);
            nuevaCarta.name = "card" + i;

            bool encontrado = false;
            int pos = 0;

            while (!encontrado)
            {
                pos = Random.Range(0, 5);
                if(contador [pos] < 2)
                {
                    contador [pos] +=1;
                    encontrado = true;
                }
            }

            //una vez creada la carta, le asignamos la imagen, el tipo y el indice, para poder tratarlo despues
            //el indice coincide con la creacion de cartas en el bucle
            nuevaCarta.GetComponent<CardScript>().frontal = imagenesFrente[pos];
            nuevaCarta.GetComponent <CardScript>().tipo = tipo[pos];
            nuevaCarta.GetComponent<CardScript>().index = i;
            
            cards.Add(nuevaCarta);

            posX += 3;
            if (i == 4)
            {
                posX = -8;
                posY = -2;
            }
        }

        //NOTAS Ej7
        //con setActive(true/false), activamos o no el gameObject, para que desaparezca del juego, pero no se elimina
        //con findObjectsWithTag, no lo encontrara
        //cards[1].SetActive(false);

        //con destroy, eliminamos por completo el GO, habra que crearlo de nuevo con el prefab.
        //Destroy(cards[1]);

        //anyadir libreria UnityEngine.UI, cuando salga error, pusar en la bombilla
        contCartas.GetComponent<Text>().text = "Numero de parejas: " + contParejas;


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

    public void clickOnCard(int tipo, int index)
    {
        Debug.Log("clickOnCard " + tipo + "indice " + index);

        if(state == 1)
        {
            cartaArriba = tipo;
            state = 2;
            cartaIndex = index;
        }
        else //state = 2
        {
            if(tipo == cartaArriba)
            {
                Debug.Log("Ha salido pareja");
                //Ej7
                //si sale pareja, desactivamos las cartas para que desaparezcan
                //con cartaindex, seleccionamos tambien la primera carta de la pareja, para desactivarla
                //Ej9
                //sumamos 1 a contParejas y accedemos al GO para mostrar el texto
                contParejas++;
                contCartas.GetComponent<Text>().text = "Numero de parejas: " + contParejas;
                cards[index].SetActive(false);
                cards[cartaIndex].SetActive(false);
                
            }
            else
            {
                Debug.Log("NO ha salido pareja");
                //como index es una variable de cardScript, no es accesible desde la corrutina
                //pasamos el index desde aqui como parametro
                StartCoroutine(EsperaAVoltear(index));
                //Ej7
                //si no hay pareja, llamamoms a la funcion voltea, para que voltee las cartas
                //cards[index].GetComponent<CardScript>().Voltea();
                //cards[cartaIndex].GetComponent<CardScript>().Voltea();
            }
            state = 1;
        }
    }

    //Ej8, Corrutina, ejecuta el codigo "en paralelo a la ejecucion principal.
    //ponemos un yield waitForSeconds, para que espere 2 segundos antes de volver a la posicion
    //inicial de las cartas. EL CODIGO PRINCIPAL SIGUE SU CURSO SIN ESPERAR.
    IEnumerator EsperaAVoltear(int index) //recibe index como parametro, para pasarlo desde la ejecucion principal                                           
    {
        yield return new WaitForSeconds(2);
        cards[index].GetComponent<CardScript>().Voltea();
        cards[cartaIndex].GetComponent<CardScript>().Voltea();
    }

    
}
