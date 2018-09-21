using System;
using System.Collections.Generic;
using System.Linq;

namespace Everhour.Net.Models
{
    [Flags]
    public enum ExportAllTeamTimeField
    {
        USER = 1,
        PROJECT = 1 << 1,
        DATE = 1 << 3,
        TASK = 1 << 4,
    }

    static internal class ExportAllTeamTimeFieldExtensions
    {
        public static string ToLower(this ExportAllTeamTimeField field)
        {
            return field.ToString().ToLower();
        }
    }
}