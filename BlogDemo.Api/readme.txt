
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



