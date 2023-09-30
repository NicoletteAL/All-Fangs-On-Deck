using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform left;

    public Transform right;

    public float moveTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        backAndFourth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void backAndFourth() {
        
        StartCoroutine(backAndFourthRoutine());
        IEnumerator backAndFourthRoutine(){
            float t = 0;

            while(t<moveTime){
                yield return null;
                t+=Time.deltaTime;
                transform.position = Vector3.Lerp(left.transform.position,right.transform.position,t/moveTime);
            }

            yield return new WaitForSeconds(1);
            t = 0;

            while(t<moveTime){
                yield return null;
                t+=Time.deltaTime;
                transform.position = Vector3.Lerp(right.transform.position,left.transform.position,t/moveTime);
            }

            yield return null;
        }
    }
}
