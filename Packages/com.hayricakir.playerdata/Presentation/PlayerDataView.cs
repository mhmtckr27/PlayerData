using System;
using System.Collections.Generic;
using PlayerData.Domain;
using TMPro;
using UnityEngine;
// using Zenject;

namespace PlayerData.Presentation
{
    public class PlayerDataView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        
        private PlayerDataController _playerDataController;
        private List<IDisposable> _disposables;

        // [Inject]
        private void Construct(PlayerDataController playerDataController)
        {
            _playerDataController = playerDataController;
            _playerDataController.OnChanged += OnPlayerDataChanged;
        }

        private void OnDestroy()
        {
            _playerDataController.OnChanged -= OnPlayerDataChanged;
        }

        private void OnPlayerDataChanged(Domain.PlayerData playerData)
        {
            text.text = playerData.ToString();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                _playerDataController.AddConsumable(new ConsumableData()
                {
                    ConsumableItems = { new ConsumableItem("Coin", 20) }
                });
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _playerDataController.AddConsumable(new ConsumableData()
                {
                    ConsumableItems = { new ConsumableItem("HP", 10) }
                });
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _playerDataController.AddConsumable(new ConsumableData()
                {
                    ConsumableItems = { new ConsumableItem("ATK", 1) }
                });
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _playerDataController.AddConsumable(new ConsumableData()
                {
                    ConsumableItems = { new ConsumableItem("DEF", 1) }
                });
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                _playerDataController.AddConsumable(new ConsumableData()
                {
                    ConsumableItems = { new ConsumableItem("DEX", 1) }
                });
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                _playerDataController.AddConsumable(new ConsumableData()
                {
                    ConsumableItems = { new ConsumableItem("INT", 1) }
                });
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                _playerDataController.AddConsumable(new ConsumableData()
                {
                    ConsumableItems = { new ConsumableItem("SPD", 1) }
                });
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                _playerDataController.AddConsumable(new ConsumableData()
                {
                    ConsumableItems = { new ConsumableItem("WIS", 1) }
                });
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                _playerDataController.AddConsumable(new ConsumableData()
                {
                    ConsumableItems = { new ConsumableItem("CHR", 1) }
                });
            }
        }

        private void LateUpdate()
        {
            Debug.Log(_playerDataController.ToString());
        }
    }
}