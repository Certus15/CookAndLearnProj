using UnityEngine;



public class MiniGame : MonoBehaviour
{
    public SquareMover square;
    public float panelWidth;
    private Vector3 defaultSquarePos;
    public bool playerSucceeded = false;
    public GameObject greenZone;

    private void Start()
    {
        defaultSquarePos = square.transform.position;
    }

    public void CheckDoneCooking()
    {
        if (Vector3.Distance(square.transform.position, greenZone.transform.position) < 1f)
        {
            Debug.Log("Success!");
            playerSucceeded = true;
            gameObject.SetActive(false);
        }
        else
        {
            square.transform.position = defaultSquarePos;
        }
    }
}
