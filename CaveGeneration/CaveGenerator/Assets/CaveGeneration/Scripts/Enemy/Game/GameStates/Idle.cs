﻿using UnityEngine;
using System.Collections;
using SD.AI.FSM;
using System;

public class Idle : State {

    private Enemy enemy;
    private Vector2 directionalInput;

    private void Awake() {
        enemy = GetComponent<Enemy>();
    }

    public override void StartState() {
        stateName = "Idle";

    }
    public override void Run() {

        if (enemy.Velocity.x == 0 && enemy.Actor.FaceDir == 1) {
            directionalInput = new Vector2(UnityEngine.Random.Range(-.5f, -1), 0);
        } else if (enemy.Velocity.x == 0 && enemy.Actor.FaceDir == -1) {
            directionalInput = new Vector2(UnityEngine.Random.Range(.5f, 1), 0);
        }

        enemy.Actor.SetDirectionalInput(directionalInput);
        enemy.Eyes.transform.right = Vector3.Lerp(enemy.Eyes.transform.right, enemy.Velocity.normalized, Time.deltaTime * 10f);

    }
    public override void Complete() {
        //     base.Complete();
    }
    public override void Transition(State fromState) {
        //   base.Transition(fromState);
    }
}