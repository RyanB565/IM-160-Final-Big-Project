using UnityEngine;

public class MovePoints : MonoBehaviour
{

    [SerializeField] private GameObject[] movePoints;
    [SerializeField] private float speed;
    private int currentIndex;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = 0;
    }

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

        transform.position = Vector3.MoveTowards(transform.position, movePoints[currentIndex].transform.position,
            speed * Time.deltaTime);
    }
}
