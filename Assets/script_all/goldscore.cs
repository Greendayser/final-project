using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goldscore : MonoBehaviour
{
    
    private int coins = 5;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (coins == 0)
        {
            SceneManager.LoadScene("Map");
        }
        
    }

    private void OnGUI()
    {
        GUI.color = Color.yellow;
        GUI.Label(new Rect(10, 5, 300, 50),"Gold left : "+ coins );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "gold")
        {
            coins -= 1;         
        }
    }
}
