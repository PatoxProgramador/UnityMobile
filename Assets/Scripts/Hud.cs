using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{

    public Text txt;
    public Text timer;

    public static int score;
    int i = 60;

    void Start()
    {

        score = 0;

        StartCoroutine(CountDown(1f));

    }
    
    void Update()
    {

            txt.text = score.ToString();

        if (i == 0 && score >= 10)
        {

            txt.text = "You Win";

        }
        else if(i == 0 && score < 10)
        {

            txt.text = "You Lose";

        }

    }

    IEnumerator CountDown(float f)
    {

        timer.text = i.ToString();

        yield return new WaitForSeconds(f);

        i--;

        if (i >= 0)
        {

            StartCoroutine(CountDown(f));

        }

    }

}
