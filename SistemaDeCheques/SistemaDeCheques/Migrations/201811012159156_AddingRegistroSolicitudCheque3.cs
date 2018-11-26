namespace SistemaDeCheques.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRegistroSolicitudCheque3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        ProveedoresId = c.Int(nullable: false, identity: true),
                        nombre = c.String(unicode: false),
                        tipoPersona = c.String(unicode: false),
                        cedulaORnc = c.String(unicode: false),
                        balance = c.Double(nullable: false),
                        cuentaProveedor = c.String(unicode: false),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProveedoresId);

            CreateTable(
                "dbo.RegistroSolicitudCheques",
                c => new
                {
                    NumeroSolicitud = c.Int(nullable: false, identity: true),
                    idProveedor = c.Int(nullable: false),
                    monto = c.Double(nullable: false),
                    fechaRegistro = c.DateTime(nullable: false, precision: 0),
                    estado = c.Boolean(nullable: false),
                    CuentaBanco = c.String(unicode: false),
                })
                .PrimaryKey(t => t.NumeroSolicitud)
                .ForeignKey("dbo.Proveedores", t => t.idProveedor, cascadeDelete: true);
            Sql("CREATE index `IX_idProveedor` on `RegistroSolicitudCheques` (`idProveedor` DESC)");
            // .Index(t => t.idProveedor);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegistroSolicitudCheques", "idProveedor", "dbo.Proveedores");
            DropIndex("dbo.RegistroSolicitudCheques", new[] { "idProveedor" });
            DropTable("dbo.RegistroSolicitudCheques");
            DropTable("dbo.Proveedores");
        }
    }
}
