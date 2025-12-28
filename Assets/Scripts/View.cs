using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        _text.text = "0";
    }

    private void OnEnable()
    {
        _counter.ValueChanged += ChangeText;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= ChangeText;
    }

    private void ChangeText()
    {
        _text.text = _counter.CurrentValue.ToString();
    }
}
