using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField]
    float duration = 5f;
    [SerializeField]
    public Transform startPoint, endPoint;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Mathf.PingPong(Time.time / duration, 1f);
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, speed);
    }
}
