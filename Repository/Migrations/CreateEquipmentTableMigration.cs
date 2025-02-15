using FluentMigrator;

[Migration(202502100000)]
public class CreateEquipmentTableMigration : Migration
{
    public override void Up()
    {
        Create.Table("Equipments")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(10).NotNullable().Indexed()
            .WithColumn("Abbreviation").AsString(4).NotNullable()
            .WithColumn("DtCadastro").AsDateTime().NotNullable()
            .WithColumn("CadastradoPor").AsString(25).NotNullable()
            .WithColumn("DtModificado").AsDateTime().NotNullable()
            .WithColumn("ModificadoPor").AsString(25).NotNullable()
            .WithColumn("IsDeleted").AsBoolean().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Equipments");
    }
}