using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountWithText : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountEverySecond());
    }
    int counter = 0;
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountEverySecond(){
        while(true){
            yield return new WaitForSeconds(1);
            counter+=1;
            text.text = counter.ToString();
        }
    }
}
