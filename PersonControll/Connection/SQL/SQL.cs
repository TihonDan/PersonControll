using PersonControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonControll.Connection.SQL
{
    public class SQL : ISQL
    {
        string NameTable = "customers";

        public SqlRes CreateColumn(string surNameText, string nameText, string fatherNameText, DateTime birthdayDate)
        {

            string sql = "INSERT INTO " + NameTable + " (surname, firstname, lastname, birthday)" +
                         "VALUES (?,?,?,?)";

            SqlRes sqlRes = new SqlRes();
            sqlRes.sql = sql;

            PersonPar citizen = new PersonPar();
            citizen.surname = surNameText;
            citizen.firstname = nameText;
            citizen.lastname = fatherNameText;
            citizen.birthday = birthdayDate;
            sqlRes.personPar = citizen;

            return sqlRes;
        }

        public SqlRes DeleteColumn(int id)
        {
            string sql = "DELETE FROM " + NameTable + " WHERE id_person = ?";

            SqlRes sqlRes = new SqlRes();
            sqlRes.sql = sql;

            PersonPar citizen = new PersonPar();
            citizen.id_person = id;
            sqlRes.personPar = citizen;

            return sqlRes;
        }

        public string GetPersonAll()
        {
            string sql = "SELECT * FROM  " + NameTable;

            return sql;
        }

        public string GetAllColumn(string surname, string firstname, string lastname, DateTime firstBirthday, DateTime lastBirthday)
        {
            string sql = "SELECT  id_person, surname, firstname, lastname, birthday FROM  " + NameTable;
            bool isNotFrirst = false;
            if (surname != "" | firstname != "" | lastname != "" | firstBirthday != DateTime.MinValue | lastBirthday != DateTime.MinValue)
            {
                sql = sql + " WHERE ";
                if (surname.Contains("*"))
                {
                    sql = sql + $" surname = '{surname.Trim(new Char[] { '*' })}'";
                    isNotFrirst = true;
                }
                else 
                {
                    sql = sql + $" surname like '%{surname}%'";
                    isNotFrirst = true;
                }
                if (firstname.Contains("*"))
                {
                    if (isNotFrirst)
                        sql = sql + " AND";
                    sql = sql + $" firstname = '{firstname.Trim(new Char[] { '*' })}'";
                    isNotFrirst = true;
                }
                else
                {
                    if (isNotFrirst)
                        sql = sql + " AND";
                    sql = sql + $" firstname like '%{firstname}%'";
                    isNotFrirst = true;
                }
                if (lastname.Contains("*"))
                {
                    if (isNotFrirst)
                        sql = sql + " AND";
                    sql = sql + $" lastname = '{lastname.Trim(new Char[] { '*' })}'";
                    isNotFrirst = true;
                }
                else
                {
                    if (isNotFrirst)
                        sql = sql + " AND";
                    sql = sql + $" lastname like '%{lastname}%'";
                    isNotFrirst = true;
                }
                if (firstBirthday != DateTime.MinValue)
                {
                    if (isNotFrirst)
                        sql = sql + " AND";
                    sql = sql + " birthday >= '" + firstBirthday.Day + "." + firstBirthday.Month + "." + firstBirthday.Year + "'";
                    isNotFrirst = true;
                }
                if (lastBirthday != DateTime.MinValue)
                {
                    if (isNotFrirst)
                        sql = sql + " and";
                    sql = sql + " birthday <= '" + lastBirthday.Day + "." + lastBirthday.Month + "." + lastBirthday.Year + "'";
                    isNotFrirst = true;
                }

            }
            return sql;
        }

        public SqlRes UpdateColumn(int id, string surnameText, string nameText, string fatherNameText, DateTime birthdayDate)
        {
            string sql = "UPDATE " + NameTable + " SET (surname, firstname, lastname, birthday) = " +
                         "(?,?,?,?)" +
                         "WHERE id_person = " + Convert.ToString(id);

            SqlRes sqlRes = new SqlRes();
            sqlRes.sql = sql;

            PersonPar citizen = new PersonPar();
            citizen.id_person = id;
            citizen.surname = surnameText;
            citizen.lastname = fatherNameText;
            citizen.firstname = nameText;
            citizen.birthday = birthdayDate;
            sqlRes.personPar = citizen;

            return sqlRes;
        }
    }
}