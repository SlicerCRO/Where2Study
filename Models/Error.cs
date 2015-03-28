using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;

namespace Where2Study.Models
{
    public partial class drzava_tekst
    {
       public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(naziv))
                yield return new RuleViolation("Morate unijeti naziv države", "naziv");
            yield break;
        }

        partial void OnValidate(ChangeAction action);
        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }
    }

    public partial class grad_tekst
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(naziv))
                yield return new RuleViolation("Morate unijeti naziv grada", "naziv");
            yield break;
        }

        partial void OnValidate(ChangeAction action);
        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }
    }

    public partial class fakultet_tekst
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(naziv))
                yield return new RuleViolation("Morate unijeti naziv fakulteta", "naziv");
            yield break;
        }

        partial void OnValidate(ChangeAction action);
        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }
    }

    public partial class sveuciliste_tekst
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(naziv))
                yield return new RuleViolation("Morate unijeti naziv sveučilišta", "naziv");
            yield break;
        }

        partial void OnValidate(ChangeAction action);
        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }
    }

    public partial class smjer_tekst
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(tekst))
                yield return new RuleViolation("Morate unijeti naziv smjera", "tekst");
            yield break;
        }

        partial void OnValidate(ChangeAction action);
        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }
    }

    public class RuleViolation
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

    }
}