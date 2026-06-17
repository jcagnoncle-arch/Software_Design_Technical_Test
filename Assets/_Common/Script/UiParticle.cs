using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiParticle : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target = default;
    private Transform start = default;

    
    [SerializeField] private float duration = 1;
    public bool splitAnimationCurve = default;
    public AnimationCurve xMovementCurve = default;
    public AnimationCurve yMovementCurve = default;

    public bool resizeParticle = default;
    [SerializeField] private Vector2 scaleBoundaries = default;
    [SerializeField] private AnimationCurve scaleCurve = default;

    public UnityEvent OnDone = default;


    public void Init(Transform initPoint, Transform targetToGo)
    {
        start = initPoint;
        target = targetToGo;
        StartCoroutine(Travel());
    }
    
    private IEnumerator Travel()
    {
        float index = default;
        float ratio = 1 / duration;
        AnimationCurve xCurve = xMovementCurve;
        AnimationCurve yCurve;
        float scale;

        if (splitAnimationCurve)
        {
            yCurve = yMovementCurve;
        }
        else
        {
            yCurve = xMovementCurve;
        }

        while (index<1)
        {
            index += Time.deltaTime * ratio;
            transform.position = new Vector3(Mathf.Lerp(start.position.x, target.position.x, xCurve.Evaluate(index)), Mathf.Lerp(start.position.y, target.position.y, yCurve.Evaluate(index)), transform.position.z);
            if (resizeParticle) 
            {
                scale = Mathf.Lerp(scaleBoundaries.x, scaleBoundaries.y, scaleCurve.Evaluate(index));
                transform.localScale = new Vector3(scale, scale, scale);
            }

            yield return null;
        }
        OnDone?.Invoke();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        OnDone.RemoveAllListeners();
    }
}
