using DBtest.chess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public enum PacketType
    {
        Message,
        ChessBoard
    }
    public class Packet
    {
        public int type;
        public Packet()
        {
            this.type = -1;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Desserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach (byte b in bt)
            {
                ms.WriteByte(b);
            }
            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }

    [Serializable]
    public class Message : Packet
    {
        public string msg;
        public Message()
        {
            this.msg = null;
        }
        public Message(string str)
        {
            this.msg = str;
        }
    }
    [Serializable]
    public class ChessBoard : Packet
    {
        public Square[,] arr = new Square[8, 8];
        public ChessBoard()
        {
            this.arr = null;
        }
        public ChessBoard(Square [,] arr)
        {
            this.arr = (Square[,])arr.Clone();
        }
    }

}
