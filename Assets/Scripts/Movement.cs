using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //velocidade de movimento
    public float movement;
    // distancia de salto
    public float salto;
    //posicoes no mapa
    float initialTouch_Y, finalTouch_Y;
    //implementacao de joystick
    public Joystick joystick;
 
    void Start()
    {

        

    }
    //para rever sempre so comandos ate o fim do jogo
    void Update()
    {

        Moving();
        Jumping();

    }
    //metodo separado para joystick
    void Moving()
    {
        //uso de joystick
        float mX = joystick.Horizontal * movement * Time.deltaTime;
        float mZ = joystick.Vertical * movement * Time.deltaTime;
        //joystick funcionando
        transform.Translate(mX, 0.0f, mZ);

    }
    //swipe
    void Jumping()
    {

        if (Input.touchCount > 0)
        {

            Touch fly = Input.GetTouch(0);

            if(fly.phase == TouchPhase.Began)
            {

                initialTouch_Y = fly.position.y;

            }
            else if (fly.phase == TouchPhase.Moved)
            {

                finalTouch_Y = fly.position.y;

            }
            else if (fly.phase == TouchPhase.Ended)
            {
                    
                    if (initialTouch_Y < finalTouch_Y)
                    {

                        StartCoroutine(Fall(0.3f));

                    }

            }

        }

    }
    //cai devolta
    IEnumerator Fall(float f)
    {

        float result = salto * Time.deltaTime;

        transform.Translate(0.0f, result , 0.0f);

        yield return new WaitForSeconds(f);

        transform.Translate(0.0f, -result, 0.0f);

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Item")
        {

            Hud.score++;

            Destroy(other.gameObject);

        }

    }

}
