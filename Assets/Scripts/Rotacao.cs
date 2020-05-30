using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacao : MonoBehaviour
{
    //script que servira para rodar o objeto que estiver na tela com diferentes velocidades, assim como no jogo knife hit
    //criei um vetor de velocidades, que possui velocidade(rotacao e seu sentido) e tambem um tempo de duracao

    [System.Serializable]
    public class Velocidades
    {
        public float velocidade;
        public float duracao;
    }

    //vetor de velocidades, pra gravar as diferentes velocidades e sentidos do obj
    [SerializeField]
    private Velocidades[] velocidades;

    //variavel que vai manipular o tempo de duracao das rotacoes
    private float tempo = 5f;

    //variavel pra saber quando uma determinada velocidade esta girando, por exemplo:
    //a velocidade[0] vai girar por 3 segundos com rotacao de 1f
    //durante este tempo de rotacao, o bool vai estar ativado e nao deve ser interrompido
    private bool girando = false;

    //variavel index pra percorrer o vetor de velocidades
    private int i = 0;


    void Update()
    {
        if (GameManager.pause != true)
        {
            Girar();
            tempo -= Time.deltaTime;
        }
        
    }

    private void Girar()
    {

        if (velocidades.Length > 0) //checa se o vetor de velocidades nao esta vazio!
        {
            if (i < velocidades.Length) //checa se o index eh menor que o vetor de velocidades. Se nao pode dar segmentation fault
            {
                if (girando == false) //se a roleta ja nao esta girando, entao, eh pq a proxima velocidade deve estipular seu tempo
                {
                    this.tempo = velocidades[i].duracao; //aqui eh estipulado o tempo/sentido que vai girar
                }
                
                if (tempo > 0) //se o tempo for maior do que 0, vai girar. Ira parar quando o tempo de duracao chegar ao fim
                {
                    transform.Rotate(0, 0, velocidades[i].velocidade);
                    girando = true; //diz que a roleta esta girando
  
                } else
                {
                    girando = false;
                    i++; //aumenta o index e libera a roleta para a proxima velocidade
                }
            }
            else
            {
                i = 0; //aqui recomeca do 0 as velocidades. Ira girar em loop infinito variando as velocidades ate vir o proximo inimigo.
            }
        }
        
    }


}
