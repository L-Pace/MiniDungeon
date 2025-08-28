using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public static class RandomNumberGenerator
    {
        private static Random _generator = new Random();

        /// <summary>
        /// This method is generating a random number
        /// </summary>
        /// <param name="minimumValue">Minimum Value</param>
        /// <param name="maximumValue">Maximum Value</param>
        /// <returns></returns>
        public static int NumberBetween(int minimumValue, int maximumValue)
        {
            return _generator.Next(minimumValue, maximumValue + 1);
        }
    }
}
