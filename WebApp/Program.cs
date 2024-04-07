using Infrastructure.DataContext;
using Infrastructure.Services.AtendanceServices;
using Infrastructure.Services.ClassroomServices;
using Infrastructure.Services.CourseServices;
using Infrastructure.Services.ExamServices;
using Infrastructure.Services.ExamTypeServices;
using Infrastructure.Services.GradeServices;
using Infrastructure.Services.ParentServices;
using Infrastructure.Services.Relations;
using Infrastructure.Services.StudentServices;
using Infrastructure.Services.TeacherServices;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IAtendanceService,AtendanceService>();
builder.Services.AddScoped<IClassroomService,ClassroomService>();
builder.Services.AddScoped<IClassroom_StudentService,Classroom_StudentService>();
builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<IExamService,ExamService>();
builder.Services.AddScoped<IExamResultService,ExamResultService>();
builder.Services.AddScoped<IExamTypeService,ExamTypeService>();
builder.Services.AddScoped<IGradeService,GradeService>();
builder.Services.AddScoped<IParentService,ParentService>();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<ITeacherService,TeacherService>();
builder.Services.AddScoped<DapperContext>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
