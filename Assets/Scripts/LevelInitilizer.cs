using UnityEngine;

public class LevelInitilizer : MonoBehaviour
{
    public int levelNumber = 2;

    void Start()
    {
        LevelManager.currentLevel = levelNumber;
    }
}
