using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Where2Study.Models
{
    //public partial class Country
    //{
        //public string tekst { get; set; }     
        //public int id_drzava { get; set; }
        //public int id_jezik { get; set; }
        //public int Id { get; set; }

        /*public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }
        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(tekst))
                yield return new RuleViolation("Morate unijeti naziv države", "tekst");
            yield break;
        }*/

       /* partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }*/
    }

    

        /*public class RuleViolation
        {

            public string ErrorMessage { get; private set; }
            public string PropertyName { get; private set; }
            public RuleViolation(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
            public RuleViolation(string errorMessage, string propertyName)
            {
                ErrorMessage = errorMessage;
                PropertyName = propertyName;
            }
        }

        public static class ControllerHelpers
        {
            public static void AddRuleViolations(this ModelStateDictionary modelstate, IEnumerable<RuleViolation> errors)
            {

                foreach (RuleViolation issue in errors)
                {
                    modelstate.AddModelError(issue.PropertyName, issue.ErrorMessage);
                }
            }

        }*/
//}