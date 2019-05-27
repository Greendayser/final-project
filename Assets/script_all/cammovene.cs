using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammovene : MonoBehaviour
{

    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(character.transform.position.x, -999f, 240f), Mathf.Clamp(character.transform.position.y, -500f, 300f), transform.position.z);
    }
}
