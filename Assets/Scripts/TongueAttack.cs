using UnityEngine;
using System.Collections;


public class TongueAttack : MonoBehaviour {

    float AttSpeed = 3;
    public GameObject Tongue;
    public GameObject Parent;
    public GameObject player;
    public GameObject AttRadius;
    public GameObject Pause;
    
    bool attack = false;
    bool AttSequEnd = false;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Pause.GetComponent<Pause>().PauseOn == false)
        {
            Vector3 PreviousT = Tongue.transform.position;
            if (Tongue.transform.localPosition.z <= 0)
            {
                attack = AttRadius.GetComponent<EnemyInRange>().PiR;
                AttSequEnd = false;
            }
            if ((attack == true && Tongue.transform.localPosition.z < .75f) && AttSequEnd == false)
            {
                Tongue.transform.position = new Vector3
                    (PreviousT.x + ((Parent.transform.forward.x * AttSpeed) * Time.deltaTime),
                    PreviousT.y, PreviousT.z + ((Parent.transform.forward.z * AttSpeed) * Time.deltaTime));
            }
            PreviousT = Tongue.transform.position;
            if (Tongue.transform.localPosition.z >= .75f)
            {
                AttSequEnd = true;
                attack = false;
            }
            if ((attack == false && Tongue.transform.localPosition.z > 0) && AttSequEnd == true)
            {
                Tongue.transform.position = new Vector3
                    (PreviousT.x - ((Parent.transform.forward.x * AttSpeed) * Time.deltaTime),
                    PreviousT.y, PreviousT.z - ((Parent.transform.forward.z * AttSpeed) * Time.deltaTime));
            }
            PreviousT = Tongue.transform.position;
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if (Pause.GetComponent<Pause>().PauseOn == false)
        {
            if (other.tag == "Player")
                player.GetComponent<PlayerController>().health -= 10;
        }
    }
}
