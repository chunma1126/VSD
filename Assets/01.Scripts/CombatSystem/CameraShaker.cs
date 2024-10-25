using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class CameraShaker : MonoBehaviour
{
    //[SerializeField] private float shakePower;

    private CinemachineImpulseSource _source;

    private void Start()
    {
        _source = GetComponent<CinemachineImpulseSource>();
    }

    public void ShakeCam(float power)
    {
        _source.GenerateImpulse(power);
    }


}
