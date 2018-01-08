﻿using System;
using Microsoft.Data.Sqlite;

namespace Borzoo.Data.SQLite
{
    public static class Extensions
    {
        private static readonly DateTime UnixEpochBase = new DateTime(1970, 1, 1);

        public static long ToUnixEpoch(this DateTime dateTime)
        {
            var diff = dateTime - UnixEpochBase;
            if (diff.Milliseconds < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return (long) diff.TotalMilliseconds;
        }

        public static DateTime FromUnixEpoch(this long epochTime)
            => new DateTime(UnixEpochBase.Ticks, DateTimeKind.Utc).AddMilliseconds(epochTime);
    }
}