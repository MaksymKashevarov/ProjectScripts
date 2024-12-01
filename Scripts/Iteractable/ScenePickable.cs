using Entity.Iteractable.Items;
using Entity.Player;
using UnityEngine;

namespace Entity.Iteractable
{
    public class ScenePickable : MonoBehaviour
    {
        [SerializeField] private ItemData _data;

        public void TryToPickup()
        {
            if (!Inventory.currentInstance.IsPossibleToAddToInventory(_data))
                return;

           Inventory.currentInstance.Add(_data);
        }

        public void DestroyGameObject()
            => Destroy(gameObject);
    }
}
