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
        ChessBoard,
        Winner
    }
    public enum PacketSendERROR
    {
        정상 = 0,
        에러
    }

    [Serializable]
    public class Packet
    {
        public int type;
        public Packet()
        {
            this.type = -1;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 5);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Desserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 5);
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
    public class SendMessage : Packet
    {
        public string msg;
        public SendMessage()
        {
            this.msg = null;
        }
        public SendMessage(string str)
        {
            this.msg = str;
        }
    }
    [Serializable]
    public class Square
    {
        public int rowNumber { get; set; }
        public int colNumber { get; set; }
        public bool IsPieceOn { get; set; }
        public bool IsExpected { get; set; }
        public ChessPiece pieceName { get; set; }
        public ChessPiece whoseExpected { get; set; }
        public ChessTeam team { get; set; }


        public Square(int i, int j)
        {
            rowNumber = i;
            colNumber = j;
        }

        public void clear() //make square having no piece
        {
            this.IsExpected = false;
            this.IsPieceOn = false;
            this.pieceName = ChessPiece.NONE;
            this.whoseExpected = ChessPiece.NONE;
            this.team = ChessTeam.NONE;
        }
    }
    [Serializable]
    public class ChessBoard : Packet
    {
        public Square[,] arr = new Square[8, 8];
        public ChessBoard()
        {
        }
        public ChessBoard(Square[,] arr)
        {
            this.arr = (Square[,])arr.Clone();
        }
    }

    [Serializable]
    public class Winner : Packet
    {
        public ChessTeam chessTeam;
        public Winner()
        {
            this.chessTeam = new ChessTeam();
        }
        public Winner(ChessTeam chessTeam)
        {
            this.chessTeam = chessTeam;
        }
    }

}
