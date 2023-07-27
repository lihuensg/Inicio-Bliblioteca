namespace Aplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
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
                        Portada = c.String(),
                        Titulo = c.String(),
                        Descripcion = c.String(),
                        Autores = c.String(),
                        Publicacion = c.String(),
                        DatosAdicionales = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ejemplars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoInventario = c.String(maxLength: 100),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaBaja = c.DateTime(),
                        Edicion_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Edicions", t => t.Edicion_Id, cascadeDelete: true)
                .Index(t => t.CodigoInventario)
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotificacionVencimientoPrestamoes", "Prestamo_Id", "dbo.Prestamoes");
            DropForeignKey("dbo.Prestamoes", "Solicitante_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Prestamoes", "Ejemplar_Id", "dbo.Ejemplars");
            DropForeignKey("dbo.Ejemplars", "Edicion_Id", "dbo.Edicions");
            DropIndex("dbo.Prestamoes", new[] { "Solicitante_Id" });
            DropIndex("dbo.Prestamoes", new[] { "Ejemplar_Id" });
            DropIndex("dbo.NotificacionVencimientoPrestamoes", new[] { "Prestamo_Id" });
            DropIndex("dbo.Ejemplars", new[] { "Edicion_Id" });
            DropIndex("dbo.Ejemplars", new[] { "CodigoInventario" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Prestamoes");
            DropTable("dbo.NotificacionVencimientoPrestamoes");
            DropTable("dbo.Ejemplars");
            DropTable("dbo.Edicions");
        }
    }
}
