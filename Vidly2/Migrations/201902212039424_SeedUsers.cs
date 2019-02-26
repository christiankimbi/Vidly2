namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'53456c0a-e2fa-4f67-a625-0d0db0dba3e8', N'chris@dren.co.za', 0, N'ALqoAXnFsqZoHrGVsacHSN7GNXE1FEDItE5fxLvukyJckQyavBWJgyDmmoqi4+KGag==', N'f9550365-ea6a-4e7b-bd1b-7f897602e3d2', NULL, 0, 0, NULL, 1, 0, N'chris@dren.co.za')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'69cf8496-b017-4daf-ac56-b1a38d0d30b5', N'guest@dren.co.za', 0, N'AF4zQXONKA5yQddqPBCaw/LMxU2JPA6Fi3dFOD2yg8X4d8Dy59lxmZbVCxmcQ89uWQ==', N'ae332a3e-89df-4cf1-bd29-291d6d286f1f', NULL, 0, 0, NULL, 1, 0, N'guest@dren.co.za')


                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b56d202f-f49b-4c07-9ff7-3b72ff42fcdb', N'CanManageMovies')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'53456c0a-e2fa-4f67-a625-0d0db0dba3e8', N'b56d202f-f49b-4c07-9ff7-3b72ff42fcdb')
            
                ");
        }
        
        public override void Down()
        {
        }
    }
}
