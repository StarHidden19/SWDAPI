using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewAndNotificationAPI.Migrations
{
    public partial class migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    studentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    major = table.Column<string>(nullable: false),
                    className = table.Column<string>(nullable: false),
                    curriculum = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false),
                    phoneNumber = table.Column<int>(nullable: false),
                    status = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: false),
                    dateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    topicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    status = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.topicId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    postId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    status = table.Column<string>(nullable: false),
                    topicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.postId);
                    table.ForeignKey(
                        name: "FK_Posts_Topics_topicId",
                        column: x => x.topicId,
                        principalTable: "Topics",
                        principalColumn: "topicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTopics",
                columns: table => new
                {
                    studentTopicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(nullable: false),
                    topicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTopics", x => x.studentTopicId);
                    table.ForeignKey(
                        name: "FK_StudentTopics_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "studentId");
                    table.ForeignKey(
                        name: "FK_StudentTopics_Topics_topicId",
                        column: x => x.topicId,
                        principalTable: "Topics",
                        principalColumn: "topicId");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    tagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    status = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    topicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.tagId);
                    table.ForeignKey(
                        name: "FK_Tags_Topics_topicId",
                        column: x => x.topicId,
                        principalTable: "Topics",
                        principalColumn: "topicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    postId = table.Column<int>(nullable: false),
                    tagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.PostTagId);
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_postId",
                        column: x => x.postId,
                        principalTable: "Posts",
                        principalColumn: "postId");
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_tagId",
                        column: x => x.tagId,
                        principalTable: "Tags",
                        principalColumn: "tagId");
                });

            migrationBuilder.CreateTable(
                name: "StudentTags",
                columns: table => new
                {
                    StudentTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(nullable: false),
                    tagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTags", x => x.StudentTagId);
                    table.ForeignKey(
                        name: "FK_StudentTags_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "studentId");
                    table.ForeignKey(
                        name: "FK_StudentTags_Tags_tagId",
                        column: x => x.tagId,
                        principalTable: "Tags",
                        principalColumn: "tagId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_topicId",
                table: "Posts",
                column: "topicId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_postId",
                table: "PostTags",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_tagId",
                table: "PostTags",
                column: "tagId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTags_studentId",
                table: "StudentTags",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTags_tagId",
                table: "StudentTags",
                column: "tagId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTopics_studentId",
                table: "StudentTopics",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTopics_topicId",
                table: "StudentTopics",
                column: "topicId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_topicId",
                table: "Tags",
                column: "topicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "StudentTags");

            migrationBuilder.DropTable(
                name: "StudentTopics");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
