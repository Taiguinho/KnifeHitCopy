using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    [SerializeField]
    private AudioSource woodCollider;
    private BoxCollider2D colisorProjetil;
    private Rigidbody2D projetil;
    [SerializeField]
    private float forca = 50000f;

    [SerializeField]
    private bool fixado = false; //variavel pra saber se o projetil ja atingiu o alvo


    // Start is called before the first frame update
    void Start()
    {
        projetil = GetComponent<Rigidbody2D>();
        colisorProjetil = GetComponent<BoxCollider2D>();
        if (fixado != true)
        {
            projetil.AddForce(transform.up * forca);
        } else
        {
            projetil.bodyType = RigidbodyType2D.Kinematic;
        }
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

    }

    //para a faca reconhecer a frutinha, foi criado um trigger. Pois assim a frutinha nao influencia em onde a faca vai atingir.
    //Apos a faca detectar a frutinha, sera coletado os pontos da mesma e a faca seguirá o seu rumo.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Frutinha"))
        {
            GameManager.pontuacao += collision.gameObject.GetComponent<Frutinha>().getPontos();
            Destroy(collision.gameObject);
        }
    }

    //esta funcao sera usada para detectar uma colisao, seja com a roleta ou com outra faca.
    private void OnCollisionEnter2D(Collision2D collision)
    {
 
        //se for detectado que eh uma roleta, a faca passa a ser um kinematico e ficara grudado à roleta.
        if (collision.gameObject.tag == "Roleta")
        {
            
            projetil.velocity = new Vector2(0, 0);
            projetil.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            //aqui serve para as facas que ja vem fixadas as roletas ao iniciar um novo nivel. Assim nao ira pontuar em vão e nem dar o som sem precisar.
            if (fixado != true)
            {
                woodCollider.Play();
                GameManager.pontuacao++;
                GameManager.espadas--;
            }
            
            //quer dizer que o objeto esta fixado a roleta.
            fixado = true;

            //trecho de codigo que serve para diminuir o boxcollider da faca ate a metade. 
            //Se este trecho nao for implementado, vai acontecer um bug de colisao e os objetos vao ficar se batendo parados
            colisorProjetil.offset = new Vector2(colisorProjetil.offset.x, -0.007638484f);
            colisorProjetil.offset = new Vector2(colisorProjetil.offset.y, -1.741099f);
            colisorProjetil.size = new Vector2(colisorProjetil.size.x, 0.7488692f);
            colisorProjetil.size = new Vector2(colisorProjetil.size.y, 2.052742f);
            //mantive o box collider so na ponta do projetil, neste caso, a faca!
            //pra fazer outros tamanhos de projetil, seria facilmente resolvido com um if e uma variavel int para nr do projetil

            

        } else
        {
            //se for detectado outro projeto, dai entao sera tratado no GameManager esta colisao, abrindo assim o menu de morte.

            if (collision.gameObject.CompareTag("Projetil"))
            {
                GameManager.acertouOutroProjetil = true;
                
            } else
            {/*
                if (collision.gameObject.CompareTag("Frutinha"))
                {
                    GameManager.pontuacao += collision.gameObject.GetComponent<Frutinha>().getPontos();
                    Destroy(collision.gameObject);
                }
                */
            }
            
        }
    }
}
