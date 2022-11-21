using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO; //necess�rio para leitura do arquivo
using System;

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
        string arquivo = File.ReadAllText("./Assets/Mazes/" + config.map_file_name + ".csv");

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

    private int round_position(float num) {
        int rounded_num;

        double only_decimals = num - Math.Truncate(num);

        if(only_decimals > 0.5) {
            rounded_num = (int)Math.Ceiling(num);
        } else {
            rounded_num = (int)Math.Floor(num);
        }

        return rounded_num;
    }
    
    public void save_game() {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        GameObject player_1 = GameObject.FindGameObjectWithTag("Seeker");
        GameObject player_2 = GameObject.FindGameObjectWithTag("Hider");

        Vector3[] walls_coords = new Vector3[walls.Length];
        int[,] saved_map = new int[config.lin, config.col];
        
        int player_1_lin = round_position(player_1.transform.position.x + 20);
        int player_1_col = round_position(player_1.transform.position.z + 20);

        int player_2_lin = round_position(player_2.transform.position.x + 20);
        int player_2_col = round_position(player_2.transform.position.z + 20);

        foreach (GameObject wall in walls)
        {
            int i = (int)wall.transform.position.x + 20;
            int j = (int)wall.transform.position.z + 20;
            saved_map[i, j] = 1;
        }

        for (int i=0; i<config.lin ; i++) {
            for (int j=0; j<config.col - 1; j++) {
                if (i == player_1_lin && j == player_1_col) {
                    saved_map[i, j] = 2;
                } else if (i == player_2_lin && j == player_2_col) {
                    saved_map[i, j] = 3;
                }
                else if (saved_map[i, j] != 1) {
                    saved_map[i, j] = 0;
                }
            }    
        }

        StreamWriter file = new StreamWriter("./Assets/Mazes/saved_maze.csv");

        for (int i = 0; i < config.lin; i++) {
            for (int j = 0; j < config.col - 1; j++) {
                if(j < config.col - 2) { // Para evitar adicionar a virgula na última coluna
                    file.Write(saved_map[i, j] + ",");
                } else {
                    file.Write(saved_map[i, j]);
                }
            }    
            if (i != config.lin - 1) { //Evita adicionar uma linha a mais no final
                file.Write("\n");
            }
        }

        file.Close();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
