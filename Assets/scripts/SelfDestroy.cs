using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {

    public float delayInSeconds;

	void Start () {
        Destroy(this, delayInSeconds);
	}
}
