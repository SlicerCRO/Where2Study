using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using Where2Study.Models;

namespace Where2Study
{
    public class SiteLanguages
    {

        public static List<Languages> AvailableLanguages = new List<Languages>
        {
            /*new Languages{ LangFullName = "English", LangCultureName = "en"},
            new Languages{ LangFullName = "Hrvatski", LangCultureName = "hr"},*/
        };
        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguages.Where(a => a.LangCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return AvailableLanguages[0].LangCultureName;
        }

        public static void GetAllLanguages() 
        {
            AvailableLanguages.Clear();
            var db = new w2sDBDataContext();
            foreach (var item in db.jeziks) 
                foreach(var i in db.jezik_teksts) 
                    foreach(var j in db.jeziks)
        
                {
                    if (i.id_jezik == item.id && i.id_id == j.id && item.kratica == Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName) 
                        AvailableLanguages.Add(new Languages { LangCultureName = j.kratica, LangFullName = i.tekst }); 
                };
        }

        public void SetLanguage(string lang)
        {
            try
            {
                if (!IsLanguageAvailable(lang))
                    lang = GetDefaultLanguage();
                var cultureInfo = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                HttpCookie langCookie = new HttpCookie("_culture", lang);
                langCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(langCookie);
            }
            catch (Exception ex)
            {

            }
        }

      /*  public string GetLanguage()
        {
            return  HttpContext.Current.Response.Cookies.Get(0);
        }*/
    }

    public class Languages
    {
        public string LangFullName { get; set; }
        public string LangCultureName { get; set; }
    }
}