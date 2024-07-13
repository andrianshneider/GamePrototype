using System;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
	public abstract class UnitFactoryAbstract
	{
        public static Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new Weapon(10, 15, "Sword"));
            player.AddItemToInventory(new Armour(10, 15, "Armour"));
            player.AddItemToInventory(new HealthPotion("Potion"));
            return player;
        }

        public abstract Unit CreateGoblinEnemy();
    }

    public class UnitFactoryEasy: UnitFactoryAbstract
    {
        public override Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 10, 10, 2);
    }

    public class UnitFactoryHard : UnitFactoryAbstract
    {
        public override Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);
    }
}

