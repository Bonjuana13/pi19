using L1.WcfServiceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L1.Server
{
    public partial class Form1 : Form
    {
        //Супер-пупер поле
        private ServiceHost m_pHost;

        public Form1()
        {
            InitializeComponent();

            //Чудо код
            string sUrlService = "http://127.0.0.1:8000/Service1";
            string sUrlServiceMeta = "http://127.0.0.1:8000/Service1/Meta";
            //Привязка для основного сервиса
            BasicHttpBinding pBinding = new BasicHttpBinding();
            pBinding.Security.Transport.ClientCredentialType =
            HttpClientCredentialType.None;
            pBinding.Security.Mode = BasicHttpSecurityMode.None;
            //Поведение для публикации информации о сервисе
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.HttpGetUrl = new Uri(sUrlServiceMeta);
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            //Создаем хост
            m_pHost = new ServiceHost(typeof(EncyclopediaService));
            m_pHost.Description.Behaviors.Add(smb);
            //Добавляем обслуживание основного функционала
            m_pHost.AddServiceEndpoint(typeof(IEncyclopediaService), pBinding, sUrlService);
            //Добавляем обслуживание публикации информации о сервисе
            m_pHost.AddServiceEndpoint(typeof(IMetadataExchange),
            MetadataExchangeBindings.CreateMexHttpBinding(), sUrlServiceMeta);
        }

        /// <summary>
        /// Кнопка запуска сервера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_But_Click(object sender, EventArgs e)
        {
            try
            {
                m_pHost.Open();
                Start_But.BackColor = Color.GreenYellow;
                Stop.BackColor = Color.IndianRed;
            }
            catch
            {
                MessageBox.Show("Ошибка", "Неизвестно.", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Кнопка выключения сервера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop_Click(object sender, EventArgs e)
        {
            try
            {
                m_pHost.Close();
                Start_But.BackColor = Color.IndianRed;
                Stop.BackColor = Color.GreenYellow;
            }
            catch
            {
                MessageBox.Show("Ошибка", "Неизвестно.", MessageBoxButtons.OK);
            }
        }
    }
}
