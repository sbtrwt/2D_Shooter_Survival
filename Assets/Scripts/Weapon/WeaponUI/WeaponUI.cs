using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter2D.Weapon
{

    public class WeaponUI : MonoBehaviour{
        public WeaponService weaponService;
        public Transform buttonContainer;
        public Button buttonPrefab;
        public List<WeaponConfig> weaponConfigs;
        public void CreateWeaponButton(WeaponConfig config){
            Button button = Instantiate(buttonPrefab, buttonContainer);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = config.WeaponName;
            button.onClick.AddListener(() => weaponService.EquipWeapon(config));
        }
    }
}