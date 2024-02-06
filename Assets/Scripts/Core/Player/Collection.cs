using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuki.NPlayer
{
    public class Collection : CoreComp
    {
        private Inventory _inventory;

        private void Start()
        {
            _inventory = _core.GetCoreComponent<Inventory>();
        }

        private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
        {
            if(collision.gameObject.CompareTag(Collectable.Sliver.ToString()))
            {
                _inventory.IncreaseCoinValue((int)Collectable.Sliver);
            }
            else if (collision.gameObject.CompareTag(Collectable.Gold.ToString()))
            {
                _inventory.IncreaseCoinValue((int)Collectable.Gold);
            }
            else if (collision.gameObject.CompareTag(Collectable.Ruby.ToString()))
            {
                _inventory.IncreaseCoinValue((int)Collectable.Ruby);
            }
            else if (collision.gameObject.CompareTag(Collectable.YellowDiamond.ToString()))
            {
                _inventory.IncreaseCoinValue((int)Collectable.YellowDiamond);
            }
            else if (collision.gameObject.CompareTag(Collectable.BlueDiamond.ToString()))
            {
                _inventory.IncreaseCoinValue((int)Collectable.BlueDiamond);
            }
            else if (collision.gameObject.CompareTag(Collectable.CyaDiamond.ToString()))
            {
                _inventory.IncreaseCoinValue((int)Collectable.CyaDiamond);
            }
            else if (collision.gameObject.CompareTag(Collectable.GreenDiamond.ToString()))
            {
                _inventory.IncreaseCoinValue((int)Collectable.GreenDiamond);
            }
            else if (collision.gameObject.CompareTag(Collectable.RedDiamond.ToString()))
            {
                _inventory.IncreaseCoinValue((int)Collectable.RedDiamond);
            }
        }
    }
}
