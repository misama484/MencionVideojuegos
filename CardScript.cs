using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    //creo una variable del tipo SpriteRenderer para capturar el componente SpriteRenderer
    SpriteRenderer myRenderer;
    //declaro una variable donde asignare la imagen del frente de la carta (desde unity, con el boton open Prefab, arrastramos la imagen a la variable.
    public Sprite frontal;
    public Sprite trasera;
    public int tipo;
    //con este booleano controlaremos que la carta este bocaarriba o bocaabajo
    bool ladoCarta = false;
    //EJ5 definimos un GO myGameManager para acceder al GameManager(pondremos una tag en el GameManager en Unity para localizarlo mas abajo
    //GameObject myGameManager;
    GameManagerScript myGameManagerScript;
    //Ej7, creamos un indice que nos dira que carta es en el array para controlar las que volteamos
    public int index;

    private void Awake()//se puede hacer en este metodo, que se ejecuta cuando iniciamos el juego o en el metodo Start
    {
        //aqui asignamos el componente a la variable
        myRenderer = GetComponent<SpriteRenderer>();
        //myGameManager = GameObject.FindGameObjectWithTag("GameController"); //buscamos el GO con la etiqueta que le hemos puesto en Unity
        myGameManagerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
    }
    void Start()
    {

    }

    //metodo que controla el click del raton
    private void OnMouseDown()
    {

        //accedemos al metodo que esta en el GameManager(debe ser publico para poder acceder)
        //myGameManager.GetComponent<GameManagerScript>().clickOnCard(tipo);
        myGameManagerScript.clickOnCard(tipo, index);
        //para controlar que al hacer click, de la vuelta la carta
        Voltea();
        
    }

    public void Voltea() //funcion que da la voltea a las cartas
    {
        if (!ladoCarta) //si la carta NO esta bocaarriba
        {
            myRenderer.sprite = frontal; //mostramos el frente             
        }
        else //SI esta bocaarriba
        {
            myRenderer.sprite = trasera; //mostramos la trasera        
        }
        //cambiamos el valor del booleano
        ladoCarta = !ladoCarta;
    }

    // Update is called once per frame
    void Update()
    {

    }
}



 /*
  * esto va en el start
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