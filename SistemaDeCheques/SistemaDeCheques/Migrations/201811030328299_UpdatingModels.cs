namespace SistemaDeCheques.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proveedores", "TipoPerona", c => c.Int(nullable: false));
            AddColumn("dbo.RegistroSolicitudCheques", "CuentaCorrienteXCuentaContable", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.ConceptoDePagoes", "descripcion", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.ConceptoDePagoes", "estado", c => c.Int(nullable: false));
            AlterColumn("dbo.Proveedores", "nombre", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Proveedores", "cedulaORnc", c => c.String(nullable: false, maxLength: 13, storeType: "nvarchar"));
            AlterColumn("dbo.Proveedores", "cuentaProveedor", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Proveedores", "Estado", c => c.Int(nullable: false));
            AlterColumn("dbo.RegistroSolicitudCheques", "Estado", c => c.Int(nullable: false));
            DropColumn("dbo.Proveedores", "tipoPersona");
            DropColumn("dbo.RegistroSolicitudCheques", "CuentaBanco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegistroSolicitudCheques", "CuentaBanco", c => c.String(unicode: false));
            AddColumn("dbo.Proveedores", "tipoPersona", c => c.String(unicode: false));
            AlterColumn("dbo.RegistroSolicitudCheques", "Estado", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Proveedores", "Estado", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Proveedores", "cuentaProveedor", c => c.String(unicode: false));
            AlterColumn("dbo.Proveedores", "cedulaORnc", c => c.String(unicode: false));
            AlterColumn("dbo.Proveedores", "nombre", c => c.String(unicode: false));
            AlterColumn("dbo.ConceptoDePagoes", "estado", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ConceptoDePagoes", "descripcion", c => c.String(unicode: false));
            DropColumn("dbo.RegistroSolicitudCheques", "CuentaCorrienteXCuentaContable");
            DropColumn("dbo.Proveedores", "TipoPerona");
        }
    }
}
