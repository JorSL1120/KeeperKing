using UnityEngine;

public class Gloves : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float range;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }
    
    void Update()
    {
        MoveGlaves();
    }

    private void MoveGlaves()
    {
        float yPos = Mathf.PingPong(Time.time * speed, range);
        transform.position = new Vector3(startPosition.x, startPosition.y + yPos, startPosition.z);
    }
}
