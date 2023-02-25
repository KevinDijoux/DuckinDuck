using System.Runtime.CompilerServices;
using GSGD1;
using UnityEngine.UI;

namespace Interfaces
{
    public interface IFactory
    {
        string factoryName { get; set; }
        Ressource ressource { get; set; }
        float cooldown { get; set; }
        int quantity { get; set; }
        Image factorySprite { get; set; }
        int level { get; set; }
        Timer timer { get; set; }

        string GetName();
        Ressource GetRessource();
        float GetCooldown();
        int GetQuantity();
        Image GetImage();
        int GetLevel();
        
        string SetName(string name);
        Ressource SetRessource(Ressource ressource);
        [System.Obsolete("Avoid, it has been decided balance would be around a cooldown of 1 seconds")]
        float SetCooldown(float cooldown);
        int SetQuantity(int quantity);
        Image SetImage(Image image);
        int IncrementLevel();

    }
}