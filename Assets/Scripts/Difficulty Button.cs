using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Button button;
    private GameManeger gameManeger;
    public int difficulty;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(DifficultyLevel);
        gameManeger = GameObject.Find("Game Maneger").GetComponent<GameManeger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DifficultyLevel()
    {

        Debug.Log(gameObject.name + "was pressed");
        gameManeger.StartGame(difficulty);
        
    }
}
