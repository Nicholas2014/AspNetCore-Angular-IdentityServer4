
Program vs Startup

Program 
	httpServer
	集成iis
	配置信心来源

Startup
	服务注册
	中间件和MVC

# 环境变量 ASPNETCORE_ENVIRONMENT可以是任何值,如果没有被设置，默认为Production
Asp.Net Core默认带了三个值：
* Production
* Development
* Staging

# Asp.Net Core应用可以为不同的环境定义单独的Startup类/方法，并在运行时选择适当的Startup类/方法
使用基于环境的类：
Startup{环境名称}
* StartupDevelopment
* StartupProduction
* StartupStaging

在Program里配置IWebHostBuilder时使用UseStartup(IWebHostBuilder,String)而不是UseStartup<Startup>(IWebHostBuilder)
* String 参数是StartupXXX所在的Assembly的名字

#使用Https
services.AddHttpsRedirection
app.UseHttpsRediction();

# 添加Entity Framework Core
1. 添加nuget包
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Sqllite

2. 建立Context
* 建立Entities
* 建立Context,继承于DbContext

3. 在Startup里注册Context

BlogDemo.Infrastructure
# Add-Migration xxx
# Remove-Migration xxx
# Update-Database [-Verbose]

Unit Of Work + Repository
为什么要用Repository模式
* 与持久化技术无关
* 易于测试
* 代码重用


# Asp.Net Core 服务注册生命周期
* Transient:每次其他的类请求（不是http请求）都会创建一个新的实例，它比较适合轻量级的无状态的服务
* Scope：每次http请求都会创建一个实例
* Singleton：在第一次请求的时候就会创建一个实例，以后也只有这一个实例；或者在ConfigureServices这段代码运行的时候创建一个实例

# DbContext 本身已经实现了Unit Of Work 和 Repository

# Entity 约束
使用IEntityTypeConfiguration<TEntity>
DbContext里的OnModelCreating()

#asp.net core提供了一套log api，它可以和各种各样的log提供商配合使用：
内置6个
console
debug
eventsource
eventlog
tracesource
azure app service

第三方log提供商
Nlog
Serilog

依赖注入ILogger<TCategoryName>即可

创建ILogger的时候指明分类
分类名约定是调用类的全名(string)
在ILoggerFactory上调用CreateLogger方法时可以指定分类的名称
例如：
ILogger<TodoController> logger
logger.CreateLogger("TodoApi.Controllers.TodoController")

# 添加Serilog https://serilog.net/
Install-Package Serilog
Install-Package Serilog.AspNetCore-DependencyVersion Highest
* Sinks
Install-Package Serilog.Sinks.Console
Install-Package Serilog.Sinks.File







