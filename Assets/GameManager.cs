using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text padel1ScoreText;
    [SerializeField] private TMP_Text padel2ScoreText;
    [SerializeField] private Transform padel1Transform;
    [SerializeField] private Transform padel2Transform;
    [SerializeField] private Transform ballTransform;   
    [SerializeField] private TMP_Text GoalText;

    private int padel1Score;
    private int padel2Score;

    public float TimeToChangePosition = 2.5f;
    public float Timer = 0.0f;

    private static GameManager instance;

    public static GameManager Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void padel1Scored(){
        padel1Score++;
        padel1ScoreText.text = padel1Score.ToString();
    }
    public void padel2Scored(){
        padel2Score++;
        padel2ScoreText.text = padel2Score.ToString();
    }
    public void Restart(){
        padel1Transform.position = new Vector2(padel1Transform.position.x, 0);
        padel2Transform.position = new Vector2(padel2Transform.position.x, 0);
        ballTransform.position = new Vector2(0,0);
        GoalText.gameObject.SetActive(true);
        Timer = 0.0f;
    }
    
    public void DontShowGoal(){
        
        if(Timer >= TimeToChangePosition){
            GoalText.gameObject.SetActive(false);            
        }
    }

    public void ShowGoal(Color color){
        GoalText.color = color;
        //GoalText.gameObject.position = transform.Translate(10,10,10);
        //TextGoal.Instance.ChangePosition();
    }
    void Start(){
        
    }
    void Update(){
        Timer += Time.deltaTime; 
        DontShowGoal();
    }
}
