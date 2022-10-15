using UnityEngine;

public class RechargeEnergy : MonoBehaviour
{
    // how long it will take to recharge to full
    public float incrementAmount = 5f;

    // Start is called before the first frame update
    private StationInteractable station;
    private bool inStation;
    private BabyController baby;

    private void Start()
    {
        station = GetComponent<StationInteractable>();
    }

    // Update is called once per frame
    private void Update()
    {
        //TODO: this is a really bad hack ideally you want to use events to inform when a station has a baby or not
        var newInStation = station.baby != null;
        if (inStation && !newInStation)
        {
            baby.rechargeBaby = false;
            baby = null;
        } else if (!inStation && newInStation)
        {
            baby = station.baby;
            baby.rechargeBaby = true;
        }
        inStation = newInStation;
        if (inStation && baby != null)
        {
            baby.IncreaseEnergy(incrementAmount * Time.deltaTime);
        }
    }
}