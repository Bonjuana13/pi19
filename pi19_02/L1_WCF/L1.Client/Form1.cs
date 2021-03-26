using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ServiceReference1;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form
  {
        /// <summary>
        /// Текущая директория для удобства
        /// </summary>
        private const string currentDirectoty = "C:/Users/bonju/Desktop/study/2 курс/pi19/pi19_02/L1_WCF/Bibl2test";

        /// <summary>
        /// Для записи папки энциклопедии
        /// </summary>
        private string currentEnc;

        /// <summary>
        /// Для записи папки статьи
        /// </summary>
        private string currentShortFull;

        public Form1()
        {
          InitializeComponent();
        }

        /// <summary>
        /// Для обращения к сервису
        /// </summary>
        /// <returns></returns>
        private EncyclopediaServiceClient GetClient()
        {
            string sUrlService = "http://127.0.0.1:8000/Service1";
            BasicHttpContextBinding pBinding = new BasicHttpContextBinding();
            EndpointAddress pEndpointAddress = new EndpointAddress(sUrlService);
            EncyclopediaServiceClient pClient = new EncyclopediaServiceClient(pBinding, pEndpointAddress);
            return pClient;
        }

        #region TestThingsRegion
        /// <summary>
        /// Добавление данных из кода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetInfo_Click(object sender, EventArgs e)
        {
            /*GetClient().Test();*/

            //GetClient().GetArticle("", "");

            //краткие
            /*EncyclopediaArticleInfoType a1 = new EncyclopediaArticleInfoType()
            {
                NameShortArticle = "Муха - это...",
                NameFileFullArticle = "001.json",
                Notes = "Здесь рассказывается, кто такие мухи," +
                    "как ни странно.",
                Mark = 4.5,
                Tags = new string[] { "Мухи", "Кто это" }
            };
            EncyclopediaArticleInfoType a2 = new EncyclopediaArticleInfoType()
            {
                NameShortArticle = "Виды мух",
                NameFileFullArticle = "002.json",
                Notes = "О всех видах мух в мире.",
                Mark = 3,
                Tags = new string[] { "Виды мух", "Мухи" }
            };

            //разделы
            EncyclopediaPartType b1 = new EncyclopediaPartType()
            {
                Folder = "001",
                NameEncyclopediaPartType = "Кто такие эти мухи?", //раздел
                ArticleInfoList = new EncyclopediaArticleInfoType[] { a1, a2 }
            };


            EncyclopediaType encyclopediaType = new EncyclopediaType();
            encyclopediaType.Author = "Забияка";
            encyclopediaType.Title = "Как приручить муху"; //энциклопедия
            encyclopediaType.Publisher = "ООО Картошечка";
            encyclopediaType.Folder = "storage1";
            encyclopediaType.PartList = new EncyclopediaPartType[] { b1 };

            EncyclopediaType test = GetClient().GetInfo();

            //dataGridView1.Columns[0].HeaderText = "Тырыпыры";
            //returnTable.Columns.Add(new DataColumn("Name"));
            dataGridView1.Columns.Add("Title", "Титул");
            dataGridView1.Columns.Add("Author", "Автор");
            dataGridView1[0, 0].Value = test.Title.ToString();
            dataGridView1[1, 0].Value = test.Author.ToString();*/
        }

        /// <summary>
        /// Вывод текста тест
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestForDeserialize_Click(object sender, EventArgs e)
        {
            

        }

        /// <summary>
        /// Записывание полной статьи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            EncyclopediaArticleType encyclopediaArticleType = new EncyclopediaArticleType()
            {
                NameArticle = "Муха - это...",
                NameFileWithArticle = "001.json",
                NameFileWithImg = new string[] { "001.jpg", "001-1.jpg", "001-2.jpg" },
                Books = new string[] { "Джон Лангстафф: Лягушонок женится", "Виталий Бианки: Репортаж со стадиона Жукамо и другие лесные истории" },
                MainArticleText = ""
            };

            GetClient().Test2("C:/Users/bonju/Desktop/study/2 курс/pi19/pi19_02/L1_WCF/Bibl2test/storage1/001",
                encyclopediaArticleType);
            //"C:\Users\bonju\Desktop\study\2 курс\pi19\pi19_02\L1_WCF\Bibl2test\storage1\001"
        }


        #endregion

        /// <summary>
        /// Вывод разделов энциклопедии с возможностью перехода в краткую информацию по разделу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PartList_But_Click(object sender, EventArgs e)
        {
            try
            {
                NameEnc_label.Text = "";
                EncyclopediaType encyclopediaType = GetClient().GetInfo(currentDirectoty);
                NameEnc_label.Text += "Энциклопедия: " + encyclopediaType.Title + "\n" +
                    "Автор: " + encyclopediaType.Author + "\n" + "Издательство: " + encyclopediaType.Publisher;
                currentEnc = encyclopediaType.Folder;

                //для красоты
                dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
                dataGridView1.DataSource = encyclopediaType.PartList;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns[1].HeaderText = "Название раздела";
                //скрываем папку для дальнейшней передачи
                dataGridView1.Columns[0].Visible = false;

                //очистка других полей
                dataGridView2.DataSource = null;
                RTBFullArticle.Text = "";
            }
            catch
            {
                MessageBox.Show("Что-то явно пошло не по плану.", "Упс...", MessageBoxButtons.OK);
            }
            
        }

        /// <summary>
        /// При двойном нажатии на ячейку (для выбора раздела)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sDir = Path.Combine(currentDirectoty, currentEnc, dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
            EncyclopediaPartType encyclopediaPartType = GetClient().GetPart(sDir);
            //MessageBox.Show(encyclopediaPartType.ArticleInfoList[0].Tags.ToString());
            currentShortFull = encyclopediaPartType.Folder;

            dataGridView2.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dataGridView2.DataSource = encyclopediaPartType.ArticleInfoList;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns[0].HeaderText = "Оценка";
            dataGridView2.Columns[2].HeaderText = "Статья";
            dataGridView2.Columns[3].HeaderText = "Описание";
        }

        /// <summary>
        /// Выйти в разделы энциклопедии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToStart_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Открытие картинки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPhoto_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// При двойном нажатии на краткую информацию (выдача целой статьи)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sDir = Path.Combine(currentDirectoty, currentEnc, currentShortFull);

            EncyclopediaArticleType encyclopediaArticleType = GetClient().GetArticle(sDir, dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString());

            //получить строчку книг
            string allbooks = "";
            foreach (var item in encyclopediaArticleType.Books)
            {
                allbooks += item + "\n";
            }

            RTBFullArticle.Text = "Название статьи: " + encyclopediaArticleType.NameArticle + 
                "\n\n" + "Книги с дополнительной информацией: " + allbooks + 
                "\n" + "Текст статьи: " + encyclopediaArticleType.MainArticleText;
        }
    }
}
