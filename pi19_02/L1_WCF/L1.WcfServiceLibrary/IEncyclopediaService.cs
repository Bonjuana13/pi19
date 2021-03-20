using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
        /// <param name="sCode"></param>
        /// <returns></returns>
        [OperationContract]
        EncyclopediaPartType GetPart(string sCode);

        /// <summary>
        /// Получить полную словарную статью
        /// </summary>
        /// <param name="sPart"></param>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [OperationContract]
        EncyclopediaArticleType GetArticle(string sPart, string sCode);
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
        /// Список разделов энциклопедии
        /// </summary>
        [DataMember]
        public EncyclopediaPartType[] PartList { get; set; }

        //TODO

        //Автор
        [DataMember]
        public string Author { get; set; }

        //Год публикации
        [DataMember]
        public string YearOfPublication { get; set; }
    }

    /// <summary>
    /// Раздел энциклопедии
    /// </summary>
    [DataContract]
    public class EncyclopediaPartType
    {
        /// <summary>
        /// Список (под)разделов энциклопедии
        /// </summary>
        [DataMember]
        public EncyclopediaArticleInfoType[] ArticleInfoList { get; set; }

        /// <summary>
        /// Имя папки
        /// </summary>
        [DataMember]
        public string Folder { get; set; }
        
        // TODO

        //Описание раздела
        [DataMember]
        public string Description { get; set; }

        //Массив полных статьей внутри раздела
        [DataMember]
        public EncyclopediaArticleType[] FullArticleInfoList { get; set; }


    }

    /// <summary>
    /// Краткая информация о статье энциклопедии
    /// </summary>
    [DataContract]
    public class EncyclopediaArticleInfoType
    {
        // TODO

        //Название файла с краткой инфой
        [DataMember]
        public string ShortArticleName { get; set; }

        //Тэги для быстрого поиска
        [DataMember]
        public string[] Tags { get; set; }


    }

    /// <summary>
    /// Полная статья энциклопедии с иллюстрацией
    /// </summary>
    [DataContract]
    public class EncyclopediaArticleType
    {
        // TODO

        //Название файла, содержащего статью
        public string NameFileWithArticle { get; set; }

        //Название файла с картинкой (массив)
        public string[] NameFileWithImg { get; set; }

        //Ссылки (массив) списки литературы внешних источников
        public string[] URLs { get; set; }
    }
}
