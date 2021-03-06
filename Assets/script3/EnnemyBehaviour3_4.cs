﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnnemyBehaviour3_4 : MonoBehaviour
{
    public Animator anim;                                       // represente l'annimation de l'ennemi;
    public GameObject player;                                   // represente le joueur
    private float posPlayer;                                     // represente la position du joueur
    public Collider2D colPlayer;                                // represente le collider du joueur
    private float posEnnemy;                                     // represente la position de l'ennemi
    public Collider2D colEnnemy;                                // represente le collider de l'ennemi
    public Rigidbody2D rb;                                      // represente le rigidbody de l'ennemi
    private float area;                                          // zone definie pour l'ennemi
    private float range = 20f;                                         // zone de vision de l'ennemi
    private bool onGoing;                                        // vrai si l'ennemi effectue un aller dans son animation
    private bool mustReturn;                                     // vrai si l'ennemi doit retourner dans sa zone
    private bool isInRange;                                      // defini si l'ennemi est a bonne distance du joueur
    private float start;                                         // defini le point de depart de l'annimation de l'ennemi
    private float end;                                           // defini le point d'arrivée de l'annimation de l'ennemi
    public float vitesse;                                       // represente la vitesse de l'ennemi
    public float borneGauche;                                   // represente la borne gauche que l'ennemi ne depassera pas
    public float borneDroite;                                   // represente la borne droite que l'ennemi ne depassera pas
    private float posyE;
    private float posyP;


    // Start is called before the first frame update
    void Start()
    {
        posPlayer = player.transform.position.x;
        posEnnemy = transform.position.x;
        start = posEnnemy;

        colPlayer = player.GetComponent<Collider2D>();
        colEnnemy = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        onGoing = true;
        isInRange = false;
        mustReturn = false;
        area = 2f;
        end = posEnnemy + area;
    }

    // Update is called once per frame
    void Update()
    {
        posyP = player.transform.position.y;
        posyE = transform.position.y;
        posEnnemy = transform.position.x;
        posPlayer = player.transform.position.x;
        isInRange = abs(posPlayer - posEnnemy) < range && abs(posyE - posyP) < range;
        if ((posEnnemy > borneGauche) && (posEnnemy < borneDroite))
        {

            if(!mustReturn)
            {
                if(isInRange)
                {
                    vitesse = 4f;
                    anim.SetTrigger("Run");
                    Follow();
                }
                else
                {
                    vitesse = 3f;
                    if((posEnnemy < start) || (posEnnemy > end))
                    {
                        Return();
                    }
                    else
                    {
                        Walk();
                    }
                }
            }
            else
            {
                if((posEnnemy > start) && (posEnnemy < end))
                {
                    mustReturn = false;
                }
            }

        }
        else
        {
            mustReturn = true;
            Return();
        }
        if (colEnnemy.IsTouching(colPlayer))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // fonction qui permet a l'ennemi d'effectuer des aller-retour
    void Walk()
    {
        if(onGoing)
        {
            rb.velocity = new Vector2(vitesse, 0);
        }
        else
        {
            rb.velocity = new Vector2(-vitesse, 0);
        }
    }

    // fonction qui permet a l'ennemi de poursuivre le joueur
    void Follow()
    {
        if(posPlayer + 0.1f < posEnnemy)
        {
            if(onGoing)
            {
                onGoing = !onGoing;
                Vector2 vect = transform.localScale;
                vect = new Vector2(-vect.x, vect.y);
                transform.localScale = vect;
            }
            rb.velocity = new Vector2(-vitesse, 0);
        }
        else if(posPlayer - 0.1f > posEnnemy)
        {
            if(!onGoing)
            {
                onGoing = !onGoing;
                Vector2 vect = transform.localScale;
                vect = new Vector2(-vect.x, vect.y);
                transform.localScale = vect;
            }
            rb.velocity = new Vector2(vitesse, 0);
        }
        else
        {
            transform.position = new Vector2(player.transform.position.x, transform.position.y);
            anim.ResetTrigger("Run");
        }
    }


    // permet a l'ennemi de retourner dans sa zone d'origine
    void Return()
    {
        if(posEnnemy < start)
        {
            if(!onGoing)
            {
                onGoing = !onGoing;
                Vector2 vect = transform.localScale;
                vect = new Vector2(-vect.x, vect.y);
                transform.localScale = vect;
            }
            rb.velocity = new Vector2(vitesse, 0);
        }
        if(posEnnemy > end)
        {
            if(onGoing)
            {
                onGoing = !onGoing;
                Vector2 vect = transform.localScale;
                vect = new Vector2(-vect.x, vect.y);
                transform.localScale = vect;
            }
            rb.velocity = new Vector2(-vitesse, 0);
        }
    }


    // fonction valeur absolue
    float abs(float a)
    {
        float res;
        if(a > 0.0f)
        {
            res = a;
        }
        else
        {
            res = - a;
        }
        return res;
    }
}
