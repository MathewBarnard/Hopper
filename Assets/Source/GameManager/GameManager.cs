using Assets.Source.DataAccessLayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // Boot up the data repository.
        DataRepository repository = DataRepository.Instance();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
