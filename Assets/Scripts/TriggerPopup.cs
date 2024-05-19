using UnityEngine;

public class TriggerPopup : MonoBehaviour
{
   
   public GameObject panel;

   public Transform player, destination;

   private void OnTriggerEnter(Collider other){
    if(other.CompareTag("Player")){
        player.position = destination.position;
    }
   }

   private void OnTriggerExit(Collider other){
    if(other.CompareTag("Player")){
        panel.SetActive(false);
    }
   }

}
