using UnityEngine;
using System.Collections;

public class SkeletonScript : MonoBehaviour {

    public GameObject Player;

    public GameObject Pause;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3
            (Random.Range(-25.0f, 25.0f), .75f, Random.Range(-25.0f - 30, 25.0f - 30));
        Pause = GameObject.FindGameObjectWithTag("Pause");
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.GetComponent<Pause>().PauseOn == false)
        {
            Vector3 Previous = gameObject.transform.position;
            transform.LookAt(Player.transform);
            gameObject.transform.position = new Vector3
            (Previous.x + ((transform.forward.x * 1) * Time.deltaTime),
                    Previous.y, Previous.z + ((transform.forward.z * 1) * Time.deltaTime));
        }
    }
}
