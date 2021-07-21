//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.MissionManagement
{
    public class MPerceptionResult : Message
    {
        public const string RosMessageName = "mission_management/PerceptionResult";

        public MHeader header;
        //  List of cones that were perceived
        public MCone[] cones;

        public MPerceptionResult()
        {
            this.header = new MHeader();
            this.cones = new MCone[0];
        }

        public MPerceptionResult(MHeader header, MCone[] cones)
        {
            this.header = header;
            this.cones = cones;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(header.SerializationStatements());
            
            listOfSerializations.Add(BitConverter.GetBytes(cones.Length));
            foreach(var entry in cones)
                listOfSerializations.Add(entry.Serialize());

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.header.Deserialize(data, offset);
            
            var conesArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.cones= new MCone[conesArrayLength];
            for(var i = 0; i < conesArrayLength; i++)
            {
                this.cones[i] = new MCone();
                offset = this.cones[i].Deserialize(data, offset);
            }

            return offset;
        }

        public override string ToString()
        {
            return "MPerceptionResult: " +
            "\nheader: " + header.ToString() +
            "\ncones: " + System.String.Join(", ", cones.ToList());
        }
    }
}