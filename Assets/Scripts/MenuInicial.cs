using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//este script foi desenvolvido para adminstrar o menu inicial
//possui 3 funcoes. Uma para iniciar o game, outra para mini tutorial e a terceira para fecha-lo.

public class MenuInicial : MonoBehaviour
{
    [SerializeField]
    private GameObject comoJogarPainel;
    private bool comoJogarAberto = false;

    private void Start()
    {
        comoJogarPainel.SetActive(false);
        comoJogarAberto = false;
    }

    public void iniciaJogo()
    {
        SceneManager.LoadScene(1);
    }

    public void comoJogar()
    {
        print("clicou");
        if (comoJogarAberto == false)
        {
            comoJogarPainel.SetActive(true);
            comoJogarAberto = true;
        } else
        {
            comoJogarPainel.SetActive(false);
            comoJogarAberto = false;
        }
    }

    public void sair()
    {
        Application.Quit();
    }
}
