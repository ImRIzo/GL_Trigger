using UnityEngine;
using UnityEngine.Splines;

public class ActionZone : MonoBehaviour
{
    [SerializeField] private SplineContainer playerSpline;
    [SerializeField] private float actionDuration;
    [SerializeField] private string animationToPlay;
    [SerializeField] private float animationSpeed;
    [SerializeField] private Transform IKTarget;
    public SplineContainer GetPlayerSpline { get { return playerSpline; } }
    public float GetActionDuration { get {  return actionDuration; } }
    public string GetAnimationToPlay { get {  return animationToPlay; } }
    public float GetAnimationSpeed { get {  return animationSpeed; } }
    public Transform GetIKTarget { get { return IKTarget; } }
}
