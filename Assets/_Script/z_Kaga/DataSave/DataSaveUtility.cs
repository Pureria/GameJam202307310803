using System.IO;
using System.Text;
using UnityEngine;
using Object = System.Object;


namespace GJ.DataSave
{
    public class DataSaveUtility
    {
        /* NOTE ---------------------------------------------------------------+
         * ★ Save() / Load() 共通 filePath 引数についての注意点 ★
         * 
         * 
         * ・filePath は保存先のファイル名まで含みます.
         * 
         * ・filePath は拡張子も含んでください.
         * 
         * ・filePath の最初の文字に "/" や "\" は含まないでください.
         * 
         * ・filePath は Appdata/LocalLow/<CompanyName>/<ProductName>/ を
         * 　ルートとする相対パスを指定してください.
        /* -------------------------------------------------------------------*/

        public static void Save(Object saveTarget, string filePath)
        {
            var jsonString = JsonUtility.ToJson(saveTarget);
            var baseDir = Application.persistentDataPath;
            var savePath = $"{baseDir}/{filePath}";
            var encoding = Encoding.UTF8;
            var writer = new StreamWriter(savePath, false, encoding);

            writer.Write(jsonString);
            writer.Close();
        }


        public static T Load<T>(string filePath)
        where T : class
        {
            var baseDir = Application.persistentDataPath;
            var loadPath = $"{baseDir}/{filePath}";
            var encoding = Encoding.UTF8;

            if (!File.Exists(loadPath)) return null;

            var reader = new StreamReader(loadPath, encoding);
            var json = reader.ReadToEnd();
            reader.Close();

            return JsonUtility.FromJson<T>(json);
        }
    }
}