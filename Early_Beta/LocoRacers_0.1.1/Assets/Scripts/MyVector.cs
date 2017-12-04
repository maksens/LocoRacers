using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector 
{
    public float x;
    public float y;
    public float z;

    public MyVector(Vector3 aV1)
    {
        this.x = aV1.x;
        this.y = aV1.y;
        this.z = aV1.z;
    }

    public static bool MinusOrEqual(Vector3 aV1, Vector3 aV2)
    {
        MyVector v1 = new MyVector(aV1);
        MyVector v2 = new MyVector(aV2);

        return v1 <= v2;
    }

    public static bool GreaterOrEqual(Vector3 aV1, Vector3 aV2)
    {
        MyVector v1 = new MyVector(aV1);
        MyVector v2 = new MyVector(aV2);

        return v1 >= v2;
    }

    public static bool Equals(Vector3 aV1, Vector3 aV2)
    {
        MyVector v1 = new MyVector(aV1);
        MyVector v2 = new MyVector(aV2);

        return v1 == v2;
    }

    public static bool operator >= (MyVector aV1, MyVector aV2)
    {
        return !(aV1 <= aV2) || (aV1 == aV2);
    }

    public static bool operator <=(MyVector aV1, MyVector aV2)
    {
        bool isMinusOrEqual = false;

        if(aV1.x <= aV2.x && aV1.y <= aV2.y && aV1.z <= aV2.z)
        {
            isMinusOrEqual = true;
        }
        return isMinusOrEqual;
    }

    public static bool operator == (MyVector aV1, MyVector aV2)
    {
        bool isEqual = false;

        if(aV1.x == aV2.x && aV1.y == aV2.y && aV1.z == aV2.z)
        {
            isEqual = true;
        }

        return isEqual;
    }

    public static bool operator != (MyVector aV1, MyVector aV2)
    {
        return !(aV1 == aV2);
    }

    public static bool SmallerThanEpsilon(Vector3 aV1, Vector3 aV2)
    {
        return (Mathf.Abs(aV1.x - aV2.x) < 2f && Mathf.Abs(aV1.z - aV2.z) < 2f);
    }
}
