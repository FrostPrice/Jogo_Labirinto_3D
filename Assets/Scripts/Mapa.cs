using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO; //necess�rio para leitura do arquivo


public class Mapa : MonoBehaviour
{
    //--------------------------
    public Config config;
    public GameObject parede;
    //--------------------------
    
    void Awake()
    {
        CriaMapa();
    }

    void CriaMapa () {
        // -- Comando para ler do arquivo e salvar na matriz de inteiros --
        //meu arquivo � um csv, mas funciona com qualquer extens�o de arquivo
        string arquivo = File.ReadAllText( "./Assets/Mazes/maze.csv" );
        config.mapa = new int[config.lin, config.col];
        int i=0, j=0;
        
        foreach (var row in arquivo.Split('\n')) {
            j = 0;
            //separei meus n�meros com v�rgula, se o de voc�s for espa�o � s� trocar no .Split()
            foreach (var col in row.Trim().Split(',')) { 
                config.mapa[i, j] = int.Parse(col.Trim());
                j++;
            }
            i++;
        }        
        // ----------------------------------------------------------------
        
        // -- percorre a matriz e insere o objeto quando l� 1 na matriz ---
        for (i=0; i<config.lin; i++) {
            for (j=0; j<config.col; j++) {
                if (config.mapa[i,j] == 1){
                    //-20 � o ajuste para come�ar na parte superior esquerda
                    //posiciona em 2 de altura, pois o objeto altura 4 tem tamanho 2 para cima e 2 para baixo
                    Vector3 p = new Vector3(i-20f, 2.0f, j-20f); 
                    Instantiate(parede, p, Quaternion.identity);
                }
            }    
        }
        // ----------------------------------------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
