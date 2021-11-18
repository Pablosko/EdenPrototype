using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class AddForceAndDestroy : MonoBehaviour
{
    public Vector2 lifeSpanRange;
    public Vector2 ForceRangeX;
    public Vector2 ForceRangeY;
    void Start()
    {
        int flip = Random.Range(-100, 100);
        Vector2 x = Vector2.right * Random.Range(ForceRangeX.x, ForceRangeX.y) * Mathf.Sign(flip);
        Vector2 y = Vector2.up * Random.Range(ForceRangeY.x, ForceRangeY.y);
        Vector2 dir = x + y;
        GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
        Invoke("Die", Random.Range(lifeSpanRange.x, lifeSpanRange.y));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Die() 
    {
        Destroy(gameObject);
    }
}
