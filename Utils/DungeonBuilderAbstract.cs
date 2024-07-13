using System;
using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Utils
{
	public abstract class DungeonBuilderAbstract
	{
        protected UnitFactoryAbstract UnitFactory;

        public abstract DungeonRoom BuildDungeon();
	}

    public class DungeonBuilderEasy: DungeonBuilderAbstract
    {
        public DungeonBuilderEasy()
        {
            UnitFactory = new UnitFactoryEasy();
        }

        public override DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactory.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");

            enter.TrySetDirection(Direction.Forward, monsterRoom);
            enter.TrySetDirection(Direction.Right, emptyRoom);
            monsterRoom.TrySetDirection(Direction.Right, emptyRoom);
            
            return enter;
        }
    }

    public class DungeonBuilderHard : DungeonBuilderAbstract
    {
        public DungeonBuilderHard()
        {
            UnitFactory = new UnitFactoryHard();
        }

        public override DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactory.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Left, emptyRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            emptyRoom.TrySetDirection(Direction.Left, monsterRoom);
            emptyRoom.TrySetDirection(Direction.Right, monsterRoom);

            lootRoom.TrySetDirection(Direction.Forward, finalRoom);
            lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }
}

