using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleLerp : MonoBehaviour
{
    public Vector3 minScale;
    public Vector3 maxScale;
    public bool repeat;
    public int i;
    public float scalingSpeed;
    public float scalingDuration;

    private IEnumerator Start() {
        while(repeat && i > 0)
        {
            yield return RepeatLerp(minScale, maxScale, scalingDuration);
            yield return RepeatLerp(maxScale, minScale, scalingDuration);
            i--;
        }
    }

    IEnumerator RepeatLerp(Vector3 startScale, Vector3 endScale, float time)
    {
        float t = 0.0f;
        float rate = (1f/time) * scalingSpeed;
        while (t < 1f)
        {
            t += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }

    }
}
