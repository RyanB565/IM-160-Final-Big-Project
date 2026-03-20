
using UnityEditor;
using UnityEngine;

public class End : MonoBehaviour
{
    public void QuitGame()
    {
# if UNITY_EDITOR
        // exit in editor 
        EditorApplication.isPlaying = false;

#else
        // quits the build 
        Application.Quit();
#endif
    }
}