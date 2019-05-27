using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammouv1 : MonoBehaviour
{

    public GameObject character;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(character.transform.position.x, -230f,250f),Mathf.Clamp(character.transform.position.y,9f,16f),transform.position.z);
    }
}
