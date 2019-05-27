using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammouv2 : MonoBehaviour
{

    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(character.transform.position.x, -13f, 13.7f), Mathf.Clamp(character.transform.position.y, 2f, 11f), transform.position.z);
    }
}
