using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Where2Study.Models
{
    public partial class DegreeSpecialization
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public string Specialization { get; set; }
        public byte? Duration { get; set; }

        public IEnumerable DegSpecDetails(string faculty)
        {
            var db = new Where2Study.Models.w2sDataContext();
            var currentLanguage = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            var u = (from ft in db.fakultet_teksts
                     from f in db.fakultets
                     from j in db.jeziks
                     from s in db.stupanjs
                     from st in db.stupanj_teksts
                     from sm in db.smjers
                     from smt in db.smjer_teksts
                     from stsm in db.stupanj_smjers
                     where ft.naziv == faculty && j.kratica == currentLanguage && ft.id_fakultet == f.id && sm.id_fakultet == f.id && stsm.id_smjer == sm.id && ft.id_jezik == j.id
                     select new Where2Study.Models.DegreeSpecialization()
                     {
                         Degree = st.naziv,
                         Specialization = smt.tekst,
                     }).ToList();

            return u;
        }
    }
    public partial class DegreeSpecialization
    {
        public List<DegreeSpecialization> partialModel { get; set; }
    }
    


}