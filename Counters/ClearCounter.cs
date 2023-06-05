using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] protected KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player) {
        if (!HasKitchenObject()) {//burada bir obje yok 
            if (player.HasKitchenObject()) {
                //karakterin elinde biþey var 
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                //karakter biþey taþýmýyor
            }
        } else {
            //burada bir obje var
            if (player.HasKitchenObject()) {
                //karakter biþey taþýyor

                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                    //karakter tabak taþýyor
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) {
                        GetKitchenObject().DestroySelf();
                    }
                } else 
                {//karakter tabak yerine baþka bieþy taþýyor

                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)) 
                        {//tezgahta tabak var

                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) 
                            {

                            player.GetKitchenObject().DestroySelf();

                        }

                    }

                }

            } else {
                //karakter biþey taþýmýyor
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
