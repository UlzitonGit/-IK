using System;
using UnityEngine;

public class IKFootSolver : MonoBehaviour
{
    [SerializeField] private Transform body;

    [SerializeField] private float footSpacing;
    
    [SerializeField] private float stepDistance;
    
    [SerializeField] private float stepHeight;

    [SerializeField] private float speed;
    
    private Vector3 currentFootPosition;

    private float lerp;
    
    private Vector3 oldFootPosition;
    
    private Vector3 newFootPosition;
    // Update is called once per frame
    void Update()
    {
        transform.position = currentFootPosition;
        
        Ray ray = new Ray(body.position + (body.right * footSpacing), Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 10))
        {
            if (Vector3.Distance(newFootPosition, hit.point) > stepDistance)
            {
                if (lerp >= 0.4)
                {
                    lerp = 0;
                }
               
                newFootPosition = hit.point;
            }
        }

        if (lerp < 1)
        {
            Vector3 footPosition = Vector3.Lerp(oldFootPosition, newFootPosition, lerp);
            footPosition.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;
            
            currentFootPosition = footPosition;
            lerp += Time.deltaTime * speed;
        }
        else
        {
            oldFootPosition = newFootPosition;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(newFootPosition, 0.4f);
    }
}
