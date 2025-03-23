using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DropOffController : MonoBehaviour
{
    public GameObject wife;
    public List<GameObject> kids;
    public GameObject husband;
    public GameObject husbandHurt;

    public MessageManager messageManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DropKids"))
        {
            foreach (GameObject kid in kids)
            {
                kid.SetActive(false);
            }

            messageManager.ShowMessage("[Father] See you later kids!  ...  [Kids] Bye!  ...  [Mother] Oh look at them go...", false, false, 7f);
        } 
        else if (other.CompareTag("DropWife"))
        {
            wife.SetActive(false);

            messageManager.ShowMessage("[Mother] See you later love.  ...  [Father] I'll be sure to pick up gran for dinner!  ...  [Mother] Splendid thankyou!", false, false, 10f);
        } 
        else if (other.CompareTag("DropStraw"))
        {
            husband.SetActive(false);
            husbandHurt.SetActive(true);
            other.gameObject.SetActive(false);

            messageManager.ShowMessage("[Father] WHAT IS THIS!?!?", false, false, 3f);
        }
    }


}
