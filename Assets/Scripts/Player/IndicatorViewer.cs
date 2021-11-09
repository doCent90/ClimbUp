using UnityEngine;

public class IndicatorViewer : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _sphers;

    private Suckers _suckers;

    private void OnEnable()
    {
        _suckers = FindObjectOfType<Suckers>();
        _suckers.DistaceChanged += SetColor;
    }

    private void OnDisable()
    {
        _suckers.DistaceChanged -= SetColor;
    }

    private void SetColor(float value)
    {
        float normalizedValue = value / 10;

        foreach (var sphere in _sphers)
        {
            sphere.sharedMaterial.color = Color.Lerp(Color.green, Color.red, normalizedValue);
        }
    }
}
