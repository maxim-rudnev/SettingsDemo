﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SettingsDemo
{
    /// <summary>
    /// Класс для работы работы с настройками приложения
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Функция получения данных настроек приложения из файла
        /// </summary>
        /// <returns></returns>
        public static Settings GetSettings()
        {
            Settings settings = null;
            string filename = Globals.SettingsFile;

            //проверка наличия файла
            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer xser = new XmlSerializer(typeof(Settings));
                    settings = (Settings)xser.Deserialize(fs);
                    fs.Close();
                }
            }
            else
            {
                settings = new Settings();
            }

            return settings;
        }

        /// <summary>
        /// Процедура сохранения настроек в файл
        /// </summary>
        public void Save()
        {
            string filename = Globals.SettingsFile;

            if (File.Exists(filename)) File.Delete(filename);


            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Settings));
                xser.Serialize(fs, this);
                fs.Close();
            }
        }


        public string Name { get; set; }

        public string Familyname { get; set; }

        public string Secondname { get; set; }
    }
}
