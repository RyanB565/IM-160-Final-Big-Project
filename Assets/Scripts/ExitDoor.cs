using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider collidingObject)
    {
        if (collidingObject.gameObject.name == "Player")
        {
            //Load the next scene from the build profile scene list
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}