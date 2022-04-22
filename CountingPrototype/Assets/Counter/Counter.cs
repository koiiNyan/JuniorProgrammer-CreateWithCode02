using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private int _count = 0;

    private void Start()
    {
        _count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        _count += 1;
        CounterText.text = "Count : " + _count;
    }
}
