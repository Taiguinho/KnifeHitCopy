using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//este script serve para devolver os pontos que cada frutinha possui
//foi criado para caso eu queria implementar mais coisas com as frutinhas depois
public class Frutinha : MonoBehaviour
{
    [SerializeField]
    private int pontos;
    
    public int getPontos()
    {
        return this.pontos;
    }
    
}
