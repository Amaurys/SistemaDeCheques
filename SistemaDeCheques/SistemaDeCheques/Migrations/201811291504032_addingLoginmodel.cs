namespace SistemaDeCheques.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingLoginmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegistroSolicitudCheques", "CuentaContable", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegistroSolicitudCheques", "CuentaContable", c => c.String(unicode: false));
        }
    }
}
