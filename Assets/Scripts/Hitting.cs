using UnityEngine;
using System.Collections;

public class Hitting : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        //GameObject otherChild = other.gameObject;
        //GameObject otherParent = otherChild.transform.parent.gameObject;
        if (other.tag == "Monster")
            Destroy(gameObject);
    }
}
