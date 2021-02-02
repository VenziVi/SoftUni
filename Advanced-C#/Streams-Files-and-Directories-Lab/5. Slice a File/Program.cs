using System;
using System.Collections.Generic;
using System.IO;

namespace _5._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = 4;

            using (FileStream textReader = new FileStream("../../../input.txt"
                ,FileMode.Open))
            {
                long pieceSize = (long)Math.Ceiling((double)textReader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long count = 0;
                    byte[] buffer = new byte[1];
                    using (var createFile = new FileStream($"../../../slice{i + 1}",FileMode.Create, FileAccess.Write))
                    { 
                        while (count < pieceSize)
                        {
                            textReader.Read(buffer, 0 , buffer.Length);
                            createFile.Write(buffer, 0, buffer.Length);
                            count += buffer.Length;

                             if (textReader.Position != textReader.Length && i == 3)
                             {
                                 int remainingBytes = (int)textReader.Length - (int)textReader.Position;
                                 byte[] lastBuffer = new byte[remainingBytes];
                                 textReader.Read(lastBuffer, 0, remainingBytes);
                                 createFile.Write(lastBuffer, 0, lastBuffer.Length);
                             }
                        }
                    }
                }
            }
        }
    }
}
