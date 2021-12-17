using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions._16.Objects
{
    public class PacketDecoder
    {
        public static long BinarystringToLong(string binarystring)
        {
            long length = binarystring.Length;
            long sum = 0;
            long i = 1;
            foreach (char c in binarystring)
            {
                if (c == '1')
                {
                    sum += (long)Math.Pow(2, length - i);
                }
                i++;
            }

            return sum;
        }

        public List<Packet> DecodeFromHex(string inputInHex, bool ispart2 = false)
        {
            string bytes = "";
            foreach (char c in inputInHex)
            {
                bytes += HexToBytes(c);
            }
            if(ispart2)
                return DecodePt2(bytes);
            return Decode(bytes);
        }

        public static List<Packet> Decode(string bytes)
        {
            List<Packet> packets = new List<Packet>();            

            int i = 0;
            Stack<OperatorPacket> operators = new Stack<OperatorPacket>();

            while(i < bytes.Length - 7)
            {
                if (bytes.Substring(i+3, 3) == "100")
                {
                    // numeric packet
                    int packetLength = i+6;
                    while (bytes.Substring(packetLength, 1) != "0")
                    {
                        packetLength += 5;
                    }
                    packetLength += 5;
                    var packet = new ValuePacket(bytes.Substring(i, packetLength - i));
                    packets.Add(packet);
                    if (operators.Count > 0)
                    {
                        var operatorPacket = operators.Pop();
                        operatorPacket.SubPackets.Add(packet);
                    }

                    i = packetLength;
                }
                else
                {
                    int length = 15;
                    if (bytes.Substring(i + 6, 1) == "1")
                        length = 11;
                    int amntOfSubpackets = (int) BinarystringToLong(bytes.Substring(i+7,length));

                    var packet = new OperatorPacket(bytes.Substring(i, 7+length));
                    packets.Add(packet);

                    if (operators.Count > 0)
                    {
                        var operatorPacket = operators.Pop();
                        operatorPacket.SubPackets.Add(packet);
                    }

                    for (int j = 0; j < amntOfSubpackets; j++)
                    {
                        operators.Push(packet);
                    }

                    i += 7 + length;
                }
            }
            return packets;
        }


        Stack<OperatorPacket> operators;
        List<Packet> packets = new List<Packet>();
        public List<Packet> DecodePt2(string bytes)
        {
            packets = new List<Packet>();
            operators = new Stack<OperatorPacket>();

            int i = 0;
            
            while (i < bytes.Length - 6)
            {
                if (bytes.Substring(i + 3, 3) == "100")
                {
                    // numeric packet
                    int packetLength = i + 6;
                    while (bytes.Substring(packetLength, 1) != "0")
                    {
                        packetLength += 5;
                    }
                    packetLength += 5;
                    var packet = new ValuePacket(bytes.Substring(i, packetLength - i));

                    AddPacketToPeer(packet, i);

                    i = packetLength;
                }
                else
                {
                    int length = 11;
                    bool useBitlength = false;
                    if (bytes.Substring(i + 6, 1) == "0")
                    {
                        length = 15;
                        useBitlength = true;
                    }
                    int amntOfSubpackets = (int)BinarystringToLong(bytes.Substring(i + 7, length));

                    var packet = new OperatorPacket(bytes.Substring(i, 7 + length));
                    packet.amountOfSubpackets = amntOfSubpackets;
                    packet.UseLength = useBitlength;

                    AddPacketToPeer(packet, i);                   

                    if (useBitlength)
                        packet.amountOfSubpackets = i + 7 + length + amntOfSubpackets;
                    operators.Push(packet);
                    i += 7 + length;
                }
            }
            long value = packets[0].GetValue();
            return packets;
        }

        private void AddPacketToPeer(Packet packet, int i)
        {
            while (operators.Any())
            {
                var operatorpkt = operators.Peek();
                if (operatorpkt.UseLength && i < operatorpkt.amountOfSubpackets)
                    break;
                else if (!operatorpkt.UseLength && operatorpkt.SubPackets.Count < operatorpkt.amountOfSubpackets)
                    break;
                operators.Pop();
            }

            if (operators.Count != 0)
            {
                operators.Peek().SubPackets.Add(packet);
            }
            else
                packets.Add(packet);
        }

        public static string HexToBytes(char input)
        {
            switch (input)
            {
                case '0':
                    return "0000";
                case '1':
                    return "0001";
                case '2':
                    return "0010";
                case '3':
                    return "0011";
                case '4':
                    return "0100";
                case '5':
                    return "0101";
                case '6':
                    return "0110";
                case '7':
                    return "0111";
                case '8':
                    return "1000";
                case '9':
                    return "1001";
                case 'A':
                    return "1010";
                case 'B':
                    return "1011";
                case 'C':
                    return "1100";
                case 'D':
                    return "1101";
                case 'E':
                    return "1110";
                case 'F':
                    return "1111";
            }
            return "";
        }

    }
}
