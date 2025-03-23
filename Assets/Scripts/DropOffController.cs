using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DropOffController : MonoBehaviour
{
    public GameObject wife;
    public List<GameObject> kids;
    public GameObject husband;
    public GameObject husbandHurt;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DropKids"))
        {
            foreach (GameObject kid in kids)
            {
                kid.SetActive(false);
            }
        } 
        else if (other.CompareTag("DropWife"))
        {
            wife.SetActive(false);
        } 
        else if (other.CompareTag("DropStraw"))
        {
            husband.SetActive(false);
            husbandHurt.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }


}
