using TMPro;
using UnityEngine;

public class DraggingItems : MonoBehaviour
{
    public string itemName;
    public bool isDragging;

    public bool isDraggable = true;

    public AudioClip nameItemFX;

    private Collider2D coll;
    private DragController dragController;

    public Canvas nameCanvas;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        dragController = FindObjectOfType<DragController>();

        DisplayItemName();
        Invoke("HideItemName", 1.5f);
    }

    public void DisplayItemName()
    {
        nameCanvas.gameObject.SetActive(true);
        TextMeshProUGUI itemNameText = nameCanvas.GetComponentInChildren<TextMeshProUGUI>();
        itemNameText.text = itemName;
    }

    public void HideItemName()
    {
        nameCanvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Item")
        {
            ColliderDistance2D colliderDistance2D = other.Distance(coll);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff/2;
        }
    }
}
