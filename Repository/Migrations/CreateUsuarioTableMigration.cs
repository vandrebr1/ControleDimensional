using FluentMigrator;

[Migration(20250130)]
public class CreateUsuarioTableMigration : Migration
{
    public override void Up()
    {
        Create.Table("Usuarios")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Nome").AsString(100).NotNullable()
            .WithColumn("Login").AsString(25).NotNullable().Indexed()
            .WithColumn("Senha").AsString(255).NotNullable()
            .WithColumn("TipoAcesso").AsInt32().NotNullable()
            .WithColumn("DtCadastro").AsDateTime().NotNullable()
            .WithColumn("CadastradoPor").AsString(25).NotNullable()
            .WithColumn("DtModificado").AsDateTime().NotNullable()
            .WithColumn("ModificadoPor").AsString(25).NotNullable()
            .WithColumn("IsDeleted").AsBoolean().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Usuarios");
    }
}