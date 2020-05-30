using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Projetil;
    [SerializeField]
    private AudioSource Slash;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.pause != true)
        {
            if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (GameManager.espadas > 0)
                {
                    //instancia a faca que sera arremessada contra a roleta.
                    Instantiate(Projetil, new Vector3(0.03f, -7.32f, 0.02f), Quaternion.identity);
                    Slash.Play(); //toca o som da faca
                }

            }
        }
        
    }
}
