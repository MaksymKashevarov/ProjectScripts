using Entity.Iteractable.Items;
using Entity.Stats;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Player
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory currentInstance;
        [SerializeField, ShowAssetPreview] private List<ItemData> _items = new List<ItemData>();
        private Parameter<float> _maxWeight;
        private float _currentWeight;
        [Inject] private Parameters _parameters;

        public ItemData this[int index] => _items[index];

        public float MaxWeight => _maxWeight.eventValue.Value;

        private void Awake()
        {
            _maxWeight = _parameters.GetAs<Parameter<float>>("maxCarriableWeight");
            foreach (ItemData item in _items)
                _currentWeight += item.weight;
        }

        public bool IsPossibleToAddToInventory(ItemData itemData) 
            => _currentWeight + itemData.weight <= _maxWeight.eventValue.Value;

        public void Add(ItemData itemData)
        {
            _currentWeight += itemData.weight;
            _items.Add(itemData);
        }
    }
}

