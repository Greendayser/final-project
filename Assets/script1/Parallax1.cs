using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax1 : MonoBehaviour
{
    private float[] parallaxScales; //les proportions du mouvement de la caméra 
    public float smoothing = 1f;

    private Transform cam;     // correspond a la main caméra 
    private Vector3 Previous_Cam_Pos;   //position précédente de la caméra
    public Transform[] backgrounds;
    void Awake() //appelé avant la fonction start
    {
        //initialiser la caméra de référence
        cam = Camera.main.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        int blg = backgrounds.Length;
        Previous_Cam_Pos = cam.position;
        parallaxScales = new float[blg];

        for (int i = 0; i < blg; i++)  // assigner le parallax correspondant 
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int blg = backgrounds.Length;
        for (int i = 0; i < blg; i++)
        {
            // le parallax a un mouvement opposé a la caméra
            float parallax = (Previous_Cam_Pos.x - cam.position.x) * parallaxScales[i];

            // creer une cible en x qui sera la position actuelle + position parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // creer la position la la cible en x y z
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // swicht entre la position actuelle et la position de la cible
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        //switch de la position de la caméra (l'avant dernière) a la position finale de l'image
        Previous_Cam_Pos = cam.position;

    }


}
