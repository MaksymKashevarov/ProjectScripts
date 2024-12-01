using RenownedGames.Apex;
using UnityEngine;

namespace Entity.Iteractable.Items
{
    [CreateAssetMenu(fileName = "NewItemData", menuName = "Game/Inventory/ItemData")]
    public class ItemData : ScriptableObject
    {
        public string itemName;
        public float weight;
        [ObjectPreview] public Mesh mesh;
    }
}
