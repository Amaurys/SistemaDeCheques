namespace SistemaDeCheques.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingConceptoDePago : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConceptoDePagoes",
                c => new
                    {
                        conceptoId = c.Int(nullable: false, identity: true),
                        descripcion = c.String(unicode: false),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.conceptoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConceptoDePagoes");
        }
    }
}
