using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace _260303_hw_Json
{
    public partial class JsonConverter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int age;
            bool ageParse = int.TryParse(ageInput.Text, out age);

            if (ageParse)
            {
                Student student = new Student
                {
                    Name = nameInput.Text,
                    Age = age
                };

                JsonSerializerOptions _options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                };
                string json = JsonSerializer.Serialize(student,_options);
                convertToJson.Text = json;
            }
            else
            {
                convertToJson.Text = "年齡輸入格式不符";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string json = jsonInput.Text;

            try
            {
                Student student = JsonSerializer.Deserialize<Student>(json);

                convertToProperties.Text = $"姓名: {student.Name} <br /> 年齡: {student.Age}";
            }
            catch(Exception ex)
            {
                convertToProperties.Text = "錯誤: 無法反序列化JSON。 <br />" + ex.Message; 
            }
        }
    }
}