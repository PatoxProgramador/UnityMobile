using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject Item;

    public float horizontalx_limit,horizontalz_limit;

    void Start()
    {

        StartCoroutine(ItemCreator(1.0f));

    }

    void Update()
    {
        
    }
    //criando items em posicoes aleatorias
    IEnumerator ItemCreator(float i)
    {

        GameObject thisItem = Instantiate(Item);

        Vector3 j = new Vector3(Random.Range(-horizontalx_limit, horizontalx_limit),3, Random.Range(-horizontalz_limit, horizontalz_limit));

        thisItem.transform.position = j;

        Destroy(thisItem, 3f);

        yield return new WaitForSeconds(i);

        StartCoroutine(ItemCreator(1.0f));

    }

}
