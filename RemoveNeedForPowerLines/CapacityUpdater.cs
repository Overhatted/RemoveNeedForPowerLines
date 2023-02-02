using ColossalFramework;
using ICities;
using System;

namespace RemoveNeedForPowerLines
{
    public class CapacityUpdater : IThreadingExtension
    {
        public void OnAfterSimulationFrame()
        {
            
        }

        public void OnAfterSimulationTick()
        {
            
        }

        public void OnBeforeSimulationFrame()
        {
            
        }

        public void OnBeforeSimulationTick()
        {
            int CurrentDailyElectricityConsumption = Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetElectricityConsumption() / 7;

            ElectricityManagerMod.ElectricityCapacity = Math.Max(CurrentDailyElectricityConsumption, 1000);
        }

        public void OnCreated(IThreading threading)
        {
            
        }

        public void OnReleased()
        {
            
        }

        public void OnUpdate(float realTimeDelta, float simulationTimeDelta)
        {
            
        }
    }
}
