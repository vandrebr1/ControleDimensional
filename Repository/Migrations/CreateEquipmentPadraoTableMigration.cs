using FluentMigrator;

[Migration(202502100001)]
public class CreateEquipmentPadraoTableMigration : Migration
{
    public override void Up()
    {
        Execute.Sql("PRAGMA foreign_keys = ON;");

        Create.Table("EquipmentsPadroes")
            .WithColumn("EquipmentId").AsInt32().NotNullable()
            .WithColumn("PadraoId").AsInt32().NotNullable()
            .WithColumn("DtCadastro").AsDateTime().NotNullable()
            .WithColumn("CadastradoPor").AsString(25).Nullable()
            .WithColumn("DtModificado").AsDateTime().NotNullable()
            .WithColumn("ModificadoPor").AsString(25).Nullable()
            .WithColumn("IsDeleted").AsBoolean().NotNullable()
            .ForeignKey("FK_EquipmentsPadroes_Equipments", "Equipments", "Id").OnDelete(System.Data.Rule.None)
            .ForeignKey("FK_EquipmentsPadroes_Padroes", "Padroes", "Id").OnDelete(System.Data.Rule.None);

    }

    public override void Down()
    {
        Delete.Table("Padroes");
    }
}