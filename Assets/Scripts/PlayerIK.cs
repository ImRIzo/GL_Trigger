using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerIK : MonoBehaviour
{
    [SerializeField] private RigBuilder rigBuilder;
    [Header("IK Constraints")]
    [SerializeField] private TwoBoneIKConstraint[] twoBoneIKConstraint;
    [SerializeField] private MultiAimConstraint[] multiAimConstraint;

    public void ConfigureIK(Transform targetIK)
    {
        rigBuilder.enabled = true;
        
        foreach (var bone in twoBoneIKConstraint)
        {
            bone.data.target = targetIK;
        }
        foreach (var bone in multiAimConstraint)
        {
            WeightedTransformArray weightedTransforms = new WeightedTransformArray();
            weightedTransforms.Add(new WeightedTransform(targetIK, 1));
            bone.data.sourceObjects = weightedTransforms;
        }

        rigBuilder.Build();
    }
    public void DisableIK()
    {
        rigBuilder.enabled = false;
    }
}
