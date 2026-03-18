using UnityEngine;

public class MyVector2
{
    /// Creating my own Vector2 class

    public float x;
    public float y;

    public MyVector2(float x, float y)
    { 
        this.x = x; 
        this.y = y;
    }

    static MyVector2 AddVectors(MyVector2 a, MyVector2 b)
    {
        //Adding two vector2s together
        MyVector2 rv = new MyVector2(0, 0);
        rv.x = a.x + b.x;
        rv.y = a.y + b.y;

        return rv;
    }

    static MyVector2 SubVectors(MyVector2 a, MyVector2 b)
    {
        //Subtracting two vector2s together
        MyVector2 rv = new MyVector2(0, 0);
        rv.x = a.x - b.x;
        rv.y = a.y - b.y;

        return rv;
    }

    public float VectorLength()
    {
        //Calculating the length of a vector2 with pythagorus
        float rv = 0f;

        rv = Mathf.Sqrt(x * x + y * y);

        return rv;
    }

    public float VectorLengthSq()
    {
        //Calculating the length of a vector2 before square rooting it
        float rv = 0f;

        rv = (x * x + y * y);

        return rv;
    }

    public Vector2 ToUnityVector()
    {
        //Converting my vector2 to a unity vector2
        Vector2 rv = new Vector2(x, y);
        return rv;
    }

    static MyVector2 ScaleVector(MyVector2 a, float scalar)
    {
        //Scaling MyVector2 by a scalar value
        MyVector2 rv = new MyVector2(0, 0);
        rv.x = a.x * scalar;
        rv.y = a.y * scalar;

        return rv;
    }

    static MyVector2 DivVector(MyVector2 a, float divider)
    {
        //Dividing MyVector2 by a dividing value
        MyVector2 rv = new MyVector2(0, 0);
        rv.x = a.x / divider;
        rv.y = a.y / divider;

        return rv;
    }

    public MyVector2 NormalizedVector()
    {
        //Normalizing Myvector2
        MyVector2 rv = new MyVector2(0, 0);

        rv = DivVector(this, this.VectorLength());

        return rv;
    }

    static float VectorDotProd(MyVector2 a, MyVector2 b, bool normalized = true)
    {
        //Conducting dot product between two vector2s, defaulting with normalized vectors
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

}
