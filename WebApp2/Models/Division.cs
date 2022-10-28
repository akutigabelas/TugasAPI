using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace WebApp2.Models
{
    public class Division
    {
        public  Division(int Id, string Nama)
        {
            this.Id = Id;
            this.Nama = Nama;
        }

        public Division()
        {

        }


        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
