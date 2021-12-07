using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript2 : MonoBehaviour
{
    //declaramos imagen
    public Sprite imagen;
    // Start is called before the first frame update
    void Start()
    {
        //recuperamos el componente SpriteRenderer
        GetComponent<SpriteRenderer>().sprite = imagen;

        transform.position = new Vector3(-1, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
