using System;

namespace RemoveNeedForPowerLines
{
    public static class ElectricityManagerMod
    {
        public static int Current_Electricity;

        public static int ElectricityCapacity;

        public static void Init()
        {
            Current_Electricity = 0;
        }

        public static void CheckElectricity(out bool Electricity)
        {
            if (Current_Electricity > 0)
            {
                Electricity = true;
            }
            else
            {
                Electricity = false;
            }
        }

        public static int DumpElectricity(int Rate)//Power Plants
        {
            Rate = Math.Min(Rate, ElectricityCapacity - Current_Electricity);
            Rate = Math.Max(Rate, 0);
            Current_Electricity += Rate;

            return Rate;
        }

        public static int FetchElectricity(int Rate)//Buildings
        {
            Rate = Math.Min(Rate, Current_Electricity);
            Current_Electricity -= Rate;

            return Rate;
        }
    }
}