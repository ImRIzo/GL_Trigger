using System;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerMovement : MonoBehaviour
{
    enum State
    {
        Idle,
        Run,
        Action
    }

    [Header("Player Settings")]
    [SerializeField] private float moveSpeed;
 
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private State state;
    [SerializeField] private PlayerIK playerIK;
    void Start()
    {
        Application.targetFrameRate = -1;
        state = State.Idle;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartRunning();
        }

        ManageState();
    }

    private void ManageState()
    {
        switch (state)
        {
            case State.Idle: 
                break;
                
            case State.Run:
                Move();
                break;

            case State.Action:
                Action();
                break;
        }
    }

    private void StartRunning()
    {
        state = State.Run;
        playerAnimation.PlayRunAnimation();
    }
    private void Move()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    private ActionZone currentActionZone;
    internal void EnteredActionZone(ActionZone actionZone)
    {
        if (currentActionZone != null) return;
        currentActionZone = actionZone;
        actionTimer = 0;
        state = State.Action;
        playerAnimation.PlayAnimation(currentActionZone.GetAnimationToPlay);
        playerIK.ConfigureIK(currentActionZone.GetIKTarget);
        ////////////////
    }
    private float actionTimer;
    private void Action()
    {
        actionTimer += Time.deltaTime;
        float splinePercent = actionTimer / currentActionZone.GetActionDuration;
        transform.position = currentActionZone.GetPlayerSpline.EvaluatePosition(splinePercent);

        if(splinePercent >= 1)
        {
            ExitActionZone();
        }
    }

    private void ExitActionZone()
    {
        state = State.Run;
        currentActionZone = null;
        playerAnimation.PlayAnimation("Run", 1);
        playerIK.DisableIK();
    }
}
