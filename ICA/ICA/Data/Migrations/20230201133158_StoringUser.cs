using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class StoringUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [ProfilePicture], [SecoundName], [Status]) VALUES (N'0604fe3c-ed4b-4fad-a0a3-e71c9c650443', N'khaledhelwane97@gmail.com', N'KHALEDHELWANE97@GMAIL.COM', N'khaledhelwane97@gmail.com', N'KHALEDHELWANE97@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEdKSpyBA8xcOUMpS0hQMJeUnAJes/yG9B0nvTkWmtLZwaEApeO96Vz0XOmgBrxOyg==', N'JL62MUCYDYJKS5V2Y3ZXX7PPGBYMMWPR', N'950f645e-2e53-420e-b930-439c603df435', N'0956410822', 0, 0, NULL, 0, 0, N'khaled', null, N'helwane', 0)\r\n");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From [dbo].[AspNetUsers] where id='0604fe3c-ed4b-4fad-a0a3-e71c9c650443'");
        }
    }
}
