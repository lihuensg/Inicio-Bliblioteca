namespace Aplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BibliotecaV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Edicions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Isbn = c.String(nullable: false),
                        AñoEdicion = c.Int(nullable: false),
                        NumeroPaginas = c.Int(nullable: false),
                        Portada = c.String(nullable: false),
                        FechaPublicacion = c.DateTime(nullable: false),
                        Obra_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Obras", t => t.Obra_Id, cascadeDelete: true)
                .Index(t => t.Obra_Id);
            
            CreateTable(
                "dbo.Obras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        Lccn = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        autores = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ejemplars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoInventario = c.String(nullable: false, maxLength: 100),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaBaja = c.DateTime(),
                        Edicion_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Edicions", t => t.Edicion_Id, cascadeDelete: true)
                .Index(t => t.Edicion_Id);
            
            CreateTable(
                "dbo.NotificacionVencimientoPrestamoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiasAnteracion = c.Int(nullable: false),
                        Prestamo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prestamoes", t => t.Prestamo_Id)
                .Index(t => t.Prestamo_Id);
            
            CreateTable(
                "dbo.Prestamoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaPrestamo = c.DateTime(nullable: false),
                        FechaDevolucion = c.DateTime(),
                        FechaVencimiento = c.DateTime(nullable: false),
                        Ejemplar_Id = c.Int(nullable: false),
                        Solicitante_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ejemplars", t => t.Ejemplar_Id, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.Solicitante_Id, cascadeDelete: true)
                .Index(t => t.Ejemplar_Id)
                .Index(t => t.Solicitante_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EsAdministrador = c.Boolean(nullable: false),
                        Dni = c.Int(nullable: false),
                        NombreUsuario = c.String(),
                        Password = c.String(),
                        Mail = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                        Puntaje = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotificacionVencimientoPrestamoes", "Prestamo_Id", "dbo.Prestamoes");
            DropForeignKey("dbo.Prestamoes", "Solicitante_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Prestamoes", "Ejemplar_Id", "dbo.Ejemplars");
            DropForeignKey("dbo.Ejemplars", "Edicion_Id", "dbo.Edicions");
            DropForeignKey("dbo.Edicions", "Obra_Id", "dbo.Obras");
            DropIndex("dbo.Prestamoes", new[] { "Solicitante_Id" });
            DropIndex("dbo.Prestamoes", new[] { "Ejemplar_Id" });
            DropIndex("dbo.NotificacionVencimientoPrestamoes", new[] { "Prestamo_Id" });
            DropIndex("dbo.Ejemplars", new[] { "Edicion_Id" });
            DropIndex("dbo.Edicions", new[] { "Obra_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Prestamoes");
            DropTable("dbo.NotificacionVencimientoPrestamoes");
            DropTable("dbo.Ejemplars");
            DropTable("dbo.Obras");
            DropTable("dbo.Edicions");
        }
    }
}
