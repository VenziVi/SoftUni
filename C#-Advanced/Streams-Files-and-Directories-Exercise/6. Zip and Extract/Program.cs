using System;
using System.IO.Compression;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            using ZipArchive zipFile = ZipFile.Open("zipFile.zip", ZipArchiveMode.Create);
            ZipArchiveEntry zipArchiveEntry =
                zipFile.CreateEntryFromFile("copyMe.png", "copyMeEntry.png");
        }
    }
}
