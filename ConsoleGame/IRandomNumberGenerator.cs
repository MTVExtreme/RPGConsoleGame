﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public interface IRandomNumberGenerator
    {
        int GetNext(int min, int max);
    }

    public class BasicRNG : IRandomNumberGenerator
    {
        public int GetNext(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }

    public class AdvancedRNG : IRandomNumberGenerator
    {
        public int GetNext(int min, int max)
        {
            var buffer = new byte[4];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buffer);
            }

            var rand = Math.Abs(BitConverter.ToInt32(buffer, 0));

            return Math.Abs(min + (rand % (max - min + 1)));
        }

        public int GetNext(int max)
        {
            int min = 0;
            var buffer = new byte[4];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buffer);
            }

            var rand = Math.Abs(BitConverter.ToInt32(buffer, 0));

            max -= 1;

            return Math.Abs(min + (rand % (max - min + 1)));
        }
    }
}
