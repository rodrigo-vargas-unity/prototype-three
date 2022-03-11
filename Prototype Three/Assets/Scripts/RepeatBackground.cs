using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeathWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeathWidth = GetComponent<BoxCollider>().size.x / 2; 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition.x - repeathWidth)
        {
            transform.position = startPosition;
        }        
    }
}
