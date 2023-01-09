using System;
//using System.IO;
using Assaignment_ConsoleApp;
using EntityMedical;
using RepoMedical1;
using UiMedical;
namespace EntityMedical
{
    class Diseases
    {
        public string Name { get; set; }
        public string Severity { get; set; }
        public string Cause { get; set; }
        public string Description { get; set; }

        public void shallowcopy(Diseases d1)
        {
            this.Name = d1.Name;
            this.Severity = d1.Severity;
            this.Cause = d1.Cause;
            this.Description = d1.Description;
        }
        public Diseases Deepcopy(Diseases obj)
        {
            Diseases d1 = new Diseases();
            d1.shallowcopy(obj);
            return d1;
        }

        public static implicit operator Diseases(Symptopms v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator string(Diseases v)
        {
            throw new NotImplementedException();
        }
    }
    class Symptopms
    {
        public string DiseaseName { get; set; }
        public string SympNAme { get; set; }
        public string description { get; set; }
    }
}

namespace RepoMedical1
{
    using EntityMedical;
    class RepoMedical
    {
        private Diseases[] distype = new Diseases[100];
        private Symptopms[] symptype = new Symptopms[100];

        public void AddDisease(Diseases data)
        {

            for (int i = 0; i < distype.Length; i++)
            {
                if (distype[i] == null)
                {
                    distype[i] = data.Deepcopy(data);
                    Console.WriteLine("data added successfully");
                    return;
                }
            }
        }
        public void AddSymptom(Symptopms data)
        {
            for (int i = 0; i < symptype.Length; i++)
            {
                if (symptype[i] == null)
                {
                    symptype[i] = new Symptopms {DiseaseName= data.DiseaseName,SympNAme= data.SympNAme,description = data.description};
                    Console.WriteLine("data added successfully");
                    return;
                }
            }
        }
        public void diseasefinder(string Name1)
        {
            string possibdisease = null;
            foreach (Diseases item in distype)
            {
                if(item != null && item.Name.Contains(Name1))
                {
                    possibdisease += item;
                }
                
            }
            Console.WriteLine($"posible disease for your { possibdisease}");
            //    Diseases data1 = distype[i];
            //    if (data1 != null && data1.Name.Contains(Name1))
            //    {
            //        Console.WriteLine("hai");
            //    }

            //}
            throw new Exception("disease not matched re-enter correctly");
            
        }

    }
}

namespace UiMedical
{
    //enum causes {internal ,external}
    class UIMedical
    {

        public static void Display()
        {
            Console.WriteLine("*******************Wel-Come to Medical Reasearch Application************************ \n1-Add Disease Details -------------------->Press 1\n" +
                "2-Add Symptom to Desease ----------------->Press 2 \n1-Check Patient -------------------------->Press 3 ");

            int choice = help.number("enter the selected number");

            switch (choice)
            {
                case 1:
                    DiseaseAddManager();
                    break;
                case 2:
                    SymptomAddManager();
                    break;
                case 3:
                    PatientManager();
                    break;
                default:
                    Console.WriteLine("invalid");
                    break;
            }
        }
        public static void DiseaseAddManager()
        {
            RepoMedical repo = new RepoMedical();
            string name = help.text("Enter Disease Name");
            string severity = help.text("enter the severity ");
            string cause = help.text("enter the cause");
            string description = help.text("description in 30 charecters");
            Diseases data = new Diseases { Name = name, Severity = severity, Cause = cause, Description = description };
            repo.AddDisease(data);
            help.text("enter to clear the field");

            Console.Clear();
            Display();
        }

        public static void SymptomAddManager()
        {
            RepoMedical repo = new RepoMedical();
            string DisName = help.text("enter the Disease name");
            string Symptom = help.text("enter symptopms");
            string description1 = help.text("description");

            Symptopms data = new Symptopms { DiseaseName = DisName, SympNAme = Symptom, description = description1 };
            repo.AddSymptom(data);
            help.text("enter to clear the field");
            Console.Clear();
            Display();
        }

        public static void PatientManager()
        {
            RepoMedical repo = new RepoMedical();
            string name = help.text("enter the patient name");
            string symptoms = help.text("enter the symptoms of patients");

            repo.diseasefinder(symptoms);
            help.text("enter to clear the field");
           Console.Clear();
           Display();
        }


    }
}



namespace Assaignment_ConsoleApp
{
    class MainClassStart
    {
        static void Main(string[] args)
        {
            UIMedical.Display();
        }
    }
}
