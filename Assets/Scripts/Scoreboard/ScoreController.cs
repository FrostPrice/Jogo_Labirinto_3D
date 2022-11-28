using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class ScoreController : MonoBehaviour
{
    private ScoreData scores_data;

    void Awake() 
    {
        string json = System.IO.File.ReadAllText("./Assets/Files/scoreboard.json");
        scores_data = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> sort_in_ascending_order() 
    {   
        IEnumerable<Score> ordered_list = scores_data.scores.OrderBy(x => x.score);

        if(ordered_list.Count() > 6) {
            scores_data.scores = ordered_list.ToList();
            return ordered_list.SkipLast(ordered_list.Count() - 6); // Limita para a lista ter apenas 10 elementos
        }

        scores_data.scores = ordered_list.ToList();
        return ordered_list;
    }

    public void add_score(Score score)
    {
        scores_data.scores.Add(score);
    }

    private void OnDestroy() 
    {
        SaveScore();
    }

    public void SaveScore()
    {
        string json = JsonUtility.ToJson(scores_data);
        System.IO.File.WriteAllText("./Assets/Files/scoreboard.json", json);
    }
}
