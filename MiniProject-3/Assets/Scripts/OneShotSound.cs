using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSound : MonoBehaviour
{
    [SerializeField]
  GameObject sourceAudio;
    void Start()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            sourceAudio.gameObject.SetActive(true);
            Destroy(gameObject, 7f);
        }
    }

}
