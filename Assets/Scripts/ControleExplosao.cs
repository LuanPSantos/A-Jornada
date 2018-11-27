using UnityEngine;
using System.Collections;

public class ControleExplosao : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
		Destroy (gameObject, 0.15f);
	}
}
