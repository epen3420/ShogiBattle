using UnityEngine;

public class KomaBase : MonoBehaviour, IFlickable
{
    private Rigidbody rb;
    protected float flickPower = 10f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FlickObject(Vector3 direction)
    {
        rb.AddForce(flickPower * direction, ForceMode.Impulse);
    }
}
