using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

	// Use this for initialization
	public void Advance()
    {
        SceneManager.LoadScene("Space_Adventure");
    }
}
