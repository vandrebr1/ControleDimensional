using FluentMigrator;

[Migration(202502100001)]
public class CreateEquipmentPadraoTableMigration : Migration
{
    public override void Up()
    {
        Create.Table("EquipmentsPadroes")
            .WithColumn("EquipmentId").AsInt32().NotNullable().ForeignKey("Equipments", "Id")
            .WithColumn("PadraoId").AsInt32().NotNullable().ForeignKey("Padroes", "Id")
            .WithColumn("DtCadastro").AsDateTime().NotNullable()
            .WithColumn("CadastradoPor").AsString(25).NotNullable()
            .WithColumn("DtModificado").AsDateTime().NotNullable()
            .WithColumn("ModificadoPor").AsString(25).NotNullable()
            .WithColumn("IsDeleted").AsBoolean().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("EquipmentsPadroes");
    }
}