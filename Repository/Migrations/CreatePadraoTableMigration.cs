using FluentMigrator;

[Migration(20250203)]
public class CreatePadraoTableMigration : Migration
{
    public override void Up()
    {
        Create.Table("Padroes")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Nome").AsString(30).NotNullable().Indexed()
            .WithColumn("Ferramental").AsString(30).NotNullable()
            .WithColumn("UnidadeMedida").AsString(5).NotNullable()
            .WithColumn("DtCadastro").AsDateTime().NotNullable()
            .WithColumn("CadastradoPor").AsString(25).Nullable()
            .WithColumn("DtModificado").AsDateTime().NotNullable()
            .WithColumn("ModificadoPor").AsString(25).Nullable()
            .WithColumn("IsDeleted").AsBoolean().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Padroes");
    }
}