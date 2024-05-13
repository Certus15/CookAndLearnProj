using UnityEngine;

public class SquareMover : MonoBehaviour
{
    public float speed = 5.0f; // adjust the speed to your liking
    [SerializeField]
    private GameObject startPosition;
    [SerializeField]
    private GameObject endPosition;

    private bool movingForward = true;



    void Update()

    {

        // move the square

        if (movingForward)

        {

            transform.position = Vector3.MoveTowards(transform.position, endPosition.transform.position, speed * Time.deltaTime);

            if (transform.position == endPosition.transform.position)

            {

                movingForward = false;

            }

        }

        else

        {

            transform.position = Vector3.MoveTowards(transform.position, startPosition.transform.position, speed * Time.deltaTime);

            if (transform.position == startPosition.transform.position)

            {

                movingForward = true;

            }

        }

    }
}
