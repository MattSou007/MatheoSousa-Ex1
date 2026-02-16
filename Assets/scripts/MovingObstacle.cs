using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float spdX = 0f;
    public float spdY = 0.01f;
    public float spdRot = 0.01f;

    public float scaleSpd = 0.01f;
    public bool grow = true;
    public bool shrink = false;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, spdRot);

        float vX = transform.position.x;
        float vY = transform.position.y;
        transform.Translate(spdX, spdY, 0, Space.World);
        if(vY>7f) {transform.position  = new Vector2(Random.Range(-4f, 6.5f), -8f);}
        if(vY<-8f) {transform.position  = new Vector2(Random.Range(-4f, 6.5f), 7f);}

        float newSize = transform.localScale.x;
        if (grow)
        {
            newSize += scaleSpd;
            if(newSize>=2.3f)
            {
                grow = false;
                shrink = true;
            }
        }
        if(shrink)
        {
            newSize -= scaleSpd;
            if(newSize<=1.5f)
            {
                grow=true;
                shrink=false;
            }
        }
        transform.localScale = new Vector3(newSize, newSize, newSize);

    }
}
