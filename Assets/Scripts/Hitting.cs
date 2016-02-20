using UnityEngine;
using System.Collections;

public class Hitting : MonoBehaviour
{
    public GameObject MonsterCount;
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
        GameObject otherObject = other.gameObject;
        if (other.tag == "Monster")
        {
            MonsterCount.GetComponent<SpawningScript>().MonsterCount--;
            Destroy(otherObject);
        }
    }
}
