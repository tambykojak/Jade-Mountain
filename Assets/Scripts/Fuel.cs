using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField] private float maximumFuel = 100f;
    [SerializeField] private float currentFuel = 100f;

    private GameObject fuelBar;

    public void Start()
    {
        fuelBar = GameObject.FindGameObjectWithTag("Fuel Bar")?.transform.Find("Fuel").gameObject;
        InvalidateFuelBar();
    }

    public bool HasFuel()
    {
        return currentFuel > 0;
    }

    public void SetFuel(float newFuel)
    {
        currentFuel = newFuel;
        if (currentFuel < 0) currentFuel = 0;
        InvalidateFuelBar();
    }

    public void ResetFuel()
    {
        SetFuel(100f);
    }

    public void ConsumeFuel(float fuelToConsume)
    {
        SetFuel(currentFuel - fuelToConsume);
    }

    public void InvalidateFuelBar()
    {
        if (!fuelBar) return;
        fuelBar.transform.localScale = new Vector2(currentFuel / maximumFuel, 1);
    }
}
