using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] protected KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player) {
        if (!HasKitchenObject()) {//burada bir obje yok 
            if (player.HasKitchenObject()) {
                //karakterin elinde bi�ey var 
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                //karakter bi�ey ta��m�yor
            }
        } else {
            //burada bir obje var
            if (player.HasKitchenObject()) {
                //karakter bi�ey ta��yor

                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                    //karakter tabak ta��yor
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) {
                        GetKitchenObject().DestroySelf();
                    }
                } else 
                {//karakter tabak yerine ba�ka bie�y ta��yor

                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)) 
                        {//tezgahta tabak var

                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) 
                            {

                            player.GetKitchenObject().DestroySelf();

                        }

                    }

                }

            } else {
                //karakter bi�ey ta��m�yor
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
