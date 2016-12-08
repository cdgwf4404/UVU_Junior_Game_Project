using UnityEngine;
using System.Collections;

public class ParticlePlaybackSpeed : MonoBehaviour
{
    public float speed = 2;
    void Start()
    {
        GetComponent<ParticleSystem>().playbackSpeed = speed;
    }
}
