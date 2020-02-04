using System.Collections.Generic;

namespace FoxAgent.Hardware
{
    public abstract class CPUInfo : AbstractHardwareInfo
    {
        private uint GetCacheSize(CPUCacheLevel level)
        {
            uint value = 0;

            if(cacheSizes.TryGetValue(level, out value))
            {
                return value;
            }

            return 0;
        }

        protected Dictionary<CPUCacheLevel, uint> cacheSizes = new Dictionary<CPUCacheLevel, uint>();

        public uint CPUCount { get; protected set; }
        public uint ThreadsPerCore { get; protected set; }
        public uint CoresPerSocket { get; protected set; }
        public string Flags { get; protected set; }

        public int Stepping { get; protected set; }
        public double MHz { get; protected set; }
        public uint CacheLevel1 { get { return GetCacheSize(CPUCacheLevel.Level1); } }
        public uint CacheLevel2 { get { return GetCacheSize(CPUCacheLevel.Level2); } }
        public uint CacheLevel3 { get { return GetCacheSize(CPUCacheLevel.Level3); } }
    }
}