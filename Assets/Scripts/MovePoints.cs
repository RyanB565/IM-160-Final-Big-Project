using UnityEngine;
using UnityEngine.SceneManagement;
/*****************************************************************************
 // File Name      : Movepoints.cs
 // Author         : Ryan Blanco
 // Creation Date  : March 19, 2026
 //
 // Brief Description : move point so that an object can move between 2 of them 
 *****************************************************************************/
public class MovePoints : MonoBehaviour
{

    [SerializeField] private GameObject[] movePoints;
    [SerializeField] private float speed;
    private int currentIndex;

    /// <summary>
    /// Start
    /// </summary>
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = 0;
    }
    /// <summary>
    /// update
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        // checks distance between objects and movepoint
        if (Vector3.Distance(transform.position, movePoints[currentIndex].transform.position) < 0.1f)

        {

            currentIndex++;

            if (currentIndex >= movePoints.Length)
            {
                currentIndex = 0;
            }
        }
        // move towards waypoit at given speed
        transform.position = Vector3.MoveTowards(transform.position, movePoints[currentIndex].transform.position,
            speed * Time.deltaTime);
    }
}
