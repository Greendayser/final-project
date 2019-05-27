using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammouv3 : MonoBehaviour
{

    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(character.transform.position.x, -9f, 135f), Mathf.Clamp(character.transform.position.y, 0.2f, 0.3f), transform.position.z);
    }
}
