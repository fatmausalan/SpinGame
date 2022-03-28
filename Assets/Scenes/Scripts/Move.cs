using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rightLeftSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal")*rightLeftSpeed*Time.deltaTime;
        this.transform.Translate(horizontalAxis, 0, speed*Time.deltaTime);
    }
}
