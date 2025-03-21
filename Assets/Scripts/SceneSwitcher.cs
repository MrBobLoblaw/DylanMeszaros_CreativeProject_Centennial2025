using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private string sceneToLoad; // Assign scene name in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndSpot")) // Ensure the colliding object is the player
        {
            SceneManager.LoadScene(sceneToLoad);
            Debug.Log("[EVENT][SWITCHING LEVEL TO<" + sceneToLoad + ">]");
        }
    }
}
