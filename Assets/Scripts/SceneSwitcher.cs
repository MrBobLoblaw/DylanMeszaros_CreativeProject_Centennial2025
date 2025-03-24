using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private string sceneToLoad; // Assign scene name in Inspector

    public MessageManager messageManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndSpot")) // Ensure the colliding object is the player
        {
            //SceneManager.LoadScene(sceneToLoad);
            string sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == "StrawLevel1")
            {
                messageManager.ShowMessage("The sounds of rustling trash... ...and a truck on the move.", true, true, 5f);
            }
            else if (sceneName == "StrawLevel2")
            {
                messageManager.ShowMessage("The sound of a plop in the water... ...and echoing life from the deep.", true, true, 7f);
            }
            else if (sceneName == "TurtleLevel1")
            {
                messageManager.ShowMessage("The sound of scurying down the stairs... ...and the shut of a door.", true, true, 6f);
            }
            else if (sceneName == "TurtleLevel2")
            {
                messageManager.ShowMessage("...an upsettling end... ... A father unable to make it back to his children, unable to be there for his wife, unable to live a life for his loved ones... ...All because a straw was dumped into the ocean...", true, true, 20f);
            }
            Debug.Log("[EVENT][SWITCHING LEVEL TO<" + sceneToLoad + ">]");
        }
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
