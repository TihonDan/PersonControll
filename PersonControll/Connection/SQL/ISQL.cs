using PersonControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonControll.Connection.SQL
{
    internal interface ISQL
    {
        string GetAllColumn(string surname, string firstname, string lastname, DateTime firstBirthday, DateTime lastBirthday);
        SqlRes CreateColumn(string surNameText, string nameText, string lastNameText, DateTime birthdayDate);
        SqlRes UpdateColumn(int id, string surnameText, string nameText, string lastNameText, DateTime birthdayDate);
        SqlRes DeleteColumn(int id);
    }
}
