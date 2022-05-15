namespace imdb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ff1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.actors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        photo = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.act_in_mov",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idact = c.Int(nullable: false),
                        idmov = c.Int(nullable: false),
                        actor_id = c.Int(),
                        Movie_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.actors", t => t.actor_id)
                .ForeignKey("dbo.movies", t => t.Movie_id)
                .Index(t => t.actor_id)
                .Index(t => t.Movie_id);
            
            CreateTable(
                "dbo.movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        photo = c.String(),
                        description = c.String(),
                        id_director = c.Int(nullable: false),
                        director_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.directors", t => t.director_id)
                .Index(t => t.director_id);
            
            CreateTable(
                "dbo.directors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        photo = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FristName = c.String(),
                        lastName = c.String(),
                        Photo = c.String(),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.movies", "director_id", "dbo.directors");
            DropForeignKey("dbo.act_in_mov", "Movie_id", "dbo.movies");
            DropForeignKey("dbo.act_in_mov", "actor_id", "dbo.actors");
            DropIndex("dbo.movies", new[] { "director_id" });
            DropIndex("dbo.act_in_mov", new[] { "Movie_id" });
            DropIndex("dbo.act_in_mov", new[] { "actor_id" });
            DropTable("dbo.Users");
            DropTable("dbo.directors");
            DropTable("dbo.movies");
            DropTable("dbo.act_in_mov");
            DropTable("dbo.actors");
        }
    }
}
