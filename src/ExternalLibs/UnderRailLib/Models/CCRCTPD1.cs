﻿using System;
using System.Runtime.Serialization;
using UnderRailLib.AssemblyResolver;
using UnderRailLib.Models.Interfaces;

namespace UnderRailLib.Models
{
    [EncodedTypeName("CCRCTPD1")]
    [Serializable]
    public sealed class CCRCTPD1 : iLCPP, ISerializable
    {
        private CCRCTPD1(SerializationInfo info, StreamingContext ctx)
        {
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
