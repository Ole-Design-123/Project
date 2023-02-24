using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppITInfo.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Question_Paper
    {
        public Question1 Question1 { get; set; }
        public Question2 Question2 { get; set; }
        public Question3 Question3 { get; set; }
        public Question4 Question4 { get; set; }
        public Question5 Question5 { get; set; }
        public Question6 Question6 { get; set; }
        public Question7 Question7 { get; set; }
        public Question8 Question8 { get; set; }
        public object QuePaperName { get; set; }
    }

    public class Question1
    {
        public string Q1Question1 { get; set; }
        public string Q1Question2 { get; set; }
        public string Q1Question3 { get; set; }
        public string Q1Question4 { get; set; }
        public string Q1Question5 { get; set; }
        public string Q1Question6 { get; set; }
        public string Q1Question7 { get; set; }
        public string Q1Question8 { get; set; }
        public string Q1Question9 { get; set; }
        public string Q1Question10 { get; set; }
    }

    public class Question2
    {
        public string Q2Question1 { get; set; }
        public string Q2Question2 { get; set; }
        public string Q2Question3 { get; set; }
        public string Q2Question4 { get; set; }
        public string Q2Question5 { get; set; }
        public string Q2Question6 { get; set; }
        public string Q2Question7 { get; set; }
        public string Q2Question8 { get; set; }
        public string Q2Question9 { get; set; }
        public string Q2Question10 { get; set; }
    }

    public class Question3
    {
        public string Q3Question1 { get; set; }
        public string Q3Question1_Option1 { get; set; }
        public string Q3Question1_Option2 { get; set; }
        public string Q3Question1_Option3 { get; set; }
        public string Q3Question1_Option4 { get; set; }
        public string Q3Question2 { get; set; }
        public string Q3Question2_Option1 { get; set; }
        public string Q3Question2_Option2 { get; set; }
        public string Q3Question2_Option3 { get; set; }
        public string Q3Question2_Option4 { get; set; }
        public string Q3Question3 { get; set; }
        public string Q3Question3_Option1 { get; set; }
        public string Q3Question3_Option2 { get; set; }
        public string Q3Question3_Option3 { get; set; }
        public string Q3Question3_Option4 { get; set; }
        public string Q3Question4 { get; set; }
        public string Q3Question4_Option1 { get; set; }
        public string Q3Question4_Option2 { get; set; }
        public string Q3Question4_Option3 { get; set; }
        public string Q3Question4_Option4 { get; set; }
        public string Q3Question5 { get; set; }
        public string Q3Question5_Option1 { get; set; }
        public string Q3Question5_Option2 { get; set; }
        public string Q3Question5_Option3 { get; set; }
        public string Q3Question5_Option4 { get; set; }
        public string Q3Question6 { get; set; }
        public string Q3Question6_Option1 { get; set; }
        public string Q3Question6_Option2 { get; set; }
        public string Q3Question6_Option3 { get; set; }
        public string Q3Question6_Option4 { get; set; }
        public string Q3Question7 { get; set; }
        public string Q3Question7_Option1 { get; set; }
        public string Q3Question7_Option2 { get; set; }
        public string Q3Question7_Option3 { get; set; }
        public string Q3Question7_Option4 { get; set; }
        public string Q3Question8 { get; set; }
        public string Q3Question8_Option1 { get; set; }
        public string Q3Question8_Option2 { get; set; }
        public string Q3Question8_Option3 { get; set; }
        public string Q3Question8_Option4 { get; set; }
        public string Q3Question9 { get; set; }
        public string Q3Question9_Option1 { get; set; }
        public string Q3Question9_Option2 { get; set; }
        public string Q3Question9_Option3 { get; set; }
        public string Q3Question9_Option4 { get; set; }
        public string Q3Question10 { get; set; }
        public string Q3Question10_Option1 { get; set; }
        public string Q3Question10_Option2 { get; set; }
        public string Q3Question10_Option3 { get; set; }
        public string Q3Question10_Option4 { get; set; }
    }

    public class Question4
    {
        public string Q4Question1 { get; set; }
        public string Q4Question1_Option1 { get; set; }
        public string Q4Question1_Option2 { get; set; }
        public string Q4Question1_Option3 { get; set; }
        public string Q4Question1_Option4 { get; set; }
        public string Q4Question1_Option5 { get; set; }
        public string Q4Question2 { get; set; }
        public string Q4Question2_Option1 { get; set; }
        public string Q4Question2_Option2 { get; set; }
        public string Q4Question2_Option3 { get; set; }
        public string Q4Question2_Option4 { get; set; }
        public string Q4Question2_Option5 { get; set; }
        public string Q4Question3 { get; set; }
        public string Q4Question3_Option1 { get; set; }
        public string Q4Question3_Option2 { get; set; }
        public string Q4Question3_Option3 { get; set; }
        public string Q4Question3_Option4 { get; set; }
        public string Q4Question3_Option5 { get; set; }
        public string Q4Question4 { get; set; }
        public string Q4Question4_Option1 { get; set; }
        public string Q4Question4_Option2 { get; set; }
        public string Q4Question4_Option3 { get; set; }
        public string Q4Question4_Option4 { get; set; }
        public string Q4Question4_Option5 { get; set; }
        public string Q4Question5 { get; set; }
        public string Q4Question5_Option1 { get; set; }
        public string Q4Question5_Option2 { get; set; }
        public string Q4Question5_Option3 { get; set; }
        public string Q4Question5_Option4 { get; set; }
        public string Q4Question5_Option5 { get; set; }
        public string Q4Question6 { get; set; }
        public string Q4Question6_Option1 { get; set; }
        public string Q4Question6_Option2 { get; set; }
        public string Q4Question6_Option3 { get; set; }
        public string Q4Question6_Option4 { get; set; }
        public string Q4Question6_Option5 { get; set; }
        public string Q4Question7 { get; set; }
        public string Q4Question7_Option1 { get; set; }
        public string Q4Question7_Option2 { get; set; }
        public string Q4Question7_Option3 { get; set; }
        public string Q4Question7_Option4 { get; set; }
        public string Q4Question7_Option5 { get; set; }
        public string Q4Question8 { get; set; }
        public string Q4Question8_Option1 { get; set; }
        public string Q4Question8_Option2 { get; set; }
        public string Q4Question8_Option3 { get; set; }
        public string Q4Question8_Option4 { get; set; }
        public string Q4Question8_Option5 { get; set; }
        public string Q4Question9 { get; set; }
        public string Q4Question9_Option1 { get; set; }
        public string Q4Question9_Option2 { get; set; }
        public string Q4Question9_Option3 { get; set; }
        public string Q4Question9_Option4 { get; set; }
        public string Q4Question9_Option5 { get; set; }
        public string Q4Question10 { get; set; }
        public string Q4Question10_Option1 { get; set; }
        public string Q4Question10_Option2 { get; set; }
        public string Q4Question10_Option3 { get; set; }
        public string Q4Question10_Option4 { get; set; }
        public string Q4Question10_Option5 { get; set; }
    }

    public class Question5
    {
        public string Q5Question1 { get; set; }
        public string Q5Question1_Option1 { get; set; }
        public string Q5Question1_Option2 { get; set; }
        public string Q5Question1_Option3 { get; set; }
        public string Q5Question1_Option4 { get; set; }
        public string Q5Question1_Option5 { get; set; }
        public string Q5Question1_Option6 { get; set; }
        public string Q5Question2 { get; set; }
        public string Q5Question2_Option1 { get; set; }
        public string Q5Question2_Option2 { get; set; }
        public string Q5Question2_Option3 { get; set; }
        public string Q5Question2_Option4 { get; set; }
        public string Q5Question2_Option5 { get; set; }
        public string Q5Question2_Option6 { get; set; }
    }

    public class Question6
    {
        public string Q6Question1 { get; set; }
        public string Q6Question1_OptionA { get; set; }
        public string Q6Question1_OptionB { get; set; }
        public string Q6Question1_OptionC { get; set; }
        public string Q6Question1_OptionD { get; set; }
        public string Q6Question1_Option1 { get; set; }
        public string Q6Question1_Option2 { get; set; }
        public string Q6Question1_Option3 { get; set; }
        public string Q6Question1_Option4 { get; set; }
    }

    public class Question7
    {
        public string Q7Question1 { get; set; }
        public string Q7Question2 { get; set; }
        public string Q7Question3 { get; set; }
        public string Q7Question4 { get; set; }
        public string Q7Question5 { get; set; }
        public string Q7Question6 { get; set; }
        public string Q7Question7 { get; set; }
        public string Q7Question8 { get; set; }
    }

    public class Question8
    {
        public string Q8Question1 { get; set; }
        public string Q8Question2 { get; set; }
        public string Q8Question3 { get; set; }
        public string Q8Question4 { get; set; }
    }





}

