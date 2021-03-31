using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using L1.WcfServiceLibrary.Manager;

namespace L1.WcfServiceLibrary
{
    public class EncyclopediaService : IEncyclopediaService
    {
        /// <summary>
        /// Стартовая директория
        /// </summary>
        private const string MainStartFolder = "C:/Users/bonju/Desktop/study/2 курс/pi19/pi19_02/L1_WCF/Bibl2test";

        /// <summary>
        /// Получение списка категорий и информации о энциклопедии
        /// </summary>
        /// <returns></returns>
        public EncyclopediaType GetInfo()
        {
            EncyclopediaManager pManager = new EncyclopediaManager();
            EncyclopediaType pEncyclopedia = pManager.Load(MainStartFolder);
            return pEncyclopedia;
        }

        /// <summary>
        /// Получить информацию по разделу энциклопедии
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public EncyclopediaPartType GetPart(string sDirectoryCode)
        {
            EncyclopediaManager pManager = new EncyclopediaManager();
            EncyclopediaPartType encyclopediaPartType = pManager.Load(MainStartFolder, sDirectoryCode);
            return encyclopediaPartType;
        }

        /// <summary>
        /// Получить полную словарную статью
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public EncyclopediaArticleType GetArticle(string sDirectoryCode, string sFileNameCode)
        {
            EncyclopediaManager pManager = new EncyclopediaManager();
            EncyclopediaArticleType encyclopediaArticleType = pManager.Load(MainStartFolder, sDirectoryCode, sFileNameCode);
            return encyclopediaArticleType;
        }

        /// <summary>
        /// Получение картинки
        /// </summary>
        /// <param name="sDirectoryCode"></param>
        /// <param name="sImgNameCode"></param>
        /// <returns></returns>
        public byte[] GetImages(string sDirectoryCode, string sImgNameCode)
        {
            Image img = Image.FromFile(Path.Combine(MainStartFolder, sDirectoryCode, sImgNameCode + ".jpg"));
            byte[] byteArray = new byte[1000000];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();

                byteArray = stream.ToArray();
            }

            return byteArray;
        }

        /// <summary>
        /// Добавить новую полную статью
        /// </summary>
        /// <param name="sDirectoryCode"></param>
        /// <param name="sFileNameCode"></param>
        public void CreateFullArticle(string sDirectoryCode, string sNameFullAtricle, string sText, string[] sBooks, List<byte[]> sPictures)
        {
            EncyclopediaManager pManager = new EncyclopediaManager();

            List<string> listPictures = new List<string>();
            //Картинки
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(MainStartFolder, sDirectoryCode));
            //максимальное айли картинки, чтобы создать еще одну
            int maxPictureId = 0;

            foreach (var item in directoryInfo.GetFiles())
            {
                if (item.Name.Substring(item.Name.Length - 4) == ".jpg" && Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 4)) > maxPictureId)
                {
                    maxPictureId = Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 4));
                }
            }

            foreach (var item in sPictures)
            {
                MemoryStream stream = new MemoryStream(item);
                Image addImage = Image.FromStream(stream);
                maxPictureId++;
                pManager.Save(Path.Combine(MainStartFolder, sDirectoryCode, maxPictureId.ToString() + ".jpg"), addImage);
                listPictures.Add(maxPictureId.ToString());
            }

            //перезапись в обычный массив
            string[] listPicturesArray = listPictures.ToArray();

            //получение файла для сохранения туда полной статьи
            int maxFileId = 0;
            foreach (var item in directoryInfo.GetFiles())
            {
                //во избежании ошибки
                if (item.Name.Substring(0, 4) != "info")
                {
                    if (item.Name.Substring(item.Name.Length - 5) == ".json" && Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 5)) > maxFileId)
                    {
                        maxFileId = Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 5));
                    }
                }
            }

            EncyclopediaArticleType encyclopediaArticleType = new EncyclopediaArticleType()
            {
                NameArticle = sNameFullAtricle,
                NameFileWithImg = listPicturesArray,
                Books = sBooks,
                MainArticleText = sText,
                NameFileWithArticle = "100.json"
            };

            pManager.Save(Path.Combine(MainStartFolder, sDirectoryCode), encyclopediaArticleType);

            //добавление в info.json


            //добавление в storage.json

        }

        public void TestCreateWithoutMassiveOnlyMemory(string sDirectoryCode, string sNameFullAtricle, string sText, MemoryStream sPictures)
        {
            EncyclopediaManager pManager = new EncyclopediaManager();

            List<string> listPictures = new List<string>();
            //Картинки
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(MainStartFolder, sDirectoryCode));
            //максимальное айли картинки, чтобы создать еще одну
            int maxPictureId = 0;

            foreach (var item in directoryInfo.GetFiles())
            {
                if (item.Name.Substring(item.Name.Length - 4) == ".jpg" && Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 4)) > maxPictureId)
                {
                    maxPictureId = Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 4));
                }
            }

            Image addImage = Image.FromStream(sPictures);
            maxPictureId++;
            pManager.Save(Path.Combine(MainStartFolder, sDirectoryCode, maxPictureId.ToString() + ".jpg"), addImage);
            listPictures.Add(maxPictureId.ToString());

            //перезапись в обычный массив
            string[] listPicturesArray = listPictures.ToArray();

            //получение файла для сохранения туда полной статьи
            int maxFileId = 0;
            foreach (var item in directoryInfo.GetFiles())
            {
                //во избежании ошибки
                if (item.Name.Substring(0, 4) != "info")
                {
                    if (item.Name.Substring(item.Name.Length - 5) == ".json" && Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 5)) > maxFileId)
                    {
                        maxFileId = Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 5));
                    }
                }
            }

            EncyclopediaArticleType encyclopediaArticleType = new EncyclopediaArticleType()
            {
                NameArticle = sNameFullAtricle,
                NameFileWithImg = listPicturesArray,
                MainArticleText = sText,
                NameFileWithArticle = "100.json"
            };

            pManager.Save(Path.Combine(MainStartFolder, sDirectoryCode), encyclopediaArticleType);

            //добавление в info.json


            //добавление в storage.json

        }

        public void AddPictureToServer(string sDirectoryCode, MemoryStream sPicture)
        {
            EncyclopediaManager pManager = new EncyclopediaManager();

            List<string> listPictures = new List<string>();
            //Картинки
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(MainStartFolder, sDirectoryCode));
            //максимальное айли картинки, чтобы создать еще одну
            int maxPictureId = 0;

            foreach (var item in directoryInfo.GetFiles())
            {
                if (item.Name.Substring(item.Name.Length - 4) == ".jpg" && Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 4)) > maxPictureId)
                {
                    maxPictureId = Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 4));
                }
            }

            Image addImage = Image.FromStream(sPicture);
            maxPictureId++;
            pManager.Save(Path.Combine(MainStartFolder, sDirectoryCode, maxPictureId.ToString() + ".jpg"), addImage);
        }

        /// <summary>
        /// Изменить полную статью
        /// </summary>
        /// <param name="sDirectoryCode"></param>
        /// <param name="sFileNameCode"></param>
        public void EditFullArticle(string sDirectoryCode, EncyclopediaArticleType changedFullArticle)
        {
            EncyclopediaManager pManager = new EncyclopediaManager();
            pManager.Save(sDirectoryCode, changedFullArticle);
        }
    }
}
