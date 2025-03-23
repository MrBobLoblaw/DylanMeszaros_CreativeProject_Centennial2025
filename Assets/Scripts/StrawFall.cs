using UnityEngine;

public class StrawFall : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 2.2f + Mathf.Abs(player.transform.position.z - transform.position.z), transform.position.z);
    }


}
