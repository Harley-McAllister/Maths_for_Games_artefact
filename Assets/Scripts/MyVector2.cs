using UnityEngine;

public class MyVector2
{
    public float x;
    public float y;

    public MyVector2(float x, float y)
    { 
        this.x = x; 
        this.y = y;
    }

    public MyVector2 AddVectors(MyVector2 a, MyVector2 b)
    {
        MyVector2 rv = new MyVector2(0, 0);
        rv.x = a.x + b.x;
        rv.y = a.y + b.y;

        //Debug.Log("Vectors added");
        return rv;
    }

    public MyVector2 SubVectors(MyVector2 a, MyVector2 b)
    {
        MyVector2 rv = new MyVector2(0, 0);
        rv.x = a.x - b.x;
        rv.y = a.y - b.y;

        return rv;
    }

    public float VectorLength()
    {
        float rv = 0f;

        rv = Mathf.Sqrt(x * x + y * y);

        return rv;
    }

    public float VectorLengthSq()
    {
        float rv = 0f;

        rv = (x * x + y * y);

        return rv;
    }

    public Vector2 ToUnityVector()
    {
        Vector2 rv = new Vector2(x, y);
        return rv;
    }

    static MyVector2 ScaleVector(MyVector2 a, float scalar)
    {
        MyVector2 rv = new MyVector2(0, 0);
        rv.x = a.x * scalar;
        rv.y = a.y * scalar;

        return rv;
    }

    static MyVector2 DivVector(MyVector2 a, float divider)
    {
        MyVector2 rv = new MyVector2(0, 0);
        rv.x = a.x / divider;
        rv.y = a.y / divider;

        return rv;
    }

    public bool OverlapVectors(MyVector2 a, MyVector2 b)
    { 
        bool rv = false;


        if (a.x - b.x < 1.25f && a.x - b.x > -1.25f)
        { 
            if (a.y - b.y < 1.25f && a.y - b.y > -1.25f)
            {
                rv = true;
                Debug.Log("Vectors overlap");
            }
        }

        return rv;
    }

    public MyVector2 NormalizedVector()
    {
        MyVector2 rv = new MyVector2(0, 0);

        rv = DivVector(this, this.VectorLength());

        return rv;
    }

    public float VectorDotProd(MyVector2 a, MyVector2 b, bool normalized = true)
    {
        float rv = 0.0f;

        if (normalized)
        {
            MyVector2 NormA = a.NormalizedVector();
            MyVector2 NormB = b.NormalizedVector();
            rv = NormA.x * NormB.x + NormA.y * NormB.y;
        }

        else 
        { 
            rv = a.x * b.x + a.y * b.y;
        }

        return rv;
    }

    public float VectorAngle(MyVector2 a)
    {
        float rv = 0.0f;

        rv = Mathf.Atan2(a.y, a.x);
        //Debug.Log("Angle = " + rv);
        return rv;
    }

    public float DegreesToRadians(float degrees)
    {
        float rv = 0.0f;
        rv = degrees * (Mathf.PI / 180f);
        return rv;
    }

    public float RadiansToDegrees(float radians)
    {
        float rv = 0.0f;
        rv = radians * (180f / Mathf.PI);
        return rv;
    }

    public MyVector2 VectorFromAngle(float radians)
    { 
        MyVector2 rv = new MyVector2(0, 0);
        rv.x = Mathf.Cos(radians);
        rv.y = Mathf.Sin(radians);
        return rv;
    }

}
