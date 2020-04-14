using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace player
{
    public struct MP3Info
    {
        public string Title;
        public string Singer;
        public string Album;
        public string Year;
        public string Comment;

        public override string ToString()
        {

            string ret = "MP3附加信息:" + Environment.NewLine +
             "-----------------------------" + Environment.NewLine +
             "标 题: " + Title + Environment.NewLine +
             "歌 手: " + Singer + Environment.NewLine +
             "唱片集: " + Album + Environment.NewLine +
             "出版年份: " + Year + Environment.NewLine +
             "备　注: " + Comment;
            return ret;
        }
    }




	public class MP3Helper
	{
       
        public static byte[] extractFrontPage(string path)
        {
            //提取封面
            TagLib.File mp3 = TagLib.File.Create(path);
            if (mp3.Tag.Pictures.Length >= 1)
            {
                //tag中的图片信息为byte数组，需要用函数进行转化
                byte[] bin = mp3.Tag.Pictures[0].Data.Data;

                //pictureBox2.Image = ReturnPhoto(bin);//转化函数
                return bin;
            }
            return null;

        }
        public static BitmapSource LoadImage(Byte[] imageData)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                var decoder = BitmapDecoder.Create(ms,
                    BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                return decoder.Frames[0];
            }
        }
        public static MP3Info ReadMP3Info(string path)
        {
                 
            


            try
            {
               
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    
                    return StreamHandler(fs);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return default(MP3Info);
        }
        public static MP3Info ReadMP3Info(Stream stream)
        {
            return StreamHandler(stream);
        }
        private static MP3Info StreamHandler(Stream stream)
        {
            byte[] b = new byte[128];
            MP3Info mp3struct = new MP3Info();

            stream.Read(b, 0, 10);
            string MP3Flag1 = System.Text.Encoding.GetEncoding("GBK").GetString(b, 0, 10);

            stream.Seek(-128, SeekOrigin.End);
            
            stream.Read(b, 0, 128);
            
            string MP3Flag = System.Text.Encoding.Default.GetString(b, 0, 3);
           
            if (MP3Flag == "TAG")
            {
                mp3struct.Title = System.Text.Encoding.GetEncoding("GBK").GetString(b, 3, 30);
                mp3struct.Singer = System.Text.Encoding.GetEncoding("GBK").GetString(b, 33, 30);
                mp3struct.Album = System.Text.Encoding.GetEncoding("GBK").GetString(b, 63, 30);
                mp3struct.Year = System.Text.Encoding.GetEncoding("GBK").GetString(b, 93, 4);
                mp3struct.Comment = System.Text.Encoding.GetEncoding("GBK").GetString(b, 97, 30);
                if(mp3struct.Singer.Contains("\0") || mp3struct.Album.Contains("\0"))
                {
                    mp3struct = UseGbk(mp3struct,b);
                }
                
            }
            return mp3struct;
        }
        private static MP3Info UseGbk(MP3Info input,byte[] b)
        {
            input.Title = System.Text.Encoding.GetEncoding("GBK").GetString(b, 3, 30);
            input.Singer = System.Text.Encoding.GetEncoding("GBK").GetString(b, 33, 30);
            input.Album = System.Text.Encoding.GetEncoding("GBK").GetString(b, 63, 30);
            input.Year = System.Text.Encoding.GetEncoding("GBK").GetString(b, 93, 4);
            input.Comment = System.Text.Encoding.GetEncoding("GBK").GetString(b, 97, 30);
            return input;
        }
    }
}
