using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //script feito sem pensar na seguranca
    //para economizar tempo, fiz as variaveis sendo public static para serem acessadas mais facilmente


    ///////////////////////////////////////////
    /// Variaveis de status
    public static int pontuacao;
    public static int espadas;
    public static int nivel;

    
    /// //////////////////////////////////////////
    /// Variaveis de controle
    public static bool acertouOutroProjetil = false;
    public static bool pause = false;
    public static bool fimDeJogo = false;


    ///////////////////////////////////////////
    /// Variaveis de texto
    [SerializeField]
    private TMP_Text textoPontuacao; //pontuacao do player na tela
    [SerializeField]
    private TMP_Text textoEspadas; //espadas na tela
    [SerializeField]
    private TMP_Text textoNivel; //nivel na tela
    [SerializeField]
    private GameObject menuPausa; //menu de pausa
    [SerializeField]
    private GameObject menuMorte; //menu de morte


    ///////////////////////////////////////////
    /// Roletas (inimigos) -> 10 OBJETOS
    [SerializeField]
    private GameObject inimigo1;
    [SerializeField]
    private GameObject inimigo2;
    [SerializeField]
    private GameObject inimigo3;
    [SerializeField]
    private GameObject inimigo4;
    [SerializeField]
    private GameObject inimigo5;
    [SerializeField]
    private GameObject inimigo6;
    [SerializeField]
    private GameObject inimigo7;
    [SerializeField]
    private GameObject inimigo8;
    [SerializeField]
    private GameObject inimigo9;
    [SerializeField]
    private GameObject inimigo10;
    void Start()
    {
        menuPausa.SetActive(false); //desativa variaveis a fim de evitar bugs
        menuMorte.SetActive(false);
        nivel = 1;
        pontuacao = 0;
        espadas = 3;
        inimigo1 = (GameObject) Instantiate(inimigo1, new Vector3(0.42f, 2.23f, 0f), Quaternion.identity);
        textoNivel.text = "Nivel 1: Onde tudo começa!";
    }

    // Update is called once per frame
    void Update()
    {
        //atualiza na tela a pontuacao e espadas. esta sempre atualizado.
        textoPontuacao.text = pontuacao.ToString();
        textoEspadas.text = espadas.ToString();

        //se as espadas forem iguais a 0, entao o jogo deve avancar para o proximo nivel
        if (espadas == 0)
        {
            proximoNivel();
        }
        
        //se o player acertar outra espada, entao fim de jogo e a tela de morte deve aparecer.
        if (acertouOutroProjetil == true)
        {
            fimDeJogo = true;
            pause = true;
            menuMorte.SetActive(true);
        }

        //se for setado fim de jogo, o jogador nao pode dar pausa na partida.
        if (fimDeJogo != true)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                pausarJogo();

            }
        }
        

    }

    //funcao para pausar o jogo.
    public void pausarJogo()
    {
        if (pause == false)
        {
            Time.timeScale = 0f;
            menuPausa.SetActive(true);
            pause = true;
            AudioListener.pause = true; //evitar que algum som toque de fundo
        }
        else
        {
            Time.timeScale = 1;
            menuPausa.SetActive(false);
            pause = false;
            AudioListener.pause = false;
        }
    }

    //funcao que serve para ir ao proximo nivel e tomar as devidas decisoes de prox nivel
    //em cada proximo nivel, o codigo ira excluir o ultimo inimigo e instanciar um novo
    void proximoNivel()
    {
        nivel++;
        switch (nivel)
        {
            case 2:
                Destroy(inimigo1);
                inimigo2 = (GameObject) Instantiate(inimigo2, new Vector3(0.42f, 2.23f, 0f), Quaternion.identity);
                textoNivel.text = "Nivel 2";
                espadas = 5;
                break;
            case 3:
                Destroy(inimigo2);
                inimigo3 = (GameObject)Instantiate(inimigo3, new Vector3(0.42f, 2.23f, 0f), Quaternion.identity);
                textoNivel.text = "Nivel 3";
                espadas = 6;
                break;
            case 4:
                Destroy(inimigo3);
                inimigo4 = (GameObject)Instantiate(inimigo4, new Vector3(0.42f, 2.23f, 0f), Quaternion.identity);
                textoNivel.text = "Nivel 4";
                espadas = 8;
                break;
            case 5:
                Destroy(inimigo4);
                inimigo5 = (GameObject)Instantiate(inimigo5, new Vector3(0.42f, 2.23f, 0f), Quaternion.identity);
                textoNivel.text = "Nivel 5";
                espadas = 10;
                break;
            case 6:
                Destroy(inimigo5);
                inimigo6 = (GameObject)Instantiate(inimigo6, new Vector3(0.42f, 2.23f, 0f), Quaternion.identity);
                textoNivel.text = "Nivel 6";
                espadas = 12;
                break;
            case 7:
                Destroy(inimigo6);
                inimigo7 = (GameObject)Instantiate(inimigo7, new Vector3(0.42f, 2.23f, 0f), Quaternion.identity);
                textoNivel.text = "Nivel 7: Aqui você desiste ou perde.";
                espadas = 20;
                break;
            case 8:
                Destroy(inimigo7);
                inimigo8= (GameObject)Instantiate(inimigo8, new Vector3(0.42f, 2.23f, 0f), Quaternion.identity);
                textoNivel.text = "Nivel 8: Ultimo aviso pra desistir";
                espadas = 25;
                break;
            case 9:
                Destroy(inimigo8);
                inimigo9 = (GameObject)Instantiate(inimigo9, new Vector3(0.42f, 2.23f, 0f), Quaternion.identity);
                textoNivel.text = "Nivel 9: Você não devia estar aqui!";
                espadas = 40;
                break;
            case 10:
                Destroy(inimigo9);
                inimigo10 = (GameObject)Instantiate(inimigo10, new Vector3(0.42f, 2.23f, 0f), Quaternion.identity);
                textoNivel.text = "Nivel 10: IMPOSSIVEL!";
                espadas = 50; //eh impossivel alguem chegar ate aqui, eu acho
                break;
        }
    }

    //funcao para recomecar o jogo. Deve ser feito atraves do menuzinho de morte.
    public void recomecarJogo()
    {
        SceneManager.LoadScene(1);
        acertouOutroProjetil = false; //desliga esta variavel para nao causar bugs
        fimDeJogo = false; //desliga essa variavel tambem
        pause = false; //tbm essa
    }

    public void sairFase()
    {
        SceneManager.LoadScene(0);
        acertouOutroProjetil = false; //desliga esta variavel para nao causar bugs
        fimDeJogo = false; //desliga essa variavel tambem
        pause = false; //tbm essa
    }






}
