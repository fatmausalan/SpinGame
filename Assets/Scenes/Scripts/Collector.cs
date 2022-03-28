using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject slime;
    int height;

    void Start()
    {
        slime = GameObject.Find("Slime");
    }

    // Update is called once per frame
    void Update()
    {
        slime.transform.position = new Vector3(transform.position.x, height, transform.position.z);
        this.transform.localPosition = new Vector3(0,-height,0);
    }

    private void OnTriggerEnter(Collider other) {
      if(other.gameObject.GetComponent<CollectableSlime>() == null){
        return;
      }
      if(other.gameObject.tag == "Collect" && other.gameObject.GetComponent<CollectableSlime>().GetIsCollect() == false){
        height += 1;
        other.gameObject.GetComponent<CollectableSlime>().SetCollect();
        other.gameObject.GetComponent<CollectableSlime>().SetIndex(height);
        other.gameObject.transform.parent = slime.transform;
      }  
    }

    public void reduceHeight(int h){
      height -= h;
      controlLive();
    }

    public void controlLive(){
      if(height < 0){
        SceneManager.LoadScene("MainMenu");
      }
    }
}
