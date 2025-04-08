using UnityEngine;

public class testscript : MonoBehaviour
{
    [Header("Animation Settings")]
    public float deformSpeed = 5f;
    public float deformAmount = 0.1f;
    public float scaleSpeed = 2f; 
    
    private Vector3 targetScale;
    private bool isScaling = false;

    private float jellyTimer = 0f;
    private float targetRadius;

    private const float scaleTolerance = 0.01f;

    private void Start()
    {
        SetScale(2f);
    }

    public void SetScale(float radius)
    {
        targetRadius = radius;
        targetScale = Vector3.one * radius;
        isScaling = true;
        jellyTimer = 0f;
    }

    void Update()
    {
        jellyTimer += Time.deltaTime * deformSpeed;
        float jellyX = Mathf.Sin(jellyTimer) * deformAmount;
        float jellyY = Mathf.Sin(jellyTimer + 1f) * deformAmount;

        Vector3 jellyOffset = new Vector3(jellyX, jellyY, 0f);
        Vector3 scaledTarget = targetScale + Vector3.Scale(targetScale, jellyOffset);

        transform.localScale = Vector3.Lerp(transform.localScale, scaledTarget, Time.deltaTime * scaleSpeed);
    }
}