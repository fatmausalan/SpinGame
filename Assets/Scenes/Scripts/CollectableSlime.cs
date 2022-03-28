using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSlime : MonoBehaviour
{
    bool isCollect;
    int index;
    public Collector collector;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isCollect == true){
            if(transform.parent != null){
                transform.localPosition = new Vector3(0,-index,0);
            }
        }
        
       
    }

    public bool GetIsCollect(){
        return isCollect;
    }

    public void SetCollect(){
        isCollect = true;
    }

    public void SetIndex(int index){
        this.index = index;
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Turtle"){
            collector.reduceHeight(1);
            transform.parent = null;
            GetComponent<SphereCollider>().enabled = false;
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
        
        }
        else if(other.gameObject.tag == "Dummy"){
            collector.reduceHeight(2);
            transform.parent = null;
            GetComponent<SphereCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        
        }
    }
}
