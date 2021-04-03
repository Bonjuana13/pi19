using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsApp1.ServiceReference1;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            //Стартовый размер формы
            this.Size = new Size(1430, 550);
            //Начальная страничка (чисто дял собственного комфорта)
            tabControl1.SelectedTab = tabPage2;

            //нужные блокировки для начала взаимодействия
            textBox1.ReadOnly = true;
            richTextBox2.ReadOnly = true;
            RTBFullArticle.ReadOnly = true;
            EditFullArticle_But.Enabled = false;
        }

        /// <summary>
        /// Для обращения к сервису
        /// </summary>
        /// <returns></returns>
        private EncyclopediaServiceClient GetClient()
        {
            string sUrlService = "http://127.0.0.1:8000/Service1";
            BasicHttpContextBinding pBinding = new BasicHttpContextBinding();

            //Увеличение количества возможных байтов для отправки
            ServicePointManager.CheckCertificateRevocationList = false;
            pBinding.MaxReceivedMessageSize = int.MaxValue;
            pBinding.Name = "BasicHttpBinding_IEncyclopediaService";
            pBinding.ReaderQuotas = XmlDictionaryReaderQuotas.Max;
            //pBinding.ReceiveTimeout = new TimeSpan(0, 3, 0);
            //pBinding.SendTimeout = new TimeSpan(0, 3, 0);

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

            //GetClient().Test2("C:/Users/bonju/Desktop/study/2 курс/pi19/pi19_02/L1_WCF/Bibl2test/storage1/001",
            //encyclopediaArticleType);
            //"C:\Users\bonju\Desktop\study\2 курс\pi19\pi19_02\L1_WCF\Bibl2test\storage1\001"
        }
        #endregion

        /// <summary>
        /// Нажатие на показать разделы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PartList_But_Click(object sender, EventArgs e)
        {
            try
            {
                EncyclopediaType encyclopediaType = GetClient().GetInfo();
                NameEnc_label.Text = "Энциклопедия: " + encyclopediaType.Title + "\n" +
                    "Автор: " + encyclopediaType.Author + "\n" + "Издательство: " + encyclopediaType.Publisher;

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
                pictureBox1.Image = null;
            }
            catch
            {
                MessageBox.Show("Что-то явно пошло не по плану.", "Упс...", MessageBoxButtons.OK);
            }

        }

        /// <summary>
        /// Открытие краткой информациидля последующего открытия статьи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                EncyclopediaPartType encyclopediaPartType = GetClient().GetPart(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());

                dataGridView2.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
                dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
                dataGridView2.DataSource = encyclopediaPartType.ArticleInfoList;

                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridView2.Columns["NameFileFullArticle"].DisplayIndex = 0;
                dataGridView2.Columns["NameShortArticle"].DisplayIndex = 1;
                dataGridView2.Columns["Notes"].DisplayIndex = 2;
                dataGridView2.Columns["Mark"].DisplayIndex = 3;

                dataGridView2.Columns["NameFileFullArticle"].Visible = false;
                dataGridView2.Columns["NameShortArticle"].HeaderText = "Название статьи";
                dataGridView2.Columns["Notes"].HeaderText = "Описание";
                dataGridView2.Columns["Mark"].HeaderText = "Оценка";

                //очистка других полей
                textBox1.Text = "";
                richTextBox2.Text = "";
                RTBFullArticle.Clear();
                pictureBox1.Image = null;
                dataGridView3.Rows.Clear();
                dataGridView3.Columns.Clear();
            }
            catch
            {
                MessageBox.Show("Что-то явно пошло не по плану.", "Упс...", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// При двойном нажатии на краткую информацию (выдача целой статьи)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                EncyclopediaArticleType encyclopediaArticleType = GetClient().GetArticle(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString(),
                dataGridView2["NameFileFullArticle", dataGridView2.CurrentRow.Index].Value.ToString());

                //получить строчку книг
                string allbooks = "";
                foreach (var item in encyclopediaArticleType.Books)
                {
                    allbooks += item + ";";
                }

                //вывод информации об энциклопедии
                textBox1.Text = encyclopediaArticleType.NameArticle;
                richTextBox2.Text = allbooks;
                RTBFullArticle.Text = encyclopediaArticleType.MainArticleText;

                //Очистка
                dataGridView3.Rows.Clear();
                dataGridView3.Columns.Clear();
                pictureBox1.Image = null;

                //Для выбора, какую картинку открыть
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView3.Columns.Add("NameFileWithImg", "Было");
                dataGridView3.Columns.Add("NamePhoto", "Выбор");
                int y = 1;
                foreach (var item in encyclopediaArticleType.NameFileWithImg)
                {
                    dataGridView3.Rows.Add(item, "Картинка " + y);
                    y++;
                }
                dataGridView3.Columns["NameFileWithImg"].Visible = false;
            }
            catch
            {
                MessageBox.Show("Что-то явно пошло не по плану.", "Упс...", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Выбор картинки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView3_CellMouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream(GetClient().GetImages(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString(),
                dataGridView3["NameFileWithImg", dataGridView3.CurrentRow.Index].Value.ToString()));
                Image returnImage = Image.FromStream(ms);
                pictureBox1.Image = returnImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
                MessageBox.Show("Что-то явно пошло не по плану.", "Упс...", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Добавить свою статью
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateFullArticle_But_Click(object sender, EventArgs e)
        {
            //с формы получить и Split
            List<string> ways = new List<string>();
            //ways.Add(@"D:\DELETE\123.jpg");
            ways.Add(@"D:\DELETE\222.jpg");

            //byte[] currentForTest = new byte[] { };
            //List<byte[]> byteArray = new List<byte[]>();

            foreach (var item in ways)
            {
                Image img = Image.FromFile(item);

                using (MemoryStream stream = new MemoryStream())
                {
                    img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //отправка
                    stream.Close();

                    //currentForTest = stream.ToArray();
                    //byteArray.Add(stream.ToArray());
                }
            }

            List<string> sBooks = new List<string>();
            sBooks.Add("Ни Сы. Хз кто ваще.");
            sBooks.Add("Вся история российского шоубизнеса. Местные критинки с широчайшего дивана.");

            #region test
            //GetClient().TestCreateWithoutMassiveOnlyMemory("002", "Дурочки и дураки.", "Все идиоты, пидорасы, гондурасы и ваще не понятные типы.", );
            //GetClient().CreateFullArticle("002", "Дурочки и дураки.", "Все идиоты, пидорасы, гондурасы и ваще не понятные типы.", sBooks.ToArray(), byteArray.ToArray());

            //отправка в метод

            /* EncyclopediaManager pManager = new EncyclopediaManager();*/

            /*List<string> listPictures = new List<string>();
            //Картинки
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\bonju\Desktop\study\2 курс\pi19\pi19_02\L1_WCF\Bibl2test\002");
            //максимальное айли картинки, чтобы создать еще одну
            int maxPictureId = 0;

            foreach (var item in directoryInfo.GetFiles())
            {
                if (item.Name.Substring(item.Name.Length - 4) == ".jpg" && Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 4)) > maxPictureId)
                {
                    maxPictureId = Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 4));
                }
            }

            foreach (var item in byteArray)
            {
                MemoryStream stream = new MemoryStream(item);
                Image addImage = Image.FromStream(stream);
                maxPictureId++;
                addImage.Save(@"C:\Users\bonju\Desktop\study\2 курс\pi19\pi19_02\L1_WCF\Bibl2test\002\" + maxPictureId + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                *//*pManager.Save(Path.Combine(MainStartFolder, sDirectoryCode, maxPictureId.ToString() + ".jpg"), addImage);*//*
                listPictures.Add(maxPictureId.ToString());
            }

            //перезапись в обычный массив
            string[] listPicturesArray = listPictures.ToArray();

            //получение файла для сохранения туда полной статьи
            int maxFileId = 0;
            foreach (var item in directoryInfo.GetFiles())
            {
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
                NameArticle = "Тырыпыры.",
                NameFileWithImg = listPicturesArray,
                Books = sBooks.ToArray(),
                MainArticleText = "ЛВПДОЫРИДЫОПРИОЫПРИЛОЫАРИПЛОПОИПОАРЛП",
                NameFileWithArticle = "100.json"
            };

            JsonSerializer pSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            });
            using (FileStream pF = File.Create(Path.Combine(@"C:\Users\bonju\Desktop\study\2 курс\pi19\pi19_02\L1_WCF\Bibl2test\002", "100.json")))
            {
                using (TextWriter pT = new StreamWriter(pF))
                {
                    pSerializer.Serialize(pT, encyclopediaArticleType);
                }
            }*/

            /*DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\bonju\Desktop\study\2 курс\pi19\pi19_02\L1_WCF\Bibl2test\002");
            int maxPictureId = 0;
            foreach (var item in directoryInfo.GetFiles())
            {
                if (item.Name.Substring(item.Name.Length - 4) == ".jpg" && Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 4)) > maxPictureId)
                {
                    maxPictureId = Convert.ToInt32(item.Name.Substring(0, item.Name.Length - 4));
                }
            }

            foreach (var item in byteArray)
            {
                MemoryStream stream1 = new MemoryStream(item);
                Image addImage = Image.FromStream(stream1);
                maxPictureId++;
                addImage.Save(@"C:\Users\bonju\Desktop\study\2 курс\pi19\pi19_02\L1_WCF\Bibl2test\002\" + maxPictureId.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }*/
            #endregion
        }

        /// <summary>
        /// Открыть возможность изменить статью
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WantToChangeFullArticle_Click(object sender, EventArgs e)
        {
            //открытие возможности изменения
            textBox1.ReadOnly = false;
            richTextBox2.ReadOnly = false;
            RTBFullArticle.ReadOnly = false;

            //кнопка
            EditFullArticle_But.Enabled = true;
        }

        /// <summary>
        /// Изменить статью + сделать сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditFullArticle_But_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && RTBFullArticle.Text != "" && richTextBox2.Text != "")
                {
                    //sBooks
                    List<string> books = new List<string>();
                    string[] splitBooks = richTextBox2.Text.Split(new char[]{ ';' });
                    foreach (var item in splitBooks)
                    {
                        books.Add(item);
                    }

                    GetClient().EditFullArticle(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString(),
                    dataGridView2["NameFileFullArticle", dataGridView2.CurrentRow.Index].Value.ToString(),
                    textBox1.Text, RTBFullArticle.Text, books.ToArray());

                    //закрытие взаимодействия заново после успешного прохода
                    textBox1.ReadOnly = true;
                    richTextBox2.ReadOnly = true;
                    RTBFullArticle.ReadOnly = true;
                    EditFullArticle_But.Enabled = false;

                    MessageBox.Show("Статья обновлена успешно!", "Успех!", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены.", "Пустота там, где не надо.", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Что-то явно пошло не по плану.", "Упс...", MessageBoxButtons.OK);
            }
        }
    }
}
