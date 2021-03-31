using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace L1.WcfServiceLibrary
{
    /// <summary>
    /// Сервис "Электронная энциклопедия"
    /// </summary>
    [ServiceContract]
    public interface IEncyclopediaService
    {
        /// <summary>
        /// Получение списка категорий и информации о энциклопедии
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        EncyclopediaType GetInfo();

        /// <summary>
        /// Получить информацию по разделу энциклопедии
        /// </summary>
        /// <param name="sDirectoryCode"></param>
        /// <returns></returns>
        [OperationContract]
        EncyclopediaPartType GetPart(string sDirectoryCode); //папка

        /// <summary>
        /// Получить полную словарную статью
        /// </summary>
        /// <param name="sDirectoryCode"></param>
        /// <param name="sFileNameCode"></param>
        /// <returns></returns>
        [OperationContract]
        EncyclopediaArticleType GetArticle(string sDirectoryCode, string sFileNameCode); //полная статья файл

        /// <summary>
        /// Картинки
        /// </summary>
        /// <param name="sDirectoryCode"></param>
        /// <param name="sFileNameCode"></param>
        /// <returns></returns>
        [OperationContract]
        byte[] GetImages(string sDirectoryCode, string sImgNameCode);

        /// <summary>
        /// Сохранение полной статьи
        /// </summary>
        /// <param name="sDirectoryCode"></param>
        /// <param name="sNameFullAtricle"></param>
        /// <param name="sText"></param>
        /// <param name="sBooks"></param>
        /// <param name="sPictures"></param>
        [OperationContract]
        void CreateFullArticle(string sDirectoryCode, string sNameFullAtricle, string sText, string[] sBooks, List<byte[]> sPictures);

        /// <summary>
        /// Test
        /// </summary>
        /// <param name="sDirectoryCode"></param>
        /// <param name="sNameFullAtricle"></param>
        /// <param name="sText"></param>
        /// <param name="sBooks"></param>
        /// <param name="sPictures"></param>
        [OperationContract]
        void TestCreateWithoutMassiveOnlyMemory(string sDirectoryCode, string sNameFullAtricle, string sText, MemoryStream sPictures);

        /// <summary>
        /// Изменение полной статьи
        /// </summary>
        /// <param name="sDirectoryCode"></param>
        /// <param name="changedEncyclopedia"></param>
        [OperationContract]
        void EditFullArticle(string sDirectoryCode, EncyclopediaArticleType createdChangedEncyclopedia);

        [OperationContract]
        void AddPictureToServer(string sDirectoryCode, MemoryStream sPicture);
    }

    /// <summary>
    /// Энциклопедия
    /// </summary>
    [DataContract]
    public class EncyclopediaType
    {
        /// <summary>
        /// Название энциклопедии
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Автор
        /// </summary>
        [DataMember]
        public string Author { get; set; }

        /// <summary>
        /// Издательство, выпускающее энциклопедию
        /// </summary>
        [DataMember]
        public string Publisher { get; set; }

        /// <summary>
        /// Имя папки
        /// </summary>
        [DataMember]
        public string Folder { get; set; } //storage1, storage2 ...

        /// <summary>
        /// Список разделов энциклопедии
        /// </summary>
        [DataMember]
        public EncyclopediaPartType[] PartList { get; set; } //001, 002 ...
    }

    /// <summary>
    /// Раздел энциклопедии
    /// </summary>
    [DataContract]
    public class EncyclopediaPartType
    {
        /// <summary>
        /// Список всех кратких информаций энциклопедии внутри файла info.json
        /// </summary>
        [DataMember]
        public EncyclopediaArticleInfoType[] ArticleInfoList { get; set; }

        /// <summary>
        /// Имя папки
        /// </summary>
        [DataMember]
        public string Folder { get; set; } //001

        /// <summary>
        /// Название раздела
        /// </summary>
        [DataMember]
        public string NameEncyclopediaPartType { get; set; }

    }

    /// <summary>
    /// Краткая информация о статье энциклопедии
    /// </summary>
    [DataContract]
    public class EncyclopediaArticleInfoType
    {
        /// <summary>
        /// Название статьи
        /// </summary>
        [DataMember]
        public string NameShortArticle { get; set; }

        /// <summary>
        /// Названия файла с полной статьей для дальнейшего поиска
        /// </summary>
        [DataMember]
        public string NameFileFullArticle { get; set; }

        /// <summary>
        /// Краткое описание статьи
        /// </summary>
        [DataMember]
        public string Notes { get; set; }

        /// <summary>
        /// Оценка диванного критика
        /// </summary>
        [DataMember]
        public double Mark { get; set; }
    }

    /// <summary>
    /// Полная статья энциклопедии с иллюстрацией
    /// </summary>
    [DataContract]
    public class EncyclopediaArticleType
    {
        /// <summary>
        /// Название файла, содержащего статью
        /// </summary>
        [DataMember]
        public string NameFileWithArticle { get; set; }

        /// <summary>
        /// Название статьи
        /// </summary>
        [DataMember]
        public string NameArticle { get; set; }

        /// <summary>
        /// Название файла с картинкой (массив)
        /// </summary>
        [DataMember]
        public string[] NameFileWithImg { get; set; }

        /// <summary>
        /// Рекомендуемые книжки для прочтения
        /// </summary>
        [DataMember]
        public string[] Books { get; set; }

        /// <summary>
        /// Сам текст статьи
        /// </summary>
        [DataMember]
        public string MainArticleText { get; set; }
    }
}
