using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace imdb.Models
{
    public class Cmodel:DbContext
    {
        public Cmodel() : base("imdb220")
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<movie> movies {get; set;}
        public DbSet<actor> actors { get; set; }
        public DbSet<director> directors { get; set;}
       
    }

    public class User
    {
        public int Id {get; set;}
        public string FristName {get; set;}
        public string lastName {get; set;}
        public string Photo {get; set;}
        public string username {get; set;}
        public string password {get; set;}

        public virtual List<fav_act> Fav_Acts {get; set;}
        public virtual List<fav_mov> Fav_Movs {get; set;}
        public virtual List<fav_dir> Fav_Dirs {get; set;}
    }

    public class movie
    {
        public int id {get; set;}
        public string name {get; set;}
        public string photo {get; set;}
        public string description {get; set;}
        public int id_director {get; set;}
        public virtual director director {get; set;}
        public virtual List<act_in_mov> Act_In_Movs {get; set;}
    }

    public class actor
    {
        public int id {get; set;}
        public string name {get; set;}
        public string photo {get; set;}
        public virtual List<act_in_mov> Act_In_Movs {get; set;}
    }


    public class act_in_mov
    {
        public int id {get; set;}
        public int idact {get; set;}
        public int idmov { get; set; }
        public virtual actor actor { get; set; }
        public virtual movie Movie { get; set; }

    }

    public class director
    {
        public int id {get; set;}
        public string name {get; set;}
        public string photo {get; set;}
        public virtual List<movie> Movies {get; set;}
    }

    public class fav_mov
    {
        public int id {get; set;}
        public int iduser {get; set;}
        public int idmov {get; set;}
        public virtual movie Movie {get; set;}
        public virtual User User {get; set;}
    }

    public class fav_dir
    {
        public int id { get; set; }
        public int iduser { get; set; }
        public int iddir {get; set;}
        public virtual director Director {get; set; }
        public virtual User User {get; set;}
    }
    public class fav_act
    {
        public int id {get; set;}
        public int iduser {get; set;}
        public int idact { get; set;}
        public virtual actor Actor {get; set; }
        public virtual User User {get; set; }
    }
}