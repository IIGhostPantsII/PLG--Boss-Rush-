using UnityEngine;

public class Example : MonoBehaviour
{
    public enum MyEnum
    {
        Value1,
        Value2,
        Value3
    }

    void Start()
    {
        MyEnum randomEnumValue = (MyEnum)Random.Range(0, 3);

        Debug.Log("Random enum value: " + randomEnumValue);
    }
}