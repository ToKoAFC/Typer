using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Typer.Globals
{
    [DataContract]
    public enum PlayerPositionEnum
    {
        [EnumMember]
        Unknown = 0,
        [EnumMember]
        Goalkeeper = 1,
        [EnumMember]
        Defender = 2,
        [EnumMember]
        Middlefielder = 3,
        [EnumMember]
        Striker = 4
    }
}
