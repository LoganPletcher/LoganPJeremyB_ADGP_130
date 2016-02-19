using UnityEngine;
using System.Collections;


public class TongueAttack : MonoBehaviour {

    float AttSpeed = 10000000;
    public GameObject Parent;
    public GameObject player;
    public GameObject AttRadius;
    
    bool attack = false;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 Previous = transform.position;
        attack = AttRadius.GetComponent<EnemyInRange>().PiR;
        if (attack == true && (Parent.transform.position.z - transform.position.z) < .75f)
            gameObject.transform.position = new Vector3
                (Previous.x - ((transform.forward.x * AttSpeed) * Time.deltaTime),
                Previous.y, Previous.z - ((transform.forward.y * AttSpeed) * Time.deltaTime));
        print(Previous.y);

	}
}
