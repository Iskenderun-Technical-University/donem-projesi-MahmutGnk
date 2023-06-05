using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{

    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;


    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;


    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int platesSpawendAmount;
    private int platesSpawnedAmountMax = 4;

    private void Update() {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax) {
            spawnPlateTimer = 0f;

            if (KitchenGameManager.Instance.IsGamePlaying() && platesSpawendAmount < platesSpawnedAmountMax) {
                platesSpawendAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player) {
        if (!player.HasKitchenObject()) {
            //oyuncunun eli boþ
            if (platesSpawendAmount > 0) {
                //en az bir tabak var
                platesSpawendAmount--;

                KitchenObject.SpawnKitchenObjects(plateKitchenObjectSO, player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);


            }
        }
    }


}
