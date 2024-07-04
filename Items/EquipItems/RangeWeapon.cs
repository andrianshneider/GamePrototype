using System;
using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
	public class RangeWeapon : Weapon
	{
        public RangeWeapon(uint damage, uint durability, string name, uint range) : base(damage, durability, name) => Range = range;

        public uint Range { get; }

        public override EquipSlot Slot => EquipSlot.RangeWeapon;
    }
}

