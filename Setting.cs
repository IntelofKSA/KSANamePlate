using IniParser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSANamePlate
{
    public class Setting
    {
        public readonly Point Std1PictureLocation;
        public readonly Point Std2PictureLocation;
        public readonly Point PictureSize;

        public readonly Point Std1IDLocation;
        public readonly Point Std2IDLocation;
        public readonly Point Std1NameLocation;
        public readonly Point Std2NameLocation;

        public readonly string IDFontFamily;
        public readonly int IDFontSize;
        public readonly Color IDFontColor;
        public readonly string NameFontFamily;
        public readonly int NameFontSize;
        public readonly Color NameFontColor;

        public Setting(string std1pl, string std2pl, string ps, string std1idl, string std2idl,
            string std1nl, string std2nl, string idff, string idfs, string idfc, string nff,
            string nfs, string nfc)
        {
            Std1PictureLocation = std1pl.ToPoint();
            Std2PictureLocation = std2pl.ToPoint();
            PictureSize = ps.ToPoint();
            Std1IDLocation = std1idl.ToPoint();
            Std2IDLocation = std2idl.ToPoint();
            Std1NameLocation = std1nl.ToPoint();
            Std2NameLocation = std2nl.ToPoint();
            IDFontFamily = idff;
            IDFontColor = idfc.ToColor();
            NameFontFamily = nff;
            NameFontColor = nfc.ToColor();
            int.TryParse(idfs, out IDFontSize);
            int.TryParse(nfs, out NameFontSize);
        }

        public static Setting FromFile(string path)
        {
            FileIniDataParser iniParser = new FileIniDataParser();
            try
            {
                IniData setting = iniParser.LoadFile(path);
                return new Setting(setting["picture"]["std1location"], setting["picture"]["std2location"],
                    setting["picture"]["size"], setting["location"]["std1id"], setting["location"]["std2id"],
                    setting["location"]["std1name"], setting["location"]["std2name"], setting["font"]["idfamily"],
                    setting["font"]["idsize"], setting["font"]["idcolor"], setting["font"]["namefamily"],
                    setting["font"]["namesize"], setting["font"]["namecolor"]);
            }
            catch { return null; }
        }
    }
}
