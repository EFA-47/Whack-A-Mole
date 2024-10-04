using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
         // destroy particle after 2 seconds
         StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
