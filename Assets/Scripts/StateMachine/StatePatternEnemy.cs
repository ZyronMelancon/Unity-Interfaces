﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StatePatternEnemy : MonoBehaviour {

    public float searchingTurnSpeed = 120f;
    public float searchingDuration = 4f;
    public float sightRange = 20f;
    public Transform[] wayPoints;
    public Transform eyes;
    public Vector3 offset = new Vector3(0, 0.5f, 0);
    public MeshRenderer meshRendererFlag;


    [HideInInspector]
    public Transform chaseTarget;
    public IEnemyState currentState;
    public ChaseState chaseState;
    public AlertState alertState;
    public PatrolState patrolState;
    public NavMeshAgent navMeshAgent;

    private void Awake()
    {
        chaseState = new ChaseState(this);
        alertState = new AlertState(this);
        patrolState = new PatrolState(this);
    }

	void Start ()
    {
        currentState = patrolState;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentState.UpdateState();
	}

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
}
