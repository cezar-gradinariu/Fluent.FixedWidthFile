[START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\KnownIssues.txt==START]1. Currently the app is using a single db context during all its lifecycle. So, we are limited at running a single app all the time, otherwise if we have 2, 
changes will be done through these 2 db contexts and they will fall out of synch in the cache. Recomendation: refresh the db context on every request. (We have to
define what a request is but "RegisterService" is a good example of action that is a request.)
2. Logging system is not yet uniform. We use both logger and [Log] attribute. [Log] attribute is a great way to document a lot of information in a very unobstrusive
way and is able to link together messages.
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\KnownIssues.txt==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ReadMe.txt==START]My idea (me = Cezar G.) is that we have the test services in this folder. 
Case a: 
	Simple ones that write to event log or a db some messages identifying themselves.	
	The functional test is zipping them and copies to Services folder in the service where they are renamed so that the service picks them up and do our checks:
		1. is it properly archived?
		2. was it supposed to fail?
		3. if it failed was it archived? 
		4. is the old version still running unaffected?
		5. if is successful is our current version running?
		5. etc etc.....

Case b)
	More complex:
	    0. Copy the solution folders of test services in a temp and them alter them priogramtiacally.
		1. change assembly info in the test projects with new information as we see fit.
		2. Change code in the projects as we see fit for our tests
		3. Compile them from functional tests setup using somethiong like : https://social.msdn.microsoft.com/Forums/vstudio/en-US/ec95c513-f972-45ad-b108-5fcfd27f39bc/how-to-build-a-solution-within-c-net-40-?forum=msbuild
		4. Zip and follow case a).
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ReadMe.txt==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.sln==START]
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 2013
VisualStudioVersion = 12.0.31101.0
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "Build", "Build\Build.csproj", "{B018B820-D4EA-472E-BB1F-1ECA5AA038B8}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ServiceScheduler", "ServiceScheduler\ServiceScheduler.csproj", "{F14D9875-EF4D-4979-ADEC-E26CD8C9EC78}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ServiceScheduler.Data", "ServiceScheduler.Data\ServiceScheduler.Data.csproj", "{AE48F4C5-1882-4ED7-B723-B70D394EA651}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ServiceScheduler.UnitTests", "ServiceScheduler.UnitTests\ServiceScheduler.UnitTests.csproj", "{01541D27-FE42-40C2-BD67-48CC2D5D1287}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ServiceScheduler.Service", "ServiceScheduler.Service\ServiceScheduler.Service.csproj", "{C61E3CFA-B61F-4123-BE07-6CAB433B7E9C}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "TestService", "TestService\TestService.csproj", "{A4316C4C-7723-4C2E-9017-AC7E464984D9}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ServiceScheduler.Portal", "ServiceScheduler.Portal\ServiceScheduler.Portal.csproj", "{034D778D-B6DB-42D8-8D08-92AD7246F68E}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ServiceScheduler.FunctionalTest", "ServiceScheduler.FunctionalTest\ServiceScheduler.FunctionalTest.csproj", "{00C7FFF8-E054-44C3-9CB6-9051E24FDA32}"
EndProject
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "Test Services", "Test Services", "{8E93B358-FED4-4F0E-B442-71A0EB2C8344}"
	ProjectSection(SolutionItems) = preProject
		KnownIssues.txt = KnownIssues.txt
		ReadMe.txt = ReadMe.txt
	EndProjectSection
EndProject
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "ServiceA", "ServiceA", "{CA8CFBAB-879E-4DE5-86D4-A904057F50CA}"
EndProject
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "ServiceB", "ServiceB", "{FB4219E8-41DF-4A15-9788-39C33EE46152}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "BaseTestService", "BaseTestService\BaseTestService.csproj", "{23EDF47D-AC14-4E5D-86C8-573786483563}"
EndProject
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "BaseService", "BaseService", "{0399AC80-49E9-4BF4-AC94-0A91F84B2907}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ServiceA.v01", "ServiceA.v01\ServiceA.v01.csproj", "{BEE0240E-7DD1-4482-843B-859CCAF6E2FA}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ServiceA.v02", "ServiceA.v02\ServiceA.v02.csproj", "{D251D7BB-6D11-43E1-AC75-F3FD616D2BA3}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ServiceA.v03", "ServiceA.v03\ServiceA.v03.csproj", "{D0709ABD-BD47-43EF-B958-B90D1FD22860}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ServiceB.v01", "ServiceB.v01\ServiceB.v01.csproj", "{FF22C5F6-5162-4F02-BCCA-E6A208EB23ED}"
EndProject
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "FunctionalTests", "FunctionalTests", "{54A95D55-C186-4806-B833-CB54925BB7AC}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ZipFilesUtility", "ZipFilesUtility\ZipFilesUtility.csproj", "{FDCA97F9-E3BD-422A-A90F-181957B457E6}"
EndProject
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "ManualTests", "ManualTests", "{B429CE39-1054-4E5F-9036-D507977F08E6}"
	ProjectSection(SolutionItems) = preProject
		UpgradeService on the fly.txt = UpgradeService on the fly.txt
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ServiceScheduler.WebApi", "ServiceScheduler.WebApi\ServiceScheduler.WebApi.csproj", "{B0A9A6EA-A9CB-4000-AD2C-8DAE4B3C8BF6}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ServiceScheduler.WebApi.FunctionalTests", "ServiceScheduler.WebApi.FunctionalTests\ServiceScheduler.WebApi.FunctionalTests.csproj", "{B24C3C2C-2827-4C4D-9DFF-2A7A36512640}"
EndProject
Global
	GlobalSection(TeamFoundationVersionControl) = preSolution
		SccNumberOfProjects = 17
		SccEnterpriseProvider = {4CA58AB2-18FA-4F8D-95D4-32DDF27D184C}
		SccTeamFoundationServer = http://autfsprod02v:8080/tfs/defaultcollection
		SccLocalPath0 = .
		SccProjectUniqueName1 = Build\\Build.csproj
		SccProjectName1 = Build
		SccLocalPath1 = Build
		SccProjectUniqueName2 = ServiceScheduler\\ServiceScheduler.csproj
		SccProjectName2 = ServiceScheduler
		SccLocalPath2 = ServiceScheduler
		SccProjectUniqueName3 = ServiceScheduler.Data\\ServiceScheduler.Data.csproj
		SccProjectName3 = ServiceScheduler.Data
		SccLocalPath3 = ServiceScheduler.Data
		SccProjectUniqueName4 = ServiceScheduler.UnitTests\\ServiceScheduler.UnitTests.csproj
		SccProjectName4 = ServiceScheduler.UnitTests
		SccLocalPath4 = ServiceScheduler.UnitTests
		SccProjectUniqueName5 = ServiceScheduler.Service\\ServiceScheduler.Service.csproj
		SccProjectName5 = ServiceScheduler.Service
		SccLocalPath5 = ServiceScheduler.Service
		SccProjectUniqueName6 = TestService\\TestService.csproj
		SccProjectName6 = TestService
		SccLocalPath6 = TestService
		SccProjectUniqueName7 = ServiceScheduler.Portal\\ServiceScheduler.Portal.csproj
		SccProjectName7 = ServiceScheduler.Portal
		SccLocalPath7 = ServiceScheduler.Portal
		SccProjectUniqueName8 = ServiceScheduler.FunctionalTest\\ServiceScheduler.FunctionalTest.csproj
		SccProjectName8 = ServiceScheduler.FunctionalTest
		SccLocalPath8 = ServiceScheduler.FunctionalTest
		SccProjectUniqueName9 = BaseTestService\\BaseTestService.csproj
		SccProjectTopLevelParentUniqueName9 = ServiceScheduler.sln
		SccProjectName9 = BaseTestService
		SccLocalPath9 = BaseTestService
		SccProjectUniqueName10 = ServiceA.v01\\ServiceA.v01.csproj
		SccProjectTopLevelParentUniqueName10 = ServiceScheduler.sln
		SccProjectName10 = ServiceA.v01
		SccLocalPath10 = ServiceA.v01
		SccProjectUniqueName11 = ServiceA.v02\\ServiceA.v02.csproj
		SccProjectTopLevelParentUniqueName11 = ServiceScheduler.sln
		SccProjectName11 = ServiceA.v02
		SccLocalPath11 = ServiceA.v02
		SccProjectUniqueName12 = ServiceA.v03\\ServiceA.v03.csproj
		SccProjectTopLevelParentUniqueName12 = ServiceScheduler.sln
		SccProjectName12 = ServiceA.v03
		SccLocalPath12 = ServiceA.v03
		SccProjectUniqueName13 = ServiceB.v01\\ServiceB.v01.csproj
		SccProjectTopLevelParentUniqueName13 = ServiceScheduler.sln
		SccProjectName13 = ServiceB.v01
		SccLocalPath13 = ServiceB.v01
		SccProjectUniqueName14 = ZipFilesUtility\\ZipFilesUtility.csproj
		SccProjectTopLevelParentUniqueName14 = ServiceScheduler.sln
		SccProjectName14 = ZipFilesUtility
		SccLocalPath14 = ZipFilesUtility
		SccProjectUniqueName15 = ServiceScheduler.WebApi\\ServiceScheduler.WebApi.csproj
		SccProjectName15 = ServiceScheduler.WebApi
		SccLocalPath15 = ServiceScheduler.WebApi
		SccProjectUniqueName16 = ServiceScheduler.WebApi.FunctionalTests\\ServiceScheduler.WebApi.FunctionalTests.csproj
		SccProjectName16 = ServiceScheduler.WebApi.FunctionalTests
		SccLocalPath16 = ServiceScheduler.WebApi.FunctionalTests
	EndGlobalSection
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		DebugLocal|Any CPU = DebugLocal|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{B018B820-D4EA-472E-BB1F-1ECA5AA038B8}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{B018B820-D4EA-472E-BB1F-1ECA5AA038B8}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{B018B820-D4EA-472E-BB1F-1ECA5AA038B8}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{B018B820-D4EA-472E-BB1F-1ECA5AA038B8}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{B018B820-D4EA-472E-BB1F-1ECA5AA038B8}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{B018B820-D4EA-472E-BB1F-1ECA5AA038B8}.Release|Any CPU.Build.0 = Release|Any CPU
		{F14D9875-EF4D-4979-ADEC-E26CD8C9EC78}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{F14D9875-EF4D-4979-ADEC-E26CD8C9EC78}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{F14D9875-EF4D-4979-ADEC-E26CD8C9EC78}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{F14D9875-EF4D-4979-ADEC-E26CD8C9EC78}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{F14D9875-EF4D-4979-ADEC-E26CD8C9EC78}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{F14D9875-EF4D-4979-ADEC-E26CD8C9EC78}.Release|Any CPU.Build.0 = Release|Any CPU
		{AE48F4C5-1882-4ED7-B723-B70D394EA651}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{AE48F4C5-1882-4ED7-B723-B70D394EA651}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{AE48F4C5-1882-4ED7-B723-B70D394EA651}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{AE48F4C5-1882-4ED7-B723-B70D394EA651}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{AE48F4C5-1882-4ED7-B723-B70D394EA651}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{AE48F4C5-1882-4ED7-B723-B70D394EA651}.Release|Any CPU.Build.0 = Release|Any CPU
		{01541D27-FE42-40C2-BD67-48CC2D5D1287}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{01541D27-FE42-40C2-BD67-48CC2D5D1287}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{01541D27-FE42-40C2-BD67-48CC2D5D1287}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{01541D27-FE42-40C2-BD67-48CC2D5D1287}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{01541D27-FE42-40C2-BD67-48CC2D5D1287}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{01541D27-FE42-40C2-BD67-48CC2D5D1287}.Release|Any CPU.Build.0 = Release|Any CPU
		{C61E3CFA-B61F-4123-BE07-6CAB433B7E9C}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{C61E3CFA-B61F-4123-BE07-6CAB433B7E9C}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{C61E3CFA-B61F-4123-BE07-6CAB433B7E9C}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{C61E3CFA-B61F-4123-BE07-6CAB433B7E9C}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{C61E3CFA-B61F-4123-BE07-6CAB433B7E9C}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{C61E3CFA-B61F-4123-BE07-6CAB433B7E9C}.Release|Any CPU.Build.0 = Release|Any CPU
		{A4316C4C-7723-4C2E-9017-AC7E464984D9}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{A4316C4C-7723-4C2E-9017-AC7E464984D9}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{A4316C4C-7723-4C2E-9017-AC7E464984D9}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{A4316C4C-7723-4C2E-9017-AC7E464984D9}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{A4316C4C-7723-4C2E-9017-AC7E464984D9}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{A4316C4C-7723-4C2E-9017-AC7E464984D9}.Release|Any CPU.Build.0 = Release|Any CPU
		{034D778D-B6DB-42D8-8D08-92AD7246F68E}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{034D778D-B6DB-42D8-8D08-92AD7246F68E}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{034D778D-B6DB-42D8-8D08-92AD7246F68E}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{034D778D-B6DB-42D8-8D08-92AD7246F68E}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{034D778D-B6DB-42D8-8D08-92AD7246F68E}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{034D778D-B6DB-42D8-8D08-92AD7246F68E}.Release|Any CPU.Build.0 = Release|Any CPU
		{00C7FFF8-E054-44C3-9CB6-9051E24FDA32}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{00C7FFF8-E054-44C3-9CB6-9051E24FDA32}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{00C7FFF8-E054-44C3-9CB6-9051E24FDA32}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{00C7FFF8-E054-44C3-9CB6-9051E24FDA32}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{00C7FFF8-E054-44C3-9CB6-9051E24FDA32}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{00C7FFF8-E054-44C3-9CB6-9051E24FDA32}.Release|Any CPU.Build.0 = Release|Any CPU
		{23EDF47D-AC14-4E5D-86C8-573786483563}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{23EDF47D-AC14-4E5D-86C8-573786483563}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{23EDF47D-AC14-4E5D-86C8-573786483563}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{23EDF47D-AC14-4E5D-86C8-573786483563}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{23EDF47D-AC14-4E5D-86C8-573786483563}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{23EDF47D-AC14-4E5D-86C8-573786483563}.Release|Any CPU.Build.0 = Release|Any CPU
		{BEE0240E-7DD1-4482-843B-859CCAF6E2FA}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{BEE0240E-7DD1-4482-843B-859CCAF6E2FA}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{BEE0240E-7DD1-4482-843B-859CCAF6E2FA}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{BEE0240E-7DD1-4482-843B-859CCAF6E2FA}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{BEE0240E-7DD1-4482-843B-859CCAF6E2FA}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{BEE0240E-7DD1-4482-843B-859CCAF6E2FA}.Release|Any CPU.Build.0 = Release|Any CPU
		{D251D7BB-6D11-43E1-AC75-F3FD616D2BA3}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{D251D7BB-6D11-43E1-AC75-F3FD616D2BA3}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{D251D7BB-6D11-43E1-AC75-F3FD616D2BA3}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{D251D7BB-6D11-43E1-AC75-F3FD616D2BA3}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{D251D7BB-6D11-43E1-AC75-F3FD616D2BA3}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{D251D7BB-6D11-43E1-AC75-F3FD616D2BA3}.Release|Any CPU.Build.0 = Release|Any CPU
		{D0709ABD-BD47-43EF-B958-B90D1FD22860}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{D0709ABD-BD47-43EF-B958-B90D1FD22860}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{D0709ABD-BD47-43EF-B958-B90D1FD22860}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{D0709ABD-BD47-43EF-B958-B90D1FD22860}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{D0709ABD-BD47-43EF-B958-B90D1FD22860}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{D0709ABD-BD47-43EF-B958-B90D1FD22860}.Release|Any CPU.Build.0 = Release|Any CPU
		{FF22C5F6-5162-4F02-BCCA-E6A208EB23ED}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{FF22C5F6-5162-4F02-BCCA-E6A208EB23ED}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{FF22C5F6-5162-4F02-BCCA-E6A208EB23ED}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{FF22C5F6-5162-4F02-BCCA-E6A208EB23ED}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{FF22C5F6-5162-4F02-BCCA-E6A208EB23ED}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{FF22C5F6-5162-4F02-BCCA-E6A208EB23ED}.Release|Any CPU.Build.0 = Release|Any CPU
		{FDCA97F9-E3BD-422A-A90F-181957B457E6}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{FDCA97F9-E3BD-422A-A90F-181957B457E6}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{FDCA97F9-E3BD-422A-A90F-181957B457E6}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{FDCA97F9-E3BD-422A-A90F-181957B457E6}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{FDCA97F9-E3BD-422A-A90F-181957B457E6}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{FDCA97F9-E3BD-422A-A90F-181957B457E6}.Release|Any CPU.Build.0 = Release|Any CPU
		{B0A9A6EA-A9CB-4000-AD2C-8DAE4B3C8BF6}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{B0A9A6EA-A9CB-4000-AD2C-8DAE4B3C8BF6}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{B0A9A6EA-A9CB-4000-AD2C-8DAE4B3C8BF6}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{B0A9A6EA-A9CB-4000-AD2C-8DAE4B3C8BF6}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{B0A9A6EA-A9CB-4000-AD2C-8DAE4B3C8BF6}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{B0A9A6EA-A9CB-4000-AD2C-8DAE4B3C8BF6}.Release|Any CPU.Build.0 = Release|Any CPU
		{B24C3C2C-2827-4C4D-9DFF-2A7A36512640}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{B24C3C2C-2827-4C4D-9DFF-2A7A36512640}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{B24C3C2C-2827-4C4D-9DFF-2A7A36512640}.DebugLocal|Any CPU.ActiveCfg = DebugLocal|Any CPU
		{B24C3C2C-2827-4C4D-9DFF-2A7A36512640}.DebugLocal|Any CPU.Build.0 = DebugLocal|Any CPU
		{B24C3C2C-2827-4C4D-9DFF-2A7A36512640}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{B24C3C2C-2827-4C4D-9DFF-2A7A36512640}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(NestedProjects) = preSolution
		{CA8CFBAB-879E-4DE5-86D4-A904057F50CA} = {8E93B358-FED4-4F0E-B442-71A0EB2C8344}
		{FB4219E8-41DF-4A15-9788-39C33EE46152} = {8E93B358-FED4-4F0E-B442-71A0EB2C8344}
		{23EDF47D-AC14-4E5D-86C8-573786483563} = {0399AC80-49E9-4BF4-AC94-0A91F84B2907}
		{0399AC80-49E9-4BF4-AC94-0A91F84B2907} = {8E93B358-FED4-4F0E-B442-71A0EB2C8344}
		{BEE0240E-7DD1-4482-843B-859CCAF6E2FA} = {CA8CFBAB-879E-4DE5-86D4-A904057F50CA}
		{D251D7BB-6D11-43E1-AC75-F3FD616D2BA3} = {CA8CFBAB-879E-4DE5-86D4-A904057F50CA}
		{D0709ABD-BD47-43EF-B958-B90D1FD22860} = {CA8CFBAB-879E-4DE5-86D4-A904057F50CA}
		{FF22C5F6-5162-4F02-BCCA-E6A208EB23ED} = {FB4219E8-41DF-4A15-9788-39C33EE46152}
		{FDCA97F9-E3BD-422A-A90F-181957B457E6} = {54A95D55-C186-4806-B833-CB54925BB7AC}
		{B429CE39-1054-4E5F-9036-D507977F08E6} = {8E93B358-FED4-4F0E-B442-71A0EB2C8344}
	EndGlobalSection
EndGlobal
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.sln==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.sln.DotSettings.user==START]<wpf:ResourceDictionary xml:space="preserve" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" xmlns:s="clr-namespace:System;assembly=mscorlib" xmlns:ss="urn:shemas-jetbrains-com:settings-storage-xaml" xmlns:wpf="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
	<s:Boolean x:Key="/Default/Housekeeping/UnitTestingMru/UnitTestSessionPersistentData/=A72CF8BA81CB4ED9844145D33838845F/@KeyIndexDefined">True</s:Boolean>
	<s:String x:Key="/Default/Housekeeping/UnitTestingMru/UnitTestSessionPersistentData/=A72CF8BA81CB4ED9844145D33838845F/Name/@EntryValue">All tests from Miscellaneous Files</s:String>
	<s:String x:Key="/Default/Housekeeping/UnitTestingMru/UnitTestSessionPersistentData/=A72CF8BA81CB4ED9844145D33838845F/XmlSerializedElements/@EntryValue">&lt;Session&gt;&lt;Elements&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.GarbageCollectionJobTests" type="NUnitTestFixtureElement" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceApplicationJobTests" type="NUnitTestFixtureElement" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceRegistrationTests" type="NUnitTestFixtureElement" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestFixtureElement" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.FunctionalTest.ServiceSchedulerServiceRunTests" type="NUnitTestFixtureElement" Project="00C7FFF8-E054-44C3-9CB6-9051E24FDA32" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StartServiceControllerTests" type="NUnitTestFixtureElement" Project="B24C3C2C-2827-4C4D-9DFF-2A7A36512640" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests" type="NUnitTestFixtureElement" Project="B24C3C2C-2827-4C4D-9DFF-2A7A36512640" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.FunctionalTest.ServiceSchedulerServiceRunTests.ExecuteTwoServices_AddServiceAVersion2WhileVersion1Running_ExpectedResultsInDatabase" ParentId="ServiceScheduler.FunctionalTest.ServiceSchedulerServiceRunTests" type="NUnitTestElement" TypeName="ServiceScheduler.FunctionalTest.ServiceSchedulerServiceRunTests" MethodName="ExecuteTwoServices_AddServiceAVersion2WhileVersion1Running_ExpectedResultsInDatabase" Project="00C7FFF8-E054-44C3-9CB6-9051E24FDA32" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.FunctionalTest.ServiceSchedulerServiceRunTests.ExecuteTwoServices_DeployFastServiceFirstThenTwoSlowServices_ExpectedResultsInDatabase" ParentId="ServiceScheduler.FunctionalTest.ServiceSchedulerServiceRunTests" type="NUnitTestElement" TypeName="ServiceScheduler.FunctionalTest.ServiceSchedulerServiceRunTests" MethodName="ExecuteTwoServices_DeployFastServiceFirstThenTwoSlowServices_ExpectedResultsInDatabase" Project="00C7FFF8-E054-44C3-9CB6-9051E24FDA32" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.FunctionalTest.ServiceSchedulerServiceRunTests.ExecuteTwoServices_HappyPath_ExpectedResultsInDatabase" ParentId="ServiceScheduler.FunctionalTest.ServiceSchedulerServiceRunTests" type="NUnitTestElement" TypeName="ServiceScheduler.FunctionalTest.ServiceSchedulerServiceRunTests" MethodName="ExecuteTwoServices_HappyPath_ExpectedResultsInDatabase" Project="00C7FFF8-E054-44C3-9CB6-9051E24FDA32" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceApplicationJobTests.Execute_HappyPath_Expected" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceApplicationJobTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceApplicationJobTests" MethodName="Execute_HappyPath_Expected" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.GarbageCollectionJobTests.Execute_HappyPath_ExpectedDirectoriesDeleted" ParentId="ServiceScheduler.UnitTests.ServiceJobs.GarbageCollectionJobTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.GarbageCollectionJobTests" MethodName="Execute_HappyPath_ExpectedDirectoriesDeleted" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceApplicationJobTests.Execute_ServicePathEmpty_ExceptionThrown" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceApplicationJobTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceApplicationJobTests" MethodName="Execute_ServicePathEmpty_ExceptionThrown" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceApplicationJobTests.Execute_ServicePathNotExists_ExceptionThrown" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceApplicationJobTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceApplicationJobTests" MethodName="Execute_ServicePathNotExists_ExceptionThrown" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests.GetSertviceSchedulesFor_ServiceFound_ShouldReturnAll" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" MethodName="GetSertviceSchedulesFor_ServiceFound_ShouldReturnAll" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests.GetServiceSchedulesFor_ServiceNotFound_ShouldReturnNotFound" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" MethodName="GetServiceSchedulesFor_ServiceNotFound_ShouldReturnNotFound" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests.Post_HappyPath_ExpectSuccess" ParentId="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests" type="NUnitTestElement" TypeName="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests" MethodName="Post_HappyPath_ExpectSuccess" Project="B24C3C2C-2827-4C4D-9DFF-2A7A36512640" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StartServiceControllerTests.Post_HappyPath_ExpectSuccess" ParentId="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StartServiceControllerTests" type="NUnitTestElement" TypeName="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StartServiceControllerTests" MethodName="Post_HappyPath_ExpectSuccess" Project="B24C3C2C-2827-4C4D-9DFF-2A7A36512640" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests.Post_ServiceBadRequest_ExpectNotFound" ParentId="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests" type="NUnitTestElement" TypeName="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests" MethodName="Post_ServiceBadRequest_ExpectNotFound" Project="B24C3C2C-2827-4C4D-9DFF-2A7A36512640" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests.Post_ServiceIsNotRunning_ExpectNotFound" ParentId="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests" type="NUnitTestElement" TypeName="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests" MethodName="Post_ServiceIsNotRunning_ExpectNotFound" Project="B24C3C2C-2827-4C4D-9DFF-2A7A36512640" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StartServiceControllerTests.Post_ServiceIsRunning_ExpectConflict" ParentId="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StartServiceControllerTests" type="NUnitTestElement" TypeName="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StartServiceControllerTests" MethodName="Post_ServiceIsRunning_ExpectConflict" Project="B24C3C2C-2827-4C4D-9DFF-2A7A36512640" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests.Post_ServiceNotFound_ExpectNotFound" ParentId="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests" type="NUnitTestElement" TypeName="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests" MethodName="Post_ServiceNotFound_ExpectNotFound" Project="B24C3C2C-2827-4C4D-9DFF-2A7A36512640" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StartServiceControllerTests.Post_ServiceNotFound_ExpectNotFound" ParentId="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StartServiceControllerTests" type="NUnitTestElement" TypeName="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StartServiceControllerTests" MethodName="Post_ServiceNotFound_ExpectNotFound" Project="B24C3C2C-2827-4C4D-9DFF-2A7A36512640" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests.Post_ServiceRunNotFound_ExpectNotFound" ParentId="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests" type="NUnitTestElement" TypeName="ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService.StopServiceControllerTests" MethodName="Post_ServiceRunNotFound_ExpectNotFound" Project="B24C3C2C-2827-4C4D-9DFF-2A7A36512640" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceRegistrationTests.Register_ExistingService_ExpectUpdate" ParentId="ServiceScheduler.UnitTests.ServiceRegistrationTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceRegistrationTests" MethodName="Register_ExistingService_ExpectUpdate" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceRegistrationTests.Register_NewService_ExpectInsert" ParentId="ServiceScheduler.UnitTests.ServiceRegistrationTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceRegistrationTests" MethodName="Register_NewService_ExpectInsert" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests.SetServiceSchedule_ShouldInsertNewServiceSchedule_WhenServiceScheduleIdIs0" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" MethodName="SetServiceSchedule_ShouldInsertNewServiceSchedule_WhenServiceScheduleIdIs0" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests.SetServiceSchedule_ShouldReturnBadRequest_ForNullInput" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" MethodName="SetServiceSchedule_ShouldReturnBadRequest_ForNullInput" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests.SetServiceSchedule_ShouldReturnNotFound_ForInvalidServiceInput" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" MethodName="SetServiceSchedule_ShouldReturnNotFound_ForInvalidServiceInput" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests.SetServiceSchedule_ShouldReturnNotFound_ForUpdatingInexisistentSchedule" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" MethodName="SetServiceSchedule_ShouldReturnNotFound_ForUpdatingInexisistentSchedule" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests.SetServiceSchedule_ShouldUpdateExistingServiceSchedule_WhenServiceScheduleIdIsPresent" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" MethodName="SetServiceSchedule_ShouldUpdateExistingServiceSchedule_WhenServiceScheduleIdIsPresent" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests.StartServiceRun_HappyPath_ServiceRunCommited" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" MethodName="StartServiceRun_HappyPath_ServiceRunCommited" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests.StartServiceRun_ServiceScheduleNotFound_ExceptionThrown" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" MethodName="StartServiceRun_ServiceScheduleNotFound_ExceptionThrown" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests.StopServiceRun_HappyPath_ServiceRunCommited" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" MethodName="StopServiceRun_HappyPath_ServiceRunCommited" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests.StopServiceRun_ServiceRunNotFound_ExceptionThrown" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" MethodName="StopServiceRun_ServiceRunNotFound_ExceptionThrown" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests.UpdateServiceRun_HappyPath_ServiceRunCommited" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" MethodName="UpdateServiceRun_HappyPath_ServiceRunCommited" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;UnitTestElement Provider="nUnit" Id="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests.UpdateServiceRun_ServiceRunNotFound_ExceptionThrown" ParentId="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" type="NUnitTestElement" TypeName="ServiceScheduler.UnitTests.ServiceJobs.ServiceRunServiceTests" MethodName="UpdateServiceRun_ServiceRunNotFound_ExceptionThrown" Project="01541D27-FE42-40C2-BD67-48CC2D5D1287" /&gt;&lt;/Elements&gt;&lt;/Session&gt;</s:String></wpf:ResourceDictionary>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.sln.DotSettings.user==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.vssscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROJECT"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.vssscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\UpgradeService on the fly.txt==START]Phase I: Preparations:

01.Go to services database:	
	<add name="loc.AuCommonServices" providerName="System.Data.SqlClient" connectionString="server=.\sql2012;database=au_common_services_app;Integrated Security=True;MultipleActiveResultSets=True" />
02.Execute scripts to clear whatever you have already set:
	delete from [au_common_services_app].[dbo].[ServiceSchedule]
	delete from [au_common_services_app].[dbo].[Service]
03. Go to log database:
    <add name="loc.AuCommonServicesLog" providerName="System.Data.SqlClient" connectionString="server=.\sql2012;database=au_common_services_app_log;Integrated Security=True;MultipleActiveResultSets=True" />
04. Execute script to clear logs:
	truncate table [au_common_services_app_log].[dbo].[LogMessage]
05. Build solution so every project in it is built. Especially the TestServices - A and B- under "..ServiceScheduler\Test Services" folder.
06. Look into these projects. They are really simple
		1. console apps
		2. have a class -service - implemented the expected IServiceApplication interface from our nuget package. Basically mark this as a "plugin".
		3. in their AssemlyInfo.cs files we use the assembly attributes to
			a) name the service ServiceA or ServiceB
			b) set services to enabled = true.
			c) define 2 schedules for each service and bothe are enabled. They both run every 1 minute but in different working days.
			d) Each of them has a different version e.g : for 1.0.0.3 the name of the service ends with v03. This is done for both versioning and easy tracking.
		4. there is a TestService.cs class that will be executed, and will write unique information to event viewer. 
		5. You can find it under: "Computer management\System Tools\Event Viewer\Applications and Services Logs\Pinpoint", with the source ServiceScheduler.{servicename}
07. Go to project "..ServiceScheduler\FunctionalTests\ZipFilesUtility" and execute it. It will produce 4 zip files -service packages- under "..\Atlas\ServiceScheduler\Trunk" folder.
	a) Service A will have 3 versions - also in the name for easy identification
	b) Service B will have 1 version  - also in the name for easy identification
08. Open another windows explorer window and go to "...\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\bin\Debug\Services" This is where the applications are going to be installed.
09. Delete everything in the folder at step 08) to have a clean start.
10. Make sure to have ServiceScheduler.Service project as start-up project and inside Program.cs  
	//ServiceBase.Run(new ServiceBase[] { service }); 
	service.Start();
	This way we don't have to install service every time. You can use the service too if you want.

Phase II: - Act - Insertion of new service
01. Copy ServiceA.v01 and ServiceB.v02 to Services folder defined at I.08).
02. Ctrl+F5 on solution to start the scheduler console app. It will run without windows mode, you can still see it in task manager.
03. Wait for a minute so that schedules will kick in and start executing the test services.

Phase III: - Assert -  Insertion of new service
01. In the services folder you  will see 2 new folders: "Registred" and "Installed"
	a) Registred has both archives copied into it. (\Registered\ServiceA\1.0.0.1 & \Registered\ServiceB\1.0.0.1)
	b) Installed has the services unzipped and in proper folders: Name and versions - they are installed. The name is  the one defined in the AssemblyInfo.cs -> Service name.
02. In the database:
	a) in log database you can execute: SELECT * FROM [au_common_services_app_log].[dbo].[LogMessage] order by 1 desc. You should see that the service is started and all the steps it went through.
	b) in the services database execute: 
		SELECT * FROM [au_common_services_app].[dbo].[ServiceSchedule]
		SELECT * FROM [au_common_services_app].[dbo].[Service]
	c) You should see 4 schedules and 2 services. 2 of the schedules point to 1 service and 2 to the other service, as configured in AssemblyInfo.cs files.
	d) You should see the correct versions 1.0.0.1 and correct paths in the services
	e) Services are enabled = 1
	f) Schedules are enabled = 1

03. Event Viewer:
	a) By this time we should also see the services as executed at least once each, since they are triggered every 1 min. 
	b) Go to "Computer management\System Tools\Event Viewer\Applications and Services Logs\Pinpoint" and look for entries that have the source:
		1. ServiceScheduler.ServiceA.v01
		2. ServiceScheduler.ServiceB.v01
		They should have been triggered every minute.


Phase II: - Act - Upgrade of existing service
01. Service scheduler is still running. If not ,start it Ctrl+F5 or click .exe.
02. Copy ServiceA.v02.zip to Services folder. 
03. Rename it to some other extension, like ServiceA.v02.zit
04. Rename it to .zip extension like ServiceA.v02.zip

Phase II: - Assert - Upgrade of existing service
01. Services Folder
	a. The service is picked up and installed. 
	b. Check Services\Registered folder for ServiceA\1.0.0.2\<your initial zip file here>
	c. Check Services\Installed folder for ServiceA\1.0.0.2\ for unzipped content of the package.
02. In the database:
	a. in log database SELECT * FROM [au_common_services_app_log].[dbo].[LogMessage] order by 1 desc, new entries for service being registred.
	b) in the services database execute: 
		SELECT * FROM [au_common_services_app].[dbo].[ServiceSchedule]
		SELECT * FROM [au_common_services_app].[dbo].[Service]
	c) Schedules, exactly as before, nothing changed. Everyone of the 4 is enabled.
	b) Services
		- ServiceA - Has the new path to ..\Services\Installed\ServiceA\1.0.0.2\
				   - Service entry is ServiceA.v02.exe
				   - Service version is 1.0.0.2
				   - installation date is updated
	    - ServiceB - identical as before.
03. Event viewer:
	a) Go to "Computer management\System Tools\Event Viewer\Applications and Services Logs\Pinpoint" and look for entries that have the source:
	b) You should see entries for both ServiceA.v01 and ServiceB.v01. before upgrade
	c) You should see from now on only entries for ServiceA.v02 and ServiceB.v01 every minute after the upgrade.
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\UpgradeService on the fly.txt==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\BaseTestService\BaseTestService.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{23EDF47D-AC14-4E5D-86C8-573786483563}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>BaseTestService</RootNamespace>
    <AssemblyName>BaseTestService</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Pinpoint.EnterpriseScheduling">
      <HintPath>..\packages\Pinpoint.EnterpriseScheduling.1.0.0.10\lib\net452\Pinpoint.EnterpriseScheduling.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="EventLogHelper.cs" />
    <Compile Include="IEventLogHelper.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="packages.config" />
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\BaseTestService\BaseTestService.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\BaseTestService\BaseTestService.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\BaseTestService\BaseTestService.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\BaseTestService\EventLogHelper.cs==START]using System;
using System.Diagnostics;

namespace BaseTestService
{
    public class EventLogHelper : IEventLogHelper
    {
        private readonly string _eventLogSource;

        public EventLogHelper(string eventLogSource)
            : this(eventLogSource, null)
        {
        }

        public EventLogHelper(string eventLogSource, string eventLogName)
        {
            _eventLogSource = string.IsNullOrWhiteSpace(eventLogSource) ? "Application" : eventLogSource;
            string eventLogName1 = string.IsNullOrWhiteSpace(eventLogName) ? "Pinpoint" : eventLogName;

            try
            {
                if (!EventLog.SourceExists(_eventLogSource))
                {
                    EventLog.CreateEventSource(_eventLogSource, eventLogName1);
                }
            }
            catch
            {
            }
        }

        public void Error(string message)
        {
            Error(message, null);
        }

        public void Error(string message, Exception ex)
        {
            using (var eventLog = new EventLog())
            {
                if (ex != null)
                {
                    message += string.Format("\n\n{0}", ex);
                }

                eventLog.Source = _eventLogSource;
                eventLog.WriteEntry(message, EventLogEntryType.Error);
            }
        }

        public void Info(string message)
        {
            using (var eventLog = new EventLog())
            {
                eventLog.Source = _eventLogSource;
                eventLog.WriteEntry(message, EventLogEntryType.Information);
            }
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\BaseTestService\EventLogHelper.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\BaseTestService\IEventLogHelper.cs==START]using System;

namespace BaseTestService
{
    public interface IEventLogHelper
    {
        void Error(string message);
        void Error(string message, Exception ex);
        void Info(string message);
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\BaseTestService\IEventLogHelper.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\BaseTestService\packages.config==START]<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Pinpoint.EnterpriseScheduling" version="1.0.0.10" targetFramework="net452" />
</packages>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\BaseTestService\packages.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\BaseTestService\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("BaseTestService")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("BaseTestService")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("f353e739-3f24-46ef-bab1-9a874912ad1a")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\BaseTestService\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Build.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProductVersion>8.0.30703</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{B018B820-D4EA-472E-BB1F-1ECA5AA038B8}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>Build</RootNamespace>
    <AssemblyName>Build</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
    <TargetFrameworkProfile />
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <Prefer32Bit>false</Prefer32Bit>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <Prefer32Bit>false</Prefer32Bit>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Properties\AssemblyInfo.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="BuildCommonServices.ps1" />
    <None Include="BuildEverything.ps1" />
    <None Include="BuildSolution.ps1" />
    <None Include="UpdateVersion.ps1" />
    <None Include="Website\IIS_AddCertificate.ps1" />
    <None Include="Website\IIS_CreateAdminWebsite.ps1" />
    <None Include="Website\IIS_CreateWebsite.ps1" />
    <None Include="Website\IIS_CreateWebsites.ps1" />
    <None Include="Website\IIS_EnsureMIMETypes.ps1" />
    <None Include="Website\IIS_Unlock.ps1" />
    <None Include="Website\localhost_cert.pfx" />
    <None Include="Website\richcopy.cmd" />
    <None Include="WindowsServices\DeployServiceApplication.ps1" />
    <None Include="WindowsServices\DeployWindowsService.ps1" />
    <None Include="WindowsServices\InstallWindowsService.ps1" />
    <None Include="WindowsServices\Service\DeployTestService.ps1" />
    <None Include="WindowsServices\ServiceScheduler\DeployServiceScheduler.ps1" />
    <None Include="WindowsServices\ServiceScheduler\InstallServiceScheduler.ps1" />
    <None Include="WindowsServices\ServiceScheduler\UnInstallServiceScheduler.ps1" />
    <None Include="WindowsServices\UnInstallWindowsService.ps1" />
  </ItemGroup>
  <ItemGroup>
    <Content Include="Include.ps1" />
  </ItemGroup>
  <ItemGroup />
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Build.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Build.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Build.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\BuildCommonServices.ps1==START]$scriptLocation = [System.IO.Path]::GetDirectoryName($MyInvocation.MyCommand.Path)

pushd $scriptLocation

. ./Include.ps1

$buildToolsPath = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath("..\..\..\CommonServices\Trunk\CommonServices.BuildTools\")

# get latest build tools
tf get $buildToolsPath /recursive

cd $buildToolsPath
.\BuildEverything.ps1

popd

cd $scriptLocation
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\BuildCommonServices.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\BuildEverything.ps1==START]# Build Everything (LOCALLY)

write-host "Build common services..." -foregroundcolor green
.\BuildCommonServices.ps1

write-host "Build solution..." -foregroundcolor green
.\BuildSolution.ps1

write-host "Build local website..." -foregroundcolor green
cd Website
.\IIS_CreateWebsites.ps1 -AppPool "DefaultAppPool"
cd ..
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\BuildEverything.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\BuildSolution.ps1==START]Param($BuildConfig = "Debug")

set-alias tf "${Env:ProgramFiles(x86)}\Microsoft Visual Studio 11.0\Common7\IDE\tf.exe"
set-alias msbld "${Env:WinDir}\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
$scriptLocation = [System.IO.Path]::GetDirectoryName($MyInvocation.MyCommand.Path)
pushd $scriptLocation

. ./Include.ps1

# get the latest for the projects
tf get "..\" /recursive

$path = Split-Path $MyInvocation.MyCommand.Path
$path = $path -replace "\\Build", ""
msbld "$path\ServiceScheduler.sln" /noconsolelogger /p:Configuration="$BuildConfig"

popd
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\BuildSolution.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Include.ps1==START]set-alias tf "c:\program files (x86)\microsoft visual studio 12.0\common7\ide\TF.exe"
set-alias msbld "$env:windir\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
set-alias _7z "c:\program files\7-zip\7z.exe"

if (test-path "c:\program files (x86)\microsoft sql server\100\tools\binn\OSQL.EXE") {
	Set-Alias osql "c:\program files (x86)\microsoft sql server\100\tools\binn\OSQL.EXE"
} elseif (test-path "c:\program files (x86)\microsoft sql server\90\tools\binn\OSQL.EXE") {
	Set-Alias osql "c:\program files (x86)\microsoft sql server\90\tools\binn\OSQL.EXE"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Include.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\UpdateVersion.ps1==START]param([string]$AssemblyFile)

#
# [assembly: AssemblyTitle("INT Japan - Trunk - 30 Jan 2014")] // file description
# [assembly: AssemblyInformationalVersion("1.0")] // service version
# [assembly: AssemblyVersion("1.0.10")] // service build version
#

$scriptLocation = [System.IO.Path]::GetDirectoryName($MyInvocation.MyCommand.Path)
pushd $scriptLocation

. ./Include.ps1

if (Test-Path $AssemblyFile) {
	tf checkout $AssemblyFile
	
	$file = [IO.File]::ReadAllText("$AssemblyFile", [Text.Encoding]::ASCII)
	
	$file -match "\[assembly: AssemblyVersion\(`"(.*)\.(.*)`"\)\]"
	
	$majorVersion = $matches[1]
	$minorVersion = [int] $matches[2]
	
	# new versions
	$newMinorVersion = $minorVersion + 1
	$newVersion = $majorVersion + "." + $newMinorVersion
	$newDate = 	Get-Date -Format "dd MMM yyyy"

	$solutionPath = (Get-Location) -split "\\"
	$fileDescription = $solutionPath[-3] + " - " + $solutionPath[-2] + " - " + $newDate
	
	Write-Host "majorVersion : $majorVersion, newVersion : $newVersion, newMinorVersion : $newMinorVersion, newDate: $newDate"
	
	$file = $file -replace "\[assembly: AssemblyInformationalVersion\(`"[^`"]*`"\)\]", "[assembly: AssemblyInformationalVersion(`"$majorVersion`")]";
	$file = $file -replace "\[assembly: AssemblyVersion\(`"$majorVersion.$minorVersion`"\)\]", "[assembly: AssemblyVersion(`"$newVersion`")]";
	$file = $file -replace "\[assembly: AssemblyTitle\(`"[^`"]*`"\)\]", "[assembly: AssemblyTitle(`"$fileDescription`")]";

	# legacy
	$file = $file -replace "\[assembly: AssemblyVersionDate\(`"[^`"]*`"\)\]", "[assembly: AssemblyVersionDate(`"$newDate`")]";
	$file = $file -replace "(\[assembly: AssemblyVersionComment\(`"[^`"]* - Build) [0-9]*(`"\)\])", "`$1 $newMinorVersion`$2";
	
	$file | Out-File $AssemblyFile -encoding "ASCII"
	
	tf checkin $AssemblyFile /comment:"new version $newVersion" /noprompt
}

popd
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\UpdateVersion.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Build")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Build")]
[assembly: AssemblyCopyright("Copyright ©  2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("54fbb469-2adf-4056-bbcc-45d152f62eb8")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\IIS_AddCertificate.ps1==START]import-module WebAdministration
import-module WebAdministration

# add the ssl cert to local store if it doesn't already exist
certutil �f -p "TEST0000" �importpfx "localhost_cert.pfx"[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\IIS_AddCertificate.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\IIS_CreateAdminWebsite.ps1==START]Param( $Folder = '', $SiteName = '', $Port=0, $SslPort = 0, $AppPool = 'DefaultAppPool')

import-module WebAdministration

Write-Host "========================================================="
Write-Host "Create $SiteName"

# remove site if it exists
if (dir IIS:\Sites | Where {$_.Name -match $SiteName}) {
Remove-Item -recurse IIS:\Sites\$SiteName }

$basePath = Resolve-Path "..\..\$Folder"
# add the site
New-Item iis:\Sites\$SiteName -bindings @{protocol="http";bindingInformation=(":" + $Port + ":")} -physicalPath ("$basePath\")
Set-ItemProperty IIS:\Sites\$SiteName -name applicationPool -value $AppPool
New-WebBinding -Name $SiteName -IP "*" -Port $SslPort -Protocol https

Set-WebConfigurationProperty -filter /system.WebServer/security/authentication/AnonymousAuthentication -name enabled -value false -location $SiteName
Set-WebConfigurationProperty -filter /system.WebServer/security/authentication/windowsAuthentication -name enabled -value true -location $SiteName
Set-WebConfigurationProperty -filter /system.WebServer/security/authentication/basicAuthentication -name enabled -value false -location $SiteName

# add the ssl cert to IIS if it doesn't already exist
$iisBindings = dir IIS:\SslBindings | where {$_.Sites -eq $SiteName}
if ($null -eq $iisBindings -or $iisBindings.count -eq 0) {
	$cert = Get-ChildItem cert:\LocalMachine\My | where { $_.Subject -like "*LocalHost*" } | select -First 1
	$cert | New-Item IIS:\SslBindings\0.0.0.0!$SslPort  }

Write-Host "Create $SiteName Complete"

[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\IIS_CreateAdminWebsite.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\IIS_CreateWebsite.ps1==START]Param( $Folder = '', $SiteName = '', $Port=0, $SslPort = 0, $AppPool = 'DefaultAppPool')

import-module WebAdministration

Write-Host "========================================================="
Write-Host "Create $SiteName"

# remove site if it exists
if (dir IIS:\Sites | Where {$_.Name -match $SiteName}) {
Remove-Item -recurse IIS:\Sites\$SiteName }

$basePath = Resolve-Path "..\..\$Folder"
# add the site
New-Item iis:\Sites\$SiteName -bindings @{protocol="http";bindingInformation=(":" + $Port + ":")} -physicalPath ("$basePath\")
Set-ItemProperty IIS:\Sites\$SiteName -name applicationPool -value $AppPool
New-WebBinding -Name $SiteName -IP "*" -Port $SslPort -Protocol https

Set-WebConfigurationProperty -filter /system.WebServer/security/authentication/AnonymousAuthentication -name enabled -value true -location $SiteName
Set-WebConfigurationProperty -filter /system.WebServer/security/authentication/windowsAuthentication -name enabled -value false -location $SiteName
Set-WebConfigurationProperty -filter /system.WebServer/security/authentication/basicAuthentication -name enabled -value false -location $SiteName

# add the ssl cert to IIS if it doesn't already exist
$iisBindings = dir IIS:\SslBindings | where {$_.Sites -eq $SiteName}
if ($null -eq $iisBindings -or $iisBindings.count -eq 0) {
	$cert = Get-ChildItem cert:\LocalMachine\My | where { $_.Subject -like "*LocalHost*" } | select -First 1
	$cert | New-Item IIS:\SslBindings\0.0.0.0!$SslPort  }

Write-Host "Create $SiteName Complete"

[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\IIS_CreateWebsite.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\IIS_CreateWebsites.ps1==START]Param($AppPool = 'DefaultAppPool')
import-module WebAdministration

# See http://wiki/display/KB/Websites+-+Port+Ranges+-+Australia for appropriate ports

.\IIS_Unlock.ps1
.\IIS_AddCertificate.ps1
.\IIS_EnsureMIMETypes.ps1

.\IIS_CreateAdminWebsite.ps1 -Folder "ServiceScheduler.Portal" -SiteName "ServiceScheduler.Portal" -Port 55000 -SslPort 55001 -AppPool $AppPool
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\IIS_CreateWebsites.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\IIS_EnsureMIMETypes.ps1==START]import-module WebAdministration

# ensuring required MIME type(s)

if (!(Get-WebConfigurationProperty -Filter "//staticContent/mimeMap[@fileExtension='.woff']" -PSPath IIS:\ -Name fileExtension)) {
	Add-WebConfigurationProperty //staticContent -name collection -value @{fileExtension='.woff'; mimeType='application/font-woff'}
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\IIS_EnsureMIMETypes.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\IIS_Unlock.ps1==START]import-module WebAdministration

Write-Host "Unlock //isapiFilters"

set-webconfiguration //isapiFilters machine/webroot/apphost -metadata overrideMode -value Allow[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\IIS_Unlock.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\localhost_cert.pfx==START]0��0�Q	*�H��
��B�>0�:0�	*�H��
��� 0��0��*�H��

���0��0
*�H��
0b��DQ�!�����0�Ql�te1�.��+ќ���J�g��ᤃs�5��q�\��b_�x�ؖ�1�>n�Ad�q�����p��x~"Z������O�ϊd���Ѧ��QUL;�>�
��⵭-Ȇd�3;������7�{�!��������w����Y�ȲK��Q���~r�'7G�pe��)��
H
�xq�'��e��b���cT��6�ƌy
�����=ᙧ�;���|�g&���U9%�Q���\M��Q����
Ϭ����!5�#�A���%&�zr[���`�#奤�'f�#��"VTM�t�yi��"%���
'����D�-��{os�ҏЅKi$��枩Lx/鯂jg�Ȭ�t�q�NB,oJ�t�����]��gW�P*
�]��Z�� ��X��i�d/��&.�N�&=�,��� � ���Ю*��V�"�X��fpy�������Ok�b��Ѐ=6a�m9���B�'|��,��2���B
G����$��;����@�\�>!:��ڀH�w��F��:��.r��l��������CB���e'f(���о���T�덜�&z����f5�q�Z��t���[�!om�?r:�(�[�,o~	��;�>��Z0��+L!�#�#�͵(+�W?�r����hbTO1�-0
	+�71 0	*�H��
	1   0i	+�71\Z M i c r o s o f t   R S A   S C h a n n e l   C r y p t o g r a p h i c   P r o v i d e r0��	*�H��
	1���� b 4 2 b 2 d 7 4 f a d 5 a 5 4 a 0 e f c d d 9 b 8 0 e f 1 8 6 1 _ 2 a e e 7 5 7 f - e 9 0 0 - 4 a 6 6 - 8 a e 1 - e c f b 1 c 5 9 5 3 6 f0�	*�H��
��0� 0�	*�H��
0
*�H��
0�Z!�i�fЀ�غ��L�q
w�u��>�����ͧA�o�*�KqM�ޚN4LF��8�{��Bvi�jP���\N���|�̠f�I�
�E��}��5�57�]��6V��t~[�/=��eZ3a�-4�\�|C����K4��2��#+�
؋��Q���rvt��2��T�$jwA5���č��,M����w�)�P��w��:�{�����imZ㽠�R��u��x�9��[d'��ަ��Ě!������k��׃��o�o+9�P���w���
������2��ux(�l�4ߧ����upp��c����heq�S�u	�W��4�;iKg���;�+w�������<OqN�����=�?s
�r��:op3�v����Jb�G�����;�����1�Qon��[<f�E�ե��˃�wP�x����:�G?���Č�/����U��/\�y�"3�|'��#	li�`��Ƞ?z�����t���j(���y�M��x#�5�*����V�+�RDl�8'+�庚�����1]T�M�?���l���V.&��!�T ���i�!��u:���(3ԕ@��]5J�����ޝ�⌝ע~KE������'nh{b~�'�z��C%2z�\�%i4��5��-�Ԫ�،��N\�;�B�O��\��n�g�uU�v9�G�]AP�l�ˌ�.�7=%U�ޭ#��>�*�Õ2|~oW����ǡ>W�ll�B0;00+�@��`����}��: �,��M�wy���ܙ?�ɬ�N�n[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\localhost_cert.pfx==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\richcopy.cmd==START]@echo off 
rem COPYIT.BAT transfers all files in all subdirectories of
rem the source drive or directory (%1) to the destination rem drive or directory (%2) 

"C:\Program Files (x86)\Microsoft Rich Tools\RichCopy 4.0\RichCopy64.exe"  %1  %2 /ALWS /FIF "*.as??;*.dll;*.ini;*.txt;*.js;*.config;*.css;*.gif;*.svg;*.jpg;*.png;*.htm;*.html;*.xsl;*.xml;*.swf;*.lic;*.cer;*.pfx,*.ttf;*.woff" /FED "tinymce" /FEF "ChilkatDotNet2.dll;ISAPI_Rewrite.dll;WASamlProvider.csproj.FileListAbsolute.txt;WAOCB_AU.csproj.FileList.txt;WAOCS_AU.csproj.FileList.txt;WAOCS_AU.csproj.FileList.txt;WAOCB_AU.csproj.FileList.txt;WAWBParent.csproj.FileList.txt;WAWBParent.csproj.FileListAbsolute.txt" /TD 10 /QN /QP "C:\report.log" /UE /US /UD /UC /UPF /UPS /UFC /UCS /USC /USS /USD /UPR /UET
 

if errorlevel 4 goto lowmemory 
if errorlevel 2 goto abort 
if errorlevel 0 goto end

:lowmemory 
echo Insufficient memory to copy files or 
echo invalid drive or command-line syntax. 
echo From %1 to %2
goto end

:abort 
echo You pressed CTRL+C to end the copy operation. 
goto end

:end[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\Website\richcopy.cmd==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\DeployServiceApplication.ps1==START]Param(
	[Parameter(Mandatory=$true)] [string]$environment,
	[Parameter(Mandatory=$true)] [string]$versionUpgrade,
	[Parameter(Mandatory=$true)] [string]$serviceName,
	[Parameter(Mandatory=$true)] [string]$projectName,
	[Parameter(Mandatory=$true)] [string]$deployFolder
)

set-alias _7z "c:\program files\7-zip\7z.exe"

$okResponse = "1", "yes", "y", "true", "$true"
$isVersionUpgrade = $okResponse -contains $versionUpgrade
if ($isVersionUpgrade) {
	"Deploying app with version number update"
} else {
	"Deploying app without version number update"
}

set-alias msbld "$env:windir\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"

Write-Host "Environment = $environment"

$currentPath = Get-Location
$env:SolutionDir = (get-item $currentPath).parent.parent.parent.FullName

if ($environment -eq "loc") 
{
	$envDeployFolder = join-path $deployFolder "LOC"
	$buildConfiguration = "Release"
}
elseif ($environment -eq "uat") 
{
	$envDeployFolder = join-path $deployFolder "UAT"
	$buildConfiguration = "Release"
}
elseif ($environment -eq "live" -or $environment -eq "prod") 
{
	$envDeployFolder = join-path $deployFolder "LIVE-STAGING"
	$buildConfiguration = "Release"
}
$envDeployFolder = join-path $envDeployFolder "Services"
$envDeployFolder = join-path $envDeployFolder $projectName

if ($envDeployFolder.length -gt 0)
{
	$serviceProjectFolder = join-path $env:SolutionDir $projectName
	$serviceProjectFile = join-path $serviceProjectFolder "$projectName.csproj"

	if ($isVersionUpgrade)
	{
		$assemblyInfoFile = join-path $serviceProjectFolder "Properties\AssemblyInfo.cs"
		..\UpdateVersion.ps1 $assemblyInfoFile
	}

	msbld "$serviceProjectFile" /t:rebuild /p:Configuration=$buildConfiguration

	$serviceBinFolder = join-path $serviceProjectFolder ("bin\" + $buildConfiguration)
	$serviceExeFile = join-path $serviceBinFolder "$projectName.exe"

	$versionNumber = (Get-Item $serviceExeFile | Select -ExpandProperty VersionInfo).FileVersion 
	$versionPath = (Get-Location) -split "\\"
	$versionProject = $projectName + " - " + $versionPath[-4]
	$versionFullName = "$versionProject - Build $versionNumber"

	$batchFolder = join-path $envDeployFolder "Batch"
    $batchFile = join-path $batchFolder "$versionFullName.bat"

	$zipType = "zip"
	$installFolder = join-path $envDeployFolder "Install"
	$installFile = join-path $installFolder "$versionFullName.$zipType"

	Write-Host "Batch File: " + $batchFile
	Write-Host "Install Folder: " + $installFolder

	if (!(Test-Path -path $installFolder)) { New-Item $installFolder -Type Directory }

	if (Test-Path $installFile) { Remove-Item $installFile }

	_7z a -t"$zipType" $installFile "$serviceBinFolder\*.exe" "$serviceBinFolder\*.exe.config" "$serviceBinFolder\*.dll" "$serviceBinFolder\*.xml"

	$serverProgramFolder = "D:\Program Files\Pinpoint\" + $serviceName
	if ($environment -eq "loc") { $serverProgramFolder = join-path $env:SolutionDir ("ServiceScheduler.Service\bin\" + $buildConfiguration) }
	# note: rename file after copying, so that file watcher in service scheduler will know when copy is complete
	#       file watcher looks for files with extension
	$batchFileContent = '
if exist "' + $serverProgramFolder + '\Services\' + $projectName + '.' + $zipType + '" del "' + $serverProgramFolder + '\Services\' + $projectName + '.' + $zipType + '"
echo f | xcopy /y /f "' + $installFile +  '" "' + $serverProgramFolder + '\Services\' + $projectName + '._' + $zipType + '"
move /y "' + $serverProgramFolder + '\Services\' + $projectName + '._' + $zipType + '" "' + $serverProgramFolder + '\Services\' + $projectName + '.' + $zipType + '"
'

	if (!(Test-Path -path $batchFolder)) {New-Item $batchFolder -Type Directory}
	$batchFileObject = New-Item -Force -ItemType file $batchFile
	add-content $batchFileObject $batchFileContent
}
else
{
	Write-Host "Unrecognised environment, deployment not run"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\DeployServiceApplication.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\DeployWindowsService.ps1==START]Param(
	[Parameter(Mandatory=$true)] [string]$environment,
	[Parameter(Mandatory=$true)] [string]$versionUpgrade,
	[Parameter(Mandatory=$true)] [string]$serviceName,
	[Parameter(Mandatory=$true)] [string]$projectName,
	[Parameter(Mandatory=$true)] [string]$deployFolder
)

$okResponse = "1", "yes", "y", "true", "$true"
$isVersionUpgrade = $okResponse -contains $versionUpgrade
if ($isVersionUpgrade) {
	"Deploying app with version number update"
} else {
	"Deploying app without version number update"
}

set-alias msbld "$env:windir\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"

Write-Host "Environment = $environment"

$currentPath = Get-Location
$env:SolutionDir = (get-item $currentPath).parent.parent.parent.FullName

if ($environment -eq "uat") 
{
	$envDeployFolder = join-path $deployFolder "UAT"
	$envInstallFolder = join-path $deployFolder "UAT"
	$buildConfiguration = "Release"
}
elseif ($environment -eq "live" -or $environment -eq "prod") 
{
	$envDeployFolder = join-path $deployFolder "LIVE-STAGING"
	$envInstallFolder = join-path $deployFolder "LIVE"
	$buildConfiguration = "Release"
}

if ($envDeployFolder.length -gt 0)
{
	$serviceProjectFolder = join-path $env:SolutionDir $projectName
	$serviceProjectFile = join-path $serviceProjectFolder "$projectName.csproj"

	if ($isVersionUpgrade)
	{
		$assemblyInfoFile = join-path $serviceProjectFolder "Properties\AssemblyInfo.cs"
		..\..\UpdateVersion.ps1 $assemblyInfoFile
	}

	msbld "$serviceProjectFile" /t:rebuild /p:Configuration=$buildConfiguration

	$serviceBinFolder = join-path $serviceProjectFolder ("bin\" + $buildConfiguration)
	$serviceExeFile = join-path $serviceBinFolder "$projectName.exe"

	$versionNumber = (Get-Item $serviceExeFile | Select -ExpandProperty VersionInfo).FileVersion 
	$versionPath = (Get-Location) -split "\\"
	$versionProject = $serviceName + " - " + $versionPath[-4]
	$versionFullName = "$versionProject - Build $versionNumber"

	$batchFolder = join-path $envDeployFolder "Batch"
    $batchFile = join-path $batchFolder "$versionFullName.bat"

	$deployFolder = join-path $envDeployFolder ("Install\" + $versionFullName)
	$installFolder = join-path $envInstallFolder ("Install\" + $versionFullName)

	Write-Host "Batch File: " + $batchFile
	Write-Host "Deploy Folder: " + $deployFolder
	Write-Host "Install Folder: " + $installFolder

	if (!(Test-Path -path $deployFolder)) { New-Item $deployFolder -Type Directory }
	copy-item "$serviceBinFolder\*.exe" $deployFolder -force -recurse
	copy-item "$serviceBinFolder\*.exe.config" $deployFolder -force -recurse
	copy-item "$serviceBinFolder\*.dll" $deployFolder -force -recurse
	copy-item "$serviceBinFolder\*.xml" $deployFolder -force -recurse

	$batchFileContent = '
net stop ' + $serviceName + '
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\installutil.exe /u "D:\Program Files\Pinpoint\' + $serviceName + '\' + $projectName + '.exe"
xcopy /y /f /e "' + $installFolder +  '" "D:\Program Files\Pinpoint\' + $serviceName + '\"
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\installutil.exe /account=User "D:\Program Files\Pinpoint\' + $serviceName + '\' + $projectName + '.exe"
'
	if (!(Test-Path -path $batchFolder)) {New-Item $batchFolder -Type Directory}
	$batchFileObject = New-Item -ItemType file $batchFile
	add-content $batchFileObject $batchFileContent
}
else
{
	Write-Host "Unrecognised environment, deployment not run"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\DeployWindowsService.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\InstallWindowsService.ps1==START]param(
	[Parameter(Mandatory=$true)] [string]$environment,
	[Parameter(Mandatory=$true)] [string]$serviceName,
	[Parameter(Mandatory=$true)] [string]$projectName,
	[Parameter(Mandatory=$false)] [bool]$autoStart
)

set-alias msbld "$env:windir\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"

Write-Host "Environment = $environment"

$execFolder = "C:\Program Files\Pinpoint\" + $serviceName

$pinpointServiceName = "Pinpoint " + $serviceName

if (Get-Service $serviceName -ErrorAction SilentlyContinue)
{
	sc.exe stop $serviceName
	Start-Sleep -s 2
    sc.exe delete $serviceName
	Start-Sleep -s 2
}

# Create folder
if (!(Test-Path $execFolder)) {	md $execFolder }

$currentPath = Get-Location
$env:SolutionDir = (get-item $currentPath).parent.parent.parent.FullName
$buildConfiguration = "Release"
$serviceProjectFolder = join-path $env:SolutionDir $projectName
$serviceProjectFile = join-path $serviceProjectFolder "$projectName.csproj"
$serviceBinFolder = join-path $serviceProjectFolder "bin\$buildConfiguration"
$execFolder = $serviceBinFolder

write-host "Build configuration: $buildConfiguration"
msbld "$serviceProjectFile" /t:rebuild /p:Configuration=$buildConfiguration

if (!$?) {exit $lastExitCode}

# Install the Service
Write-Host "Installing $serviceName"
sc.exe create $serviceName binpath= "$execFolder\$projectName.exe" start= auto DisplayName= $pinpointServiceName
if (!$?) {exit $lastExitCode}

# Start the Service
if ($autoStart)
{
	Write-Host "Starting $serviceName"
	sc.exe start $serviceName
	Write-Host "Service started." -foregroundcolor "yellow"
}
else
{
	Write-Host "Service not started. Please start manually." -foregroundcolor "yellow"
}

exit $lastExitCode
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\InstallWindowsService.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\UnInstallWindowsService.ps1==START]param(
	[Parameter(Mandatory=$true)] [string]$serviceName
)

if (Get-Service $serviceName -ErrorAction SilentlyContinue)
{
	sc.exe stop $serviceName
	Start-Sleep -s 2
    sc.exe delete $serviceName
	Start-Sleep -s 2
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\UnInstallWindowsService.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\Service\DeployTestService.ps1==START]#Param(
#	[Parameter(Mandatory=$true)] [string]$environment,
#	[Parameter(Mandatory=$true)] [string]$versionUpgrade
#)
$environment = "LOC"
$versionUpgrade = $false

$deployFolder = convert-path Microsoft.PowerShell.Core\FileSystem::"\\au.pp.net\ppapps\ServiceScheduler\Australia"

$scriptLocation = [System.IO.Path]::GetDirectoryName($MyInvocation.MyCommand.Path)

pushd $scriptLocation
..\DeployServiceApplication.ps1 $environment $versionUpgrade ServiceScheduler TestService $deployFolder
popd[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\Service\DeployTestService.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\ServiceScheduler\DeployServiceScheduler.ps1==START]Param(
	[Parameter(Mandatory=$true)] [string]$environment,
	[Parameter(Mandatory=$true)] [string]$versionUpgrade
)

$deployFolder = convert-path Microsoft.PowerShell.Core\FileSystem::"\\au.pp.net\ppapps\ServiceScheduler\Australia"

$scriptLocation = [System.IO.Path]::GetDirectoryName($MyInvocation.MyCommand.Path)

pushd $scriptLocation
..\DeployWindowsService.ps1 $environment $versionUpgrade ServiceScheduler ServiceScheduler.Service $deployFolder
popd[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\ServiceScheduler\DeployServiceScheduler.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\ServiceScheduler\InstallServiceScheduler.ps1==START]param(
	[Parameter(Mandatory=$false)] [bool]$autoStart
)

$scriptLocation = [System.IO.Path]::GetDirectoryName($MyInvocation.MyCommand.Path)

pushd $scriptLocation
..\InstallWindowsService.ps1 loc ServiceScheduler ServiceScheduler.Service $autoStart
popd
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\ServiceScheduler\InstallServiceScheduler.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\ServiceScheduler\UnInstallServiceScheduler.ps1==START]$scriptLocation = [System.IO.Path]::GetDirectoryName($MyInvocation.MyCommand.Path)

pushd $scriptLocation
..\UnInstallWindowsService.ps1 ServiceScheduler
popd
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\Build\WindowsServices\ServiceScheduler\UnInstallServiceScheduler.ps1==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\App.config==START]<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
    </startup>
</configuration>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\App.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\packages.config==START]<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Pinpoint.EnterpriseScheduling" version="1.0.0.10" targetFramework="net452" />
</packages>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\packages.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\Program.cs==START]namespace ServiceA.v01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new TestService().Execute(args);
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\Program.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\ServiceA.v01.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{BEE0240E-7DD1-4482-843B-859CCAF6E2FA}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ServiceA.v01</RootNamespace>
    <AssemblyName>ServiceA</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
    <Prefer32Bit>false</Prefer32Bit>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Pinpoint.EnterpriseScheduling">
      <HintPath>..\packages\Pinpoint.EnterpriseScheduling.1.0.0.10\lib\net452\Pinpoint.EnterpriseScheduling.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Program.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
    <Compile Include="TestService.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
    <None Include="packages.config" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\BaseTestService\BaseTestService.csproj">
      <Project>{23edf47d-ac14-4e5d-86c8-573786483563}</Project>
      <Name>BaseTestService</Name>
    </ProjectReference>
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\ServiceA.v01.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\ServiceA.v01.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\ServiceA.v01.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\TestService.cs==START]using System;
using System.Threading;
using BaseTestService;
using Pinpoint.EnterpriseScheduling;

namespace ServiceA.v01
{
    public class TestService : IServiceApplication
    {
        public void Execute(string[] args)
        {
            new EventLogHelper("ServiceScheduler.ServiceA.v01").Info("ServiceA v01. Executed at:" + DateTime.Now.ToString("F"));
            Thread.Sleep(TimeSpan.FromSeconds(30));
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\TestService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
using Pinpoint.EnterpriseScheduling;

[assembly: AssemblyTitle("ServiceA")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("ServiceA")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("74c391f6-dc54-444b-b275-211b34939269")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]

//[assembly: ServiceApplication(ServiceName = "ServiceA", Enabled = true)] // used for functional tests
//[assembly: ServiceApplicationSchedule(ScheduleName = "ServiceA ONCE", Schedule = "ONCE", Enabled = true)] // used for functional tests

[assembly: ServiceApplication(ServiceName = "ServiceA", Enabled = true)]
[assembly: ServiceApplicationSchedule(ScheduleName = "Every 1 mins on Mon, Wed, Fri", Schedule = "0 0/1 * ? * MON,WED,FRI *", Enabled = true)]
[assembly: ServiceApplicationSchedule(ScheduleName = "Every 1 mins on Tue, Thu", Schedule = "0 0/1 * ? * TUE,THU *", Enabled = true)]
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v01\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\App.config==START]<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
    </startup>
</configuration>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\App.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\packages.config==START]<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Pinpoint.EnterpriseScheduling" version="1.0.0.10" targetFramework="net452" />
</packages>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\packages.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\Program.cs==START]namespace ServiceA.v02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new TestService().Execute(args);
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\Program.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\ServiceA.v02.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{D251D7BB-6D11-43E1-AC75-F3FD616D2BA3}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ServiceA.v02</RootNamespace>
    <AssemblyName>ServiceA</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>x64</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
    <Prefer32Bit>false</Prefer32Bit>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Pinpoint.EnterpriseScheduling">
      <HintPath>..\packages\Pinpoint.EnterpriseScheduling.1.0.0.10\lib\net452\Pinpoint.EnterpriseScheduling.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Program.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
    <Compile Include="TestService.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
    <None Include="packages.config" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\BaseTestService\BaseTestService.csproj">
      <Project>{23edf47d-ac14-4e5d-86c8-573786483563}</Project>
      <Name>BaseTestService</Name>
    </ProjectReference>
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\ServiceA.v02.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\ServiceA.v02.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\ServiceA.v02.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\TestService.cs==START]using System;
using System.Threading;
using BaseTestService;
using Pinpoint.EnterpriseScheduling;

namespace ServiceA.v02
{
    public class TestService : IServiceApplication
    {
        public void Execute(string[] args)
        {
            new EventLogHelper("ServiceScheduler.ServiceA.v02").Info("ServiceA v02. Executed at:" + DateTime.Now.ToString("F"));
            Thread.Sleep(TimeSpan.FromSeconds(30));
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\TestService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
using Pinpoint.EnterpriseScheduling;

[assembly: AssemblyTitle("ServiceA")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("ServiceA")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("4b9169d0-deff-4df1-9604-ed929c01fcd1")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.2")]
[assembly: AssemblyFileVersion("1.0.0.2")]

//[assembly: ServiceApplication(ServiceName = "ServiceA", Enabled = true)] // used for functional tests
//[assembly: ServiceApplicationSchedule(ScheduleName = "ServiceA ONCE", Schedule = "ONCE", Enabled = true)] // used for functional tests

[assembly: ServiceApplication(ServiceName = "ServiceA", Enabled = true)]
[assembly: ServiceApplicationSchedule(ScheduleName = "Every 1 mins on Mon, Wed, Fri", Schedule = "0 0/1 * ? * MON,WED,FRI *", Enabled = true)]
[assembly: ServiceApplicationSchedule(ScheduleName = "Every 1 mins on Tue, Thu", Schedule = "0 0/1 * ? * TUE,THU *", Enabled = true)]

[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v02\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\App.config==START]<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
    </startup>
</configuration>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\App.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\packages.config==START]<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Pinpoint.EnterpriseScheduling" version="1.0.0.10" targetFramework="net452" />
</packages>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\packages.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\Program.cs==START]namespace ServiceA.v03
{
     internal class Program
    {
        private static void Main(string[] args)
        {
            new TestService().Execute(args);
        }
    }

}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\Program.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\ServiceA.v03.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{D0709ABD-BD47-43EF-B958-B90D1FD22860}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ServiceA.v03</RootNamespace>
    <AssemblyName>ServiceA</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
    <Prefer32Bit>false</Prefer32Bit>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Pinpoint.EnterpriseScheduling">
      <HintPath>..\packages\Pinpoint.EnterpriseScheduling.1.0.0.10\lib\net452\Pinpoint.EnterpriseScheduling.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Program.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
    <Compile Include="TestService.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
    <None Include="packages.config" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\BaseTestService\BaseTestService.csproj">
      <Project>{23edf47d-ac14-4e5d-86c8-573786483563}</Project>
      <Name>BaseTestService</Name>
    </ProjectReference>
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\ServiceA.v03.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\ServiceA.v03.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\ServiceA.v03.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\TestService.cs==START]using System;
using System.Threading;
using BaseTestService;
using Pinpoint.EnterpriseScheduling;

namespace ServiceA.v03
{
    public class TestService : IServiceApplication
    {
        public void Execute(string[] args)
        {
            new EventLogHelper("ServiceScheduler.ServiceA.v03").Info("ServiceA v03. Executed at:" + DateTime.Now.ToString("F"));
            Thread.Sleep(TimeSpan.FromSeconds(30));
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\TestService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
using Pinpoint.EnterpriseScheduling;

[assembly: AssemblyTitle("ServiceA")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("ServiceA")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5ac276b5-19e7-461a-b5d4-ed43f602c367")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.3")]
[assembly: AssemblyFileVersion("1.0.0.3")]

[assembly: ServiceApplication(ServiceName = "ServiceA", Enabled = true)]
[assembly: ServiceApplicationSchedule(ScheduleName = "Every 1 mins on Mon, Wed, Fri", Schedule = "0 0/1 * ? * MON,WED,FRI *", Enabled = true)]
[assembly: ServiceApplicationSchedule(ScheduleName = "Every 1 mins on Tue, Thu", Schedule = "0 0/1 * ? * TUE,THU *", Enabled = true)]
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceA.v03\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\App.config==START]<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
    </startup>
</configuration>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\App.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\packages.config==START]<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Pinpoint.EnterpriseScheduling" version="1.0.0.10" targetFramework="net452" />
</packages>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\packages.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\Program.cs==START]namespace ServiceB.v01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new TestService().Execute(args);
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\Program.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\ServiceB.v01.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{FF22C5F6-5162-4F02-BCCA-E6A208EB23ED}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ServiceB.v01</RootNamespace>
    <AssemblyName>ServiceB</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
    <Prefer32Bit>false</Prefer32Bit>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Pinpoint.EnterpriseScheduling">
      <HintPath>..\packages\Pinpoint.EnterpriseScheduling.1.0.0.10\lib\net452\Pinpoint.EnterpriseScheduling.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Program.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
    <Compile Include="TestService.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
    <None Include="packages.config" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\BaseTestService\BaseTestService.csproj">
      <Project>{23EDF47D-AC14-4E5D-86C8-573786483563}</Project>
      <Name>BaseTestService</Name>
    </ProjectReference>
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\ServiceB.v01.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\ServiceB.v01.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\ServiceB.v01.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\TestService.cs==START]using System;
using System.Threading;
using BaseTestService;
using Pinpoint.EnterpriseScheduling;

namespace ServiceB.v01
{
    public class TestService : IServiceApplication
    {
        public void Execute(string[] args)
        {
            string parameters = string.Join(" ", args);
            new EventLogHelper("ServiceScheduler.ServiceB.v01").Info(
                string.Format("ServiceB v01. Executed at:{0} With parameters:{1}", DateTime.Now.ToString("F"), parameters));
            Thread.Sleep(TimeSpan.FromSeconds(30));
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\TestService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
using Pinpoint.EnterpriseScheduling;

[assembly: AssemblyTitle("ServiceB")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("ServiceB")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5c9be955-7b79-429d-971e-dcdda0883f37")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]

//[assembly: ServiceApplication(ServiceName = "ServiceB", Enabled = true)] // used for functional tests
//[assembly: ServiceApplicationSchedule(ScheduleName = "ServiceB ONCE", Schedule = "ONCE", Enabled = true, Parameters = "/a /b:\"Hello World!\"")] // used for functional tests

[assembly: ServiceApplication(ServiceName = "ServiceB", Enabled = true)]
[assembly: ServiceApplicationSchedule(ScheduleName = "Every 1 mins on Mon, Wed, Fri", Schedule = "0 0/1 * ? * MON,WED,FRI *", Enabled = true)]
[assembly: ServiceApplicationSchedule(ScheduleName = "Every 1 mins on Tue, Thu", Schedule = "0 0/1 * ? * TUE,THU *", Enabled = true)]
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceB.v01\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\App.config==START]<?xml version="1.0" encoding="utf-8"?>

<configuration>
  <configSections>

    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
    <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 --></configSections>
  <entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
    <providers>
      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    </providers>
  </entityFramework>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
  </startup>
</configuration>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\App.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\DbServiceRegistration.cs==START]using System;
using System.Linq;
using ServiceScheduler.Data.Model;
using ServiceScheduler.Data.Repository;
using ServiceScheduler.Domain;
using ServiceScheduler.FileServices;
using ServiceScheduler.LogAttributes;

namespace ServiceScheduler
{
    public class DbServiceRegistration : IDbServiceRegistration
    {
        private readonly IPathsProvider _pathsProvider;
        private readonly IServiceRepository _serviceRepository;

        public DbServiceRegistration(IPathsProvider pathsProvider, IServiceRepository serviceRepository)
        {
            _pathsProvider = pathsProvider;
            _serviceRepository = serviceRepository;
        }

        [Log]
        public virtual Service RegisterService(ServiceInformation serviceInformation)
        {
            var service = _serviceRepository.Retrieve(serviceInformation.ServiceName) ??
                                  BuildNewService(serviceInformation);
            var isNew = service.ServiceId <= 0;
            if (isNew)
            {
                _serviceRepository.Insert(service);
            }
            else
            {
                service.DateInstalled = DateTime.Now;
                service.ServicePath = _pathsProvider.GetServiceLocation(serviceInformation.ServiceName,
                    serviceInformation.ServiceVersion);
                service.ServiceVersion = serviceInformation.ServiceVersion;
                service.ServiceEntry = serviceInformation.ServiceEntry;
            }
            _serviceRepository.Commit();
            return service;
        }

        private Service BuildNewService(ServiceInformation serviceInformation)
        {
            return new Service
            {
                AllowConcurrency = serviceInformation.AllowConcurrency,
                ServicePath =
                    _pathsProvider.GetServiceLocation(serviceInformation.ServiceName, serviceInformation.ServiceVersion),
                ServiceVersion = serviceInformation.ServiceVersion,
                ServiceEntry = serviceInformation.ServiceEntry,
                DateInstalled = DateTime.Now,
                Enabled = serviceInformation.Enabled,
                ServiceName = serviceInformation.ServiceName,
                ModifiedBy = string.Empty,
                ServiceSchedule = serviceInformation.Schedule.Select(
                    o => new ServiceSchedule
                    {
                        Enabled = o.Enabled,
                        Parameters = o.Parameters,
                        Schedule = o.Schedule,
                        ScheduleName = o.ScheduleName,
                        ModifiedBy = string.Empty
                    }).ToList()
            };
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\DbServiceRegistration.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\IDbServiceRegistration.cs==START]using ServiceScheduler.Data.Model;
using ServiceScheduler.Domain;

namespace ServiceScheduler
{
    public interface IDbServiceRegistration
    {
        Service RegisterService(ServiceInformation serviceInformation);
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\IDbServiceRegistration.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\IServiceApplication.cs==START]namespace ServiceScheduler
{
    public interface IServiceApplication
    {
        void Execute();
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\IServiceApplication.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\IServiceRegistration.cs==START]namespace ServiceScheduler
{
    public interface IServiceRegistration
    {
        void InitializeFileWatcher();
        void InstallPendingPackages();
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\IServiceRegistration.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\IServiceScheduler.cs==START]using System.Collections.Generic;
using ServiceScheduler.Data.Model;
using ServiceScheduler.Domain;

namespace ServiceScheduler
{
    public interface IServiceScheduler
    {
        string GarbageCollectionSchedule { get; set; }
        void StartService(string serviceName, string serviceParameters);
        void StartServiceAll();
        void StopService(string serviceName, int serviceRunId);
        void StopServiceAll();
        ServiceInformation GetServiceInformation(string serviceName);
        List<ServiceInformation> GetServiceInformationAll();
        List<ServiceInformation> GetServiceInformationCurrent();
        void StopServiceScheduler();
        void RegisterService(Service service);
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\IServiceScheduler.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\job_scheduling_data_2_0.xsd==START]<?xml version="1.0" encoding="UTF-8"?>

<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema"
           xmlns="http://quartznet.sourceforge.net/JobSchedulingData"
           targetNamespace="http://quartznet.sourceforge.net/JobSchedulingData"
           elementFormDefault="qualified"
           version="2.0">

  <xs:element name="job-scheduling-data">
    <xs:annotation>
      <xs:documentation>Root level node</xs:documentation>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence maxOccurs="unbounded">
        <xs:element name="pre-processing-commands" type="pre-processing-commandsType" minOccurs="0" maxOccurs="1">
          <xs:annotation>
            <xs:documentation>Commands to be executed before scheduling the jobs and triggers in this file.</xs:documentation>
          </xs:annotation>
        </xs:element>
        <xs:element name="processing-directives" type="processing-directivesType" minOccurs="0" maxOccurs="1">
          <xs:annotation>
            <xs:documentation>Directives to be followed while scheduling the jobs and triggers in this file.</xs:documentation>
          </xs:annotation>
        </xs:element>
        <xs:element name="schedule" minOccurs="0" maxOccurs="unbounded">
          <xs:complexType>
            <xs:sequence maxOccurs="unbounded">
              <xs:element name="job" type="job-detailType" minOccurs="0" maxOccurs="unbounded" />
              <xs:element name="trigger" type="triggerType" minOccurs="0" maxOccurs="unbounded" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
      <xs:attribute name="version" type="xs:string">
        <xs:annotation>
          <xs:documentation>Version of the XML Schema instance</xs:documentation>
        </xs:annotation>
      </xs:attribute>
    </xs:complexType>
  </xs:element>

  <xs:complexType name="pre-processing-commandsType">
    <xs:sequence maxOccurs="unbounded">
      <xs:element name="delete-jobs-in-group" type="xs:string" minOccurs="0" maxOccurs="unbounded">
        <xs:annotation>
          <xs:documentation>Delete all jobs, if any, in the identified group. "*" can be used to identify all groups. Will also result in deleting all triggers related to the jobs.</xs:documentation>
        </xs:annotation>
      </xs:element>
      <xs:element name="delete-triggers-in-group" type="xs:string" minOccurs="0" maxOccurs="unbounded">
        <xs:annotation>
          <xs:documentation>Delete all triggers, if any, in the identified group. "*" can be used to identify all groups. Will also result in deletion of related jobs that are non-durable.</xs:documentation>
        </xs:annotation>
      </xs:element>
      <xs:element name="delete-job" minOccurs="0" maxOccurs="unbounded">
        <xs:annotation>
          <xs:documentation>Delete the identified job if it exists (will also result in deleting all triggers related to it).</xs:documentation>
        </xs:annotation>
        <xs:complexType>
          <xs:sequence>
            <xs:element name="name" type="xs:string" />
            <xs:element name="group" type="xs:string" minOccurs="0" />
          </xs:sequence>
        </xs:complexType>
      </xs:element>
      <xs:element name="delete-trigger" minOccurs="0" maxOccurs="unbounded">
        <xs:annotation>
          <xs:documentation>Delete the identified trigger if it exists (will also result in deletion of related jobs that are non-durable).</xs:documentation>
        </xs:annotation>
        <xs:complexType>
          <xs:sequence>
            <xs:element name="name" type="xs:string" />
            <xs:element name="group" type="xs:string" minOccurs="0" />
          </xs:sequence>
        </xs:complexType>
      </xs:element>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name="processing-directivesType">
    <xs:sequence>
      <xs:element name="overwrite-existing-data" type="xs:boolean" minOccurs="0" default="true">
        <xs:annotation>
          <xs:documentation>Whether the existing scheduling data (with same identifiers) will be overwritten. If false, and ignore-duplicates is not false, and jobs or triggers with the same names already exist as those in the file, an error will occur.</xs:documentation>
        </xs:annotation>
      </xs:element>
      <xs:element name="ignore-duplicates" type="xs:boolean" minOccurs="0" default="false">
        <xs:annotation>
          <xs:documentation>If true (and overwrite-existing-data is false) then any job/triggers encountered in this file that have names that already exist in the scheduler will be ignored, and no error will be produced.</xs:documentation>
        </xs:annotation>
      </xs:element>
      <xs:element name="schedule-trigger-relative-to-replaced-trigger" type="xs:boolean" minOccurs="0" default="false">
        <xs:annotation>
          <xs:documentation>If true trigger's start time is calculated based on earlier run time instead of fixed value. Trigger's start time must be undefined for this to work.</xs:documentation>
        </xs:annotation>
      </xs:element>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name="job-detailType">
    <xs:annotation>
      <xs:documentation>Define a JobDetail</xs:documentation>
    </xs:annotation>
    <xs:sequence>
      <xs:element name="name" type="xs:string" />
      <xs:element name="group" type="xs:string" minOccurs="0" />
      <xs:element name="description" type="xs:string" minOccurs="0" />
      <xs:element name="job-type" type="xs:string" />
      <xs:sequence minOccurs="0">
        <xs:element name="durable" type="xs:boolean" />
        <xs:element name="recover" type="xs:boolean" />
      </xs:sequence>
      <xs:element name="job-data-map" type="job-data-mapType" minOccurs="0" />
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name="job-data-mapType">
    <xs:annotation>
      <xs:documentation>Define a JobDataMap</xs:documentation>
    </xs:annotation>
    <xs:sequence minOccurs="0" maxOccurs="unbounded">
      <xs:element name="entry" type="entryType" />
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name="entryType">
    <xs:annotation>
      <xs:documentation>Define a JobDataMap entry</xs:documentation>
    </xs:annotation>
    <xs:sequence>
      <xs:element name="key" type="xs:string" />
      <xs:element name="value" type="xs:string" />
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name="triggerType">
    <xs:annotation>
      <xs:documentation>Define a Trigger</xs:documentation>
    </xs:annotation>
    <xs:choice>
      <xs:element name="simple" type="simpleTriggerType" />
      <xs:element name="cron" type="cronTriggerType" />
      <xs:element name="calendar-interval" type="calendarIntervalTriggerType" />
    </xs:choice>
  </xs:complexType>

  <xs:complexType name="abstractTriggerType" abstract="true">
    <xs:annotation>
      <xs:documentation>Common Trigger definitions</xs:documentation>
    </xs:annotation>
    <xs:sequence>
      <xs:element name="name" type="xs:string" />
      <xs:element name="group" type="xs:string" minOccurs="0" />
      <xs:element name="description" type="xs:string" minOccurs="0" />
      <xs:element name="job-name" type="xs:string" />
      <xs:element name="job-group" type="xs:string" minOccurs="0" />
      <xs:element name="priority" type="xs:nonNegativeInteger" minOccurs="0" />
      <xs:element name="calendar-name" type="xs:string" minOccurs="0" />
      <xs:element name="job-data-map" type="job-data-mapType" minOccurs="0" />
      <xs:sequence minOccurs="0">
        <xs:choice>
          <xs:element name="start-time" type="xs:dateTime" />
          <xs:element name="start-time-seconds-in-future" type="xs:nonNegativeInteger" />
        </xs:choice>
        <xs:element name="end-time" type="xs:dateTime" minOccurs="0" />
      </xs:sequence>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name="simpleTriggerType">
    <xs:annotation>
      <xs:documentation>Define a SimpleTrigger</xs:documentation>
    </xs:annotation>
    <xs:complexContent>
      <xs:extension base="abstractTriggerType">
        <xs:sequence>
          <xs:element name="misfire-instruction" type="simple-trigger-misfire-instructionType" minOccurs="0" />
          <xs:sequence minOccurs="0">
            <xs:element name="repeat-count" type="repeat-countType" />
            <xs:element name="repeat-interval" type="xs:nonNegativeInteger" />
          </xs:sequence>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name="cronTriggerType">
    <xs:annotation>
      <xs:documentation>Define a CronTrigger</xs:documentation>
    </xs:annotation>
    <xs:complexContent>
      <xs:extension base="abstractTriggerType">
        <xs:sequence>
          <xs:element name="misfire-instruction" type="cron-trigger-misfire-instructionType" minOccurs="0" />
          <xs:element name="cron-expression" type="cron-expressionType" />
          <xs:element name="time-zone" type="xs:string" minOccurs="0" />
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name="calendarIntervalTriggerType">
    <xs:annotation>
      <xs:documentation>Define a DateIntervalTrigger</xs:documentation>
    </xs:annotation>
    <xs:complexContent>
      <xs:extension base="abstractTriggerType">
        <xs:sequence>
          <xs:element name="misfire-instruction" type="date-interval-trigger-misfire-instructionType" minOccurs="0" />
          <xs:element name="repeat-interval" type="xs:nonNegativeInteger" />
          <xs:element name="repeat-interval-unit" type="interval-unitType" />
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:simpleType name="cron-expressionType">
    <xs:annotation>
      <xs:documentation>
        Cron expression (see JavaDoc for examples)

        Special thanks to Chris Thatcher (thatcher@butterfly.net) for the regular expression!

        Regular expressions are not my strong point but I believe this is complete,
        with the caveat that order for expressions like 3-0 is not legal but will pass,
        and month and day names must be capitalized.
        If you want to examine the correctness look for the [\s] to denote the
        seperation of individual regular expressions. This is how I break them up visually
        to examine them:

        SECONDS:
        (
        ((([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?,)*([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?)
        | (([\*]|[0-9]|[0-5][0-9])/([0-9]|[0-5][0-9]))
        | ([\?])
        | ([\*])
        ) [\s]
        MINUTES:
        (
        ((([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?,)*([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?)
        | (([\*]|[0-9]|[0-5][0-9])/([0-9]|[0-5][0-9]))
        | ([\?])
        | ([\*])
        ) [\s]
        HOURS:
        (
        ((([0-9]|[0-1][0-9]|[2][0-3])(-([0-9]|[0-1][0-9]|[2][0-3]))?,)*([0-9]|[0-1][0-9]|[2][0-3])(-([0-9]|[0-1][0-9]|[2][0-3]))?)
        | (([\*]|[0-9]|[0-1][0-9]|[2][0-3])/([0-9]|[0-1][0-9]|[2][0-3]))
        | ([\?])
        | ([\*])
        ) [\s]
        DAY OF MONTH:
        (
        ((([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])(-([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1]))?,)*([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])(-([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1]))?(C)?)
        | (([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])/([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])(C)?)
        | (L(-[0-9])?)
        | (L(-[1-2][0-9])?)
        | (L(-[3][0-1])?)
        | (LW)
        | ([1-9]W)
        | ([1-3][0-9]W)
        | ([\?])
        | ([\*])
        )[\s]
        MONTH:
        (
        ((([1-9]|0[1-9]|1[0-2])(-([1-9]|0[1-9]|1[0-2]))?,)*([1-9]|0[1-9]|1[0-2])(-([1-9]|0[1-9]|1[0-2]))?)
        | (([1-9]|0[1-9]|1[0-2])/([1-9]|0[1-9]|1[0-2]))
        | (((JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)(-(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))?,)*(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)(-(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))?)
        | ((JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)/(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))
        | ([\?])
        | ([\*])
        )[\s]
        DAY OF WEEK:
        (
        (([1-7](-([1-7]))?,)*([1-7])(-([1-7]))?)
        | ([1-7]/([1-7]))
        | (((MON|TUE|WED|THU|FRI|SAT|SUN)(-(MON|TUE|WED|THU|FRI|SAT|SUN))?,)*(MON|TUE|WED|THU|FRI|SAT|SUN)(-(MON|TUE|WED|THU|FRI|SAT|SUN))?(C)?)
        | ((MON|TUE|WED|THU|FRI|SAT|SUN)/(MON|TUE|WED|THU|FRI|SAT|SUN)(C)?)
        | (([1-7]|(MON|TUE|WED|THU|FRI|SAT|SUN))(L|LW)?)
        | (([1-7]|MON|TUE|WED|THU|FRI|SAT|SUN)#([1-7])?)
        | ([\?])
        | ([\*])
        )
        YEAR (OPTIONAL):
        (
        [\s]?
        ([\*])?
        | ((19[7-9][0-9])|(20[0-9][0-9]))?
        | (((19[7-9][0-9])|(20[0-9][0-9]))/((19[7-9][0-9])|(20[0-9][0-9])))?
        | ((((19[7-9][0-9])|(20[0-9][0-9]))(-((19[7-9][0-9])|(20[0-9][0-9])))?,)*((19[7-9][0-9])|(20[0-9][0-9]))(-((19[7-9][0-9])|(20[0-9][0-9])))?)?
        )
      </xs:documentation>
    </xs:annotation>
    <xs:restriction base="xs:string">
      <xs:pattern
        value="(((([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?,)*([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?)|(([\*]|[0-9]|[0-5][0-9])/([0-9]|[0-5][0-9]))|([\?])|([\*]))[\s](((([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?,)*([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?)|(([\*]|[0-9]|[0-5][0-9])/([0-9]|[0-5][0-9]))|([\?])|([\*]))[\s](((([0-9]|[0-1][0-9]|[2][0-3])(-([0-9]|[0-1][0-9]|[2][0-3]))?,)*([0-9]|[0-1][0-9]|[2][0-3])(-([0-9]|[0-1][0-9]|[2][0-3]))?)|(([\*]|[0-9]|[0-1][0-9]|[2][0-3])/([0-9]|[0-1][0-9]|[2][0-3]))|([\?])|([\*]))[\s](((([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])(-([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1]))?,)*([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])(-([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1]))?(C)?)|(([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])/([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])(C)?)|(L(-[0-9])?)|(L(-[1-2][0-9])?)|(L(-[3][0-1])?)|(LW)|([1-9]W)|([1-3][0-9]W)|([\?])|([\*]))[\s](((([1-9]|0[1-9]|1[0-2])(-([1-9]|0[1-9]|1[0-2]))?,)*([1-9]|0[1-9]|1[0-2])(-([1-9]|0[1-9]|1[0-2]))?)|(([1-9]|0[1-9]|1[0-2])/([1-9]|0[1-9]|1[0-2]))|(((JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)(-(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))?,)*(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)(-(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))?)|((JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)/(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))|([\?])|([\*]))[\s]((([1-7](-([1-7]))?,)*([1-7])(-([1-7]))?)|([1-7]/([1-7]))|(((MON|TUE|WED|THU|FRI|SAT|SUN)(-(MON|TUE|WED|THU|FRI|SAT|SUN))?,)*(MON|TUE|WED|THU|FRI|SAT|SUN)(-(MON|TUE|WED|THU|FRI|SAT|SUN))?(C)?)|((MON|TUE|WED|THU|FRI|SAT|SUN)/(MON|TUE|WED|THU|FRI|SAT|SUN)(C)?)|(([1-7]|(MON|TUE|WED|THU|FRI|SAT|SUN))?(L|LW)?)|(([1-7]|MON|TUE|WED|THU|FRI|SAT|SUN)#([1-7])?)|([\?])|([\*]))([\s]?(([\*])?|(19[7-9][0-9])|(20[0-9][0-9]))?| (((19[7-9][0-9])|(20[0-9][0-9]))/((19[7-9][0-9])|(20[0-9][0-9])))?| ((((19[7-9][0-9])|(20[0-9][0-9]))(-((19[7-9][0-9])|(20[0-9][0-9])))?,)*((19[7-9][0-9])|(20[0-9][0-9]))(-((19[7-9][0-9])|(20[0-9][0-9])))?)?)" />
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name="repeat-countType">
    <xs:annotation>
      <xs:documentation>Number of times to repeat the Trigger (-1 for indefinite)</xs:documentation>
    </xs:annotation>
    <xs:restriction base="xs:integer">
      <xs:minInclusive value="-1" />
    </xs:restriction>
  </xs:simpleType>


  <xs:simpleType name="simple-trigger-misfire-instructionType">
    <xs:annotation>
      <xs:documentation>Simple Trigger Misfire Instructions</xs:documentation>
    </xs:annotation>
    <xs:restriction base="xs:string">
      <xs:pattern value="SmartPolicy" />
      <xs:pattern value="RescheduleNextWithExistingCount" />
      <xs:pattern value="RescheduleNextWithRemainingCount" />
      <xs:pattern value="RescheduleNowWithExistingRepeatCount" />
      <xs:pattern value="RescheduleNowWithRemainingRepeatCount" />
      <xs:pattern value="FireNow" />
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name="cron-trigger-misfire-instructionType">
    <xs:annotation>
      <xs:documentation>Cron Trigger Misfire Instructions</xs:documentation>
    </xs:annotation>
    <xs:restriction base="xs:string">
      <xs:pattern value="SmartPolicy" />
      <xs:pattern value="DoNothing" />
      <xs:pattern value="FireOnceNow" />
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name="date-interval-trigger-misfire-instructionType">
    <xs:annotation>
      <xs:documentation>Date Interval Trigger Misfire Instructions</xs:documentation>
    </xs:annotation>
    <xs:restriction base="xs:string">
      <xs:pattern value="SmartPolicy" />
      <xs:pattern value="DoNothing" />
      <xs:pattern value="FireOnceNow" />
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name="interval-unitType">
    <xs:annotation>
      <xs:documentation>Interval Units</xs:documentation>
    </xs:annotation>
    <xs:restriction base="xs:string">
      <xs:pattern value="Day" />
      <xs:pattern value="Hour" />
      <xs:pattern value="Minute" />
      <xs:pattern value="Month" />
      <xs:pattern value="Second" />
      <xs:pattern value="Week" />
      <xs:pattern value="Year" />
    </xs:restriction>
  </xs:simpleType>

</xs:schema>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\job_scheduling_data_2_0.xsd==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\NinjectJobFactory.cs==START]using Ninject;
using Ninject.Syntax;
using Quartz;
using Quartz.Spi;

namespace ServiceScheduler
{
    public class NinjectJobFactory : IJobFactory
    {
        private readonly IResolutionRoot _resolutionRoot;

        public NinjectJobFactory(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return (IJob)_resolutionRoot.Get(bundle.JobDetail.JobType);
        }

        public void ReturnJob(IJob job)
        {
            _resolutionRoot.Release(job);
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\NinjectJobFactory.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\packages.config==START]<?xml version="1.0" encoding="utf-8"?>

<packages>
  <package id="Castle.Core" version="3.2.0" targetFramework="net452" />
  <package id="Common.Logging" version="3.0.0" targetFramework="net452" />
  <package id="Common.Logging.Core" version="3.0.0" targetFramework="net452" />
  <package id="EntityFramework" version="6.1.3" targetFramework="net452" />
  <package id="Newtonsoft.Json" version="6.0.4" targetFramework="net452" />
  <package id="Ninject" version="3.2.2.0" targetFramework="net452" />
  <package id="Ninject.Extensions.Interception" version="3.2.0.0" targetFramework="net452" />
  <package id="Ninject.Extensions.Interception.DynamicProxy" version="3.2.0.0" targetFramework="net452" />
  <package id="Pinpoint.EnterpriseLogging" version="1.0.0.5" targetFramework="net452" />
  <package id="Pinpoint.EnterpriseScheduling" version="1.0.0.10" targetFramework="net452" />
  <package id="Quartz" version="2.3.3" targetFramework="net452" />
</packages>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\packages.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceRegistration.cs==START]using ServiceScheduler.Data.Model;
using ServiceScheduler.DiskOperations;
using ServiceScheduler.Domain;
using ServiceScheduler.FileServices;
using ServiceScheduler.FileWatcher;
using ServiceScheduler.LogAttributes;
using ServiceScheduler.ServiceInformationCollector;

namespace ServiceScheduler
{
    public class ServiceRegistration : IServiceRegistration
    {
        private readonly IServiceWatcher _serviceWatcher;
        private readonly IDbServiceRegistration _dbServiceRegistration;
        private readonly IDiskArchiverService _diskArchiverService;
        private readonly IDiskInstallerService _diskInstallerService;
        private readonly IFileService _fileService;
        private readonly IPathsProvider _pathsProvider;
        private readonly IServiceInformationCollector _serviceInformationCollector;
        private readonly IServiceScheduler _serviceScheduler;

        public ServiceRegistration(IServiceWatcher serviceWatcher,
            IServiceInformationCollector serviceInformationCollector, IFileService fileService,
            IPathsProvider pathsProvider, IDiskInstallerService diskInstallerService,
            IDiskArchiverService diskArchiverService, IDbServiceRegistration dbServiceRegistration,
            IServiceScheduler serviceScheduler)
        {
            _serviceWatcher = serviceWatcher;
            _serviceInformationCollector = serviceInformationCollector;
            _fileService = fileService;
            _pathsProvider = pathsProvider;
            _diskInstallerService = diskInstallerService;
            _diskArchiverService = diskArchiverService;
            _dbServiceRegistration = dbServiceRegistration;
            _serviceScheduler = serviceScheduler;

        }

        [Log]
        public virtual void InstallPendingPackages()
        {
            var services = _pathsProvider.GetPendingInstallationServices();
            foreach (var service in services)
            {
                RegisterService(service);
            }
        }

        [Log]
        public virtual void InitializeFileWatcher()
        {
            _fileService.EnsureDirectoryExists(_pathsProvider.ServicesPath);
            _serviceWatcher.StartWatcher(_pathsProvider.ServicesPath);
            _serviceWatcher.NewVersionAvailable += OnNewServiceVersionAvailable;
        }

        private void OnNewServiceVersionAvailable(IServiceWatcher sender,
            NewVersionAvailableEventArgs args)
        {
            RegisterService(args.FullPath);
        }

        private void RegisterService(string serviceZipPath)
        {
            try
            {
                ServiceInformation serviceInformation;
                try
                {
                    serviceInformation = _serviceInformationCollector.ReadServiceInformation(serviceZipPath);
                }
                catch
                {
                    _diskArchiverService.ArchiveAsFailed(serviceZipPath);
                    return;
                }

                try
                {
                    _diskInstallerService.InstallService(serviceZipPath, serviceInformation);
                }
                catch
                {
                    _diskArchiverService.ArchiveAsFailed(serviceZipPath);
                    return;
                }

                try
                {
                    _diskArchiverService.ArchiveService(serviceZipPath, serviceInformation);
                }
                catch
                {

                    _diskInstallerService.UninstallService(serviceInformation);
                    _diskArchiverService.ArchiveAsFailed(serviceZipPath);
                    return;
                }

                Service service;
                try
                {
                    service = _dbServiceRegistration.RegisterService(serviceInformation);
                }
                catch
                {
                    _diskInstallerService.UninstallService(serviceInformation);
                    _diskArchiverService.ArchiveAsFailed(serviceZipPath);
                    return;
                }
                
                try
                {
                    _serviceScheduler.RegisterService(service);
                }
                catch
                {
                    //TODO: should we undo db registration and disk installations and move to archive failed?
                    return;
                }
            }
            catch 
            {
                //SINK exception as [Log] already logged it - some  do-uindo pattern here?
                return;
            }
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceRegistration.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceScheduler.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{F14D9875-EF4D-4979-ADEC-E26CD8C9EC78}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ServiceScheduler</RootNamespace>
    <AssemblyName>ServiceScheduler</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
    <TargetFrameworkProfile />
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>x64</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Castle.Core">
      <HintPath>..\packages\Castle.Core.3.2.0\lib\net45\Castle.Core.dll</HintPath>
    </Reference>
    <Reference Include="Common.Logging, Version=3.0.0.0, Culture=neutral, PublicKeyToken=af08829b84f0328e, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Common.Logging.3.0.0\lib\net40\Common.Logging.dll</HintPath>
    </Reference>
    <Reference Include="Common.Logging.Core">
      <HintPath>..\packages\Common.Logging.Core.3.0.0\lib\net40\Common.Logging.Core.dll</HintPath>
    </Reference>
    <Reference Include="EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, processorArchitecture=MSIL">
      <HintPath>..\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll</HintPath>
    </Reference>
    <Reference Include="EntityFramework.SqlServer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.SqlServer.dll</HintPath>
    </Reference>
    <Reference Include="Newtonsoft.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Newtonsoft.Json.6.0.4\lib\net45\Newtonsoft.Json.dll</HintPath>
    </Reference>
    <Reference Include="Ninject">
      <HintPath>..\packages\Ninject.3.2.2.0\lib\net45-full\Ninject.dll</HintPath>
    </Reference>
    <Reference Include="Ninject.Extensions.Interception">
      <HintPath>..\packages\Ninject.Extensions.Interception.3.2.0.0\lib\net45-full\Ninject.Extensions.Interception.dll</HintPath>
    </Reference>
    <Reference Include="Ninject.Extensions.Interception.DynamicProxy">
      <HintPath>..\packages\Ninject.Extensions.Interception.DynamicProxy.3.2.0.0\lib\net45-full\Ninject.Extensions.Interception.DynamicProxy.dll</HintPath>
    </Reference>
    <Reference Include="Pinpoint.EnterpriseLogging, Version=1.0.0.0, Culture=neutral, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Pinpoint.EnterpriseLogging.1.0.0.5\lib\net40\Pinpoint.EnterpriseLogging.dll</HintPath>
    </Reference>
    <Reference Include="Pinpoint.EnterpriseScheduling, Version=1.0.0.0, Culture=neutral, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Pinpoint.EnterpriseScheduling.1.0.0.10\lib\net452\Pinpoint.EnterpriseScheduling.dll</HintPath>
    </Reference>
    <Reference Include="Quartz, Version=2.3.3.0, Culture=neutral, PublicKeyToken=f6b8c98a402cc8a4, processorArchitecture=MSIL">
      <HintPath>..\packages\Quartz.2.3.3\lib\net40\Quartz.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.ComponentModel.DataAnnotations" />
    <Reference Include="System.Configuration" />
    <Reference Include="System.Core" />
    <Reference Include="System.Data.Services" />
    <Reference Include="System.IO.Compression" />
    <Reference Include="System.IO.Compression.FileSystem" />
    <Reference Include="System.Runtime.Serialization" />
    <Reference Include="System.ServiceModel" />
    <Reference Include="System.ServiceModel.Activation" />
    <Reference Include="System.ServiceModel.Web" />
    <Reference Include="System.Transactions" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="DbServiceRegistration.cs" />
    <Compile Include="DiskOperations\DiskArchiverService.cs" />
    <Compile Include="DiskOperations\DiskInstallerService.cs" />
    <Compile Include="Domain\ServiceInformation.cs" />
    <Compile Include="Domain\ServiceRunDto.cs" />
    <Compile Include="Domain\ServiceScheduleDto.cs" />
    <Compile Include="Domain\ServiceScheduleInformation.cs" />
    <Compile Include="Domain\SetScheduleResponse.cs" />
    <Compile Include="FileServices\FileService.cs" />
    <Compile Include="FileServices\IFileService.cs" />
    <Compile Include="FileServices\IPathsProvider.cs" />
    <Compile Include="FileServices\PathsProvider.cs" />
    <Compile Include="LogAttributes\LogHelper.cs" />
    <Compile Include="ServiceJobs\GarbageCollectionJob.cs" />
    <Compile Include="DiskOperations\IDiskInstallerService.cs" />
    <Compile Include="DiskOperations\IDiskArchiverService.cs" />
    <Compile Include="IDbServiceRegistration.cs" />
    <Compile Include="ServiceJobs\IServiceApplicationJob.cs" />
    <Compile Include="ServiceJobs\IGarbageCollectionJob.cs" />
    <Compile Include="QuartzBuilders\IQuartzBuilder.cs" />
    <Compile Include="QuartzBuilders\IQuartzBuilderDirector.cs" />
    <Compile Include="LogAttributes\LogAttribute.cs" />
    <Compile Include="LogAttributes\LogInterceptor.cs" />
    <Compile Include="NinjectJobFactory.cs" />
    <Compile Include="QuartzBuilders\QuartzBuilder.cs" />
    <Compile Include="QuartzBuilders\QuartzBuilderDirector.cs" />
    <Compile Include="ServiceInformationCollector\AssemblyReflectionManager.cs" />
    <Compile Include="AssembliesReader\IAssembliesReader.cs" />
    <Compile Include="AssembliesReader\DirectoryAssembliesReader.cs" />
    <Compile Include="ServiceInformationCollector\IServiceInformationCollector.cs" />
    <Compile Include="ServiceInformationCollector\ServiceInformationCollector.cs" />
    <Compile Include="AssembliesReader\ZipAssembliesReader.cs" />
    <Compile Include="FileWatcher\IServiceWatcher.cs" />
    <Compile Include="FileWatcher\NewVersionAvailableEventArgs.cs" />
    <Compile Include="FileWatcher\NewVersionAvailableHandler.cs" />
    <Compile Include="IServiceRegistration.cs" />
    <Compile Include="IServiceScheduler.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
    <Compile Include="FileWatcher\ServiceWatcher.cs" />
    <Compile Include="ServiceJobs\IServiceProcess.cs" />
    <Compile Include="ServiceJobs\IServiceRunService.cs" />
    <Compile Include="ServiceJobs\ProcessExitHandler.cs" />
    <Compile Include="ServiceJobs\ServiceProcess.cs" />
    <Compile Include="Domain\ServiceRunResponse.cs" />
    <Compile Include="ServiceJobs\ServiceRunService.cs" />
    <Compile Include="ServiceRegistration.cs" />
    <Compile Include="ServiceSchedulerCore.cs" />
    <Compile Include="ServiceJobs\ServiceApplicationJob.cs" />
    <Compile Include="ServiceSchedulerApi.cs" />
    <Compile Include="ServiceSchedulerIocModule.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
    <None Include="job_scheduling_data_2_0.xsd">
      <SubType>Designer</SubType>
    </None>
    <None Include="packages.config">
      <SubType>Designer</SubType>
    </None>
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\ServiceScheduler.Data\ServiceScheduler.Data.csproj">
      <Project>{ae48f4c5-1882-4ed7-b723-b70d394ea651}</Project>
      <Name>ServiceScheduler.Data</Name>
    </ProjectReference>
  </ItemGroup>
  <ItemGroup />
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceScheduler.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceScheduler.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceScheduler.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceSchedulerApi.cs==START]using System;
using System.Collections.Generic;
using Quartz;
using ServiceScheduler.Domain;

namespace ServiceScheduler
{
    public partial class ServiceSchedulerCore
    {
        public void StartService(string serviceName, string serviceParameters)
        {
            _logger.LogInfo(string.Format("Service '{0}' with parameters '{1}' started", serviceName, serviceParameters));
        }

        public void StopService(string serviceName, int serviceRunId)
        {
            _logger.LogInfo(string.Format("Service '{0}' for run id '{1}' stopped", serviceName, serviceRunId));
        }

        public void StopServiceAll()
        {
            _logger.LogInfo(string.Format("All Application Stopped"));
        }

        public ServiceInformation GetServiceInformation(string serviceName)
        {
            var service = _serviceRepository.Retrieve(serviceName);
            return service != null ? MapToServiceInformation(service) : null;
        }

        public List<ServiceInformation> GetServiceInformationCurrent()
        {
            var infoList = GetServiceInformationAll();

            foreach (var info in infoList)
            {
                var jobKey = new JobKey(info.ServiceName);
                if (_scheduler.CheckExists(jobKey))
                {
                    var jobTimes = new SortedSet<DateTime>();
                    var jobTriggers = _scheduler.GetTriggersOfJob(jobKey);
                    foreach (var trigger in jobTriggers)
                    {
                        var nextFireTime = trigger.GetNextFireTimeUtc();
                        if (!nextFireTime.HasValue) continue;

                        for (var i = 0; i < 3; i++)
                        {
                            jobTimes.Add(nextFireTime.Value.LocalDateTime);
                            nextFireTime = trigger.GetFireTimeAfter(nextFireTime);
                            if (!nextFireTime.HasValue) break;
                        }
                    }
                    //info.NextSchedule = jobTimes.Take(3);
                }
            }

            return infoList;
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceSchedulerApi.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceSchedulerCore.cs==START]using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Pinpoint.EnterpriseLogging.Interfaces;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using ServiceScheduler.Data.Model;
using ServiceScheduler.Data.Repository;
using ServiceScheduler.Domain;
using ServiceScheduler.LogAttributes;
using ServiceScheduler.QuartzBuilders;
using ServiceScheduler.ServiceJobs;

namespace ServiceScheduler
{
    public partial class ServiceSchedulerCore : IServiceScheduler
    {
        private readonly IQuartzBuilderDirector _quartzBuilderDirector;
        private readonly IScheduler _scheduler;
        private readonly IServiceRepository _serviceRepository;
        private readonly ILogger _logger;

        public ServiceSchedulerCore(IJobFactory jobFactory, IServiceRepository serviceRepository,
            IQuartzBuilderDirector quartzBuilderDirector, ILogger logger)
        {
            var serviceSchedulerPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var servicesFolderPath = Path.Combine(serviceSchedulerPath ?? string.Empty, "Services");
            if (!Directory.Exists(servicesFolderPath)) Directory.CreateDirectory(servicesFolderPath);

            _scheduler = new StdSchedulerFactory().GetScheduler();
            _scheduler.JobFactory = jobFactory;

            _serviceRepository = serviceRepository;
            _quartzBuilderDirector = quartzBuilderDirector;
            _logger = logger;
        }

        public string GarbageCollectionSchedule { get; set; }

        [Log]
        public virtual void StopServiceScheduler()
        {
            if (_scheduler != null)
            {
                _scheduler.Shutdown(true);
            }
        }
        
        [Log]
        public virtual void StartServiceAll()
        {
            _scheduler.Standby();
            var serviceInformationAll = GetServiceInformationAll();
            serviceInformationAll.ForEach(InsertJob<ServiceApplicationJob>);
            var garbageServiceInformation = GetGarbageCollectionService();
            InsertJob<GarbageCollectionJob>(garbageServiceInformation);
            _scheduler.Start();
        }

        [Log]
        public virtual void RegisterService(Service service)
        {
            RegisterService<ServiceApplicationJob>(service);
        }

        [Log]
        public virtual List<ServiceInformation> GetServiceInformationAll()
        {
            return _serviceRepository.Retrieve().Select(MapToServiceInformation).ToList();
        }

        private static ServiceInformation MapToServiceInformation(Service service)
        {
            var serviceRunningCount =
                Process.GetProcessesByName(service.ServiceName).Count(
                    p => p.MainModule.FileName.Equals(
                        service.ServicePath, StringComparison.InvariantCultureIgnoreCase));

            var serviceInformation = new ServiceInformation
            {
                ServiceName = service.ServiceName,
                ServicePath = service.ServicePath,
                ServiceEntry = service.ServiceEntry,
                ServiceVersion = service.ServiceVersion,
                //IsRunning = serviceRunningCount > 0,
                //IsRunningCount = serviceRunningCount,
                Enabled = service.Enabled,
                AllowConcurrency = service.AllowConcurrency,
                Schedule = service.ServiceSchedule.Select(
                    o => new ServiceScheduleInformation
                    {
                        Enabled = o.Enabled,
                        Parameters = o.Parameters,
                        Schedule = o.Schedule,
                        ScheduleName = o.ScheduleName,
                        ServiceSchedulerId = o.ServiceScheduleId
                    }).ToList()
            };

            return serviceInformation;
        }

        private void RegisterService<TJobType>(Service service)
        {
            if (JobIsAlreadyRegistered(service.ServiceName))
            {
                Delete(service.ServiceName);
            }
            var serviceInformation = MapToServiceInformation(service);
            InsertJob<TJobType>(serviceInformation);
        }

        private void InsertJob<TJobType>(ServiceInformation serviceInformation)
        {
            if (serviceInformation == null ||
                !serviceInformation.Schedule.Any() ||
                !serviceInformation.Enabled)
            {
                return;
            }
            var quartzBuilder = _quartzBuilderDirector.CreateQuartzBuilder(serviceInformation);
            var jobDetail = quartzBuilder.BuildJobDetail<TJobType>();
            if (jobDetail == null)
            {
                return;
            }
            var jobTriggers = quartzBuilder.BuildTriggers();
            if (jobTriggers == null || !jobTriggers.Any())
            {
                return;
            }
            var triggerList = new Quartz.Collection.HashSet<ITrigger>();
            jobTriggers
                .Where(t => !_scheduler.CheckExists(t.Key))
                .ToList()
                .ForEach(t => triggerList.Add(t));
            if (triggerList.Any())
            {
                _scheduler.ScheduleJob(jobDetail, triggerList, true);
            }
        }

        private bool JobIsAlreadyRegistered(string serviceName)
        {
            var jobKey = new JobKey(serviceName);
            return _scheduler.CheckExists(jobKey);
        }

        private bool Delete(string serviceName)
        {
            var jobKey = new JobKey(serviceName);
            return _scheduler.DeleteJob(jobKey);
        }

        private ServiceInformation GetGarbageCollectionService()
        {
            return new ServiceInformation
            {
                Enabled = true,
                ServiceName = "GarbageCollectionService",
                Schedule =
                    new List<ServiceScheduleInformation>
                    {
                        new ServiceScheduleInformation
                        {
                            Enabled = true,
                            ScheduleName = "GarbageCollectionSchedule",
                            Schedule = GarbageCollectionSchedule,
                            ServiceSchedulerId = null 
                        }
                    }
            };
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceSchedulerCore.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceSchedulerIocModule.cs==START]using Ninject.Modules;
using Pinpoint.EnterpriseLogging;
using Pinpoint.EnterpriseLogging.Interfaces;
using Quartz.Spi;
using ServiceScheduler.AssembliesReader;
using ServiceScheduler.Data.Repository;
using ServiceScheduler.DiskOperations;
using ServiceScheduler.FileServices;
using ServiceScheduler.FileWatcher;
using ServiceScheduler.QuartzBuilders;
using ServiceScheduler.ServiceInformationCollector;
using ServiceScheduler.ServiceJobs;

namespace ServiceScheduler
{
    public class ServiceSchedulerIocModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IJobFactory>().To<NinjectJobFactory>();
            Bind<IServiceApplicationJob>().To<ServiceApplicationJob>();
            Bind<IGarbageCollectionJob>().To<GarbageCollectionJob>();
            Bind<IServiceRepository>().To<ServiceRepository>();
            Bind<IServiceRepositoryFactory>().To<ServiceRepositoryFactory>();
            Bind<IAssembliesReader>().To<ZipAssembliesReader>();
            Bind<IServiceInformationCollector>().To<ServiceInformationCollector.ServiceInformationCollector>();
            Bind<ILogger>().ToMethod(o => Logger.Instance).InSingletonScope();
            Bind<IServiceWatcher>().To<ServiceWatcher>();
            Bind<IFileService>().To<FileService>();
            Bind<IPathsProvider>().To<PathsProvider>();
            Bind<IDiskInstallerService>().To<DiskInstallerService>();
            Bind<IDiskArchiverService>().To<DiskArchiverService>();
            Bind<IDbServiceRegistration>().To<DbServiceRegistration>();
            Bind<IQuartzBuilder>().To<QuartzBuilder>();
            Bind<IQuartzBuilderDirector>().To<QuartzBuilderDirector>();
            Bind<IServiceScheduler>().To<ServiceSchedulerCore>().InSingletonScope();
            Bind<IServiceRegistration>().To<ServiceRegistration>();
            Bind<IServiceProcess>().To<ServiceProcess>();
            Bind<IServiceRunService>().To<ServiceRunService>();
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceSchedulerIocModule.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\AssembliesReader\DirectoryAssembliesReader.cs==START]using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ServiceScheduler.LogAttributes;

namespace ServiceScheduler.AssembliesReader
{
    public class DirectoryAssembliesReader : IAssembliesReader
    {
        [Log]
        public virtual Dictionary<string, byte[]> ReadAssemblies(string sourcePath)
        {
            if (!Directory.Exists(sourcePath))
            {
                return null;
            }
            var dictionary = new Dictionary<string, byte[]>();
            var files =
                Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories)
                    .Where(p => (p.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) || 
                                 p.EndsWith(".exe", StringComparison.OrdinalIgnoreCase)) && 
                                !p.EndsWith(".vshost.exe", StringComparison.OrdinalIgnoreCase))
                    .ToList();
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file) ?? string.Empty;
                var rawAssembly = File.ReadAllBytes(file);
                dictionary.Add(fileName, rawAssembly);
            }
            return dictionary;
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\AssembliesReader\DirectoryAssembliesReader.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\AssembliesReader\IAssembliesReader.cs==START]using System.Collections.Generic;

namespace ServiceScheduler.AssembliesReader
{
    public interface IAssembliesReader
    {
        Dictionary<string, byte[]> ReadAssemblies(string sourcePath);
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\AssembliesReader\IAssembliesReader.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\AssembliesReader\ZipAssembliesReader.cs==START]using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ServiceScheduler.AssembliesReader
{
    public class ZipAssembliesReader : IAssembliesReader
    {
        public Dictionary<string, byte[]> ReadAssemblies(string sourcePath)
        {
            var dictionary = new Dictionary<string, byte[]>();
            if (!File.Exists(sourcePath) || Path.GetExtension(sourcePath) != ".zip")
            {
                return null;
            }
            using (var archive = ZipFile.OpenRead(sourcePath))
            {
                foreach (var entry in archive.Entries)
                {
                    var fullName = entry.FullName ?? string.Empty;
                    if (!fullName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) &&
                        (!fullName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) ||
                         fullName.EndsWith(".vshost.exe", StringComparison.OrdinalIgnoreCase)))
                    {
                        continue;
                    }
                    using (var stream = entry.Open())
                    {
                        var rawAssembly = new byte[(int) entry.Length];
                        stream.Read(rawAssembly, 0, (int) entry.Length);
                        dictionary.Add(Path.GetFileNameWithoutExtension(fullName), rawAssembly);
                    }
                }
            }
            return dictionary;
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\AssembliesReader\ZipAssembliesReader.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\DiskOperations\DiskArchiverService.cs==START]using System;
using System.IO;
using ServiceScheduler.Domain;
using ServiceScheduler.FileServices;
using ServiceScheduler.LogAttributes;

namespace ServiceScheduler.DiskOperations
{
    public class DiskArchiverService : IDiskArchiverService
    {
        private readonly IFileService _fileService;
        private readonly IPathsProvider _pathsProvider;

        public DiskArchiverService(IFileService fileService, IPathsProvider pathsProvider)
        {
            _fileService = fileService;
            _pathsProvider = pathsProvider;
        }
        
        [Log]
        public virtual void ArchiveService(string source, ServiceInformation serviceInformation)
        {
            var fileName = Path.GetFileName(source);
            var archivedFilePath = _pathsProvider.GetArchiveLocation(
                serviceInformation.ServiceName, serviceInformation.ServiceVersion, fileName);

            if (_fileService.FileExists(archivedFilePath))
            {
                archivedFilePath = string.Format("{0}.{1}", archivedFilePath,
                    DateTime.Now.ToString("ddMMyyyyhhmmss"));
            }
            _fileService.MoveFile(source, archivedFilePath);
        }

        [Log]
        public virtual void ArchiveAsFailed(string serviceZipPath)
        {
            var filePath = _pathsProvider.GetFailedZipDestination(Path.GetFileName(serviceZipPath));
            _fileService.MoveFile(serviceZipPath, filePath);
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\DiskOperations\DiskArchiverService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\DiskOperations\DiskInstallerService.cs==START]using ServiceScheduler.Domain;
using ServiceScheduler.FileServices;

namespace ServiceScheduler.DiskOperations
{
    public class DiskInstallerService : IDiskInstallerService
    {
        private readonly IFileService _fileService;
        private readonly IPathsProvider _pathsProvider;

        public DiskInstallerService(IFileService fileService,
            IPathsProvider pathsProvider)
        {
            _fileService = fileService;
            _pathsProvider = pathsProvider;
        }

        public void InstallService(string source, ServiceInformation serviceInformation)
        {
            var installDirectory = _pathsProvider.GetServiceLocation(serviceInformation.ServiceName,
                    serviceInformation.ServiceVersion);
            _fileService.UnZip(source, installDirectory);
        }

        public void UninstallService(ServiceInformation serviceInformation)
        {
            var installDirectory = _pathsProvider.GetServiceLocation(serviceInformation.ServiceName,
                   serviceInformation.ServiceVersion);
            _fileService.DeleteDirectory(installDirectory);
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\DiskOperations\DiskInstallerService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\DiskOperations\IDiskArchiverService.cs==START]using ServiceScheduler.Domain;

namespace ServiceScheduler.DiskOperations
{
    public interface IDiskArchiverService
    {
        void ArchiveService(string source, ServiceInformation serviceInformation);
        void ArchiveAsFailed(string serviceZipPath);
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\DiskOperations\IDiskArchiverService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\DiskOperations\IDiskInstallerService.cs==START]using ServiceScheduler.Domain;

namespace ServiceScheduler.DiskOperations
{
    public interface IDiskInstallerService
    {
        void InstallService(string source, ServiceInformation serviceInformation);
        void UninstallService(ServiceInformation serviceInformation);
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\DiskOperations\IDiskInstallerService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Domain\ServiceInformation.cs==START]using System;
using System.Collections.Generic;

namespace ServiceScheduler.Domain
{
    [Serializable]
    public class ServiceInformation
    {
        public ServiceInformation()
        {
            Schedule = new List<ServiceScheduleInformation>();
        }

        public string ServiceName { get; set; }
        public bool Enabled { get; set; }
        public bool AllowConcurrency { get; set; }
        public string ServiceVersion { get; set; }
        public string ServicePath { get; set; }
        public string ServiceEntry { get; set; }

        public List<ServiceScheduleInformation> Schedule { get; set; }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Domain\ServiceInformation.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Domain\ServiceRunDto.cs==START]namespace ServiceScheduler.Domain
{
    public class ServiceRunDto
    {
        public DatabaseInfo Database { get; set; }
        public OperatingSystemInfo OperatingSystem { get; set; }

        public class DatabaseInfo
        {
            public int ServiceRunId { get; set; }
            public string ServiceName { get; set; }
            public string Parameters { get; set; }
            public string Status { get; set; }
            public long RunningTimeInMs { get; set; }
        }

        public class OperatingSystemInfo
        {
            public bool IsProcessStillRunning { get; set; }
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Domain\ServiceRunDto.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Domain\ServiceRunResponse.cs==START]using System;

namespace ServiceScheduler.Domain
{
    [Serializable]
    public class ServiceRunResponse
    {
        public int ServiceRunId { get; set; }
        public Response State { get; set; }

        public enum Response
        {
            Ok,
            NotFound,
            Conflict
        }

        public static ServiceRunResponse NotFound()
        {
            return new ServiceRunResponse{State = Response.NotFound, ServiceRunId = -1};
        }
        public static ServiceRunResponse Conflict()
        {
            return new ServiceRunResponse {State = Response.Conflict, ServiceRunId = -1};
        }
        public static ServiceRunResponse Ok(int serviceRunId)
        {
            return new ServiceRunResponse{State = Response.Ok, ServiceRunId = serviceRunId};
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Domain\ServiceRunResponse.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Domain\ServiceScheduleDto.cs==START]namespace ServiceScheduler.Domain
{
    public class ServiceScheduleDto
    {
        public int ServiceScheduleId { get; set; }
        public int ServiceId { get; set; }
        public string ScheduleName { get; set; }
        public string Schedule { get; set; }
        public string Parameters { get; set; }
        public bool Enabled { get; set; }
        public string ModifiedBy { get; set; }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Domain\ServiceScheduleDto.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Domain\ServiceScheduleInformation.cs==START]using System;

namespace ServiceScheduler.Domain
{
    [Serializable]
    public class ServiceScheduleInformation
    {
        public int? ServiceSchedulerId { get; set; }
        public string ScheduleName { get; set; }
        public string Schedule { get; set; }
        public string Parameters { get; set; }
        public bool Enabled { get; set; }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Domain\ServiceScheduleInformation.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Domain\SetScheduleResponse.cs==START]using System;

namespace ServiceScheduler.Domain
{
    [Serializable]
    public class Response<T>
    {
        public T Content { get; set; }
        public StatusType Status { get; set; }

        public static Response<T> NotFound()
        {
            return new Response<T> {Status = StatusType.NotFound};
        }

        public static Response<T> Conflict()
        {
            return new Response<T> {Status = StatusType.Conflict};
        }

        public static Response<T> Ok(T content)
        {
            return new Response<T> {Status = StatusType.Ok, Content = content};
        }

        public static Response<T> BadRequest()
        {
            return new Response<T> {Status = StatusType.BadRequest};
        }
    }

    public enum StatusType
    {
        Ok,
        NotFound,
        Conflict,
        BadRequest
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Domain\SetScheduleResponse.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileServices\FileService.cs==START]using System;
using System.IO;
using System.IO.Compression;
using ServiceScheduler.LogAttributes;

namespace ServiceScheduler.FileServices
{
    public class FileService : IFileService
    {
        [Log]
        public virtual void UnZip(string sourceZipFile, string destinationDirectory)
        {
            if (!FileExists(sourceZipFile))
            {
                throw new Exception(string.Format("Source zip file does not exist. Expected source file: {0}.", sourceZipFile));
            }
            if (DirectoryExists(destinationDirectory))
            {
                throw new Exception(string.Format("Destination folder already exists: {0}.", destinationDirectory));
            }
            ZipFile.ExtractToDirectory(sourceZipFile, destinationDirectory);
        }

        [Log]
        public virtual void MoveFile(string source, string destination)
        {
            if (!FileExists(source))
            {
                throw new Exception(string.Format("File {0} wasn't found!", source));
            }
            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new Exception("Destination file is null or empty. It must have a valid value");
            }
            var directory = Path.GetDirectoryName(destination) ?? string.Empty;
            EnsureDirectoryExists(directory);
            File.Move(source, destination);
        }

        [Log]
        public virtual void EnsureDirectoryExists(string directory)
        {
            if (!DirectoryExists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        [Log]
        public virtual void DeleteDirectory(string directory)
        {
            if (DirectoryExists(directory))
            {
                Directory.Delete(directory);
            }
        }

        [Log]
        public virtual bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        [Log]
        public virtual bool DirectoryExists(string filePath)
        {
            return Directory.Exists(filePath);
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileServices\FileService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileServices\IFileService.cs==START]namespace ServiceScheduler.FileServices
{
    public interface IFileService
    {
        void UnZip(string sourceZipFile, string destinationDirectory);
        void MoveFile(string source, string destination);
        void EnsureDirectoryExists(string directory);
        void DeleteDirectory(string directory);
        bool FileExists(string filePath);
        bool DirectoryExists(string filePath);
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileServices\IFileService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileServices\IPathsProvider.cs==START]using System.Collections.Generic;

namespace ServiceScheduler.FileServices
{
    public interface IPathsProvider
    {
        string ServicesPath { get; }
        string GetServiceLocation(string serviceName);
        string GetServiceLocation(string serviceName, string serviceVersion);
        string GetArchiveLocation(string serviceName);
        string GetArchiveLocation(string serviceName, string serviceVersion, string fileName);
        string GetFailedZipDestination(string fileName);
        IEnumerable<string> GetPendingInstallationServices();
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileServices\IPathsProvider.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileServices\PathsProvider.cs==START]using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ServiceScheduler.LogAttributes;

namespace ServiceScheduler.FileServices
{
    public class PathsProvider : IPathsProvider
    {
        public string ServicesPath
        {
            //TODO: Make the Path less hardcoded and less dependant on the ServiceSchedulerPath
            get { return Path.Combine(ServiceSchedulerPath, "Services"); }
        }

        private string RegisteredServicesPath
        {
            //TODO: Make the Path less hardcoded and less dependant on the ServiceSchedulerPath
            get { return Path.Combine(ServicesPath, "Registered"); }
        }

        private string InstalledServicesPath
        {
            //TODO: Make the Path less hardcoded and less dependant on the ServiceSchedulerPath
            get { return Path.Combine(ServicesPath, "Installed"); }
        }

        private string FailedServicesPath
        {
            //TODO: Make the Path less hardcoded and less dependant on the ServiceSchedulerPath
            get { return Path.Combine(ServicesPath, "Failed"); }
        }

        private string ServiceSchedulerPath
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
                       string.Empty;
            }
        }

        public string GetServiceLocation(string serviceName)
        {
            return Path.Combine(InstalledServicesPath, serviceName);
        }

        public string GetServiceLocation(string serviceName, string serviceVersion)
        {
            return Path.Combine(InstalledServicesPath, serviceName, serviceVersion);
        }

        public string GetArchiveLocation(string serviceName)
        {
            return Path.Combine(RegisteredServicesPath, serviceName);
        }

        public string GetArchiveLocation(string serviceName, string serviceVersion, string fileName)
        {
            return Path.Combine(RegisteredServicesPath, serviceName, serviceVersion, fileName);
        }

        public string GetFailedZipDestination(string fileName)
        {
            return Path.Combine(FailedServicesPath,
                Path.GetFileName(fileName ?? string.Empty) + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".failed.");
        }

        [Log]
        public virtual IEnumerable<string> GetPendingInstallationServices()
        {
            return Directory.GetFiles(ServicesPath, "*.zip").ToList();
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileServices\PathsProvider.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileWatcher\IServiceWatcher.cs==START]namespace ServiceScheduler.FileWatcher
{
    public interface IServiceWatcher
    {
        string WatchedPath { get; }
        event NewVersionAvailableHandler NewVersionAvailable;
        void StartWatcher(string path);
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileWatcher\IServiceWatcher.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileWatcher\NewVersionAvailableEventArgs.cs==START]using System;

namespace ServiceScheduler.FileWatcher
{
    public class NewVersionAvailableEventArgs : EventArgs
    {
        public NewVersionAvailableEventArgs(string fullPath)
        {
            FullPath = fullPath;
        }

        public string FullPath { get; set; }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileWatcher\NewVersionAvailableEventArgs.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileWatcher\NewVersionAvailableHandler.cs==START]namespace ServiceScheduler.FileWatcher
{
    public delegate void NewVersionAvailableHandler(IServiceWatcher sender, NewVersionAvailableEventArgs args);
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileWatcher\NewVersionAvailableHandler.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileWatcher\ServiceWatcher.cs==START]using System.IO;

namespace ServiceScheduler.FileWatcher
{
    public class ServiceWatcher : IServiceWatcher
    {
        private FileSystemWatcher _moduleWatcher;
        public string WatchedPath { get; private set; }

        public event NewVersionAvailableHandler NewVersionAvailable;

        public void StartWatcher(string modulePath)
        {
            WatchedPath = modulePath;
            _moduleWatcher = new FileSystemWatcher(WatchedPath) { NotifyFilter = NotifyFilters.FileName };
            _moduleWatcher.Renamed += _moduleWatcher_Renamed;
            _moduleWatcher.Filter = "*.zip";
            _moduleWatcher.EnableRaisingEvents = true;
        }

        private void _moduleWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Renamed)
            {
                return;
            }
            var handler = NewVersionAvailable;
            if (handler != null)
            {
                handler(this, new NewVersionAvailableEventArgs(e.FullPath));
            }
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\FileWatcher\ServiceWatcher.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\LogAttributes\LogAttribute.cs==START]using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;

namespace ServiceScheduler.LogAttributes
{
    //TODO: SHOULD WE HAVE A NEW ATTRIBUTE THAT SINKS EXCEPTIONS AFTER LOGGING THEM?
    public class LogAttribute : InterceptAttribute
    {
        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return request.Kernel.Get<LogInterceptor>();
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\LogAttributes\LogAttribute.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\LogAttributes\LogHelper.cs==START]using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using Pinpoint.EnterpriseLogging;
using Pinpoint.EnterpriseLogging.Domain;

namespace ServiceScheduler.LogAttributes
{
    public static class LogHelper
    {
        public const string ServiceLogContextKey = "Keep LogContext Object Built On Service Interception Logging";

        public static LogContext BuildLogContext()
        {
            var callerClass = "";
            var callerMethod = "";
            var callerStackFrame = new StackTrace().GetFrame(1);
            if (callerStackFrame != null)
            {
                var callerMethodBase = callerStackFrame.GetMethod();
                if (callerMethodBase != null)
                {
                    if (callerMethodBase.DeclaringType != null)
                    {
                        callerClass = callerMethodBase.DeclaringType.FullName;
                    }
                    callerMethod = callerMethodBase.Name;
                }
            }

            var logContext = CallContext.GetData(Constants.LogContextKey) as LogContext;
            var currentLogContext = new LogContext();
            if (logContext != null)
            {
                currentLogContext.ClientIp = logContext.ClientIp;
                currentLogContext.RequestId = logContext.RequestId;
                currentLogContext.SessionId = logContext.SessionId;
                currentLogContext.SourceSiteId = logContext.SourceSiteId;
                currentLogContext.User = logContext.User;
            }
            else
            {
                currentLogContext.RequestId = Guid.NewGuid().ToString();
                currentLogContext.User = Thread.CurrentPrincipal.Identity.Name;
            }
            currentLogContext.SessionId = Guid.NewGuid().ToString();
            currentLogContext.Method = callerMethod;
            currentLogContext.Class = callerClass;

            return currentLogContext;
        }


        public static LogContext LogContext([CallerMemberName] string callingMethod = "")
        {
            var logContext = (CallContext.GetData(ServiceLogContextKey) as LogContext) ?? new LogContext();
            logContext.Method = callingMethod;
            return logContext;
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\LogAttributes\LogHelper.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\LogAttributes\LogInterceptor.cs==START]using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Ninject.Extensions.Interception;
using Pinpoint.EnterpriseLogging;
using Pinpoint.EnterpriseLogging.Domain;
using Pinpoint.EnterpriseLogging.Interfaces;

namespace ServiceScheduler.LogAttributes
{
    public class LogInterceptor : IInterceptor
    {
        private readonly ILogger _logger;
        private LogContext _logContext = new LogContext();

        public LogInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            var stopWatch = new Stopwatch();

            try
            {
                _logContext = BuildLogContext(invocation);
                CallContext.SetData(LogHelper.ServiceLogContextKey, Clone(_logContext));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to build the log context.", ex);
            }

            var start = DateTime.Now;
            var callInformation = BuildCallInfo(invocation, start, null, null);
            var serializedCallInfo = SerializeCallInfo(callInformation);
            try
            {
                _logger.LogInfo("[START] : " + invocation.Request.Method.Name + " | " + serializedCallInfo, _logContext);
                stopWatch.Start();
                invocation.Proceed();
                stopWatch.Stop();

                callInformation = BuildCallInfo(invocation, start, DateTime.Now, stopWatch.ElapsedMilliseconds);
                serializedCallInfo = SerializeCallInfo(callInformation);
                _logger.LogInfo("[END] : " + invocation.Request.Method.Name + " | " + serializedCallInfo, _logContext);
            }
            catch (Exception ex)
            {
                stopWatch.Stop();
                callInformation = BuildCallInfo(invocation, start, DateTime.Now, stopWatch.ElapsedMilliseconds);
                serializedCallInfo = SerializeCallInfo(callInformation);
                _logger.LogError("[END - EXCEPTION] : " + invocation.Request.Method.Name + " | " + serializedCallInfo, ex, _logContext);
                throw;
            }
        }

        private static LogContext BuildLogContext(IInvocation invocation)
        {
            var logContext = CallContext.GetData(Constants.LogContextKey) as LogContext;
            var currentLogContext = new LogContext();
            if (logContext != null)
            {
                currentLogContext.ClientIp = logContext.ClientIp;
                currentLogContext.RequestId = logContext.RequestId;
                currentLogContext.SourceSiteId = logContext.SourceSiteId;
                currentLogContext.User = logContext.User;
            }
            else
            {
                currentLogContext.RequestId = Guid.NewGuid().ToString();
                currentLogContext.User = Thread.CurrentPrincipal.Identity.Name;
            }
            currentLogContext.SessionId = Guid.NewGuid().ToString();
            currentLogContext.Method = invocation.Request.Method.Name;
            if (invocation.Request.Method.DeclaringType != null)
            {
                currentLogContext.Class = invocation.Request.Method.DeclaringType.FullName;
            }
            return currentLogContext;
        }

        private static string SerializeCallInfo(CallInfo callInfo)
        {
            try
            {
                return JsonConvert.SerializeObject(callInfo, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return string.Format("Failed to serialize call information as Json. Exception: {0}", ex);
            }
        }

        private static LogContext Clone(LogContext toClone)
        {
            return JsonConvert.DeserializeObject<LogContext>(JsonConvert.SerializeObject(toClone));
        }

        private static CallInfo BuildCallInfo(IInvocation invocation, DateTime? start, DateTime? end, long? totalExecutionTime)
        {
            var callInfo = new CallInfo
            {
                StarTime = start == null ? null : start.Value.ToString("HH:mm:ss.fff yyyy:MM:dd"),
                EndTime = end == null ? null : end.Value.ToString("HH:mm:ss.fff yyyy:MM:dd"),
                ExecutionTimeInMs = totalExecutionTime,
                Method = invocation.Request.Method.Name,
                Class = invocation.Request.Method.DeclaringType != null
                            ? invocation.Request.Method.DeclaringType.FullName
                            : null,
                MethodSignature = MethodSignature(invocation)
            };
            if (end == null)// only at the start I need the parameters and args
            {
                callInfo.Arguments = invocation.Request.Arguments;
            }
            return callInfo;
        }
        private static string MethodSignature(IInvocation invocation)
        {
            var method = invocation.Request.Method;
            var builder = new StringBuilder();
            builder.AppendFormat("{0}.{1} {2}(", method.ReturnType.Namespace, method.ReturnType.Name, method.Name);
            var parameters = invocation.Request.Method.GetParameters();
            if (parameters.Any())
            {
                foreach (var parameterInfo in parameters)
                {
                    builder.AppendFormat("{0} {1},", parameterInfo.ParameterType.FullName, parameterInfo.Name);
                }
            }
            builder.Append(")");
            return builder.ToString();
        }

        private class CallInfo
        {
            public string StarTime { get; set; }
            public string EndTime { get; set; }
            public long? ExecutionTimeInMs { get; set; }
            public string Class { get; set; }
            public string Method { get; set; }
            public object[] Arguments { get; set; }
            public string MethodSignature { get; set; }
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\LogAttributes\LogInterceptor.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ServiceScheduler")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Pinpoint")]
[assembly: AssemblyProduct("ServiceScheduler")]
[assembly: AssemblyCopyright("Copyright © Pinpoint 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("ee9357c0-4fcf-4cbb-af5e-75caabd11f19")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: InternalsVisibleTo("ServiceScheduler.UnitTests")]
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\QuartzBuilders\IQuartzBuilder.cs==START]using System.Collections.Generic;
using Quartz;

namespace ServiceScheduler.QuartzBuilders
{
    public interface IQuartzBuilder
    {
        IJobDetail BuildJobDetail<TJobType>();
        IList<ITrigger> BuildTriggers();
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\QuartzBuilders\IQuartzBuilder.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\QuartzBuilders\IQuartzBuilderDirector.cs==START]using ServiceScheduler.Domain;

namespace ServiceScheduler.QuartzBuilders
{
    public interface IQuartzBuilderDirector
    {
        IQuartzBuilder CreateQuartzBuilder(ServiceInformation serviceInformation);
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\QuartzBuilders\IQuartzBuilderDirector.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\QuartzBuilders\QuartzBuilder.cs==START]using System;
using System.Collections.Generic;
using System.Linq;
using Quartz;
using ServiceScheduler.Domain;
using ServiceScheduler.LogAttributes;

namespace ServiceScheduler.QuartzBuilders
{
    public class QuartzBuilder : IQuartzBuilder
    {
        private readonly ServiceInformation _serviceInformation;

        public QuartzBuilder(ServiceInformation serviceInformation)
        {
            _serviceInformation = serviceInformation;
        }

        [Log]
        public virtual IJobDetail BuildJobDetail<TJobType>()
        {
            var jobDetail = JobBuilder.Create(typeof (TJobType))
                .WithIdentity(_serviceInformation.ServiceName)
                .Build();
            SetJobDataMapFor(jobDetail);
            return jobDetail;
        }

        [Log]
        public virtual IList<ITrigger> BuildTriggers()
        {
            var list = new List<ITrigger>();
            if (_serviceInformation.Schedule == null)
            {
                return list;
            }
            var scheduleList = _serviceInformation.Schedule
                .Where(p => !string.IsNullOrWhiteSpace(p.Schedule))
                .Where(p => !p.Schedule.Equals("ADHOC", StringComparison.InvariantCultureIgnoreCase))
                .Where(p => p.Enabled)
//                .Select(p => p.Schedule)
                .ToList();
            for (var index = 0; index < scheduleList.Count; index++)
            {
                var scheduleInfo = scheduleList[index];
                var triggerId = string.Format("{0}.{1}", _serviceInformation.ServiceName, index);
                var trigger = BuildTrigger(triggerId, scheduleInfo.Schedule, scheduleInfo.Parameters, scheduleInfo.ServiceSchedulerId);
                list.Add(trigger);
            }
            return list;
        }

        private void SetJobDataMapFor(IJobDetail jobDetail)
        {
            jobDetail.JobDataMap.Put("ServiceName", _serviceInformation.ServiceName);
            jobDetail.JobDataMap.Put("ServicePath", _serviceInformation.ServicePath);
            jobDetail.JobDataMap.Put("ServiceEntry", _serviceInformation.ServiceEntry);
            jobDetail.JobDataMap.Put("ServiceVersion", _serviceInformation.ServiceVersion);
            jobDetail.JobDataMap.Put("AllowConcurrency", _serviceInformation.AllowConcurrency);
        }

        private static ITrigger BuildTrigger(string triggerId, string scheduleExpression, string scheduleParameters, int? serviceSchedulerId)
        {
            var jobDataMap = new JobDataMap();
            jobDataMap.Put("ScheduleExpression", scheduleExpression);
            jobDataMap.Put("ScheduleParameters", scheduleParameters);
            jobDataMap.Put("ServiceScheduleId", serviceSchedulerId);

            var triggerBuilder = TriggerBuilder.Create().WithIdentity(triggerId).UsingJobData(jobDataMap);
            if (scheduleExpression.Trim().ToUpper().StartsWith("ONCE"))
            {
                triggerBuilder.WithSimpleSchedule(s => s.WithRepeatCount(0));
                if (!scheduleExpression.Trim().ToUpper().StartsWith("ONCEAT "))
                {
                    return triggerBuilder.Build();
                }
                DateTimeOffset startTime;
                if (DateTimeOffset.TryParse(scheduleExpression.Substring(7), out startTime))
                {
                    triggerBuilder.StartAt(startTime);
                }
            }
            else
            {
                triggerBuilder.WithCronSchedule(scheduleExpression);
            }
            return triggerBuilder.Build();
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\QuartzBuilders\QuartzBuilder.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\QuartzBuilders\QuartzBuilderDirector.cs==START]using ServiceScheduler.Domain;

namespace ServiceScheduler.QuartzBuilders
{
    public class QuartzBuilderDirector : IQuartzBuilderDirector
    {
        public IQuartzBuilder CreateQuartzBuilder(ServiceInformation serviceInformation)
        {
            IQuartzBuilder quartzBuilder = new QuartzBuilder(serviceInformation);
            return quartzBuilder;
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\QuartzBuilders\QuartzBuilderDirector.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceInformationCollector\AssemblyReflectionManager.cs==START]using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;

namespace ServiceScheduler.ServiceInformationCollector
{
    /// <summary>
    /// Refactored version of http://www.codeproject.com/Articles/776819/Strategy-Pattern-Csharp 
    /// that uses byte[] as source for loading assemblies rather than files on disk.
    /// </summary>
    public class AssemblyReflectionManager : IDisposable
    {
        private readonly Dictionary<string, AppDomain> _loadedAssemblies = new Dictionary<string, AppDomain>();
        private readonly Dictionary<string, AppDomain> _mapDomains = new Dictionary<string, AppDomain>();

        private readonly Dictionary<string, AssemblyReflectionProxy> _proxies =
            new Dictionary<string, AssemblyReflectionProxy>();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool LoadAssembly(string assemblyName, Dictionary<string, byte[]> rawAssemblies, string domainName)
        {
            if (_loadedAssemblies.ContainsKey(assemblyName))
            {
                return false;
            }
            AppDomain appDomain;
            if (_mapDomains.ContainsKey(domainName))
            {
                appDomain = _mapDomains[domainName];
            }
            else
            {
                appDomain = CreateChildDomain(AppDomain.CurrentDomain, domainName);
                _mapDomains[domainName] = appDomain;
            }
            // load the assembly in the specified app domain
            try
            {
                var proxyType = typeof(AssemblyReflectionProxy);
                var proxy =
                    (AssemblyReflectionProxy)appDomain.
                        CreateInstanceFrom(
                            proxyType.Assembly.Location,
                            proxyType.FullName).Unwrap();


                proxy.LoadAssembly(assemblyName, rawAssemblies);


                _loadedAssemblies[assemblyName] = appDomain;
                _proxies[assemblyName] = proxy;

                return true;
            }
            catch
            {
            }
            return false;
        }


        public bool UnloadDomain(string domainName)
        {
            if (string.IsNullOrEmpty(domainName))
                return false;

            if (!_mapDomains.ContainsKey(domainName))
            {
                return false;
            }
            try
            {
                var appDomain = _mapDomains[domainName];
                var assemblies = (from kvp in _loadedAssemblies where kvp.Value == appDomain select kvp.Key).ToList();
                // remove these assemblies from the internal dictionaries
                foreach (var assemblyName in assemblies)
                {
                    _loadedAssemblies.Remove(assemblyName);
                    _proxies.Remove(assemblyName);
                }
                // remove the appdomain from the dictionary
                _mapDomains.Remove(domainName);
                AppDomain.Unload(appDomain);
                return true;
            }
            catch
            {
            }
            return false;
        }


        public TResult Reflect<TResult>(string assemblyName, Func<Assembly, TResult> func)
        {
            // check if the assembly is found in the internal dictionaries
            return _loadedAssemblies.ContainsKey(assemblyName) &&
                   _proxies.ContainsKey(assemblyName)
                ? _proxies[assemblyName].Reflect(func)
                : default(TResult);
        }

        ~AssemblyReflectionManager()
        {
            Dispose(false);
        }


        private void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            foreach (var appDomain in _mapDomains.Values)
                AppDomain.Unload(appDomain);

            _loadedAssemblies.Clear();
            _proxies.Clear();
            _mapDomains.Clear();
        }


        private static AppDomain CreateChildDomain(AppDomain parentDomain, string domainName)
        {
            var evidence = new Evidence(parentDomain.Evidence);
            var setup = parentDomain.SetupInformation;
            return AppDomain.CreateDomain(domainName, evidence, setup);
        }


        private class AssemblyReflectionProxy : MarshalByRefObject
        {
            private string _assemblyName;
            private Dictionary<string, byte[]> _rawAssemblies;


            public void LoadAssembly(String assemblyName, Dictionary<string, byte[]> rawAssemblies)
            {
                try
                {
                    _assemblyName = assemblyName;
                    _rawAssemblies = rawAssemblies;
                    Assembly.Load(rawAssemblies[assemblyName]);
                }
                catch (FileNotFoundException)
                {
                    // Continue loading assemblies even if an assembly can not be loaded in the new AppDomain.
                }
            }

            public TResult Reflect<TResult>(Func<Assembly, TResult> func)
            {
                ResolveEventHandler resolveEventHandler = (s, e) => OnAssemblyResolve(e);
                AppDomain.CurrentDomain.AssemblyResolve += resolveEventHandler;
                var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a =>
                {
                    var assemblyName = new AssemblyName(a.FullName);
                    return String.Compare(assemblyName.Name, _assemblyName, StringComparison.Ordinal) == 0;
                });
                var result = func(assembly);
                AppDomain.CurrentDomain.AssemblyResolve -= resolveEventHandler;
                return result;
            }

            private Assembly OnAssemblyResolve(ResolveEventArgs args)
            {
                var loadedAssembly =
                    AppDomain.CurrentDomain.GetAssemblies()
                        .FirstOrDefault(
                            asm => string.Equals(asm.FullName, args.Name,
                                StringComparison.OrdinalIgnoreCase));
                if (loadedAssembly != null)
                {
                    return loadedAssembly;
                }

                var assemblyName = new AssemblyName(args.Name);
                if (_rawAssemblies.ContainsKey(assemblyName.Name))
                {
                    return Assembly.Load(_rawAssemblies[assemblyName.Name]);
                }
                return _rawAssemblies.ContainsKey(assemblyName.Name)
                    ? Assembly.Load(_rawAssemblies[assemblyName.Name])
                    : Assembly.Load(assemblyName.Name);
            }
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceInformationCollector\AssemblyReflectionManager.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceInformationCollector\IServiceInformationCollector.cs==START]using ServiceScheduler.Domain;

namespace ServiceScheduler.ServiceInformationCollector
{
    public interface IServiceInformationCollector
    {
        ServiceInformation ReadServiceInformation(string zipPath);
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceInformationCollector\IServiceInformationCollector.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceInformationCollector\ServiceInformationCollector.cs==START]using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Pinpoint.EnterpriseScheduling;
using ServiceScheduler.AssembliesReader;
using ServiceScheduler.Domain;
using ServiceScheduler.LogAttributes;

namespace ServiceScheduler.ServiceInformationCollector
{
    public class ServiceInformationCollector : IServiceInformationCollector
    {
        private readonly IAssembliesReader _assembliesReader;

        public ServiceInformationCollector(IAssembliesReader assembliesReader)
        {
            _assembliesReader = assembliesReader;
        }

        [Log]
        public virtual ServiceInformation ReadServiceInformation(string zipPath)
        {
            var list = CollectData(zipPath).Where(p => p != null).ToList();
            if (list.Count == 0)
            {
                throw new Exception(string.Format("No assembly was found to implement the {0} interface!",
                    typeof (ServiceApplicationAttribute)));
            }
            if (list.Count > 1)
            {
                throw new Exception(
                    string.Format(
                        "Too many assemblies were found to implement the {0} interface! Only one must be implementing it.",
                        typeof (ServiceApplicationAttribute)));
            }
            var serviceInfo = list.First();
            if (string.IsNullOrWhiteSpace(serviceInfo.ServiceName))
            {
                throw new Exception("Service name is required!");
            }
            serviceInfo.ServicePath = zipPath;
            return serviceInfo;
        }

        private IEnumerable<ServiceInformation> CollectData(string zipPath)
        {
            var dictionary = _assembliesReader.ReadAssemblies(zipPath);
            if (dictionary.Count == 0)
            {
                throw new Exception(string.Format("No assemblies found in {0} package!", zipPath));
            }
            var uniqueDomainName = "hereBeUnicorns " + Guid.NewGuid().ToString("N");
            var manager = new AssemblyReflectionManager();
            try
            {
                foreach (var file in dictionary.Keys)
                {
                    if (!manager.LoadAssembly(file, dictionary, uniqueDomainName))
                    {
                        continue;
                    }
                    yield return manager.Reflect(file,
                        assembly => IsPlugin(assembly)
                            ? ReadServiceInformation(assembly)
                            : null);
                }
            }
            finally
            {
                manager.UnloadDomain(uniqueDomainName);
            }
        }

        private static bool IsPlugin(Assembly assembly)
        {
            return assembly
                .GetTypes()
                .ToList()
                .Any(t => t.GetInterfaces()
                    .Any(i => i == typeof (IServiceApplication)));
        }

        private static ServiceInformation ReadServiceInformation(Assembly assembly)
        {
            ServiceInformation serviceInformation = null;

            var serviceAttributeData =
                assembly.CustomAttributes.FirstOrDefault(p => p.AttributeType == typeof (ServiceApplicationAttribute));
            if (serviceAttributeData == null || serviceAttributeData.NamedArguments == null)
            {
                return null;
            }
            var serviceArgs = serviceAttributeData.NamedArguments;
            if (serviceArgs != null)
            {
                serviceInformation = new ServiceInformation
                {
                    ServiceName =
                        (string) serviceArgs.FirstOrDefault(p => p.MemberName == "ServiceName").TypedValue.Value,
                    Enabled =
                        (bool?) serviceArgs.FirstOrDefault(p => p.MemberName == "Enabled").TypedValue.Value ?? false,
                    AllowConcurrency =
                        (bool?) serviceArgs.FirstOrDefault(p => p.MemberName == "AllowConcurrency").TypedValue.Value ??
                        false,
                    ServiceVersion = assembly.GetName().Version.ToString(),
                    ServiceEntry = assembly.GetName().Name + (assembly.EntryPoint == null ? ".dll" : ".exe")
                };
            }

            if (serviceInformation != null)
            {
                var scheduleAttributesData =
                    assembly.CustomAttributes.Where(p => p.AttributeType == typeof (ServiceApplicationScheduleAttribute));
                foreach (var scheduleAttributeData in scheduleAttributesData)
                {
                    var scheduleArgs = scheduleAttributeData.NamedArguments;
                    if (scheduleArgs != null)
                    {
                        var scheduleInformation = new ServiceScheduleInformation
                        {
                            ScheduleName =
                                (string)
                                    scheduleArgs.FirstOrDefault(p => p.MemberName == "ScheduleName").TypedValue.Value,
                            Schedule =
                                (string) scheduleArgs.FirstOrDefault(p => p.MemberName == "Schedule").TypedValue.Value ??
                                string.Empty,
                            Parameters =
                                (string) scheduleArgs.FirstOrDefault(p => p.MemberName == "Parameters").TypedValue.Value ??
                                string.Empty,
                            Enabled =
                                (bool?) scheduleArgs.FirstOrDefault(p => p.MemberName == "Enabled").TypedValue.Value ??
                                false,
                            ServiceSchedulerId = null
                        };
                        serviceInformation.Schedule.Add(scheduleInformation);
                    }
                }
            }

            return serviceInformation;
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceInformationCollector\ServiceInformationCollector.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\GarbageCollectionJob.cs==START]using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Pinpoint.EnterpriseLogging;
using Pinpoint.EnterpriseLogging.Interfaces;
using Quartz;
using ServiceScheduler.Data.Repository;
using ServiceScheduler.LogAttributes;

namespace ServiceScheduler.ServiceJobs
{
    [DisallowConcurrentExecution]
    public class GarbageCollectionJob : IJob, IGarbageCollectionJob
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ILogger _logger;

        public GarbageCollectionJob(IServiceRepositoryFactory serviceRepositoryFactory, ILogger logger)
        {
            _logger = logger;
            _serviceRepository = serviceRepositoryFactory.GetServiceRepository();
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                CallContext.SetData(Constants.LogContextKey, LogHelper.BuildLogContext());

                _logger.LogInfo("Started garbage collection job.");

                var services = _serviceRepository.Retrieve();

                foreach (var service in services)
                {
                    try
                    {
                        var serviceFolder = Directory.GetParent(service.ServicePath);

                        var excludedFolders = new List<string>
                        {
                            Path.Combine(serviceFolder.FullName, service.ServiceVersion)
                        };
                        excludedFolders.AddRange(
                            service.ServiceRun.Where(o => o.DateCompleted == null).Select(
                                serviceRun => Path.Combine(serviceFolder.FullName, serviceRun.ServiceVersion)));

                        var serviceFoldersToDelete = Directory.GetDirectories(serviceFolder.FullName)
                            .Where(f => !excludedFolders.Exists(
                                xf => xf.Equals(f, StringComparison.InvariantCultureIgnoreCase)));

                        foreach (var serviceFolderToDelete in serviceFoldersToDelete)
                        {
                            if (Directory.Exists(serviceFolderToDelete))
                            {
                                Directory.Delete(serviceFolderToDelete, true);
                                _logger.LogInfo(string.Format("Garbage collector deleted folder: {0}", serviceFolderToDelete));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogInfo(
                            string.Format("Failed garbage collection for service: {0}. Error: {1}", service.ServiceName, ex));
                    }
                }

                _logger.LogInfo("Finished garbage collection job.");
            }
            catch (Exception ex)
            {
                _logger.LogInfo(string.Format("Failed garbage collection. Error: {0}", ex));
            }
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\GarbageCollectionJob.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\IGarbageCollectionJob.cs==START]namespace ServiceScheduler.ServiceJobs
{
    public interface IGarbageCollectionJob
    {
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\IGarbageCollectionJob.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\IServiceApplicationJob.cs==START]namespace ServiceScheduler.ServiceJobs
{
    public interface IServiceApplicationJob
    {
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\IServiceApplicationJob.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\IServiceProcess.cs==START]using System;

namespace ServiceScheduler.ServiceJobs
{
    public interface IServiceProcess
    {
        event EventHandler Exited;
        int Id { get; }
        DateTime StartTime { get; }
        DateTime ExitTime { get; }
        void Start(string servicePath, string serviceParameters);
        void Stop(int processId, string serviceEntry);
        void Stop(string servicePath);
        bool IsRunning(int processId, string servicePath);
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\IServiceProcess.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\IServiceRunService.cs==START]using System;
using System.Collections.Generic;
using ServiceScheduler.Data.Model;
using ServiceScheduler.Domain;

namespace ServiceScheduler.ServiceJobs
{
    public interface IServiceRunService
    {
        int StartServiceRun(string serviceName, string serviceVersion, string scheduleExpression,
            string scheduleParameters, int? scheduleServiceId);
        void UpdateServiceRun(string serviceName, int serviceRunId, int processId, ServiceRunStatus serviceRunStatus, DateTime serviceRunStatusTimestamp);
        bool IsServiceRunning(string serviceName, string parameters);
        ServiceRunResponse KillRunningService(string serviceName, int serviceRunId);
        ServiceRunResponse StartService(string serviceName, string parameters);
        List<ServiceRunDto> GetExecutingServices();
        Response<List<ServiceScheduleDto>> GetServiceSchedules(int serviceId);
        Response<ServiceScheduleDto> GetServiceSchedule(int serviceId, int serviceScheduleId);
        Response<int> SetServiceSchedule(ServiceScheduleDto serviceSchedule);
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\IServiceRunService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\ProcessExitHandler.cs==START]using System;
using Pinpoint.EnterpriseLogging.Interfaces;
using ServiceScheduler.Data.Model;
using ServiceScheduler.LogAttributes;

namespace ServiceScheduler.ServiceJobs
{
    internal class ProcessExitHandler 
    {
        private readonly ILogger _logger;
        private readonly string _serviceName;
        private readonly int _serviceRunId;
        private readonly IServiceRunService _serviceRunService;
        private IServiceProcess _serviceProcess;


        public ProcessExitHandler(IServiceProcess serviceProcess, IServiceRunService serviceRunService,
            ILogger logger, string serviceName, int serviceRunId)
        {
            _serviceProcess = serviceProcess;
            _serviceRunService = serviceRunService;
            _logger = logger;
            _serviceName = serviceName;
            _serviceRunId = serviceRunId;
        }

        public virtual void ServiceProcessExited(object sender, EventArgs e)
        {
            var logContext = LogHelper.BuildLogContext();
            try
            {
                _serviceRunService.UpdateServiceRun(
                    _serviceName, _serviceRunId, _serviceProcess.Id,
                    ServiceRunStatus.Completed, _serviceProcess.ExitTime);

                _logger.LogInfo(
                    string.Format("Updated service run on exit for service {0} with service run id: {1}.",
                        _serviceName, _serviceRunId), logContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    string.Format(
                        "Failed to update service run on exit for service {0} with service run id: {1}. Error: {2}",
                        _serviceName, _serviceRunId, ex), logContext);
            }
            finally
            {
                // events and memory leaks.
                _serviceProcess.Exited -= ServiceProcessExited;
                _serviceProcess = null;
            }
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\ProcessExitHandler.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\ServiceApplicationJob.cs==START]using System;
using System.IO;
using System.Threading;
using Pinpoint.EnterpriseLogging.Interfaces;
using Quartz;
using ServiceScheduler.Data.Model;
using ServiceScheduler.Data.Repository;
using ServiceScheduler.LogAttributes;

namespace ServiceScheduler.ServiceJobs
{
    [DisallowConcurrentExecution]
    public class ServiceApplicationJob : IJob, IServiceApplicationJob
    {
        private readonly ILogger _logger;
        private readonly IServiceProcess _serviceProcess;
        private readonly IServiceRunService _serviceRunService;
        private readonly IServiceScheduler _serviceScheduler;

        public ServiceApplicationJob(IServiceRepositoryFactory serviceRepositoryFactory, IServiceProcess serviceProcess,
            ILogger logger, IServiceScheduler serviceScheduler)
        {
            // require new context each time, to prevent concurrency issues
            _serviceRunService = new ServiceRunService(serviceRepositoryFactory.GetServiceRepository(), serviceProcess,
                logger, _serviceScheduler);
            _serviceProcess = serviceProcess;
            _logger = logger;
            _serviceScheduler = serviceScheduler;
        }

        public virtual void Execute(IJobExecutionContext context)
        {
            var serviceName = string.Empty;
            try
            {
                serviceName = context.JobDetail.JobDataMap["ServiceName"] as string;
                _logger.LogInfo(
                    string.Format("Starting service application job for service '{0}'.",
                        serviceName));

                var servicePath = context.JobDetail.JobDataMap["ServicePath"] as string;
                var serviceEntry = context.JobDetail.JobDataMap["ServiceEntry"] as string;
                var serviceVersion = context.JobDetail.JobDataMap["ServiceVersion"] as string;

                servicePath = Path.Combine(servicePath ?? "", serviceEntry ?? "");

                var scheduleExpression = context.Trigger.JobDataMap["ScheduleExpression"] as string;
                var scheduleParameters = context.Trigger.JobDataMap["ScheduleParameters"] as string;
                var scheduleServiceId = (int?)context.Trigger.JobDataMap["ServiceScheduleId"];

                var allowConcurrency = (bool) context.JobDetail.JobDataMap["AllowConcurrency"];
                if (!allowConcurrency && _serviceRunService.IsServiceRunning(serviceName, scheduleParameters))
                {
                    // don't allow concurrent execution
                    _logger.LogInfo(
                        string.Format(
                            "Starting service application job for service '{0}'. Service is running and will not be started.",
                            serviceName), LogHelper.LogContext());

                    return;
                }

                var serviceRunId = _serviceRunService.StartServiceRun(
                    serviceName, serviceVersion, scheduleExpression, scheduleParameters, scheduleServiceId);

                try
                {
                    var exitHandler = new ProcessExitHandler(_serviceProcess, _serviceRunService, _logger, serviceName,
                        serviceRunId);
                    _serviceProcess.Exited += exitHandler.ServiceProcessExited;
                    _serviceProcess.Start(servicePath, scheduleParameters);

                    _serviceRunService.UpdateServiceRun(
                        serviceName, serviceRunId, _serviceProcess.Id,
                        ServiceRunStatus.Started, _serviceProcess.StartTime);

                    _logger.LogInfo(
                        string.Format("Finished service application job for service '{0}' with parameters '{1}'.",
                            serviceName, scheduleParameters), LogHelper.LogContext());
                }
                catch
                {
                    _serviceRunService.UpdateServiceRun(
                        serviceName, serviceRunId, _serviceProcess.Id,
                        ServiceRunStatus.Error, DateTime.Now);

                    throw;
                }

                // wait for process to load (to allow concurrency check above)
                for (var i = 0; i < 10; i++)
                {
                    if (_serviceRunService.IsServiceRunning(serviceName, scheduleParameters))
                    {
                        // process is running
                        break;
                    }

                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    string.Format("Failed service application job for service '{0}'. Error: {1}",
                        serviceName, ex), LogHelper.LogContext());
            }
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\ServiceApplicationJob.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\ServiceProcess.cs==START]using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Pinpoint.EnterpriseLogging.Interfaces;
using ServiceScheduler.LogAttributes;

namespace ServiceScheduler.ServiceJobs
{
    public class ServiceProcess : IServiceProcess
    {
        private readonly ILogger _logger;
        private readonly Process _process = new Process();

        public ServiceProcess(ILogger logger)
        {
            _logger = logger;
            _process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            _process.StartInfo.CreateNoWindow = true;
            _process.EnableRaisingEvents = true;
        }

        public int Id
        {
            get { return _process.Id; }
        }

        public DateTime StartTime
        {
            get { return _process.StartTime; }
        }

        public DateTime ExitTime
        {
            get { return _process.ExitTime; }
        }

        public event EventHandler Exited
        {
            add { _process.Exited += value; }
            remove { _process.Exited -= value; }
        }

        [Log]
        public void Start(string servicePath, string serviceParameters)
        {
            if (string.IsNullOrWhiteSpace(servicePath))
                throw new Exception("Application path has not been set.");

            if (!File.Exists(servicePath))
                throw new Exception(string.Format("Application path does not exist ({0}).", servicePath));

            _process.StartInfo.FileName = servicePath;
            _process.StartInfo.Arguments = serviceParameters ?? "";

            _process.Start();
        }

        [Log]
        public void Stop(int processId, string serviceEntry)
        {
            Process process;
            try
            {
                process = Process.GetProcessById(processId);
            }
            catch (ArgumentException)
            {
                throw new ServiceProcessNotFoundException();
            }

            var processName = Path.GetFileNameWithoutExtension(serviceEntry);
            if (!process.ProcessName.Equals(processName, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ServiceProcessNotFoundException();
            }

            process.Kill();
        }

        [Log]
        public void Stop(string servicePath)
        {
            var processName = Path.GetFileNameWithoutExtension(servicePath);

            // get service base folder ie. parent of version folder
            var processBaseFolder = GetProcessBaseFolder(servicePath);
            if (processBaseFolder == null)
            {
                return;
            }
            var runningProcess = Process.GetProcessesByName(processName).FirstOrDefault(p =>
                p.MainModule.FileName.StartsWith(processBaseFolder, StringComparison.InvariantCultureIgnoreCase));

            if (runningProcess != null)
            {
                runningProcess.Kill();
            }
        }

        [Log]
        public bool IsRunning(int processId, string servicePath)
        {
            var process = Process.GetProcesses().ToList().FirstOrDefault(p => p.Id == processId);
            if (process == null)
            {
                return false;
            }
            //Check if it is the same executable we look for and not another process with the same process id,
            //because our process might have stopped executing a while back and the OS started 
            //another totally unrelated process giving it the same process id.
            var processBaseFolder = GetProcessBaseFolder(servicePath);
            if (processBaseFolder == null)
            {
                return false;
            }
            try
            {
                return process.MainModule.FileName.StartsWith(processBaseFolder ?? string.Empty,
                    StringComparison.CurrentCultureIgnoreCase);
            }
            catch (Win32Exception ex)
            {
                _logger.LogError(
                    string.Format("Error while checking if process '{0}' is running and if it is using '{1}' path.",
                        processId, servicePath), ex, LogHelper.LogContext());
                return false;
            }
        }

        //TODO: move to paths provider service.
        private static string GetProcessBaseFolder(string exeServicePath)
        {
            //I want to return from "\Services\Installed\ServiceA\1.0.0.1" 
            //the "\Services\Installed\ServiceA\" part only, without version.
            var baseFolder = Path.GetDirectoryName(Path.GetDirectoryName(exeServicePath));
            return baseFolder != null
                ? baseFolder.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar
                : null;
        }
    }

    public class ServiceProcessNotFoundException : Exception
    {
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\ServiceProcess.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\ServiceRunService.cs==START]using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using Pinpoint.EnterpriseLogging.Interfaces;
using ServiceScheduler.Data.Model;
using ServiceScheduler.Data.Repository;
using ServiceScheduler.Domain;
using ServiceScheduler.LogAttributes;

namespace ServiceScheduler.ServiceJobs
{
    public class ServiceRunService : IServiceRunService
    {
        private readonly ILogger _logger;
        private readonly IServiceProcess _serviceProcess;
        private readonly IServiceRepository _serviceRepository;
        private readonly IServiceScheduler _serviceScheduler;

        private readonly Func<ServiceRun, bool> _serviceRunIsActive =
            o => o.ServiceRunStatusId == ServiceRunStatus.Idle ||
                 o.ServiceRunStatusId == ServiceRunStatus.Started ||
                 o.ServiceRunStatusId == ServiceRunStatus.Starting;

        public ServiceRunService(IServiceRepository serviceRepository, IServiceProcess serviceProcess, ILogger logger,
            IServiceScheduler serviceScheduler)
        {
            _serviceRepository = serviceRepository;
            _serviceProcess = serviceProcess;
            _logger = logger;
            _serviceScheduler = serviceScheduler;
        }

        [Log]
        public int StartServiceRun(string serviceName, string serviceVersion, string scheduleExpression,
            string scheduleParameters, int? scheduleServiceId)
        {
            var service = _serviceRepository.Retrieve(serviceName);

            var serviceSchedule = scheduleServiceId == null
                ? service.ServiceSchedule.FirstOrDefault(
                    o => o.Schedule.Equals(scheduleExpression, StringComparison.InvariantCultureIgnoreCase))
                : service.ServiceSchedule.FirstOrDefault(o => o.ServiceScheduleId == scheduleServiceId);

            if (serviceSchedule == null)
            {
                throw new Exception(
                    string.Format("Service schedule not found for service: {0}.", serviceName));
            }

            var serviceRun = new ServiceRun
            {
                DateRun = DateTime.Now,
                Message = "",
                Parameters = scheduleParameters,
                ProcessId = 0,
                ServiceScheduleId = serviceSchedule.ServiceScheduleId,
                ServiceVersion = serviceVersion,
                ServiceRunStatusId = ServiceRunStatus.Starting
            };

            service.ServiceRun.Add(serviceRun);
            _serviceRepository.Commit();

            return serviceRun.ServiceRunId;
        }

        [Log]
        public void UpdateServiceRun(string serviceName, int serviceRunId, int processId,
            ServiceRunStatus serviceRunStatus, DateTime serviceRunStatusTimestamp)
        {
            var service = _serviceRepository.Retrieve(serviceName);
            var serviceRun = service.ServiceRun.FirstOrDefault(o => o.ServiceRunId == serviceRunId);

            if (serviceRun == null)
            {
                throw new Exception(
                    string.Format("Service run not found for service: {0} with service run id: {1}.",
                        serviceName, serviceRunId));
            }

            serviceRun.ServiceRunStatusId = serviceRunStatus;

            switch (serviceRunStatus)
            {
                case ServiceRunStatus.Completed:
                case ServiceRunStatus.Error:
                    serviceRun.DateCompleted = serviceRunStatusTimestamp;
                    break;

                case ServiceRunStatus.Started:
                    serviceRun.ProcessId = processId;
                    serviceRun.DateRun = serviceRunStatusTimestamp;
                    break;
            }

            _serviceRepository.Commit();
        }

        [Log]
        public bool IsServiceRunning(string serviceName, string parameters)
        {
            var activeRun = GetActiveServiceRun(serviceName, parameters);
            return activeRun != null;
        }

        [Log]
        public ServiceRunResponse KillRunningService(string serviceName, int serviceRunId)
        {
            var serviceRun = GetActiveServiceRun(serviceName, serviceRunId);
            if (serviceRun == null)
            {
                _logger.LogInfo(
                    string.Format(
                        "Stopping service '{0}' with service run id {1}. Service was not found to be running and so there is nothing to stop.",
                        serviceName, serviceRunId), LogHelper.LogContext());
                return ServiceRunResponse.NotFound();
            }
            var service = serviceRun.Service;
            try
            {
                _serviceProcess.Stop(serviceRun.ProcessId, service.ServiceEntry);
                UpdateServiceRun(
                    serviceName, serviceRunId, serviceRun.ProcessId,
                    ServiceRunStatus.Completed, DateTime.Now);
                return ServiceRunResponse.Ok(serviceRunId);
            }
            catch (ServiceProcessNotFoundException ex)
            {
                _logger.LogError(
                    string.Format("Stopping service '{0}' with service run id {1}. Error: {2}",
                        serviceName, serviceRunId, ex), LogHelper.LogContext());
                return ServiceRunResponse.NotFound();
            }
        }

        [Log]
        public ServiceRunResponse StartService(string name, string parameters)
        {
            var service = _serviceRepository.Retrieve(name);
            if (service == null)
            {
                return ServiceRunResponse.NotFound();
            }
            var activeServiceRun = GetActiveServiceRun(name, parameters);
            if (activeServiceRun != null)
            {
                _logger.LogInfo(
                    string.Format(
                        "Starting service '{0}' with parameters '{1}'. Service already running with service run id: {2}.",
                        name, parameters, activeServiceRun.ServiceRunId), LogHelper.LogContext());
                return ServiceRunResponse.Conflict();
            }
            var serviceSchedule = GetOrCreateServiceSchedule(name, parameters, service);
            var serviceRunId = StartServiceRun(name, service.ServiceVersion, serviceSchedule.Schedule, parameters, serviceSchedule.ServiceScheduleId);

            try
            {
                var servicePath = Path.Combine(service.ServicePath, service.ServiceEntry);
                var processExit = new ProcessExitHandler(_serviceProcess, this, _logger, name, serviceRunId);
                _serviceProcess.Exited += processExit.ServiceProcessExited;
                _serviceProcess.Start(servicePath, parameters);

                UpdateServiceRun(
                    name, serviceRunId, _serviceProcess.Id,
                    ServiceRunStatus.Started, _serviceProcess.StartTime);
                _logger.LogInfo(
                    string.Format("Started service '{0}' with parameters '{1}'.",
                        name, parameters), LogHelper.LogContext());
                return ServiceRunResponse.Ok(serviceRunId);
            }
            catch
            {
                UpdateServiceRun(
                    name, serviceRunId, _serviceProcess.Id,
                    ServiceRunStatus.Error, DateTime.Now);
                throw;
            }
        }

        [Log]
        public Response<List<ServiceScheduleDto>> GetServiceSchedules(int serviceId)
        {
            var service = _serviceRepository.Retrieve().FirstOrDefault(p => p.ServiceId == serviceId);
            if (service == null)
            {
                return Response<List<ServiceScheduleDto>>.NotFound();
            }
            var list = (service.ServiceSchedule ?? new List<ServiceSchedule>()).Select(GetAsServiceScheduleDto).ToList();
            return Response<List<ServiceScheduleDto>>.Ok(list);
        }

        [Log]
        public Response<ServiceScheduleDto> GetServiceSchedule(int serviceId, int serviceScheduleId)
        {
            var service = _serviceRepository.Retrieve().FirstOrDefault(p => p.ServiceId == serviceId);
            if (service == null)
            {
                return Response<ServiceScheduleDto>.NotFound();
            }
            var serviceSchedule = service.ServiceSchedule.FirstOrDefault(q => q.ServiceScheduleId == serviceScheduleId);
            if (serviceSchedule == null)
            {
                return Response<ServiceScheduleDto>.NotFound();
            }
            var schedule = GetAsServiceScheduleDto(serviceSchedule);
            return Response<ServiceScheduleDto>.Ok(schedule);
        }
        
        [Log]
        public List<ServiceRunDto> GetExecutingServices()
        {
            var services = _serviceRepository.Retrieve();
            //TODO: SELECT N+1 problem here. Should we have a serviceRun repository? How to share the same context?
            var serviceRuns =
                services.SelectMany(p => p.ServiceRun.Where(_serviceRunIsActive))
                    .Select(p => new ServiceRunDto
                    {
                        Database = new ServiceRunDto.DatabaseInfo
                        {
                            Parameters = p.Parameters,
                            RunningTimeInMs = (long) (DateTime.Now - p.DateRun).TotalMilliseconds,
                            ServiceName = p.Service.ServiceName,
                            ServiceRunId = p.ServiceRunId,
                            Status = p.ServiceRunStatusId.ToString()
                        },
                        OperatingSystem = new ServiceRunDto.OperatingSystemInfo
                        {
                            IsProcessStillRunning = _serviceProcess.IsRunning(p.ProcessId, p.Service.ServicePath)
                        }
                    })
                    .ToList();
            return serviceRuns;
        }

        [Log]
        public Response<int> SetServiceSchedule(ServiceScheduleDto serviceSchedule)
        {
            if (serviceSchedule == null)
            {
                _logger.LogInfo("No info provided for resetting the service schedule!", LogHelper.LogContext());
                return Response<int>.BadRequest();
            }
            var service = _serviceRepository.Retrieve().FirstOrDefault(s => s.ServiceId == serviceSchedule.ServiceId);
            if (service == null)
            {
                _logger.LogInfo(string.Format("Could not find the service with id: {0}", serviceSchedule.ServiceId), LogHelper.LogContext());
                return Response<int>.NotFound();
            }
            var serviceSchedules = service.ServiceSchedule ?? new List<ServiceSchedule>();
            var isUpate = serviceSchedule.ServiceScheduleId > 0;
            var schedule = serviceSchedules.FirstOrDefault(p => p.ServiceScheduleId == serviceSchedule.ServiceScheduleId);
            if (schedule == null)
            {
                if (isUpate)
                {
                    _logger.LogInfo(string.Format("Could not find the service schedule with id: {0}",
                        serviceSchedule.ServiceScheduleId), LogHelper.LogContext());
                    return Response<int>.NotFound();
                }

                schedule = new ServiceSchedule();
                if (service.ServiceSchedule == null)
                {
                    service.ServiceSchedule = new List<ServiceSchedule>();
                }
                service.ServiceSchedule.Add(schedule);
            }

            using (var transaction = new TransactionScope())
            {
                MapToServiceSchedule(serviceSchedule, schedule);
                _serviceRepository.Commit();
                _serviceScheduler.RegisterService(service);
                transaction.Complete();
            }
            return Response<int>.Ok(schedule.ServiceScheduleId);
        }

        private static void MapToServiceSchedule(ServiceScheduleDto serviceSchedule, ServiceSchedule schedule)
        {
            schedule.ServiceScheduleId = serviceSchedule.ServiceScheduleId;
            schedule.ServiceId = serviceSchedule.ServiceId;
            schedule.ScheduleName = serviceSchedule.ScheduleName;
            schedule.Schedule = serviceSchedule.Schedule;
            schedule.Parameters = serviceSchedule.Parameters;
            schedule.Enabled = serviceSchedule.Enabled;
            schedule.ModifiedBy = serviceSchedule.ModifiedBy;
        }
        private static ServiceScheduleDto GetAsServiceScheduleDto(ServiceSchedule serviceSchedule)
        {
            if (serviceSchedule == null)
            {
                return null;
            }
            return new ServiceScheduleDto
            {
                Enabled = serviceSchedule.Enabled,
                ModifiedBy = serviceSchedule.ModifiedBy,
                Parameters = serviceSchedule.Parameters,
                Schedule = serviceSchedule.Schedule,
                ScheduleName = serviceSchedule.ScheduleName,
                ServiceId = serviceSchedule.ServiceId,
                ServiceScheduleId = serviceSchedule.ServiceScheduleId
            };
        }

        private ServiceRun GetActiveServiceRun(string serviceName, string parameters)
        {
            var service = _serviceRepository.Retrieve(serviceName);
            if (service == null)
            {
                _logger.LogInfo(
                    string.Format("Service '{0}' with parameters '{1}' was not found.",
                        serviceName, parameters), LogHelper.LogContext());
                return null;
            }
            var serviceRuns = service.ServiceRun
                .Where(o => _serviceRunIsActive(o) &&
                            o.Parameters.Equals(parameters, StringComparison.InvariantCultureIgnoreCase)).ToList();
            return serviceRuns.FirstOrDefault(p => _serviceProcess.IsRunning(p.ProcessId, service.ServicePath));
        }

        private ServiceRun GetActiveServiceRun(string serviceName, int serviceRunId)
        {
            var service = _serviceRepository.Retrieve(serviceName);
            if (service == null)
            {
                _logger.LogInfo(
                    string.Format("Error: Service '{0}' was not found.", serviceName), LogHelper.LogContext());
                return null;
            }
            var activeRun = service.ServiceRun.FirstOrDefault(o =>
                _serviceRunIsActive(o) &&
                o.ServiceRunId == serviceRunId);
            return activeRun == null || !_serviceProcess.IsRunning(activeRun.ProcessId, service.ServicePath)
                ? null
                : activeRun;
        }

        private ServiceSchedule GetOrCreateServiceSchedule(string name, string parameters, Service service)
        {
            var serviceSchedule = service.ServiceSchedule.FirstOrDefault(o =>
                o.Schedule.Equals("ADHOC", StringComparison.InvariantCultureIgnoreCase) &&
                o.Parameters.Equals(parameters, StringComparison.InvariantCultureIgnoreCase));
            if (serviceSchedule == null)
            {
                serviceSchedule = new ServiceSchedule
                {
                    Enabled = true,
                    ModifiedBy = string.Empty,
                    Parameters = parameters,
                    Schedule = "ADHOC",
                    ScheduleName = string.Format("{0} ADHOC", name)
                };
                service.ServiceSchedule.Add(serviceSchedule);
                _serviceRepository.Commit();
            }
            return serviceSchedule;
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler\ServiceJobs\ServiceRunService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\App.config==START]<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <configSections>
    
    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
  <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 --></configSections>
  <entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
    <providers>
      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    </providers>
  </entityFramework>
<startup><supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" /></startup></configuration>
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\App.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\packages.config==START]<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="EntityFramework" version="6.1.3" targetFramework="net452" />
  <package id="Pinpoint.Environment" version="1.0.0.7" targetFramework="net452" />
</packages>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\packages.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\ServiceScheduler.Data.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{AE48F4C5-1882-4ED7-B723-B70D394EA651}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ServiceScheduler.Data</RootNamespace>
    <AssemblyName>ServiceScheduler.Data</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
    <TargetFrameworkProfile />
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>x64</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll</HintPath>
    </Reference>
    <Reference Include="EntityFramework.SqlServer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.SqlServer.dll</HintPath>
    </Reference>
    <Reference Include="Pinpoint.Environment">
      <HintPath>..\packages\Pinpoint.Environment.1.0.0.7\lib\net40\Pinpoint.Environment.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.ComponentModel.DataAnnotations" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Model\Mapping\ServiceScheduleMap.cs" />
    <Compile Include="Model\Mapping\ServiceRunMap.cs" />
    <Compile Include="Model\Mapping\ServiceLogMap.cs" />
    <Compile Include="Model\Mapping\ServiceMap.cs" />
    <Compile Include="Model\Service.cs" />
    <Compile Include="Model\ServiceLog.cs" />
    <Compile Include="Model\ServiceRun.cs" />
    <Compile Include="Model\ServiceRunStatus.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
    <Compile Include="Repository\IServiceRepository.cs" />
    <Compile Include="Model\ServiceSchedule.cs" />
    <Compile Include="Repository\IServiceRepositoryFactory.cs" />
    <Compile Include="Repository\ServiceRepository.cs" />
    <Compile Include="Repository\ServiceRepositoryFactory.cs" />
    <Compile Include="ServiceSchedulerDataContext.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
    <None Include="packages.config" />
  </ItemGroup>
  <ItemGroup />
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\ServiceScheduler.Data.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\ServiceScheduler.Data.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\ServiceScheduler.Data.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\ServiceSchedulerDataContext.cs==START]using System.Data.Entity;
using ServiceScheduler.Data.Model;
using ServiceScheduler.Data.Model.Mapping;

namespace ServiceScheduler.Data
{
    public class ServiceSchedulerDataContext : DbContext
    {
        static ServiceSchedulerDataContext()
        {
            Database.SetInitializer<ServiceSchedulerDataContext>(null);
        }

        public ServiceSchedulerDataContext(Pinpoint.Environment.IEnvironment environment)
            : base(string.Format("Name={0}.AuCommonServices", environment.Current))
        {
        }

        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceLog> ServiceLog { get; set; }
        public DbSet<ServiceRun> ServiceRun { get; set; }
        public DbSet<ServiceSchedule> ServiceSchedule { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ServiceMap());
            modelBuilder.Configurations.Add(new ServiceLogMap());
            modelBuilder.Configurations.Add(new ServiceRunMap());
            modelBuilder.Configurations.Add(new ServiceScheduleMap());
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\ServiceSchedulerDataContext.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\Service.cs==START]using System;
using System.Collections.Generic;

namespace ServiceScheduler.Data.Model
{
    public class Service
    {
        public Service()
        {
            ServiceSchedule = new List<ServiceSchedule>();
            ServiceRun = new List<ServiceRun>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public bool Enabled { get; set; }
        public DateTime DateInstalled { get; set; }
        public string ServiceVersion { get; set; }
        public string ServicePath { get; set; }
        public string ServiceEntry { get; set; }
        public bool AllowConcurrency { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<ServiceSchedule> ServiceSchedule { get; set; }
        public virtual ICollection<ServiceRun> ServiceRun { get; set; }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\Service.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\ServiceLog.cs==START]using System;

namespace ServiceScheduler.Data.Model
{
    public class ServiceLog
    {
        public int ServiceLogId { get; set; }
        public int ServiceId { get; set; }
        public int ServiceRunId { get; set; }
        public string LogType { get; set; }
        public DateTime DateLogged { get; set; }
        public string Description { get; set; }
        public string StackTrace { get; set; }
        public string ServiceVersion { get; set; }

        public virtual Service Service { get; set; }
        public virtual ServiceRun ServiceRun { get; set; }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\ServiceLog.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\ServiceRun.cs==START]using System;

namespace ServiceScheduler.Data.Model
{
    public class ServiceRun
    {
        public int ServiceRunId { get; set; }
        public int ServiceId { get; set; }
        public int ServiceScheduleId { get; set; }
        public string ServiceVersion { get; set; }
        public DateTime DateRun { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string Parameters { get; set; }
        public ServiceRunStatus ServiceRunStatusId { get; set; }
        public string Message { get; set; }
        public int ProcessId { get; set; }

        public virtual Service Service { get; set; }
        public virtual ServiceSchedule ServiceSchedule { get; set; }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\ServiceRun.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\ServiceRunStatus.cs==START]namespace ServiceScheduler.Data.Model
{
    public enum ServiceRunStatus
    {
        Idle = 0,
        Starting = 1,
        Started = 2,
        Completed = 3,
        Error = 4
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\ServiceRunStatus.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\ServiceSchedule.cs==START]namespace ServiceScheduler.Data.Model
{
    public class ServiceSchedule
    {
        public int ServiceScheduleId { get; set; }
        public int ServiceId { get; set; }
        public string ScheduleName { get; set; }
        public string Schedule { get; set; }
        public string Parameters { get; set; }
        public bool Enabled { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Service Service { get; set; }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\ServiceSchedule.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\Mapping\ServiceLogMap.cs==START]using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceScheduler.Data.Model.Mapping
{
    public class ServiceLogMap : EntityTypeConfiguration<ServiceLog>
    {
        public ServiceLogMap()
        {
            // Primary Key
            HasKey(t => t.ServiceLogId);

            // Properties
            Property(t => t.ServiceLogId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.ServiceId)
                .IsRequired();
            Property(t => t.ServiceRunId)
                .IsRequired();
            Property(t => t.LogType)
                .IsRequired()
                .HasMaxLength(20);
            Property(t => t.DateLogged)
                .IsRequired();
            Property(t => t.Description)
                .IsRequired();
            Property(t => t.StackTrace)
                .IsRequired();
            Property(t => t.ServiceVersion)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("ServiceLog");
            Property(t => t.ServiceLogId).HasColumnName("ServiceLogId");
            Property(t => t.ServiceId).HasColumnName("ServiceId");
            Property(t => t.ServiceRunId).HasColumnName("ServiceRunId");
            Property(t => t.LogType).HasColumnName("LogType");
            Property(t => t.DateLogged).HasColumnName("DateLogged");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.StackTrace).HasColumnName("StackTrace");
            Property(t => t.ServiceVersion).HasColumnName("ServiceVersion");

            // Relationships
            this.HasRequired(t => t.Service)
                .WithMany()
                .HasForeignKey(t => t.ServiceId);
            this.HasRequired(t => t.ServiceRun)
                .WithMany()
                .HasForeignKey(t => t.ServiceRunId);
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\Mapping\ServiceLogMap.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\Mapping\ServiceMap.cs==START]using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceScheduler.Data.Model.Mapping
{
    public class ServiceMap : EntityTypeConfiguration<Service>
    {
        public ServiceMap()
        {
            // Primary Key
            HasKey(t => t.ServiceId);

            // Properties
            Property(t => t.ServiceId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.ServiceName)
                .IsRequired()
                .HasMaxLength(100);
            Property(t => t.Enabled)
                .IsRequired();
            Property(t => t.DateInstalled)
                .IsRequired();
            Property(t => t.ServiceVersion)
                .IsRequired()
                .HasMaxLength(50);
            Property(t => t.ServicePath)
                .IsRequired()
                .HasMaxLength(250);
            Property(t => t.ServiceEntry)
                .IsRequired()
                .HasMaxLength(100);
            Property(t => t.AllowConcurrency)
                .IsRequired();
            Property(t => t.ModifiedBy)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("Service");
            Property(t => t.ServiceId).HasColumnName("ServiceId");
            Property(t => t.ServiceName).HasColumnName("ServiceName");
            Property(t => t.Enabled).HasColumnName("Enabled");
            Property(t => t.DateInstalled).HasColumnName("DateInstalled");
            Property(t => t.ServiceVersion).HasColumnName("ServiceVersion");
            Property(t => t.ServicePath).HasColumnName("ServicePath");
            Property(t => t.ServiceEntry).HasColumnName("ServiceEntry");
            Property(t => t.AllowConcurrency).HasColumnName("AllowConcurrency");
            Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\Mapping\ServiceMap.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\Mapping\ServiceRunMap.cs==START]using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceScheduler.Data.Model.Mapping
{
    public class ServiceRunMap : EntityTypeConfiguration<ServiceRun>
    {
        public ServiceRunMap()
        {
            // Primary Key
            HasKey(t => t.ServiceRunId);

            // Properties
            Property(t => t.ServiceRunId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.ServiceId)
                .IsRequired();
            Property(t => t.ServiceScheduleId)
                .IsRequired();
            Property(t => t.ServiceVersion)
                .IsRequired()
                .HasMaxLength(50);
            Property(t => t.DateRun)
                .IsRequired();
            Property(t => t.DateCompleted)
                .IsOptional();
            Property(t => t.Parameters)
                .IsRequired();
            Property(t => t.ServiceRunStatusId)
                .IsRequired();
            Property(t => t.Message)
                .IsRequired()
                .HasMaxLength(1000);
            Property(t => t.ProcessId)
                .IsRequired();

            // Table & Column Mappings
            ToTable("ServiceRun");
            Property(t => t.ServiceRunId).HasColumnName("ServiceRunId");
            Property(t => t.ServiceId).HasColumnName("ServiceId");
            Property(t => t.ServiceScheduleId).HasColumnName("ServiceScheduleId");
            Property(t => t.ServiceVersion).HasColumnName("ServiceVersion");
            Property(t => t.DateRun).HasColumnName("DateRun");
            Property(t => t.DateCompleted).HasColumnName("DateCompleted");
            Property(t => t.Parameters).HasColumnName("Parameters");
            Property(t => t.ServiceRunStatusId).HasColumnName("ServiceRunStatusId");
            Property(t => t.Message).HasColumnName("Message");
            Property(t => t.ProcessId).HasColumnName("ProcessId");

            // Relationships
            this.HasRequired(t => t.Service)
                .WithMany(t=>t.ServiceRun)
                .HasForeignKey(t => t.ServiceId);
            this.HasRequired(t => t.ServiceSchedule)
                .WithMany()
                .HasForeignKey(t => t.ServiceScheduleId);
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\Mapping\ServiceRunMap.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\Mapping\ServiceScheduleMap.cs==START]using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceScheduler.Data.Model.Mapping
{
    public class ServiceScheduleMap : EntityTypeConfiguration<ServiceSchedule>
    {
        public ServiceScheduleMap()
        {
            // Primary Key
            HasKey(t => t.ServiceScheduleId);

            // Properties
            Property(t => t.ServiceScheduleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.ServiceId)
                .IsRequired();
            Property(t => t.ScheduleName)
                .IsRequired()
                .HasMaxLength(100);
            Property(t => t.Schedule)
                .IsRequired()
                .HasMaxLength(1000);
            Property(t => t.Parameters)
                .IsRequired();
            Property(t => t.Enabled)
                .IsRequired();
            Property(t => t.ModifiedBy)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("ServiceSchedule");
            Property(t => t.ServiceScheduleId).HasColumnName("ServiceScheduleId");
            Property(t => t.ServiceId).HasColumnName("ServiceId");
            Property(t => t.ScheduleName).HasColumnName("ScheduleName");
            Property(t => t.Schedule).HasColumnName("Schedule");
            Property(t => t.Parameters).HasColumnName("Parameters");
            Property(t => t.Enabled).HasColumnName("Enabled");
            Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");

            this.HasRequired(t => t.Service)
                .WithMany(t => t.ServiceSchedule)
                .HasForeignKey(t => t.ServiceId);
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Model\Mapping\ServiceScheduleMap.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ServiceScheduler.Data")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("ServiceScheduler.Data")]
[assembly: AssemblyCopyright("Copyright © Pinpoint 2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("ee3480e7-94c2-45b4-a7bc-32c442457dc7")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Repository\IServiceRepository.cs==START]using System.Collections.Generic;
using ServiceScheduler.Data.Model;

namespace ServiceScheduler.Data.Repository
{
    public interface IServiceRepository
    {
        Service Retrieve(string serviceName);
        IEnumerable<Service> Retrieve();
        IEnumerable<ServiceSchedule> GetSchedules(int serviceId);
        void Insert(Service service);
        void Update(Service service);
        void Commit();
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Repository\IServiceRepository.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Repository\IServiceRepositoryFactory.cs==START]namespace ServiceScheduler.Data.Repository
{
    public interface IServiceRepositoryFactory
    {
        IServiceRepository GetServiceRepository();
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Repository\IServiceRepositoryFactory.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Repository\ServiceRepository.cs==START]using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ServiceScheduler.Data.Model;

namespace ServiceScheduler.Data.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ServiceSchedulerDataContext _context;

        public ServiceRepository(ServiceSchedulerDataContext context)
        {
            _context = context;
        }

        public Service Retrieve(string serviceName)
        {
            return _context.Service.FirstOrDefault(o => o.ServiceName == serviceName);
        }

        public IEnumerable<Service> Retrieve()
        {
            return _context.Service;
        }

        public void Insert(Service service)
        {
            if (_context.Service != null)
                _context.Service.Add(service);
        }

        public void Update(Service service)
        {
            _context.Entry(service).State = EntityState.Modified;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IEnumerable<ServiceSchedule> GetSchedules(int serviceId)
        {
            return _context.ServiceSchedule.Where(p => p.ServiceId == serviceId);
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Repository\ServiceRepository.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Repository\ServiceRepositoryFactory.cs==START]namespace ServiceScheduler.Data.Repository
{
    public class ServiceRepositoryFactory : IServiceRepositoryFactory
    {
        private readonly Pinpoint.Environment.IEnvironment _environment;

        public ServiceRepositoryFactory(Pinpoint.Environment.IEnvironment environment)
        {
            _environment = environment;
        }

        public IServiceRepository GetServiceRepository()
        {
            return new ServiceRepository(new ServiceSchedulerDataContext(_environment));
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Data\Repository\ServiceRepositoryFactory.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\App.config==START]<?xml version="1.0" encoding="utf-8"?>
<configuration />[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\App.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\packages.config==START]<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Moq" version="4.2.1402.2112" targetFramework="net452" />
  <package id="NUnit" version="2.6.4" targetFramework="net452" />
  <package id="Pinpoint.Environment" version="1.0.0.7" targetFramework="net452" />
</packages>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\packages.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\ServiceScheduler.FunctionalTest.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{00C7FFF8-E054-44C3-9CB6-9051E24FDA32}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ServiceScheduler.FunctionalTest</RootNamespace>
    <AssemblyName>ServiceScheduler.FunctionalTest</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Moq">
      <HintPath>..\packages\Moq.4.2.1402.2112\lib\net40\Moq.dll</HintPath>
    </Reference>
    <Reference Include="nunit.framework, Version=2.6.4.14350, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\NUnit.2.6.4\lib\nunit.framework.dll</HintPath>
    </Reference>
    <Reference Include="Pinpoint.Environment, Version=1.0.0.0, Culture=neutral, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Pinpoint.Environment.1.0.0.7\lib\net40\Pinpoint.Environment.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.ComponentModel.DataAnnotations" />
    <Reference Include="System.Core" />
    <Reference Include="System.Data" />
    <Reference Include="System.Net.Http" />
    <Reference Include="System.ServiceProcess" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Properties\AssemblyInfo.cs" />
    <Compile Include="ServiceSchedulerServiceRunTests.cs" />
    <Compile Include="TestServicesHelper.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
    <None Include="AssembliesReader\ZipSamples\ConsoleSample.zip" />
    <None Include="AssembliesReader\ZipSamples\DllSample.zip" />
    <None Include="packages.config">
      <SubType>Designer</SubType>
    </None>
    <None Include="Test Services\ServiceA.v01.zip" />
    <None Include="Test Services\ServiceA.v02.zip" />
    <None Include="Test Services\ServiceB.v01.zip" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\ServiceScheduler.Data\ServiceScheduler.Data.csproj">
      <Project>{ae48f4c5-1882-4ed7-b723-b70d394ea651}</Project>
      <Name>ServiceScheduler.Data</Name>
    </ProjectReference>
    <ProjectReference Include="..\ServiceScheduler\ServiceScheduler.csproj">
      <Project>{f14d9875-ef4d-4979-adec-e26cd8c9ec78}</Project>
      <Name>ServiceScheduler</Name>
    </ProjectReference>
  </ItemGroup>
  <ItemGroup>
    <Content Include="Test Services\ReadMe.txt" />
  </ItemGroup>
  <ItemGroup />
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\ServiceScheduler.FunctionalTest.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\ServiceScheduler.FunctionalTest.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\ServiceScheduler.FunctionalTest.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\ServiceSchedulerServiceRunTests.cs==START]using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using NUnit.Framework;
using ServiceScheduler.Data.Model;

namespace ServiceScheduler.FunctionalTest
{
    [TestFixture]
    public class ServiceSchedulerServiceRunTests
    {
        private readonly TestServicesHelper _servicesHelper = new TestServicesHelper();

        [SetUp]
        public void SetUp()
        {
            _servicesHelper.CleanupServiceFolders();
            _servicesHelper.ResetServiceTables();
            _servicesHelper.StartServiceScheduler();
        }

        [TearDown]
        public void TearDown()
        {
            _servicesHelper.StopServiceScheduler();
            _servicesHelper.ResetServiceTables();
            _servicesHelper.CleanupServiceFolders();
        }

        [Test, Explicit]
        public void ExecuteTwoServices_HappyPath_ExpectedResultsInDatabase()
        {
            _servicesHelper.DeployServicesVersion1();

            // wait for services to complete, each takes 30 seconds
            Thread.Sleep(TimeSpan.FromSeconds(35));

            VerifyServiceTables1();
        }

        [Test, Explicit]
        public void ExecuteTwoServices_AddServiceAVersion2WhileVersion1Running_ExpectedResultsInDatabase()
        {
            _servicesHelper.DeployServicesVersion1();

            // deploy services version 2 after 10 sec
            Thread.Sleep(TimeSpan.FromSeconds(10));
            _servicesHelper.DeployServicesVersion2();

            // wait for services to complete, each takes 30 seconds
            Thread.Sleep(TimeSpan.FromSeconds(35));

            VerifyServiceTables2();
        }

        [Test, Explicit]
        public void ExecuteTwoServices_DeployFastServiceFirstThenTwoSlowServices_ExpectedResultsInDatabase()
        {
            _servicesHelper.DeployServicesVersion2();
            _servicesHelper.DeployServicesVersion1();

            // wait for services to complete, each takes 30 seconds
            Thread.Sleep(TimeSpan.FromSeconds(35));

            VerifyServiceTables3();
        }

        #region Private Methods
        private void VerifyServiceTables1()
        {
            string serviceFolder = Path.GetDirectoryName(_servicesHelper.GetExecutablePath(_servicesHelper.ServiceSchedulerServiceName));
            serviceFolder = Path.Combine(serviceFolder, "Services");

            const string serviceVersion = "1.0.0.1";
            string installedFolder = Path.Combine(serviceFolder, "Installed");
            string installedServiceAFolder = Path.Combine(installedFolder, _servicesHelper.TestServiceAName, serviceVersion);
            string installedServiceBFolder = Path.Combine(installedFolder, _servicesHelper.TestServiceBName, serviceVersion);
            string serviceAScheduleName = string.Format("{0} ONCE", _servicesHelper.TestServiceAName);
            string serviceBScheduleName = string.Format("{0} ONCE", _servicesHelper.TestServiceBName);

            const string sqlQuery = @"
                declare @serviceAId int
                declare @serviceBId int
                declare @serviceAScheduleId int
                declare @serviceBScheduleId int
                declare @serviceARunId int
                declare @serviceBRunId int
                declare @msg varchar(max)
                set @msg = ''

                select @serviceAId = serviceid
                from service (nolock)
                where servicename = @ServiceA
                and serviceversion = @ServiceAVersion
                and servicepath = @ServiceAPath
                and serviceentry = 'ServiceA.exe'
                and enabled = 1
                and allowconcurrency = 0

                if isnull(@serviceAId, 0) = 0
                begin
                    select @msg = @msg + 'Service record incorrect for ' + @ServiceA + '; '
                end
                else
                begin
                    select @serviceAScheduleId = servicescheduleid
                    from serviceschedule (nolock)
                    where serviceid = @serviceAId
                    and schedulename = @ServiceASchedule
                    and schedule = 'ONCE'
                    and parameters = ''
                    and enabled = 1

                    if isnull(@serviceAScheduleId, 0) = 0
                    begin
                        select @msg = @msg + 'Service schedule record incorrect for ' + @ServiceA + '; '
                    end
                    else
                    begin
                        select @serviceARunId = servicerunid
                        from servicerun (nolock)
                        where serviceid = @serviceAId
                        and servicescheduleid = @serviceAScheduleId
                        and serviceversion = @ServiceAVersion
                        and parameters = ''
                        and ServiceRunStatusId = @ServiceAStatus
                        and message = ''
                        and processid > 0

                        if isnull(@serviceARunId, 0) = 0
                        begin
                            select @msg = @msg + 'Service run record incorrect for ' + @ServiceA + '; '
                        end
                    end
                end

                select @serviceBId = serviceid
                from service (nolock)
                where servicename = @ServiceB
                and serviceversion = @ServiceBVersion
                and servicepath = @ServiceBPath
                and serviceentry = 'ServiceB.exe'
                and enabled = 1
                and allowconcurrency = 0

                if isnull(@serviceBId, 0) = 0
                begin
                    select @msg = @msg + 'Service record incorrect for ' + @ServiceB + '; '
                end
                else
                begin
                    select @serviceBScheduleId = servicescheduleid
                    from serviceschedule (nolock)
                    where serviceid = @serviceBId
                    and schedulename = @ServiceBSchedule
                    and schedule = 'ONCE'
                    and parameters = '/a /b:""Hello World!""'
                    and enabled = 1

                    if isnull(@serviceBScheduleId, 0) = 0
                    begin
                        select @msg = @msg + 'Service schedule record incorrect for ' + @ServiceB + '; '
                    end
                    else
                    begin
                        select @serviceBRunId = servicerunid
                        from servicerun (nolock)
                        where serviceid = @serviceBId
                        and servicescheduleid = @serviceBScheduleId
                        and serviceversion = @ServiceBVersion
                        and parameters = '/a /b:""Hello World!""'
                        and ServiceRunStatusId = @ServiceBStatus
                        and message = ''
                        and processid > 0

                        if isnull(@serviceBRunId, 0) = 0
                        begin
                            select @msg = @msg + 'Service run record incorrect for ' + @ServiceB + '; '
                        end
                    end
                end

                select @msg as msg
            ";

            var sqlParameters = new[]
            {
                new SqlParameter("@ServiceA", _servicesHelper.TestServiceAName),
                new SqlParameter("@ServiceASchedule", serviceAScheduleName),
                new SqlParameter("@ServiceAVersion", serviceVersion),
                new SqlParameter("@ServiceAPath", installedServiceAFolder),
                new SqlParameter("@ServiceAStatus", ServiceRunStatus.Completed),
                new SqlParameter("@ServiceB", _servicesHelper.TestServiceBName),
                new SqlParameter("@ServiceBSchedule", serviceBScheduleName),
                new SqlParameter("@ServiceBVersion", serviceVersion),
                new SqlParameter("@ServiceBPath", installedServiceBFolder),
                new SqlParameter("@ServiceBStatus", ServiceRunStatus.Completed)
            };

            var msg = string.Format("{0}", _servicesHelper.ExecSqlScalar(sqlQuery, sqlParameters));

            Assert.IsEmpty(msg, msg);
        }

        private void VerifyServiceTables2()
        {
            string serviceFolder = Path.GetDirectoryName(_servicesHelper.GetExecutablePath(_servicesHelper.ServiceSchedulerServiceName));
            serviceFolder = Path.Combine(serviceFolder, "Services");

            const string serviceVersion1 = "1.0.0.1";
            const string serviceVersion2 = "1.0.0.2";
            string installedFolder = Path.Combine(serviceFolder, "Installed");
            string installedServiceAFolder = Path.Combine(installedFolder, _servicesHelper.TestServiceAName, serviceVersion2);
            string installedServiceBFolder = Path.Combine(installedFolder, _servicesHelper.TestServiceBName, serviceVersion1);
            string serviceAScheduleName = string.Format("{0} ONCE", _servicesHelper.TestServiceAName);
            string serviceBScheduleName = string.Format("{0} ONCE", _servicesHelper.TestServiceBName);

            const string sqlQuery = @"
                declare @serviceAId int
                declare @serviceBId int
                declare @serviceAScheduleId int
                declare @serviceBScheduleId int
                declare @serviceARunId int
                declare @serviceBRunId int
                declare @msg varchar(max)
                set @msg = ''

                select @serviceAId = serviceid
                from service (nolock)
                where servicename = @ServiceA
                and serviceversion = @ServiceAVersion
                and servicepath = @ServiceAPath
                and serviceentry = 'ServiceA.exe'
                and enabled = 1
                and allowconcurrency = 0

                if isnull(@serviceAId, 0) = 0
                begin
                    select @msg = @msg + 'Service record incorrect for ' + @ServiceA + '; '
                end
                else
                begin
                    select @serviceAScheduleId = servicescheduleid
                    from serviceschedule (nolock)
                    where serviceid = @serviceAId
                    and schedulename = @ServiceASchedule
                    and schedule = 'ONCE'
                    and parameters = ''
                    and enabled = 1

                    if isnull(@serviceAScheduleId, 0) = 0
                    begin
                        select @msg = @msg + 'Service schedule record incorrect for ' + @ServiceA + '; '
                    end
                    else
                    begin
                        select @serviceARunId = servicerunid
                        from servicerun (nolock)
                        where serviceid = @serviceAId
                        and servicescheduleid = @serviceAScheduleId
                        and serviceversion = @ServiceRunAVersion
                        and parameters = ''
                        and ServiceRunStatusId = @ServiceAStatus
                        and message = ''
                        and processid > 0

                        if isnull(@serviceARunId, 0) = 0
                        begin
                            select @msg = @msg + 'Service run record incorrect for ' + @ServiceA + '; '
                        end
                    end
                end

                select @serviceBId = serviceid
                from service (nolock)
                where servicename = @ServiceB
                and serviceversion = @ServiceBVersion
                and servicepath = @ServiceBPath
                and serviceentry = 'ServiceB.exe'
                and enabled = 1
                and allowconcurrency = 0

                if isnull(@serviceBId, 0) = 0
                begin
                    select @msg = @msg + 'Service record incorrect for ' + @ServiceB + '; '
                end
                else
                begin
                    select @serviceBScheduleId = servicescheduleid
                    from serviceschedule (nolock)
                    where serviceid = @serviceBId
                    and schedulename = @ServiceBSchedule
                    and schedule = 'ONCE'
                    and parameters = '/a /b:""Hello World!""'
                    and enabled = 1

                    if isnull(@serviceBScheduleId, 0) = 0
                    begin
                        select @msg = @msg + 'Service schedule record incorrect for ' + @ServiceB + '; '
                    end
                    else
                    begin
                        select @serviceBRunId = servicerunid
                        from servicerun (nolock)
                        where serviceid = @serviceBId
                        and servicescheduleid = @serviceBScheduleId
                        and serviceversion = @ServiceRunBVersion
                        and parameters = '/a /b:""Hello World!""'
                        and ServiceRunStatusId = @ServiceBStatus
                        and message = ''
                        and processid > 0

                        if isnull(@serviceBRunId, 0) = 0
                        begin
                            select @msg = @msg + 'Service run record incorrect for ' + @ServiceB + '; '
                        end
                    end
                end

                select @msg as msg
            ";

            var sqlParameters = new[]
            {
                new SqlParameter("@ServiceA", _servicesHelper.TestServiceAName),
                new SqlParameter("@ServiceASchedule", serviceAScheduleName),
                new SqlParameter("@ServiceAVersion", serviceVersion2),
                new SqlParameter("@ServiceRunAVersion", serviceVersion1),
                new SqlParameter("@ServiceAPath", installedServiceAFolder),
                new SqlParameter("@ServiceAStatus", ServiceRunStatus.Completed),
                new SqlParameter("@ServiceB", _servicesHelper.TestServiceBName),
                new SqlParameter("@ServiceBSchedule", serviceBScheduleName),
                new SqlParameter("@ServiceBVersion", serviceVersion1),
                new SqlParameter("@ServiceRunBVersion", serviceVersion1),
                new SqlParameter("@ServiceBPath", installedServiceBFolder),
                new SqlParameter("@ServiceBStatus", ServiceRunStatus.Completed)
            };

            var msg = string.Format("{0}", _servicesHelper.ExecSqlScalar(sqlQuery, sqlParameters));

            Assert.IsEmpty(msg, msg);
        }

        private void VerifyServiceTables3()
        {
            string serviceFolder = Path.GetDirectoryName(_servicesHelper.GetExecutablePath(_servicesHelper.ServiceSchedulerServiceName));
            serviceFolder = Path.Combine(serviceFolder, "Services");

            const string serviceVersion1 = "1.0.0.1";
            const string serviceVersion2 = "1.0.0.2";
            string installedFolder = Path.Combine(serviceFolder, "Installed");
            string installedServiceAFolder = Path.Combine(installedFolder, _servicesHelper.TestServiceAName, serviceVersion1);
            string installedServiceBFolder = Path.Combine(installedFolder, _servicesHelper.TestServiceBName, serviceVersion1);
            string serviceAScheduleName = string.Format("{0} ONCE", _servicesHelper.TestServiceAName);
            string serviceBScheduleName = string.Format("{0} ONCE", _servicesHelper.TestServiceBName);

            const string sqlQuery = @"
                declare @serviceAId int
                declare @serviceBId int
                declare @serviceAScheduleId int
                declare @serviceBScheduleId int
                declare @serviceARunId int
                declare @serviceBRunId int
                declare @msg varchar(max)
                set @msg = ''

                select @serviceAId = serviceid
                from service (nolock)
                where servicename = @ServiceA
                and serviceversion = @ServiceAVersion
                and servicepath = @ServiceAPath
                and serviceentry = 'ServiceA.exe'
                and enabled = 1
                and allowconcurrency = 0

                if isnull(@serviceAId, 0) = 0
                begin
                    select @msg = @msg + 'Service record incorrect for ' + @ServiceA + '; '
                end
                else
                begin
                    select @serviceAScheduleId = servicescheduleid
                    from serviceschedule (nolock)
                    where serviceid = @serviceAId
                    and schedulename = @ServiceASchedule
                    and schedule = 'ONCE'
                    and parameters = ''
                    and enabled = 1

                    if isnull(@serviceAScheduleId, 0) = 0
                    begin
                        select @msg = @msg + 'Service schedule record incorrect for ' + @ServiceA + '; '
                    end
                    else
                    begin
                        select @serviceARunId = servicerunid
                        from servicerun (nolock)
                        where serviceid = @serviceAId
                        and servicescheduleid = @serviceAScheduleId
                        and serviceversion = @ServiceRunAVersion
                        and parameters = ''
                        and ServiceRunStatusId = @ServiceAStatus
                        and message = ''
                        and processid > 0

                        if isnull(@serviceARunId, 0) = 0
                        begin
                            select @msg = @msg + 'Service run record incorrect for ' + @ServiceA + '; '
                        end
                    end
                end

                select @serviceBId = serviceid
                from service (nolock)
                where servicename = @ServiceB
                and serviceversion = @ServiceBVersion
                and servicepath = @ServiceBPath
                and serviceentry = 'ServiceB.exe'
                and enabled = 1
                and allowconcurrency = 0

                if isnull(@serviceBId, 0) = 0
                begin
                    select @msg = @msg + 'Service record incorrect for ' + @ServiceB + '; '
                end
                else
                begin
                    select @serviceBScheduleId = servicescheduleid
                    from serviceschedule (nolock)
                    where serviceid = @serviceBId
                    and schedulename = @ServiceBSchedule
                    and schedule = 'ONCE'
                    and parameters = '/a /b:""Hello World!""'
                    and enabled = 1

                    if isnull(@serviceBScheduleId, 0) = 0
                    begin
                        select @msg = @msg + 'Service schedule record incorrect for ' + @ServiceB + '; '
                    end
                    else
                    begin
                        select @serviceBRunId = servicerunid
                        from servicerun (nolock)
                        where serviceid = @serviceBId
                        and servicescheduleid = @serviceBScheduleId
                        and serviceversion = @ServiceRunBVersion
                        and parameters = '/a /b:""Hello World!""'
                        and ServiceRunStatusId = @ServiceBStatus
                        and message = ''
                        and processid > 0

                        if isnull(@serviceBRunId, 0) = 0
                        begin
                            select @msg = @msg + 'Service run record incorrect for ' + @ServiceB + '; '
                        end
                    end
                end

                select @msg as msg
            ";

            var sqlParameters = new[]
            {
                new SqlParameter("@ServiceA", _servicesHelper.TestServiceAName),
                new SqlParameter("@ServiceASchedule", serviceAScheduleName),
                new SqlParameter("@ServiceAVersion", serviceVersion1),
                new SqlParameter("@ServiceRunAVersion", serviceVersion2),
                new SqlParameter("@ServiceAPath", installedServiceAFolder),
                new SqlParameter("@ServiceAStatus", ServiceRunStatus.Completed),
                new SqlParameter("@ServiceB", _servicesHelper.TestServiceBName),
                new SqlParameter("@ServiceBSchedule", serviceBScheduleName),
                new SqlParameter("@ServiceBVersion", serviceVersion1),
                new SqlParameter("@ServiceRunBVersion", serviceVersion1),
                new SqlParameter("@ServiceBPath", installedServiceBFolder),
                new SqlParameter("@ServiceBStatus", ServiceRunStatus.Completed)
            };

            var msg = string.Format("{0}", _servicesHelper.ExecSqlScalar(sqlQuery, sqlParameters));

            Assert.IsEmpty(msg, msg);
        }
        #endregion
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\ServiceSchedulerServiceRunTests.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\TestServicesHelper.cs==START]using System;
using System.Data.SqlClient;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using Microsoft.Win32;

namespace ServiceScheduler.FunctionalTest
{
    public class TestServicesHelper
    {
        private const int FILE_FOLDER_RETRY_COUNT = 3;
        private const string TEST_SERVICES_FOLDER = @"C:\dotnet2013\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\Test Services";
        private const string CONNECTION_STRING = @"server=.\sql2012;database=au_common_services_app;Integrated Security=True;MultipleActiveResultSets=True";

        public string TestServiceAName = "ServiceA";
        public string TestServiceBName = "ServiceB";
        public string TestServiceAParameters = "";
        public string TestServiceBParameters = "";
        public string ServiceSchedulerServiceName = "ServiceScheduler";

        public void StartServiceScheduler()
        {
            var service = new ServiceController(ServiceSchedulerServiceName);

            if (service.Status == ServiceControllerStatus.Running)
            {
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.MaxValue);
            }

            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.MaxValue);
        }

        public void StopServiceScheduler()
        {
            var service = new ServiceController(ServiceSchedulerServiceName);

            if (service.Status == ServiceControllerStatus.Running)
            {
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.MaxValue);
            }
        }

        public void WaitForServicesToComplete()
        {
            // wait for services to complete, each takes 30 seconds
            Thread.Sleep(TimeSpan.FromSeconds(35));
        }

        public string GetExecutablePath(string serviceName)
        {
            string executablePath = "";
            string registryPath = @"SYSTEM\CurrentControlSet\Services\" + serviceName;
            RegistryKey keyHKLM = Registry.LocalMachine;

            RegistryKey key = keyHKLM.OpenSubKey(registryPath);
            if (key != null)
            {
                string value = key.GetValue("ImagePath").ToString();
                key.Close();

                executablePath = System.Environment.ExpandEnvironmentVariables(value);
            }

            return executablePath;
        }

        public void DeployServicesVersion1()
        {
            string serviceFolder = Path.GetDirectoryName(GetExecutablePath(ServiceSchedulerServiceName));
            serviceFolder = Path.Combine(serviceFolder, "Services");
            if (!Directory.Exists(serviceFolder)) Directory.CreateDirectory(serviceFolder);

            string serviceAv01ZipPathSrc = Path.Combine(TEST_SERVICES_FOLDER, "ServiceA.v01.zip");
            string serviceBv02ZipPathSrc = Path.Combine(TEST_SERVICES_FOLDER, "ServiceB.v01.zip");

            string serviceAv01ZipPathDst1 = Path.Combine(serviceFolder, "ServiceA.v01._zip");
            string serviceAv01ZipPathDst2 = Path.Combine(serviceFolder, "ServiceA.v01.zip");
            string serviceBv02ZipPathDst1 = Path.Combine(serviceFolder, "ServiceB.v01._zip");
            string serviceBv02ZipPathDst2 = Path.Combine(serviceFolder, "ServiceB.v01.zip");

            DeleteFile(serviceAv01ZipPathDst1);
            DeleteFile(serviceAv01ZipPathDst2);
            DeleteFile(serviceBv02ZipPathDst1);
            DeleteFile(serviceBv02ZipPathDst2);

            File.Copy(serviceAv01ZipPathSrc, serviceAv01ZipPathDst1, true);
            File.Copy(serviceBv02ZipPathSrc, serviceBv02ZipPathDst1, true);

            File.Move(serviceAv01ZipPathDst1, serviceAv01ZipPathDst2);
            File.Move(serviceBv02ZipPathDst1, serviceBv02ZipPathDst2);
        }

        public void DeployServicesVersion2()
        {
            string serviceFolder = Path.GetDirectoryName(GetExecutablePath(ServiceSchedulerServiceName));
            serviceFolder = Path.Combine(serviceFolder, "Services");
            if (!Directory.Exists(serviceFolder)) Directory.CreateDirectory(serviceFolder);

            string serviceAv01ZipPathSrc = Path.Combine(TEST_SERVICES_FOLDER, "ServiceA.v02.zip");

            string serviceAv01ZipPathDst1 = Path.Combine(serviceFolder, "ServiceA.v02._zip");
            string serviceAv01ZipPathDst2 = Path.Combine(serviceFolder, "ServiceA.v02.zip");

            DeleteFile(serviceAv01ZipPathDst1);
            DeleteFile(serviceAv01ZipPathDst2);

            File.Copy(serviceAv01ZipPathSrc, serviceAv01ZipPathDst1, true);

            File.Move(serviceAv01ZipPathDst1, serviceAv01ZipPathDst2);
        }

        public void CleanupServiceFolders()
        {
            string serviceFolder = Path.GetDirectoryName(GetExecutablePath(ServiceSchedulerServiceName));
            serviceFolder = Path.Combine(serviceFolder, "Services");

            string installedFolder = Path.Combine(serviceFolder, "Installed");
            string installedServiceAFolder = Path.Combine(installedFolder, TestServiceAName);
            string installedServiceBFolder = Path.Combine(installedFolder, TestServiceBName);
            string registeredFolder = Path.Combine(serviceFolder, "Registered");
            string registeredServiceAFolder = Path.Combine(registeredFolder, TestServiceAName);
            string registeredServiceBFolder = Path.Combine(registeredFolder, TestServiceBName);


            DeleteFolder(installedServiceAFolder);
            DeleteFolder(installedServiceBFolder);
            DeleteFolder(registeredServiceAFolder);
            DeleteFolder(registeredServiceBFolder);
        }

        private void DeleteFolder(string folderPath)
        {
            for (int i = 0; i < FILE_FOLDER_RETRY_COUNT; i++) // retry
            {
                try
                {
                    if (Directory.Exists(folderPath)) Directory.Delete(folderPath, true);
                    return;
                }
                catch (Exception)
                {
                    if (i == (FILE_FOLDER_RETRY_COUNT - 1))
                    {
                        //throw;
                    }
                }
            }
        }

        private void DeleteFile(string filePath)
        {
            for (int i = 0; i < FILE_FOLDER_RETRY_COUNT; i++) // retry
            {
                try
                {
                    if (File.Exists(filePath)) File.Delete(filePath);
                    return;
                }
                catch (Exception)
                {
                    if (i == (FILE_FOLDER_RETRY_COUNT - 1))
                    {
                        //throw;
                    }
                }
            }
        }

        public void ResetServiceTables()
        {
            string sqlQuery = @"
                delete servicerun where serviceid in (
                    select serviceid from service where servicename in (@ServiceA, @ServiceB)
                )
                delete serviceschedule where serviceid in (
                    select serviceid from service where servicename in (@ServiceA, @ServiceB)
                )
                delete service where servicename in (@ServiceA, @ServiceB)
            ";

            var sqlParameters = new[]
            {
                new SqlParameter("@ServiceA", TestServiceAName),
                new SqlParameter("@ServiceB", TestServiceBName)
            };

            ExecSqlNonQuery(sqlQuery, sqlParameters);
        }

        public void UpdateServiceRunProcessId(int serviceRunId, int processId)
        {
            string sqlQuery = @"
                update servicerun
                set processid = @ProcessId
                where servicerunid = @ServiceRunId
            ";

            var sqlParameters = new[]
            {
                new SqlParameter("@ProcessId", processId),
                new SqlParameter("@ServiceRunId", serviceRunId)
            };

            ExecSqlNonQuery(sqlQuery, sqlParameters);
        }

        public void ExecSqlNonQuery(string sqlQuery, params SqlParameter[] sqlParameters)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = sqlQuery;
            if (sqlParameters != null && sqlParameters.Length > 0)
            {
                command.Parameters.AddRange(sqlParameters);
            }
            command.ExecuteNonQuery();

            connection.Close();
        }

        public object ExecSqlScalar(string sqlQuery, params SqlParameter[] sqlParameters)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = sqlQuery;
            if (sqlParameters != null && sqlParameters.Length > 0)
            {
                command.Parameters.AddRange(sqlParameters);
            }
            object scalar = command.ExecuteScalar();

            connection.Close();

            return scalar;
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\TestServicesHelper.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ServiceScheduler.FunctionalTest")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("ServiceScheduler.FunctionalTest")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("9c2f3871-82e9-43ee-85a5-9848083ccfa3")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\Test Services\ReadMe.txt==START]ServiceA.v01.zip		- Runs once only for 30 sec.
ServiceA.v02.zip		- Runs once only with no sleep.
ServiceB.v01.zip		- Runs once only for 30 sec with parameters.
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.FunctionalTest\Test Services\ReadMe.txt==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\App.config==START]<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <configSections>
    
    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
  <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 --></configSections>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
  </startup>
  <appSettings>
    <!-- Enterprise Logging Library Settings-->
    <add key="LogLevel" value="Debug" />
    <add key="SourceDataCentre" value="AU" />
    <add key="MaskSensitiveData" value="true" />
    <add key="loc.WebApiHost" value="http://localhost:9000" />
    <add key="uat.WebApiHost" value="http://localhost:9000" />
    <add key="pro.WebApiHost" value="http://localhost:9000" />
    <add key="loc.GarbageCollectionJob.Schedule" value="" /> <!-- every ? -->
    <add key="uat.GarbageCollectionJob.Schedule" value="0 0 0/1 1/1 * ? *" /> <!-- every hour -->
    <add key="pro.GarbageCollectionJob.Schedule" value="0 0 6 ? * MON *" /> <!-- every week, monday, 6am -->
  </appSettings>
  <connectionStrings>
    <add name="loc.AuCommonServices" providerName="System.Data.SqlClient" connectionString="server=.\sql2012;database=au_common_services_app;Integrated Security=True;MultipleActiveResultSets=True" />
    <add name="uat.AuCommonServices" providerName="System.Data.SqlClient" connectionString="server=AUSQLUATSCL25\CMN;Initial Catalog=au_common_services_app;Integrated Security=True;MultipleActiveResultSets=True" />
    <add name="pro.AuCommonServices" providerName="System.Data.SqlClient" connectionString="server=AUSQLPRODSCL25\CMN;Initial Catalog=au_common_services_app;Integrated Security=True;MultipleActiveResultSets=True" />
    <add name="loc.AuCommonServicesLog" providerName="System.Data.SqlClient" connectionString="server=.\sql2012;database=au_common_services_app_log;Integrated Security=True;MultipleActiveResultSets=True" />
    <add name="uat.AuCommonServicesLog" providerName="System.Data.SqlClient" connectionString="server=AUSQLUATSCL25\CMN;Initial Catalog=au_common_services_app_log;Integrated Security=True;MultipleActiveResultSets=True" />
    <add name="pro.AuCommonServicesLog" providerName="System.Data.SqlClient" connectionString="server=AUSQLPRODSCL25\CMN;Initial Catalog=au_common_services_app_log;Integrated Security=True;MultipleActiveResultSets=True" />
  </connectionStrings>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="Microsoft.Owin" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-3.0.1.0" newVersion="3.0.1.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Http" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Http.Owin" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Net.Http.Formatting" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
  <entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
      <parameters>
        <parameter value="mssqllocaldb" />
      </parameters>
    </defaultConnectionFactory>
    <providers>
      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    </providers>
  </entityFramework>
</configuration>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\App.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\EventLogHelper.cs==START]using System;
using System.Diagnostics;

namespace ServiceScheduler.Service
{
    public class EventLogHelper : IEventLogHelper
    {
        private readonly string _eventLogSource;

        public EventLogHelper(string eventLogSource)
            : this(eventLogSource, null)
        {
        }

        public EventLogHelper(string eventLogSource, string eventLogName)
        {
            _eventLogSource = string.IsNullOrWhiteSpace(eventLogSource) ? "Application" : eventLogSource;
            string logName = string.IsNullOrWhiteSpace(eventLogName) ? "Pinpoint" : eventLogName;

            try
            {
                if (!EventLog.SourceExists(_eventLogSource))
                {
                    EventLog.CreateEventSource(_eventLogSource, logName);
                }
            }
            catch
            {
            }
        }

        public void Error(string message)
        {
            Error(message, null);
        }

        public void Error(string message, Exception ex)
        {
            using (var eventLog = new EventLog())
            {
                if (ex != null)
                {
                    message += string.Format("\n\n{0}", ex);
                }

                eventLog.Source = _eventLogSource;
                eventLog.WriteEntry(message, EventLogEntryType.Error);
            }
        }

        public void Info(string message)
        {
            using (var eventLog = new EventLog())
            {
                eventLog.Source = _eventLogSource;
                eventLog.WriteEntry(message, EventLogEntryType.Information);
            }
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\EventLogHelper.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\IEventLogHelper.cs==START]using System;

namespace ServiceScheduler.Service
{
    public interface IEventLogHelper
    {
        void Error(string message);
        void Error(string message, Exception ex);
        void Info(string message);
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\IEventLogHelper.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\packages.config==START]<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Castle.Core" version="3.2.0" targetFramework="net452" />
  <package id="EntityFramework" version="6.1.3" targetFramework="net452" />
  <package id="log4net" version="2.0.3" targetFramework="net45" />
  <package id="Microsoft.AspNet.WebApi.Client" version="5.2.3" targetFramework="net452" />
  <package id="Microsoft.AspNet.WebApi.Core" version="5.2.3" targetFramework="net452" />
  <package id="Microsoft.AspNet.WebApi.Owin" version="5.2.3" targetFramework="net452" />
  <package id="Microsoft.AspNet.WebApi.OwinSelfHost" version="5.2.3" targetFramework="net452" />
  <package id="Microsoft.Owin" version="3.0.1" targetFramework="net452" />
  <package id="Microsoft.Owin.Host.HttpListener" version="3.0.1" targetFramework="net452" />
  <package id="Microsoft.Owin.Hosting" version="3.0.1" targetFramework="net452" />
  <package id="Newtonsoft.Json" version="6.0.4" targetFramework="net452" />
  <package id="Ninject" version="3.2.2.0" targetFramework="net45" />
  <package id="Ninject.Extensions.Interception" version="3.2.0.0" targetFramework="net452" />
  <package id="Ninject.Extensions.Interception.DynamicProxy" version="3.2.0.0" targetFramework="net452" />
  <package id="Owin" version="1.0" targetFramework="net452" />
  <package id="Pinpoint.EnterpriseLogging" version="1.0.0.5" targetFramework="net452" />
  <package id="Pinpoint.Environment" version="1.0.0.7" targetFramework="net452" />
</packages>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\packages.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\Program.cs==START]using System;
using System.Configuration;
using System.Runtime.Remoting.Messaging;
using System.ServiceProcess;
using Ninject;
using Pinpoint.EnterpriseLogging;
using Pinpoint.EnterpriseLogging.Services;
using ServiceScheduler.LogAttributes;

namespace ServiceScheduler.Service
{
	static class Program
	{
	    private const string EventLogSource = "ServiceScheduler.Service";

		private static void Main()
		{
            ConfigureLogging();
            CallContext.SetData(Constants.LogContextKey, LogHelper.BuildLogContext());

		    try
		    {
		        Logger.Instance.LogInfo(string.Format("{0} program started.", EventLogSource));

		        var kernel = new StandardKernel(new ServiceIocModule(), new ServiceSchedulerIocModule());
		        var service = kernel.Get<ServiceSchedulerService>();

#if DebugLocal
                service.Start();
#else           
                ServiceBase.Run(new ServiceBase[] { service });
#endif

		    }
		    catch (Exception ex)
		    {
		        Logger.Instance.LogError(string.Format("{0} program error.", EventLogSource), ex);
		    }
		}

        private static void ConfigureLogging()
        {
            var logConnectionString = GetLoggingConnectionString();
            LoggerService.Instance.OverrideDefaultConnectionStringWith(logConnectionString);
            LoggerService.Instance.Start();
        }

        private static string GetLoggingConnectionString()
        {
            var env = new Pinpoint.Environment.Environment();
            return ConfigurationManager.ConnectionStrings[
                string.Format("{0}.AuCommonServicesLog", env.Current)].ConnectionString;
        }
	}
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\Program.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ProjectInstaller.cs==START]using System;
using System.Collections;
using System.ComponentModel;
using System.ServiceProcess;

namespace ServiceScheduler.Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);

            string account = GetContextParameter("account").Trim();
            if (!string.IsNullOrWhiteSpace(account))
            {
                ServiceAccount serviceAccount;
                if (Enum.TryParse(account, out serviceAccount))
                {
                    serviceProcessInstaller.Account = serviceAccount;
                }
            }
        }

        private string GetContextParameter(string key)
        {
            try
            {
                return Context.Parameters[key];
            }
            catch
            {
                return "";
            }
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ProjectInstaller.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ProjectInstaller.Designer.cs==START]namespace ServiceScheduler.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller
            // 
            this.serviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller.Password = null;
            this.serviceProcessInstaller.Username = null;
            // 
            // serviceInstaller
            // 
			this.serviceInstaller.Description = "Pinpoint Service Scheduler";
			this.serviceInstaller.DisplayName = "Pinpoint Service Scheduler";
            this.serviceInstaller.ServiceName = "ServiceScheduler.Service";
            this.serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller,
            this.serviceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller serviceInstaller;
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ProjectInstaller.Designer.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ProjectInstaller.resx==START]<?xml version="1.0" encoding="utf-8"?>
<root>
  <!-- 
    Microsoft ResX Schema 
    
    Version 2.0
    
    The primary goals of this format is to allow a simple XML format 
    that is mostly human readable. The generation and parsing of the 
    various data types are done through the TypeConverter classes 
    associated with the data types.
    
    Example:
    
    ... ado.net/XML headers & schema ...
    <resheader name="resmimetype">text/microsoft-resx</resheader>
    <resheader name="version">2.0</resheader>
    <resheader name="reader">System.Resources.ResXResourceReader, System.Windows.Forms, ...</resheader>
    <resheader name="writer">System.Resources.ResXResourceWriter, System.Windows.Forms, ...</resheader>
    <data name="Name1"><value>this is my long string</value><comment>this is a comment</comment></data>
    <data name="Color1" type="System.Drawing.Color, System.Drawing">Blue</data>
    <data name="Bitmap1" mimetype="application/x-microsoft.net.object.binary.base64">
        <value>[base64 mime encoded serialized .NET Framework object]</value>
    </data>
    <data name="Icon1" type="System.Drawing.Icon, System.Drawing" mimetype="application/x-microsoft.net.object.bytearray.base64">
        <value>[base64 mime encoded string representing a byte array form of the .NET Framework object]</value>
        <comment>This is a comment</comment>
    </data>
                
    There are any number of "resheader" rows that contain simple 
    name/value pairs.
    
    Each data row contains a name, and value. The row also contains a 
    type or mimetype. Type corresponds to a .NET class that support 
    text/value conversion through the TypeConverter architecture. 
    Classes that don't support this are serialized and stored with the 
    mimetype set.
    
    The mimetype is used for serialized objects, and tells the 
    ResXResourceReader how to depersist the object. This is currently not 
    extensible. For a given mimetype the value must be set accordingly:
    
    Note - application/x-microsoft.net.object.binary.base64 is the format 
    that the ResXResourceWriter will generate, however the reader can 
    read any of the formats listed below.
    
    mimetype: application/x-microsoft.net.object.binary.base64
    value   : The object must be serialized with 
            : System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            : and then encoded with base64 encoding.
    
    mimetype: application/x-microsoft.net.object.soap.base64
    value   : The object must be serialized with 
            : System.Runtime.Serialization.Formatters.Soap.SoapFormatter
            : and then encoded with base64 encoding.

    mimetype: application/x-microsoft.net.object.bytearray.base64
    value   : The object must be serialized into a byte array 
            : using a System.ComponentModel.TypeConverter
            : and then encoded with base64 encoding.
    -->
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <metadata name="serviceProcessInstaller.TrayLocation" type="System.Drawing.Point, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a">
    <value>17, 56</value>
  </metadata>
  <metadata name="serviceInstaller.TrayLocation" type="System.Drawing.Point, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a">
    <value>196, 17</value>
  </metadata>
  <metadata name="$this.TrayLargeIcon" type="System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
    <value>False</value>
  </metadata>
</root>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ProjectInstaller.resx==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ServiceIocModule.cs==START]using Ninject.Modules;

namespace ServiceScheduler.Service
{
    public class ServiceIocModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Pinpoint.Environment.IEnvironment>().To<Pinpoint.Environment.Environment>();
            Bind<ServiceSchedulerService>().ToSelf();
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ServiceIocModule.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ServiceScheduler.Service.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{C61E3CFA-B61F-4123-BE07-6CAB433B7E9C}</ProjectGuid>
    <OutputType>WinExe</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ServiceScheduler.Service</RootNamespace>
    <AssemblyName>ServiceScheduler.Service</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
    <TargetFrameworkProfile />
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <Prefer32Bit>false</Prefer32Bit>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>x64</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>TRACE;DEBUG;DebugLocal</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
    <Prefer32Bit>false</Prefer32Bit>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Castle.Core">
      <HintPath>..\packages\Castle.Core.3.2.0\lib\net45\Castle.Core.dll</HintPath>
    </Reference>
    <Reference Include="EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll</HintPath>
    </Reference>
    <Reference Include="EntityFramework.SqlServer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.SqlServer.dll</HintPath>
    </Reference>
    <Reference Include="log4net">
      <HintPath>..\packages\log4net.2.0.3\lib\net40-full\log4net.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.Owin">
      <HintPath>..\packages\Microsoft.Owin.3.0.1\lib\net45\Microsoft.Owin.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.Owin.Host.HttpListener, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Microsoft.Owin.Host.HttpListener.3.0.1\lib\net45\Microsoft.Owin.Host.HttpListener.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.Owin.Hosting, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Microsoft.Owin.Hosting.3.0.1\lib\net45\Microsoft.Owin.Hosting.dll</HintPath>
    </Reference>
    <Reference Include="Newtonsoft.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Newtonsoft.Json.6.0.4\lib\net45\Newtonsoft.Json.dll</HintPath>
    </Reference>
    <Reference Include="Ninject">
      <HintPath>..\packages\Ninject.3.2.2.0\lib\net45-full\Ninject.dll</HintPath>
    </Reference>
    <Reference Include="Ninject.Extensions.Interception, Version=3.2.0.0, Culture=neutral, PublicKeyToken=c7192dc5380945e7, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Ninject.Extensions.Interception.3.2.0.0\lib\net45-full\Ninject.Extensions.Interception.dll</HintPath>
    </Reference>
    <Reference Include="Ninject.Extensions.Interception.DynamicProxy, Version=3.2.0.0, Culture=neutral, PublicKeyToken=c7192dc5380945e7, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Ninject.Extensions.Interception.DynamicProxy.3.2.0.0\lib\net45-full\Ninject.Extensions.Interception.DynamicProxy.dll</HintPath>
    </Reference>
    <Reference Include="Owin">
      <HintPath>..\packages\Owin.1.0\lib\net40\Owin.dll</HintPath>
    </Reference>
    <Reference Include="Pinpoint.EnterpriseLogging, Version=1.0.0.0, Culture=neutral, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Pinpoint.EnterpriseLogging.1.0.0.5\lib\net40\Pinpoint.EnterpriseLogging.dll</HintPath>
    </Reference>
    <Reference Include="Pinpoint.Environment, Version=1.0.0.0, Culture=neutral, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Pinpoint.Environment.1.0.0.7\lib\net40\Pinpoint.Environment.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.ComponentModel.DataAnnotations" />
    <Reference Include="System.Configuration" />
    <Reference Include="System.Configuration.Install" />
    <Reference Include="System.Core" />
    <Reference Include="System.Management" />
    <Reference Include="System.Net.Http" />
    <Reference Include="System.Net.Http.Formatting, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Microsoft.AspNet.WebApi.Client.5.2.3\lib\net45\System.Net.Http.Formatting.dll</HintPath>
    </Reference>
    <Reference Include="System.ServiceModel" />
    <Reference Include="System.Web.Http, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Microsoft.AspNet.WebApi.Core.5.2.3\lib\net45\System.Web.Http.dll</HintPath>
    </Reference>
    <Reference Include="System.Web.Http.Owin">
      <HintPath>..\packages\Microsoft.AspNet.WebApi.Owin.5.2.3\lib\net45\System.Web.Http.Owin.dll</HintPath>
    </Reference>
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.ServiceProcess" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="EventLogHelper.cs" />
    <Compile Include="IEventLogHelper.cs" />
    <Compile Include="ServiceIocModule.cs" />
    <Compile Include="ProjectInstaller.cs">
      <SubType>Component</SubType>
    </Compile>
    <Compile Include="ProjectInstaller.Designer.cs">
      <DependentUpon>ProjectInstaller.cs</DependentUpon>
    </Compile>
    <Compile Include="ServiceSchedulerService.cs">
      <SubType>Component</SubType>
    </Compile>
    <Compile Include="ServiceSchedulerService.Designer.cs">
      <DependentUpon>ServiceSchedulerService.cs</DependentUpon>
    </Compile>
    <Compile Include="Program.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
    <None Include="packages.config" />
  </ItemGroup>
  <ItemGroup>
    <EmbeddedResource Include="ProjectInstaller.resx">
      <DependentUpon>ProjectInstaller.cs</DependentUpon>
    </EmbeddedResource>
    <EmbeddedResource Include="ServiceSchedulerService.resx">
      <DependentUpon>ServiceSchedulerService.cs</DependentUpon>
    </EmbeddedResource>
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\ServiceScheduler.WebApi\ServiceScheduler.WebApi.csproj">
      <Project>{b0a9a6ea-a9cb-4000-ad2c-8dae4b3c8bf6}</Project>
      <Name>ServiceScheduler.WebApi</Name>
    </ProjectReference>
    <ProjectReference Include="..\ServiceScheduler\ServiceScheduler.csproj">
      <Project>{f14d9875-ef4d-4979-adec-e26cd8c9ec78}</Project>
      <Name>ServiceScheduler</Name>
    </ProjectReference>
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <PropertyGroup>
    <PreBuildEvent>
    </PreBuildEvent>
  </PropertyGroup>
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ServiceScheduler.Service.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ServiceScheduler.Service.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ServiceScheduler.Service.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ServiceSchedulerService.cs==START]using System;
using System.Configuration;
using System.Runtime.Remoting.Messaging;
using System.ServiceProcess;
using Pinpoint.EnterpriseLogging;
using Pinpoint.EnterpriseLogging.Interfaces;
using Pinpoint.EnterpriseLogging.Services;
using ServiceScheduler.LogAttributes;
using ServiceScheduler.WebApi;
using Environment = Pinpoint.Environment.Environment;

namespace ServiceScheduler.Service
{
    public partial class ServiceSchedulerService : ServiceBase
    {
        private readonly IServiceRegistration _serviceRegistration;
        private readonly IServiceScheduler _serviceScheduler;
        private readonly ILogger _logger;

        public ServiceSchedulerService(IServiceScheduler serviceScheduler, IServiceRegistration serviceRegistration, ILogger logger)
        {
            _serviceScheduler = serviceScheduler;
            _serviceRegistration = serviceRegistration;
            _logger = logger;

            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            CallContext.SetData(Constants.LogContextKey, LogHelper.BuildLogContext());

            try
            {
                _logger.LogInfo("Starting service application scheduler.");

                var env = new Environment();
                string gcScheduleSection = string.Format("{0}.GarbageCollectionJob.Schedule", env.Current);
                _serviceScheduler.GarbageCollectionSchedule = ConfigurationManager.AppSettings[gcScheduleSection];

                _serviceScheduler.StartServiceAll();

                _logger.LogInfo("Started service application scheduler.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to start service application scheduler.", ex);
                return;
            }

            try
            {
                _logger.LogInfo("Starting file watcher.");

                _serviceRegistration.InitializeFileWatcher();

                _logger.LogInfo("Started file watcher.");

                _logger.LogInfo("Start looking for services in the drop folder that are pending install");

                _serviceRegistration.InstallPendingPackages();

                _logger.LogInfo("End looking for services in the drop folder that are pending install");
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to start file watcher.", ex);
                return;
            }

            try
            {
                _logger.LogInfo("Starting Web API host.");

                WebApiHost.Start();

                _logger.LogInfo("Started Web API host.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to start Web API host.", ex);
            }
        }

        protected override void OnStop()
        {
            CallContext.SetData(Constants.LogContextKey, LogHelper.BuildLogContext());

            try
            {
                _logger.LogInfo("Stopping Web API host.");

                WebApiHost.Stop();

                _logger.LogInfo("Stopped Web API host.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to stop Web API host.", ex);
            }

            try
            {
                _logger.LogDebug("Stopping service application scheduler.");

                _serviceScheduler.StopServiceScheduler();

                _logger.LogDebug("Stopped service application scheduler.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to stop service application scheduler.", ex);
            }
            finally
            {
                LoggerService.Instance.Stop();
            }
        }

        public void Start()
        {
            OnStart(null);
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ServiceSchedulerService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ServiceSchedulerService.Designer.cs==START]namespace ServiceScheduler.Service
{
    partial class ServiceSchedulerService
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ServiceScheduler.Service
            // 
			this.ServiceName = "ServiceScheduler.Service";

        }

        #endregion
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ServiceSchedulerService.Designer.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ServiceSchedulerService.resx==START]<?xml version="1.0" encoding="utf-8"?>
<root>
  <!-- 
    Microsoft ResX Schema 
    
    Version 2.0
    
    The primary goals of this format is to allow a simple XML format 
    that is mostly human readable. The generation and parsing of the 
    various data types are done through the TypeConverter classes 
    associated with the data types.
    
    Example:
    
    ... ado.net/XML headers & schema ...
    <resheader name="resmimetype">text/microsoft-resx</resheader>
    <resheader name="version">2.0</resheader>
    <resheader name="reader">System.Resources.ResXResourceReader, System.Windows.Forms, ...</resheader>
    <resheader name="writer">System.Resources.ResXResourceWriter, System.Windows.Forms, ...</resheader>
    <data name="Name1"><value>this is my long string</value><comment>this is a comment</comment></data>
    <data name="Color1" type="System.Drawing.Color, System.Drawing">Blue</data>
    <data name="Bitmap1" mimetype="application/x-microsoft.net.object.binary.base64">
        <value>[base64 mime encoded serialized .NET Framework object]</value>
    </data>
    <data name="Icon1" type="System.Drawing.Icon, System.Drawing" mimetype="application/x-microsoft.net.object.bytearray.base64">
        <value>[base64 mime encoded string representing a byte array form of the .NET Framework object]</value>
        <comment>This is a comment</comment>
    </data>
                
    There are any number of "resheader" rows that contain simple 
    name/value pairs.
    
    Each data row contains a name, and value. The row also contains a 
    type or mimetype. Type corresponds to a .NET class that support 
    text/value conversion through the TypeConverter architecture. 
    Classes that don't support this are serialized and stored with the 
    mimetype set.
    
    The mimetype is used for serialized objects, and tells the 
    ResXResourceReader how to depersist the object. This is currently not 
    extensible. For a given mimetype the value must be set accordingly:
    
    Note - application/x-microsoft.net.object.binary.base64 is the format 
    that the ResXResourceWriter will generate, however the reader can 
    read any of the formats listed below.
    
    mimetype: application/x-microsoft.net.object.binary.base64
    value   : The object must be serialized with 
            : System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            : and then encoded with base64 encoding.
    
    mimetype: application/x-microsoft.net.object.soap.base64
    value   : The object must be serialized with 
            : System.Runtime.Serialization.Formatters.Soap.SoapFormatter
            : and then encoded with base64 encoding.

    mimetype: application/x-microsoft.net.object.bytearray.base64
    value   : The object must be serialized into a byte array 
            : using a System.ComponentModel.TypeConverter
            : and then encoded with base64 encoding.
    -->
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <metadata name="$this.TrayLargeIcon" type="System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
    <value>False</value>
  </metadata>
</root>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\ServiceSchedulerService.resx==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ServiceScheduler - Trunk - 23 Feb 2015")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Pinpoint")]
[assembly: AssemblyProduct("ServiceScheduler.Service")]
[assembly: AssemblyCopyright("Copyright ? Pinpoint 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("8c5265a0-9d3d-41a4-89c8-ccc04c95e44a")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyInformationalVersion("1.1")] // service version 
[assembly: AssemblyVersion("1.1.0")] // service build version 













[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.Service\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\job_scheduling_data_2_0.xsd==START]<?xml version="1.0" encoding="UTF-8"?>

<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema"
           xmlns="http://quartznet.sourceforge.net/JobSchedulingData"
           targetNamespace="http://quartznet.sourceforge.net/JobSchedulingData"
           elementFormDefault="qualified"
           version="2.0">

  <xs:element name="job-scheduling-data">
    <xs:annotation>
      <xs:documentation>Root level node</xs:documentation>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence maxOccurs="unbounded">
        <xs:element name="pre-processing-commands" type="pre-processing-commandsType" minOccurs="0" maxOccurs="1">
          <xs:annotation>
            <xs:documentation>Commands to be executed before scheduling the jobs and triggers in this file.</xs:documentation>
          </xs:annotation>
        </xs:element>
        <xs:element name="processing-directives" type="processing-directivesType" minOccurs="0" maxOccurs="1">
          <xs:annotation>
            <xs:documentation>Directives to be followed while scheduling the jobs and triggers in this file.</xs:documentation>
          </xs:annotation>
        </xs:element>
        <xs:element name="schedule" minOccurs="0" maxOccurs="unbounded">
          <xs:complexType>
            <xs:sequence maxOccurs="unbounded">
              <xs:element name="job" type="job-detailType" minOccurs="0" maxOccurs="unbounded" />
              <xs:element name="trigger" type="triggerType" minOccurs="0" maxOccurs="unbounded" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
      <xs:attribute name="version" type="xs:string">
        <xs:annotation>
          <xs:documentation>Version of the XML Schema instance</xs:documentation>
        </xs:annotation>
      </xs:attribute>
    </xs:complexType>
  </xs:element>

  <xs:complexType name="pre-processing-commandsType">
    <xs:sequence maxOccurs="unbounded">
      <xs:element name="delete-jobs-in-group" type="xs:string" minOccurs="0" maxOccurs="unbounded">
        <xs:annotation>
          <xs:documentation>Delete all jobs, if any, in the identified group. "*" can be used to identify all groups. Will also result in deleting all triggers related to the jobs.</xs:documentation>
        </xs:annotation>
      </xs:element>
      <xs:element name="delete-triggers-in-group" type="xs:string" minOccurs="0" maxOccurs="unbounded">
        <xs:annotation>
          <xs:documentation>Delete all triggers, if any, in the identified group. "*" can be used to identify all groups. Will also result in deletion of related jobs that are non-durable.</xs:documentation>
        </xs:annotation>
      </xs:element>
      <xs:element name="delete-job" minOccurs="0" maxOccurs="unbounded">
        <xs:annotation>
          <xs:documentation>Delete the identified job if it exists (will also result in deleting all triggers related to it).</xs:documentation>
        </xs:annotation>
        <xs:complexType>
          <xs:sequence>
            <xs:element name="name" type="xs:string" />
            <xs:element name="group" type="xs:string" minOccurs="0" />
          </xs:sequence>
        </xs:complexType>
      </xs:element>
      <xs:element name="delete-trigger" minOccurs="0" maxOccurs="unbounded">
        <xs:annotation>
          <xs:documentation>Delete the identified trigger if it exists (will also result in deletion of related jobs that are non-durable).</xs:documentation>
        </xs:annotation>
        <xs:complexType>
          <xs:sequence>
            <xs:element name="name" type="xs:string" />
            <xs:element name="group" type="xs:string" minOccurs="0" />
          </xs:sequence>
        </xs:complexType>
      </xs:element>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name="processing-directivesType">
    <xs:sequence>
      <xs:element name="overwrite-existing-data" type="xs:boolean" minOccurs="0" default="true">
        <xs:annotation>
          <xs:documentation>Whether the existing scheduling data (with same identifiers) will be overwritten. If false, and ignore-duplicates is not false, and jobs or triggers with the same names already exist as those in the file, an error will occur.</xs:documentation>
        </xs:annotation>
      </xs:element>
      <xs:element name="ignore-duplicates" type="xs:boolean" minOccurs="0" default="false">
        <xs:annotation>
          <xs:documentation>If true (and overwrite-existing-data is false) then any job/triggers encountered in this file that have names that already exist in the scheduler will be ignored, and no error will be produced.</xs:documentation>
        </xs:annotation>
      </xs:element>
      <xs:element name="schedule-trigger-relative-to-replaced-trigger" type="xs:boolean" minOccurs="0" default="false">
        <xs:annotation>
          <xs:documentation>If true trigger's start time is calculated based on earlier run time instead of fixed value. Trigger's start time must be undefined for this to work.</xs:documentation>
        </xs:annotation>
      </xs:element>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name="job-detailType">
    <xs:annotation>
      <xs:documentation>Define a JobDetail</xs:documentation>
    </xs:annotation>
    <xs:sequence>
      <xs:element name="name" type="xs:string" />
      <xs:element name="group" type="xs:string" minOccurs="0" />
      <xs:element name="description" type="xs:string" minOccurs="0" />
      <xs:element name="job-type" type="xs:string" />
      <xs:sequence minOccurs="0">
        <xs:element name="durable" type="xs:boolean" />
        <xs:element name="recover" type="xs:boolean" />
      </xs:sequence>
      <xs:element name="job-data-map" type="job-data-mapType" minOccurs="0" />
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name="job-data-mapType">
    <xs:annotation>
      <xs:documentation>Define a JobDataMap</xs:documentation>
    </xs:annotation>
    <xs:sequence minOccurs="0" maxOccurs="unbounded">
      <xs:element name="entry" type="entryType" />
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name="entryType">
    <xs:annotation>
      <xs:documentation>Define a JobDataMap entry</xs:documentation>
    </xs:annotation>
    <xs:sequence>
      <xs:element name="key" type="xs:string" />
      <xs:element name="value" type="xs:string" />
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name="triggerType">
    <xs:annotation>
      <xs:documentation>Define a Trigger</xs:documentation>
    </xs:annotation>
    <xs:choice>
      <xs:element name="simple" type="simpleTriggerType" />
      <xs:element name="cron" type="cronTriggerType" />
      <xs:element name="calendar-interval" type="calendarIntervalTriggerType" />
    </xs:choice>
  </xs:complexType>

  <xs:complexType name="abstractTriggerType" abstract="true">
    <xs:annotation>
      <xs:documentation>Common Trigger definitions</xs:documentation>
    </xs:annotation>
    <xs:sequence>
      <xs:element name="name" type="xs:string" />
      <xs:element name="group" type="xs:string" minOccurs="0" />
      <xs:element name="description" type="xs:string" minOccurs="0" />
      <xs:element name="job-name" type="xs:string" />
      <xs:element name="job-group" type="xs:string" minOccurs="0" />
      <xs:element name="priority" type="xs:nonNegativeInteger" minOccurs="0" />
      <xs:element name="calendar-name" type="xs:string" minOccurs="0" />
      <xs:element name="job-data-map" type="job-data-mapType" minOccurs="0" />
      <xs:sequence minOccurs="0">
        <xs:choice>
          <xs:element name="start-time" type="xs:dateTime" />
          <xs:element name="start-time-seconds-in-future" type="xs:nonNegativeInteger" />
        </xs:choice>
        <xs:element name="end-time" type="xs:dateTime" minOccurs="0" />
      </xs:sequence>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name="simpleTriggerType">
    <xs:annotation>
      <xs:documentation>Define a SimpleTrigger</xs:documentation>
    </xs:annotation>
    <xs:complexContent>
      <xs:extension base="abstractTriggerType">
        <xs:sequence>
          <xs:element name="misfire-instruction" type="simple-trigger-misfire-instructionType" minOccurs="0" />
          <xs:sequence minOccurs="0">
            <xs:element name="repeat-count" type="repeat-countType" />
            <xs:element name="repeat-interval" type="xs:nonNegativeInteger" />
          </xs:sequence>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name="cronTriggerType">
    <xs:annotation>
      <xs:documentation>Define a CronTrigger</xs:documentation>
    </xs:annotation>
    <xs:complexContent>
      <xs:extension base="abstractTriggerType">
        <xs:sequence>
          <xs:element name="misfire-instruction" type="cron-trigger-misfire-instructionType" minOccurs="0" />
          <xs:element name="cron-expression" type="cron-expressionType" />
          <xs:element name="time-zone" type="xs:string" minOccurs="0" />
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name="calendarIntervalTriggerType">
    <xs:annotation>
      <xs:documentation>Define a DateIntervalTrigger</xs:documentation>
    </xs:annotation>
    <xs:complexContent>
      <xs:extension base="abstractTriggerType">
        <xs:sequence>
          <xs:element name="misfire-instruction" type="date-interval-trigger-misfire-instructionType" minOccurs="0" />
          <xs:element name="repeat-interval" type="xs:nonNegativeInteger" />
          <xs:element name="repeat-interval-unit" type="interval-unitType" />
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:simpleType name="cron-expressionType">
    <xs:annotation>
      <xs:documentation>
        Cron expression (see JavaDoc for examples)

        Special thanks to Chris Thatcher (thatcher@butterfly.net) for the regular expression!

        Regular expressions are not my strong point but I believe this is complete,
        with the caveat that order for expressions like 3-0 is not legal but will pass,
        and month and day names must be capitalized.
        If you want to examine the correctness look for the [\s] to denote the
        seperation of individual regular expressions. This is how I break them up visually
        to examine them:

        SECONDS:
        (
        ((([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?,)*([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?)
        | (([\*]|[0-9]|[0-5][0-9])/([0-9]|[0-5][0-9]))
        | ([\?])
        | ([\*])
        ) [\s]
        MINUTES:
        (
        ((([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?,)*([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?)
        | (([\*]|[0-9]|[0-5][0-9])/([0-9]|[0-5][0-9]))
        | ([\?])
        | ([\*])
        ) [\s]
        HOURS:
        (
        ((([0-9]|[0-1][0-9]|[2][0-3])(-([0-9]|[0-1][0-9]|[2][0-3]))?,)*([0-9]|[0-1][0-9]|[2][0-3])(-([0-9]|[0-1][0-9]|[2][0-3]))?)
        | (([\*]|[0-9]|[0-1][0-9]|[2][0-3])/([0-9]|[0-1][0-9]|[2][0-3]))
        | ([\?])
        | ([\*])
        ) [\s]
        DAY OF MONTH:
        (
        ((([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])(-([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1]))?,)*([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])(-([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1]))?(C)?)
        | (([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])/([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])(C)?)
        | (L(-[0-9])?)
        | (L(-[1-2][0-9])?)
        | (L(-[3][0-1])?)
        | (LW)
        | ([1-9]W)
        | ([1-3][0-9]W)
        | ([\?])
        | ([\*])
        )[\s]
        MONTH:
        (
        ((([1-9]|0[1-9]|1[0-2])(-([1-9]|0[1-9]|1[0-2]))?,)*([1-9]|0[1-9]|1[0-2])(-([1-9]|0[1-9]|1[0-2]))?)
        | (([1-9]|0[1-9]|1[0-2])/([1-9]|0[1-9]|1[0-2]))
        | (((JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)(-(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))?,)*(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)(-(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))?)
        | ((JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)/(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))
        | ([\?])
        | ([\*])
        )[\s]
        DAY OF WEEK:
        (
        (([1-7](-([1-7]))?,)*([1-7])(-([1-7]))?)
        | ([1-7]/([1-7]))
        | (((MON|TUE|WED|THU|FRI|SAT|SUN)(-(MON|TUE|WED|THU|FRI|SAT|SUN))?,)*(MON|TUE|WED|THU|FRI|SAT|SUN)(-(MON|TUE|WED|THU|FRI|SAT|SUN))?(C)?)
        | ((MON|TUE|WED|THU|FRI|SAT|SUN)/(MON|TUE|WED|THU|FRI|SAT|SUN)(C)?)
        | (([1-7]|(MON|TUE|WED|THU|FRI|SAT|SUN))(L|LW)?)
        | (([1-7]|MON|TUE|WED|THU|FRI|SAT|SUN)#([1-7])?)
        | ([\?])
        | ([\*])
        )
        YEAR (OPTIONAL):
        (
        [\s]?
        ([\*])?
        | ((19[7-9][0-9])|(20[0-9][0-9]))?
        | (((19[7-9][0-9])|(20[0-9][0-9]))/((19[7-9][0-9])|(20[0-9][0-9])))?
        | ((((19[7-9][0-9])|(20[0-9][0-9]))(-((19[7-9][0-9])|(20[0-9][0-9])))?,)*((19[7-9][0-9])|(20[0-9][0-9]))(-((19[7-9][0-9])|(20[0-9][0-9])))?)?
        )
      </xs:documentation>
    </xs:annotation>
    <xs:restriction base="xs:string">
      <xs:pattern
        value="(((([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?,)*([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?)|(([\*]|[0-9]|[0-5][0-9])/([0-9]|[0-5][0-9]))|([\?])|([\*]))[\s](((([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?,)*([0-9]|[0-5][0-9])(-([0-9]|[0-5][0-9]))?)|(([\*]|[0-9]|[0-5][0-9])/([0-9]|[0-5][0-9]))|([\?])|([\*]))[\s](((([0-9]|[0-1][0-9]|[2][0-3])(-([0-9]|[0-1][0-9]|[2][0-3]))?,)*([0-9]|[0-1][0-9]|[2][0-3])(-([0-9]|[0-1][0-9]|[2][0-3]))?)|(([\*]|[0-9]|[0-1][0-9]|[2][0-3])/([0-9]|[0-1][0-9]|[2][0-3]))|([\?])|([\*]))[\s](((([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])(-([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1]))?,)*([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])(-([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1]))?(C)?)|(([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])/([1-9]|[0][1-9]|[1-2][0-9]|[3][0-1])(C)?)|(L(-[0-9])?)|(L(-[1-2][0-9])?)|(L(-[3][0-1])?)|(LW)|([1-9]W)|([1-3][0-9]W)|([\?])|([\*]))[\s](((([1-9]|0[1-9]|1[0-2])(-([1-9]|0[1-9]|1[0-2]))?,)*([1-9]|0[1-9]|1[0-2])(-([1-9]|0[1-9]|1[0-2]))?)|(([1-9]|0[1-9]|1[0-2])/([1-9]|0[1-9]|1[0-2]))|(((JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)(-(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))?,)*(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)(-(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))?)|((JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)/(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))|([\?])|([\*]))[\s]((([1-7](-([1-7]))?,)*([1-7])(-([1-7]))?)|([1-7]/([1-7]))|(((MON|TUE|WED|THU|FRI|SAT|SUN)(-(MON|TUE|WED|THU|FRI|SAT|SUN))?,)*(MON|TUE|WED|THU|FRI|SAT|SUN)(-(MON|TUE|WED|THU|FRI|SAT|SUN))?(C)?)|((MON|TUE|WED|THU|FRI|SAT|SUN)/(MON|TUE|WED|THU|FRI|SAT|SUN)(C)?)|(([1-7]|(MON|TUE|WED|THU|FRI|SAT|SUN))?(L|LW)?)|(([1-7]|MON|TUE|WED|THU|FRI|SAT|SUN)#([1-7])?)|([\?])|([\*]))([\s]?(([\*])?|(19[7-9][0-9])|(20[0-9][0-9]))?| (((19[7-9][0-9])|(20[0-9][0-9]))/((19[7-9][0-9])|(20[0-9][0-9])))?| ((((19[7-9][0-9])|(20[0-9][0-9]))(-((19[7-9][0-9])|(20[0-9][0-9])))?,)*((19[7-9][0-9])|(20[0-9][0-9]))(-((19[7-9][0-9])|(20[0-9][0-9])))?)?)" />
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name="repeat-countType">
    <xs:annotation>
      <xs:documentation>Number of times to repeat the Trigger (-1 for indefinite)</xs:documentation>
    </xs:annotation>
    <xs:restriction base="xs:integer">
      <xs:minInclusive value="-1" />
    </xs:restriction>
  </xs:simpleType>


  <xs:simpleType name="simple-trigger-misfire-instructionType">
    <xs:annotation>
      <xs:documentation>Simple Trigger Misfire Instructions</xs:documentation>
    </xs:annotation>
    <xs:restriction base="xs:string">
      <xs:pattern value="SmartPolicy" />
      <xs:pattern value="RescheduleNextWithExistingCount" />
      <xs:pattern value="RescheduleNextWithRemainingCount" />
      <xs:pattern value="RescheduleNowWithExistingRepeatCount" />
      <xs:pattern value="RescheduleNowWithRemainingRepeatCount" />
      <xs:pattern value="FireNow" />
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name="cron-trigger-misfire-instructionType">
    <xs:annotation>
      <xs:documentation>Cron Trigger Misfire Instructions</xs:documentation>
    </xs:annotation>
    <xs:restriction base="xs:string">
      <xs:pattern value="SmartPolicy" />
      <xs:pattern value="DoNothing" />
      <xs:pattern value="FireOnceNow" />
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name="date-interval-trigger-misfire-instructionType">
    <xs:annotation>
      <xs:documentation>Date Interval Trigger Misfire Instructions</xs:documentation>
    </xs:annotation>
    <xs:restriction base="xs:string">
      <xs:pattern value="SmartPolicy" />
      <xs:pattern value="DoNothing" />
      <xs:pattern value="FireOnceNow" />
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name="interval-unitType">
    <xs:annotation>
      <xs:documentation>Interval Units</xs:documentation>
    </xs:annotation>
    <xs:restriction base="xs:string">
      <xs:pattern value="Day" />
      <xs:pattern value="Hour" />
      <xs:pattern value="Minute" />
      <xs:pattern value="Month" />
      <xs:pattern value="Second" />
      <xs:pattern value="Week" />
      <xs:pattern value="Year" />
    </xs:restriction>
  </xs:simpleType>

</xs:schema>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\job_scheduling_data_2_0.xsd==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\packages.config==START]<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Common.Logging" version="3.0.0" targetFramework="net452" />
  <package id="Common.Logging.Core" version="3.0.0" targetFramework="net452" />
  <package id="Moq" version="4.2.1402.2112" targetFramework="net45" />
  <package id="NUnit" version="2.6.4" targetFramework="net452" />
  <package id="Pinpoint.EnterpriseLogging" version="1.0.0.5" targetFramework="net452" />
  <package id="Quartz" version="2.3.3" targetFramework="net452" />
</packages>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\packages.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\ServiceRegistrationTests.cs==START]using System;
using Moq;
using NUnit.Framework;
using ServiceScheduler.Data.Model;
using ServiceScheduler.Data.Repository;
using ServiceScheduler.DiskOperations;
using ServiceScheduler.Domain;
using ServiceScheduler.FileServices;
using ServiceScheduler.FileWatcher;
using ServiceScheduler.ServiceInformationCollector;

namespace ServiceScheduler.UnitTests
{
    [TestFixture]
    public class ServiceRegistrationTests
    {
        [SetUp]
        public void SetUp()
        {
            _serviceRepository = new Mock<IServiceRepository>();
            _serviceWatcher = new Mock<IServiceWatcher>();
            _serviceInformationCollector = new Mock<IServiceInformationCollector>();
            _diskArchiverService = new Mock<IDiskArchiverService>();
            _diskInstallerService = new Mock<IDiskInstallerService>();
            _dbServiceRegistration = new Mock<IDbServiceRegistration>();
            _fileService = new Mock<IFileService>();
            _pathsProvider = new Mock<IPathsProvider>();
            _serviceScheduler = new Mock<IServiceScheduler>();
            _serviceRegistration = new ServiceRegistration(_serviceWatcher.Object,
                _serviceInformationCollector.Object,
                _fileService.Object, _pathsProvider.Object, _diskInstallerService.Object,
                _diskArchiverService.Object, _dbServiceRegistration.Object, _serviceScheduler.Object);
            _testService = new Service
            {
                AllowConcurrency = false,
                DateInstalled = DateTime.Now,
                Enabled = true,
                ServiceEntry = "TestService.exe",
                ServiceId = 1,
                ServiceName = "Test Service",
                ServicePath = @"C:\Temp\TestService.exe",
                ServiceVersion = "1.0.0.0"
            };
            _testServiceInformation = new ServiceInformation
            {
                AllowConcurrency = _testService.AllowConcurrency,
                Enabled = _testService.Enabled,
                ServiceEntry = _testService.ServiceEntry,
                ServiceName = _testService.ServiceName,
                ServicePath = _testService.ServicePath,
                ServiceVersion = _testService.ServiceVersion
            };
        }

        private Mock<IServiceRepository> _serviceRepository;
        private Mock<IDbServiceRegistration> _dbServiceRegistration;
        private Mock<IServiceWatcher> _serviceWatcher;
        private Mock<IServiceScheduler> _serviceScheduler;
        private Mock<IFileService> _fileService;
        private Mock<IServiceInformationCollector> _serviceInformationCollector;
        private Mock<IPathsProvider> _pathsProvider;
        private ServiceRegistration _serviceRegistration;
        private Mock<IDiskArchiverService> _diskArchiverService;
        private Mock<IDiskInstallerService> _diskInstallerService;
        private Service _testService;
        private ServiceInformation _testServiceInformation;

        [Test]
        public void Register_ExistingService_ExpectUpdate()
        {
            _serviceRepository.Setup(o => o.Retrieve(_testServiceInformation.ServiceName))
                .Returns(_testService);

            bool isUpdateCalled = false;
            _serviceRepository.Setup(o => o.Update(It.IsAny<Service>()))
                .Callback(() => isUpdateCalled = true);

            _serviceRegistration.InitializeFileWatcher();
            _serviceRegistration.InstallPendingPackages();

            //Assert.IsTrue(isUpdateCalled); WE no longer call update there as it is useless. the entity is already marked as Modified.
        }

        [Test]
        public void Register_NewService_ExpectInsert()
        {
            _serviceRepository.Setup(o => o.Retrieve(_testServiceInformation.ServiceName))
                .Returns((Service) null);

            bool isInsertCalled = false;
            _serviceRepository.Setup(o => o.Insert(It.IsAny<Service>()))
                .Callback(() => isInsertCalled = true);

            _serviceRegistration.InitializeFileWatcher();
            _serviceRegistration.InstallPendingPackages();

            //Assert.IsTrue(isInsertCalled);
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\ServiceRegistrationTests.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\ServiceScheduler.UnitTests.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{01541D27-FE42-40C2-BD67-48CC2D5D1287}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ServiceScheduler.UnitTests</RootNamespace>
    <AssemblyName>ServiceScheduler.UnitTests</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
    <TargetFrameworkProfile />
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Common.Logging, Version=3.0.0.0, Culture=neutral, PublicKeyToken=af08829b84f0328e, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Common.Logging.3.0.0\lib\net40\Common.Logging.dll</HintPath>
    </Reference>
    <Reference Include="Common.Logging.Core">
      <HintPath>..\packages\Common.Logging.Core.3.0.0\lib\net40\Common.Logging.Core.dll</HintPath>
    </Reference>
    <Reference Include="Moq">
      <HintPath>..\packages\Moq.4.2.1402.2112\lib\net40\Moq.dll</HintPath>
    </Reference>
    <Reference Include="nunit.framework, Version=2.6.4.14350, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\NUnit.2.6.4\lib\nunit.framework.dll</HintPath>
    </Reference>
    <Reference Include="Pinpoint.EnterpriseLogging, Version=1.0.0.0, Culture=neutral, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Pinpoint.EnterpriseLogging.1.0.0.5\lib\net40\Pinpoint.EnterpriseLogging.dll</HintPath>
    </Reference>
    <Reference Include="Quartz, Version=2.3.3.0, Culture=neutral, PublicKeyToken=f6b8c98a402cc8a4, processorArchitecture=MSIL">
      <HintPath>..\packages\Quartz.2.3.3\lib\net40\Quartz.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="ServiceJobs\ServiceApplicationJobTests.cs" />
    <Compile Include="ServiceJobs\ServiceRunServiceTests.cs" />
    <Compile Include="ServiceJobs\GarbageCollectionJobTests.cs" />
    <Compile Include="ServiceRegistrationTests.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="job_scheduling_data_2_0.xsd">
      <SubType>Designer</SubType>
    </None>
    <None Include="packages.config" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\ServiceScheduler.Data\ServiceScheduler.Data.csproj">
      <Project>{ae48f4c5-1882-4ed7-b723-b70d394ea651}</Project>
      <Name>ServiceScheduler.Data</Name>
    </ProjectReference>
    <ProjectReference Include="..\ServiceScheduler\ServiceScheduler.csproj">
      <Project>{f14d9875-ef4d-4979-adec-e26cd8c9ec78}</Project>
      <Name>ServiceScheduler</Name>
    </ProjectReference>
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\ServiceScheduler.UnitTests.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\ServiceScheduler.UnitTests.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\ServiceScheduler.UnitTests.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ServiceScheduler.UnitTests")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("ServiceScheduler.UnitTests")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("097cb41e-2512-4cbe-aefe-322b907e107d")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\ServiceJobs\GarbageCollectionJobTests.cs==START]using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using NUnit.Framework;
using Pinpoint.EnterpriseLogging.Interfaces;
using Quartz;
using ServiceScheduler.Data.Model;
using ServiceScheduler.Data.Repository;
using ServiceScheduler.ServiceJobs;

namespace ServiceScheduler.UnitTests.ServiceJobs
{
    [TestFixture]
    public class GarbageCollectionJobTests
    {
        private string _serviceFolder;
        private List<Service> _serviceData = new List<Service>();
        private Mock<IJobExecutionContext> _jobExecutionContext;
        private Mock<IServiceRepository> _serviceRepository;
        private Mock<IServiceRepositoryFactory> _serviceRepositoryFactory;
        private Mock<ILogger> _logger;

        [SetUp]
        public void SetUp()
        {
            _serviceFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            _jobExecutionContext = new Mock<IJobExecutionContext>();
            _serviceRepository = new Mock<IServiceRepository>();
            _serviceRepositoryFactory = new Mock<IServiceRepositoryFactory>();

            _serviceData = new List<Service>();
            for (int i = 3; i > 0; i--)
            {
                var serviceName = string.Format("TestService{0}", i);
                const string serviceVersion = "1.0.0.3";

                _serviceData.Add(
                    new Service
                    {
                        ServiceId = i,
                        ServiceName = serviceName,
                        ServicePath = Path.Combine(_serviceFolder, serviceName, serviceVersion),
                        ServiceVersion = serviceVersion,
                        Enabled = (i > 1),
                        ServiceRun = new[]
                        {
                            new ServiceRun
                            {
                                ServiceId = i,
                                ServiceVersion = string.Format("1.0.0.{0}", i),
                                ServiceRunStatusId = ServiceRunStatus.Idle
                            }
                        }
                    });

                for (int j = 1; j <= 3; j++)
                {
                    SetUpServiceFolder(serviceName, string.Format(@"1.0.0.{0}", j));
                }
            }
            _logger=  new Mock<ILogger>();
            _serviceRepository.Setup(o => o.Retrieve()).Returns(_serviceData);
            _serviceRepositoryFactory.Setup(o => o.GetServiceRepository()).Returns(_serviceRepository.Object);
        }

        private void SetUpServiceFolder(string serviceName, string versionName)
        {
            if (!Directory.Exists(_serviceFolder))
                Directory.CreateDirectory(_serviceFolder);

            var serviceVersionFolder = Path.Combine(_serviceFolder, serviceName, versionName);
            if (!Directory.Exists(serviceVersionFolder))
                Directory.CreateDirectory(serviceVersionFolder);
        }

        private void TearDownServiceFolder()
        {
            if (Directory.Exists(_serviceFolder))
                Directory.Delete(_serviceFolder, true);
        }

        [TearDown]
        public void TearDown()
        {
            TearDownServiceFolder();
        }

        [Test, Explicit]
        public void Execute_HappyPath_ExpectedDirectoriesDeleted()
        {
            var garbageCollectionJob = new GarbageCollectionJob(_serviceRepositoryFactory.Object, _logger.Object);
            garbageCollectionJob.Execute(_jobExecutionContext.Object);

            Assert.True(Directory.Exists(Path.Combine(_serviceFolder, "TestService1", "1.0.0.1")));
            Assert.False(Directory.Exists(Path.Combine(_serviceFolder, "TestService1", "1.0.0.2")));
            Assert.True(Directory.Exists(Path.Combine(_serviceFolder, "TestService1", "1.0.0.3")));

            Assert.False(Directory.Exists(Path.Combine(_serviceFolder, "TestService2", "1.0.0.1")));
            Assert.True(Directory.Exists(Path.Combine(_serviceFolder, "TestService2", "1.0.0.2")));
            Assert.True(Directory.Exists(Path.Combine(_serviceFolder, "TestService2", "1.0.0.3")));

            Assert.False(Directory.Exists(Path.Combine(_serviceFolder, "TestService3", "1.0.0.1")));
            Assert.False(Directory.Exists(Path.Combine(_serviceFolder, "TestService3", "1.0.0.2")));
            Assert.True(Directory.Exists(Path.Combine(_serviceFolder, "TestService3", "1.0.0.3")));
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\ServiceJobs\GarbageCollectionJobTests.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\ServiceJobs\ServiceApplicationJobTests.cs==START]using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Pinpoint.EnterpriseLogging.Interfaces;
using Quartz;
using ServiceScheduler.Data.Model;
using ServiceScheduler.Data.Repository;
using ServiceScheduler.ServiceJobs;

namespace ServiceScheduler.UnitTests.ServiceJobs
{
    [TestFixture]
    public class ServiceApplicationJobTests
    {
        private const string SERVICE_NAME = "TestService1";
        private const string SERVICE_VERSION = "1.0.0.0";
        private const string SERVICE_PATH = "c:\\temp\\1.0.0.0";
        private const string SERVICE_ENTRY = "TestService1.exe";
        private const string SCHEDULE_EXPRESSION = "0 0/1 * ? * MON,WED,FRI *";
        private const int SERVICE_ID = 1;
        private const int SERVICE_RUN_ID = 1;
        private const int SERVICE_SCHEDULE_ID = 1;
        private const int PROCESS_ID = 1;
        private DateTime DATE_RUN = DateTime.Now;
        private DateTime DATE_COMPLETED = DateTime.Now;
        private Service _serviceData;
        private Mock<IJobExecutionContext> _jobExecutionContext;
        private Mock<IServiceRepository> _serviceRepository;
        private Mock<IServiceRepositoryFactory> _serviceRepositoryFactory;
        private Mock<IServiceProcess> _serviceProcess;
        private Mock<ILogger> _logger;
        private Mock<IServiceScheduler> _serviceScheduler;

        [SetUp]
        public void SetUp()
        {
            _jobExecutionContext = new Mock<IJobExecutionContext>();
            _serviceRepository = new Mock<IServiceRepository>();
            _serviceRepositoryFactory = new Mock<IServiceRepositoryFactory>();
            _serviceProcess = new Mock<IServiceProcess>();

            _jobExecutionContext.Setup(o => o.JobDetail.JobDataMap["ServiceName"]).Returns(SERVICE_NAME);
            _jobExecutionContext.Setup(o => o.JobDetail.JobDataMap["ServicePath"]).Returns(SERVICE_PATH);
            _jobExecutionContext.Setup(o => o.JobDetail.JobDataMap["ServiceEntry"]).Returns(SERVICE_ENTRY);
            _jobExecutionContext.Setup(o => o.JobDetail.JobDataMap["ServiceVersion"]).Returns(SERVICE_VERSION);
            _jobExecutionContext.Setup(o => o.JobDetail.JobDataMap["AllowConcurrency"]).Returns(false);

            _serviceData = new Service
            {
                ServiceId = SERVICE_ID,
                ServiceName = SERVICE_NAME,
                ServicePath = "",
                ServiceVersion = SERVICE_VERSION,
                Enabled = true,
                ServiceRun = new List<ServiceRun>(),
                ServiceSchedule = new[]
                {
                    new ServiceSchedule
                    {
                        ServiceId = SERVICE_ID,
                        ServiceScheduleId = SERVICE_SCHEDULE_ID,
                        Enabled = true,
                        ModifiedBy = "",
                        Parameters = "",
                        Schedule = SCHEDULE_EXPRESSION,
                        ScheduleName = ""
                    }
                }
            };

            _serviceRepository.Setup(o => o.Retrieve(SERVICE_NAME)).Returns(_serviceData);
            _serviceRepositoryFactory.Setup(o => o.GetServiceRepository()).Returns(_serviceRepository.Object);
            _logger = new Mock<ILogger>();
            _serviceScheduler = new Mock<IServiceScheduler>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Execute_HappyPath_Expected()
        {
            var serviceApplicationJob = new ServiceApplicationJob(_serviceRepositoryFactory.Object, _serviceProcess.Object, _logger.Object, _serviceScheduler.Object);
            serviceApplicationJob.Execute(_jobExecutionContext.Object);
        }

        [Test]
        public void Execute_ServicePathEmpty_ExceptionThrown()
        {
            _jobExecutionContext.Setup(o => o.JobDetail.JobDataMap["ServicePath"]).Returns("");
            _jobExecutionContext.Setup(o => o.JobDetail.JobDataMap["ServiceEntry"]).Returns("");

            var serviceApplicationJob = new ServiceApplicationJob(_serviceRepositoryFactory.Object, _serviceProcess.Object, _logger.Object, _serviceScheduler.Object);
            serviceApplicationJob.Execute(_jobExecutionContext.Object);
        }

        [Test]
        public void Execute_ServicePathNotExists_ExceptionThrown()
        {
            _jobExecutionContext.Setup(o => o.JobDetail.JobDataMap["ServicePath"]).Returns(string.Format("c:\\{0}", Guid.NewGuid()));
            _jobExecutionContext.Setup(o => o.JobDetail.JobDataMap["ServiceEntry"]).Returns("test.txt");

            var serviceApplicationJob = new ServiceApplicationJob(_serviceRepositoryFactory.Object, _serviceProcess.Object, _logger.Object, _serviceScheduler.Object);
            serviceApplicationJob.Execute(_jobExecutionContext.Object);
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\ServiceJobs\ServiceApplicationJobTests.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\ServiceJobs\ServiceRunServiceTests.cs==START]using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Pinpoint.EnterpriseLogging.Interfaces;
using ServiceScheduler.Data.Model;
using ServiceScheduler.Data.Repository;
using ServiceScheduler.Domain;
using ServiceScheduler.ServiceJobs;

namespace ServiceScheduler.UnitTests.ServiceJobs
{
    [TestFixture]
    public class ServiceRunServiceTests
    {
        private const string SERVICE_NAME = "TestService1";
        private const string SERVICE_VERSION = "1.0.0.0";
        private const string SCHEDULE_EXPRESSION = "0 0/1 * ? * MON,WED,FRI *";
        private const string SCHEDULE_PARAMETERS = "/a /b:\"Hello World!\"";
        private const int SERVICE_ID = 1;
        private const int SERVICE_RUN_ID = 1;
        private const int SERVICE_SCHEDULE_ID = 1;
        private const int PROCESS_ID = 1;
        private DateTime DATE_RUN = DateTime.Now;
        private DateTime DATE_COMPLETED = DateTime.Now;
        private Service _serviceData;
        private Mock<IServiceRepository> _serviceRepository;
        private Mock<ILogger> _logger;
        private Mock<IServiceProcess> _serviceProcess;
        private Mock<IServiceScheduler> _serviceScheduler;
        private ServiceRunService _sut;

        [SetUp]
        public void SetUp()
        {
            _serviceRepository = new Mock<IServiceRepository>();

            _serviceData = new Service
            {
                ServiceId = SERVICE_ID,
                ServiceName = SERVICE_NAME,
                ServicePath = "",
                ServiceVersion = SERVICE_VERSION,
                Enabled = true,
                ServiceRun = new List<ServiceRun>(),
                ServiceSchedule = new[]
                {
                    new ServiceSchedule
                    {
                        ServiceId = SERVICE_ID,
                        ServiceScheduleId = SERVICE_SCHEDULE_ID,
                        Enabled = true,
                        ModifiedBy = "",
                        Parameters = "",
                        Schedule = SCHEDULE_EXPRESSION,
                        ScheduleName = ""
                    }
                }
            };
            _logger = new Mock<ILogger>();
            _serviceProcess = new Mock<IServiceProcess>();
            _serviceRepository.Setup(o => o.Retrieve(SERVICE_NAME)).Returns(_serviceData);
            _serviceScheduler = new Mock<IServiceScheduler>();
            _sut = new ServiceRunService(_serviceRepository.Object, _serviceProcess.Object, _logger.Object, _serviceScheduler.Object);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void StartServiceRun_HappyPath_ServiceRunCommited()
        {
            bool isCommitCalled = false;
            _serviceRepository.Setup(o => o.Commit()).Callback(() => isCommitCalled = true);

            _sut.StartServiceRun(SERVICE_NAME, SERVICE_VERSION, SCHEDULE_EXPRESSION, SCHEDULE_PARAMETERS, SERVICE_SCHEDULE_ID);

            Assert.IsTrue(isCommitCalled);
            Assert.IsTrue(_serviceData.ServiceRun.Count == 1);

            var serviceRun = _serviceData.ServiceRun.First();
            Assert.IsNotNull(serviceRun);
            Assert.AreEqual(SERVICE_SCHEDULE_ID, serviceRun.ServiceScheduleId);
            Assert.AreEqual(SERVICE_VERSION, serviceRun.ServiceVersion);
            Assert.AreEqual(SCHEDULE_PARAMETERS, serviceRun.Parameters);
            Assert.AreEqual(ServiceRunStatus.Starting, serviceRun.ServiceRunStatusId);
        }

        [Test, ExpectedException]
        public void StartServiceRun_ServiceScheduleNotFound_ExceptionThrown()
        {
            _serviceData.ServiceSchedule = new List<ServiceSchedule>();
            _sut.StartServiceRun(SERVICE_NAME, SERVICE_VERSION, SCHEDULE_EXPRESSION, SCHEDULE_PARAMETERS, SERVICE_SCHEDULE_ID);
        }

        [Test]
        public void UpdateServiceRun_HappyPath_ServiceRunCommited()
        {
            bool isCommitCalled = false;
            _serviceRepository.Setup(o => o.Commit()).Callback(() => isCommitCalled = true);

            var serviceRun = new ServiceRun
            {
                ServiceRunId = SERVICE_RUN_ID,
                ServiceId = SERVICE_ID
            };

            _serviceData.ServiceRun.Add(serviceRun);

            _sut.UpdateServiceRun(SERVICE_NAME, SERVICE_RUN_ID, PROCESS_ID, ServiceRunStatus.Started, DATE_RUN);

            Assert.AreEqual(PROCESS_ID, serviceRun.ProcessId);
            Assert.AreEqual(DATE_RUN, serviceRun.DateRun);
            Assert.IsTrue(isCommitCalled);
        }

        [Test, ExpectedException]
        public void UpdateServiceRun_ServiceRunNotFound_ExceptionThrown()
        {
            _sut.UpdateServiceRun(SERVICE_NAME, SERVICE_RUN_ID, PROCESS_ID, ServiceRunStatus.Started, DATE_RUN);
        }

        [Test]
        public void StopServiceRun_HappyPath_ServiceRunCommited()
        {
            bool isCommitCalled = false;
            _serviceRepository.Setup(o => o.Commit()).Callback(() => isCommitCalled = true);

            var serviceRun = new ServiceRun
            {
                ServiceRunId = SERVICE_RUN_ID,
                ServiceId = SERVICE_ID
            };

            _serviceData.ServiceRun.Add(serviceRun);
            _sut.UpdateServiceRun(SERVICE_NAME, SERVICE_RUN_ID, PROCESS_ID, ServiceRunStatus.Completed, DATE_COMPLETED);

            Assert.AreEqual(DATE_COMPLETED, serviceRun.DateCompleted);
            Assert.AreEqual(ServiceRunStatus.Completed, serviceRun.ServiceRunStatusId);
            Assert.IsTrue(isCommitCalled);
        }

        [Test, ExpectedException]
        public void StopServiceRun_ServiceRunNotFound_ExceptionThrown()
        {
            _sut.UpdateServiceRun(SERVICE_NAME, SERVICE_RUN_ID, PROCESS_ID, ServiceRunStatus.Completed, DATE_COMPLETED);
        }

        [Test]
        public void GetServiceSchedulesFor_ServiceNotFound_ShouldReturnNotFound()
        {
            _serviceRepository.Setup(p => p.Retrieve()).Returns(new List<Service>());//when empty
            var x = _sut.GetServiceSchedules(It.IsAny<int>());
            Assert.AreEqual(StatusType.NotFound, x.Status);
        }

        [Test]
        public void GetSertviceSchedulesFor_ServiceFound_ShouldReturnAll()
        {
            _serviceRepository.Setup(p => p.Retrieve()).Returns(new List<Service>
            {
                new Service
                {
                    ServiceId = 1,
                    ServiceName = "To be returned",
                    ServiceSchedule = new List<ServiceSchedule>
                    {
                        new ServiceSchedule{Enabled =  false, ServiceId = 1, ScheduleName = "BlueMoon", ServiceScheduleId = 1},
                        new ServiceSchedule{Enabled = true, ServiceId = 2, ScheduleName = "Every 6th Sunday of the month", ServiceScheduleId = 2}
                    }
                },
                new Service
                {
                    ServiceId = 2,
                    ServiceName = "Not to be returned",
                }
            });

            var result = _sut.GetServiceSchedules(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Content.Count);
            Assert.AreEqual(1, result.Content.First().ServiceId);
        }

        [Test]
        public void SetServiceSchedule_ShouldReturnBadRequest_ForNullInput()
        {
            var x = _sut.SetServiceSchedule(null);
            Assert.IsNotNull(x);
            Assert.AreEqual(StatusType.BadRequest, x.Status);
        }

        [Test]
        public void SetServiceSchedule_ShouldReturnNotFound_ForInvalidServiceInput()
        {
            _serviceRepository.Setup(p => p.Retrieve()).Returns(new List<Service>());//emptty
            var x = _sut.SetServiceSchedule(new ServiceScheduleDto {ServiceId = 100});
            Assert.IsNotNull(x);
            Assert.AreEqual(StatusType.NotFound, x.Status);
        }

        [Test]
        public void SetServiceSchedule_ShouldReturnNotFound_ForUpdatingInexisistentSchedule()
        {
            _serviceRepository.Setup(p => p.Retrieve()).Returns(new List<Service>
            {
                new Service{ServiceId = 1, ServiceSchedule = new List<ServiceSchedule>
                {
                    new ServiceSchedule{ ServiceId = 1, ServiceScheduleId = 10000000}
                }}
            });
            var x = _sut.SetServiceSchedule(new ServiceScheduleDto { ServiceId = 1, ServiceScheduleId = 1});
            Assert.IsNotNull(x);
            Assert.AreEqual(StatusType.NotFound, x.Status);
        }

        [Test]
        public void SetServiceSchedule_ShouldInsertNewServiceSchedule_WhenServiceScheduleIdIs0()
        {
            var service = new Service
            {
                ServiceId = 1,
                ServiceSchedule = new List<ServiceSchedule>
                {
                    new ServiceSchedule {ServiceId = 1, ServiceScheduleId = 25}
                }
            };
            _serviceRepository.Setup(p => p.Retrieve()).Returns(new List<Service>
            {
                service
            });

            var x = _sut.SetServiceSchedule(new ServiceScheduleDto { ServiceId = 1, ServiceScheduleId = 0 });
            _serviceScheduler.Verify(p => p.RegisterService(It.IsAny<Service>()), Times.Once);
            _serviceRepository.Verify(p => p.Commit(), Times.Once);

            Assert.AreEqual(2, service.ServiceSchedule.Count);
            Assert.IsNotNull(x);
            Assert.AreEqual(StatusType.Ok, x.Status);
        }


        [Test]
        public void SetServiceSchedule_ShouldUpdateExistingServiceSchedule_WhenServiceScheduleIdIsPresent()
        {
            var service = new Service
            {
                ServiceId = 1,
                ServiceSchedule = new List<ServiceSchedule>
                {
                    new ServiceSchedule {ServiceId = 1, ServiceScheduleId = 25}
                }
            };
            _serviceRepository.Setup(p => p.Retrieve()).Returns(new List<Service>
            {
                service
            });

            var x = _sut.SetServiceSchedule(new ServiceScheduleDto { ServiceId = 1, ServiceScheduleId = 25, ModifiedBy = "TEST"});
            _serviceScheduler.Verify(p => p.RegisterService(It.IsAny<Service>()), Times.Once);
            _serviceRepository.Verify(p => p.Commit(), Times.Once);

            Assert.AreEqual(1, service.ServiceSchedule.Count);
            Assert.AreEqual("TEST", service.ServiceSchedule.First().ModifiedBy);
            Assert.IsNotNull(x);
            Assert.AreEqual(StatusType.Ok, x.Status);
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.UnitTests\ServiceJobs\ServiceRunServiceTests.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\app.config==START]<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="Microsoft.Owin" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-3.0.1.0" newVersion="3.0.1.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Http" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Net.Http.Formatting" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Http.Owin" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
<startup><supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" /></startup></configuration>
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\app.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\NinjectResolver.cs==START]using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;

namespace ServiceScheduler.WebApi
{
    /// <summary>
    ///     Updated from https://gist.github.com/2417226/040dd842d3dadb810065f1edad7f2594eaebe806
    /// </summary>
    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot _resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            Contract.Assert(resolver != null);

            _resolver = resolver;
        }

        public void Dispose()
        {
            _resolver = null;
        }

        public object GetService(Type serviceType)
        {
            if (_resolver == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed");

            return _resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (_resolver == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed");

            return _resolver.GetAll(serviceType);
        }
    }

    public class NinjectResolver : NinjectDependencyScope, IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(_kernel);
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\NinjectResolver.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\packages.config==START]<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Microsoft.AspNet.WebApi" version="5.0.0" targetFramework="net45" />
  <package id="Microsoft.AspNet.WebApi.Client" version="5.2.3" targetFramework="net45" />
  <package id="Microsoft.AspNet.WebApi.Core" version="5.2.3" targetFramework="net45" />
  <package id="Microsoft.AspNet.WebApi.Owin" version="5.2.3" targetFramework="net45" />
  <package id="Microsoft.AspNet.WebApi.OwinSelfHost" version="5.2.3" targetFramework="net45" />
  <package id="Microsoft.AspNet.WebApi.WebHost" version="5.0.0" targetFramework="net45" />
  <package id="Microsoft.Owin" version="3.0.1" targetFramework="net45" />
  <package id="Microsoft.Owin.Host.HttpListener" version="3.0.1" targetFramework="net45" />
  <package id="Microsoft.Owin.Hosting" version="3.0.1" targetFramework="net45" />
  <package id="Newtonsoft.Json" version="6.0.4" targetFramework="net45" />
  <package id="Ninject" version="3.2.2.0" targetFramework="net45" />
  <package id="Ninject.Extensions.ContextPreservation" version="3.2.0.0" targetFramework="net45" />
  <package id="Ninject.Extensions.NamedScope" version="3.2.0.0" targetFramework="net45" />
  <package id="Ninject.Web.Common" version="3.2.3.0" targetFramework="net45" />
  <package id="Ninject.Web.Common.OwinHost" version="3.2.3.0" targetFramework="net45" />
  <package id="Ninject.Web.WebApi" version="3.2.0.0" targetFramework="net45" />
  <package id="Ninject.Web.WebApi.OwinHost" version="3.2.4.0" targetFramework="net45" />
  <package id="Owin" version="1.0" targetFramework="net45" />
  <package id="Pinpoint.EnterpriseLogging" version="1.0.0.10" targetFramework="net452" />
  <package id="Pinpoint.Environment" version="1.0.0.7" targetFramework="net45" />
</packages>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\packages.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\ServiceScheduler.WebApi.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{B0A9A6EA-A9CB-4000-AD2C-8DAE4B3C8BF6}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ServiceScheduler.WebApi</RootNamespace>
    <AssemblyName>ServiceScheduler.WebApi</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
    <TargetFrameworkProfile />
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition="'$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU'">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Microsoft.Owin">
      <HintPath>..\packages\Microsoft.Owin.3.0.1\lib\net45\Microsoft.Owin.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.Owin.Host.HttpListener">
      <HintPath>..\packages\Microsoft.Owin.Host.HttpListener.3.0.1\lib\net45\Microsoft.Owin.Host.HttpListener.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.Owin.Hosting, Version=2.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Microsoft.Owin.Hosting.3.0.1\lib\net45\Microsoft.Owin.Hosting.dll</HintPath>
    </Reference>
    <Reference Include="Newtonsoft.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Newtonsoft.Json.6.0.4\lib\net45\Newtonsoft.Json.dll</HintPath>
    </Reference>
    <Reference Include="Ninject">
      <HintPath>..\packages\Ninject.3.2.2.0\lib\net45-full\Ninject.dll</HintPath>
    </Reference>
    <Reference Include="Ninject.Extensions.ContextPreservation">
      <HintPath>..\packages\Ninject.Extensions.ContextPreservation.3.2.0.0\lib\net45-full\Ninject.Extensions.ContextPreservation.dll</HintPath>
    </Reference>
    <Reference Include="Ninject.Extensions.NamedScope">
      <HintPath>..\packages\Ninject.Extensions.NamedScope.3.2.0.0\lib\net45-full\Ninject.Extensions.NamedScope.dll</HintPath>
    </Reference>
    <Reference Include="Ninject.Web.Common">
      <HintPath>..\packages\Ninject.Web.Common.3.2.3.0\lib\net45-full\Ninject.Web.Common.dll</HintPath>
    </Reference>
    <Reference Include="Ninject.Web.Common.OwinHost">
      <HintPath>..\packages\Ninject.Web.Common.OwinHost.3.2.3.0\lib\net45-full\Ninject.Web.Common.OwinHost.dll</HintPath>
    </Reference>
    <Reference Include="Ninject.Web.WebApi">
      <HintPath>..\packages\Ninject.Web.WebApi.3.2.0.0\lib\net45-full\Ninject.Web.WebApi.dll</HintPath>
    </Reference>
    <Reference Include="Ninject.Web.WebApi.OwinHost">
      <HintPath>..\packages\Ninject.Web.WebApi.OwinHost.3.2.4.0\lib\net45-full\Ninject.Web.WebApi.OwinHost.dll</HintPath>
    </Reference>
    <Reference Include="Owin">
      <HintPath>..\packages\Owin.1.0\lib\net40\Owin.dll</HintPath>
    </Reference>
    <Reference Include="Pinpoint.EnterpriseLogging">
      <HintPath>..\packages\Pinpoint.EnterpriseLogging.1.0.0.10\lib\net40\Pinpoint.EnterpriseLogging.dll</HintPath>
    </Reference>
    <Reference Include="Pinpoint.EnterpriseLogging.Mvc">
      <HintPath>..\packages\Pinpoint.EnterpriseLogging.Mvc.1.0.0.72\lib\net40\Pinpoint.EnterpriseLogging.Mvc.dll</HintPath>
    </Reference>
    <Reference Include="Pinpoint.Environment">
      <HintPath>..\packages\Pinpoint.Environment.1.0.0.7\lib\net40\Pinpoint.Environment.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.ComponentModel.DataAnnotations" />
    <Reference Include="System.Configuration" />
    <Reference Include="System.Core" />
    <Reference Include="System.Net.Http" />
    <Reference Include="System.Net.Http.Formatting, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <HintPath>..\packages\Microsoft.AspNet.WebApi.Client.5.2.3\lib\net45\System.Net.Http.Formatting.dll</HintPath>
    </Reference>
    <Reference Include="System.ServiceModel" />
    <Reference Include="System.Web" />
    <Reference Include="System.Web.Http, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Microsoft.AspNet.WebApi.Core.5.2.3\lib\net45\System.Web.Http.dll</HintPath>
    </Reference>
    <Reference Include="System.Web.Http.Owin">
      <HintPath>..\packages\Microsoft.AspNet.WebApi.Owin.5.2.3\lib\net45\System.Web.Http.Owin.dll</HintPath>
    </Reference>
    <Reference Include="System.Web.Http.WebHost, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Microsoft.AspNet.WebApi.WebHost.5.0.0\lib\net45\System.Web.Http.WebHost.dll</HintPath>
    </Reference>
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Controllers\BaseController.cs" />
    <Compile Include="Controllers\ServiceController.cs" />
    <Compile Include="FilterAttributes\NotNullParameterFilterAttribute.cs" />
    <Compile Include="Infrastructure\DictionaryExtensions.cs" />
    <Compile Include="Infrastructure\JsonSerializerHelper.cs" />
    <Compile Include="FilterAttributes\OwinLogFilterAttribute.cs" />
    <Compile Include="FilterAttributes\ModelValidationFilterAttribute.cs" />
    <Compile Include="FilterAttributes\SerializableDictionary.cs" />
    <Compile Include="Models\SetServiceSchedule.cs" />
    <Compile Include="Models\StopServiceRequest.cs" />
    <Compile Include="Models\StopServiceResponse.cs" />
    <Compile Include="Models\StartServiceRequest.cs" />
    <Compile Include="Models\StartServiceResponse.cs" />
    <Compile Include="NinjectResolver.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
    <Compile Include="WebApiIocModule.cs" />
    <Compile Include="WebApiConfig.cs" />
    <Compile Include="WebApiHost.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="app.config" />
    <None Include="packages.config" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\ServiceScheduler\ServiceScheduler.csproj">
      <Project>{f14d9875-ef4d-4979-adec-e26cd8c9ec78}</Project>
      <Name>ServiceScheduler</Name>
    </ProjectReference>
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\ServiceScheduler.WebApi.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\ServiceScheduler.WebApi.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\ServiceScheduler.WebApi.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\WebApiConfig.cs==START]using System.Web.Http;
using Ninject;

namespace ServiceScheduler.WebApi
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Configure(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = new NinjectResolver(CreateKernel());
            return config;
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(new WebApiIocModule(), new ServiceSchedulerIocModule());
            return kernel;
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\WebApiConfig.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\WebApiHost.cs==START]using System;
using System.Configuration;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;
using Pinpoint.EnterpriseLogging.Services;
using Environment = Pinpoint.Environment.Environment;

namespace ServiceScheduler.WebApi
{
    public class WebApiHost
    {
        private static string _baseAddress;
        private static IDisposable _webApplication;

        public static void Start()
        {
            ConfigureLogging();
            var env = new Environment();
            _baseAddress = ConfigurationManager.AppSettings[string.Format("{0}.WebApiHost", env.Current)];
            _webApplication = WebApp.Start<WebApiHost>(_baseAddress);
        }

        public static void Stop()
        {
            _webApplication.Dispose();
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host.
            var config = WebApiConfig.Configure(new HttpConfiguration());
            appBuilder.UseWebApi(config);

            // NOTE: this did not work !!!
            //appBuilder.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);
        }


        private static void ConfigureLogging()
        {
            var logConnectionString = GetLoggingConnectionString();
            LoggerService.Instance.OverrideDefaultConnectionStringWith(logConnectionString);
            LoggerService.Instance.Start();
        }

        private static string GetLoggingConnectionString()
        {
            var env = new Environment();
            return ConfigurationManager.ConnectionStrings[
                string.Format("{0}.AuCommonServicesLog", env.Current)].ConnectionString;
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\WebApiHost.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\WebApiIocModule.cs==START]using Ninject.Modules;

namespace ServiceScheduler.WebApi
{
    public class WebApiIocModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Pinpoint.Environment.IEnvironment>().To<Pinpoint.Environment.Environment>();
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\WebApiIocModule.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Controllers\BaseController.cs==START]using ServiceScheduler.WebApi.FilterAttributes;
using System.Web.Http;

namespace ServiceScheduler.WebApi.Controllers
{
    [OwinLogFilter, ModelValidationFilter]
    public abstract class BaseController : ApiController
    {
       
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Controllers\BaseController.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Controllers\ServiceController.cs==START]using System;
using System.Web.Http;
using Pinpoint.EnterpriseLogging.Interfaces;
using ServiceScheduler.Domain;
using ServiceScheduler.ServiceJobs;
using ServiceScheduler.WebApi.FilterAttributes;
using ServiceScheduler.WebApi.Models;

namespace ServiceScheduler.WebApi.Controllers
{
    [RoutePrefix("api/Service")]
    public class ServiceController : BaseController
    {
        private readonly ILogger _logger;
        private readonly IServiceRunService _serviceRunService;

        public ServiceController(IServiceRunService serviceRunService, ILogger logger)
        {
            _serviceRunService = serviceRunService;
            _logger = logger;
        }

        [HttpPost]
        [Route("Stop", Name = "StoppingService")]
        public IHttpActionResult Stop(StopServiceRequest request)
        {
            try
            {
                var serviceRunResponse = _serviceRunService.KillRunningService(request.ServiceName,
                    request.ServiceRunId);
                switch (serviceRunResponse.State)
                {
                    case ServiceRunResponse.Response.Conflict:
                        return Conflict();
                    case ServiceRunResponse.Response.NotFound:
                        return NotFound();
                    case ServiceRunResponse.Response.Ok:
                        return Ok(new StopServiceResponse {ServiceRunId = request.ServiceRunId});
                    default:
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    string.Format("Stopping service '{0}' with service run id {1}. Error: {2}",
                        request.ServiceName, request.ServiceRunId, ex));
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("Start", Name = "StartingService")]
        public IHttpActionResult Start(StartServiceRequest request)
        {
            try
            {
                var serviceRunResponse = _serviceRunService.StartService(request.ServiceName,
                    request.ServiceParameters);
                switch (serviceRunResponse.State)
                {
                    case ServiceRunResponse.Response.Conflict:
                        return Conflict();
                    case ServiceRunResponse.Response.NotFound:
                        return NotFound();
                    case ServiceRunResponse.Response.Ok:
                        return Ok(new StopServiceResponse {ServiceRunId = serviceRunResponse.ServiceRunId});
                    default:
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    string.Format("Starting service '{0}' with parameters '{1}'. Error: {2}",
                        request.ServiceName, request.ServiceParameters, ex));
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("ExecutingServices")]
        public IHttpActionResult GetExecutingServices()
        {
            var activeServiceRuns = _serviceRunService.GetExecutingServices();
            return Ok(activeServiceRuns);
        }

        [HttpGet]
        [Route("{serviceId:int:min(1)}/Schedules/")]
        public IHttpActionResult GetSchedules(int serviceId)
        {
            var response = _serviceRunService.GetServiceSchedules(serviceId);
            return Interpret(response);
        }


        [HttpGet]
        [Route("{serviceId:int:min(1)}/Schedules/{scheduleId:int:min(1)}")]
        public IHttpActionResult GetSchedules(int serviceId, int scheduleId)
        {
            var response = _serviceRunService.GetServiceSchedule(serviceId, scheduleId);
            return Interpret(response);
        }

        [HttpPost]
        [NotNullParameterFilter]
        [Route("{ServiceId:int:min(1)}/Schedules/{ServiceScheduleId:int}")]
        public IHttpActionResult SetSchedule(SetServiceScheduleRequest request)
        {
            try
            {
                var scheduleResponse = _serviceRunService.SetServiceSchedule(new ServiceScheduleDto
                {
                    Enabled = request.Enabled,
                    Parameters = request.Parameters,
                    Schedule = request.Schedule,
                    ScheduleName = request.ScheduleName,
                    ServiceId = request.ServiceId,
                    ServiceScheduleId = request.ServiceScheduleId,
                    ModifiedBy = request.ModifiedBy
                });
                return Interpret(scheduleResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                     string.Format("Failed to set a new schedule for service with id {0}!", request.ServiceId), ex);
                return InternalServerError(ex);
            }
        }

        private IHttpActionResult Interpret<T>(Response<T> response)
        {
            switch (response.Status)
            {
                case StatusType.Conflict:
                    return Conflict();
                case StatusType.NotFound:
                    return NotFound();
                case StatusType.Ok:
                    return Ok(response.Content);
                case StatusType.BadRequest:
                    return BadRequest();
                default:
                    throw new Exception("Unrecognized returned status type:" + response.Status);
            }
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Controllers\ServiceController.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\FilterAttributes\ModelValidationFilterAttribute.cs==START]using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using Pinpoint.EnterpriseLogging;
using Pinpoint.EnterpriseLogging.Domain;
using Pinpoint.EnterpriseLogging.Interfaces;
using ServiceScheduler.WebApi.Infrastructure;

namespace ServiceScheduler.WebApi.FilterAttributes
{
    public class ModelValidationFilterAttribute : ActionFilterAttribute
    {
        private ILogger Logger { get; set; }

        public ModelValidationFilterAttribute(ILogger logger)
        {
            Logger = logger;
        }

        public ModelValidationFilterAttribute()
            : this(Pinpoint.EnterpriseLogging.Logger.Instance)
        {
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid)
            {
                return;
            }
            var validationErrorDtos = actionContext.ModelState
                .Select(keyValue => new
                {
                    Errors = GetErrorMessages(keyValue),
                    KeyValue = keyValue
                })
                .Where(e => e.Errors.Count > 0)
                .Select(e => new {Code = e.KeyValue.Key, Message = string.Join(Environment.NewLine, e.Errors)});

            var validations = JsonSerializerHelper.Serialize(validationErrorDtos);
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                ReasonPhrase = "Validation Errors",
                Content = new StringContent(validations)
            };
            Logger.LogError("Failed model state validation. See " + validations, CallContext.GetData(Constants.LogContextKey) as LogContext);
            actionContext.Response = response;
        }

        private List<string> GetErrorMessages(KeyValuePair<string, ModelState> keyValue)
        {
            var modelErrors =
                keyValue.Value.Errors.Where(e => e.ErrorMessage != string.Empty)
                    .Select(e => e.ErrorMessage)
                    .ToList();

            var serializationExceptions =
                keyValue.Value.Errors.Where(e => e.Exception != null).Select(e => e.Exception.Message).ToList();

            return modelErrors.Union(serializationExceptions).ToList();
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\FilterAttributes\ModelValidationFilterAttribute.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\FilterAttributes\NotNullParameterFilterAttribute.cs==START]using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Pinpoint.EnterpriseLogging;
using Pinpoint.EnterpriseLogging.Domain;
using Pinpoint.EnterpriseLogging.Interfaces;

namespace ServiceScheduler.WebApi.FilterAttributes
{
    public class NotNullParameterFilterAttribute : ActionFilterAttribute
    {
        private ILogger Logger { get; set; }

        public NotNullParameterFilterAttribute(ILogger logger)
        {
            Logger = logger;
        }

        public NotNullParameterFilterAttribute()
            : this(Pinpoint.EnterpriseLogging.Logger.Instance)
        {
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var actionArguments = actionContext.ActionArguments;
            if (actionArguments == null || actionArguments.Count == 0)
            {
                return;
            }

            if (actionArguments.All(arg => arg.Value != null))
            {
                return;
            }

            var message = actionArguments.Count == 1
                ? "The argument for this call is missing and it is required!"
                : "All arguments for this call must be valued!";

            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                ReasonPhrase = "Validation Errors",
                Content = new StringContent(message)
            };
            Logger.LogError(message, CallContext.GetData(Constants.LogContextKey) as LogContext);
            actionContext.Response = response;
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\FilterAttributes\NotNullParameterFilterAttribute.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\FilterAttributes\OwinLogFilterAttribute.cs==START]using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.Owin;
using Pinpoint.EnterpriseLogging;
using Pinpoint.EnterpriseLogging.Domain;
using Pinpoint.EnterpriseLogging.Interfaces;
using ServiceScheduler.WebApi.Infrastructure;

namespace ServiceScheduler.WebApi.FilterAttributes
{
    public class OwinLogFilterAttribute : ActionFilterAttribute
    {
        private OwinLogFilterAttribute(ILogger logger, IObjectLogger objectLogger)
        {
            Logger = logger;
            ObjectLogger = objectLogger;
            LogArguments = true;
        }

        public OwinLogFilterAttribute()
            : this(Pinpoint.EnterpriseLogging.Logger.Instance, Pinpoint.EnterpriseLogging.ObjectLogger.Instance)
        {
        }

        private ILogger Logger { get; set; }
        private IObjectLogger ObjectLogger { get; set; }
        public bool LogArguments { get; set; }

        private void LogBeforeExecute(IDictionary<string, object> actionParameters)
        {
            if (LogArguments)
            {
                if (actionParameters == null || actionParameters.Count == 0)
                {
                    Logger.LogInfo("Before execution [Has no arguments].");
                    return;
                }
                if (actionParameters.Count > 0)
                {
                    Logger.LogInfo("Before execution.");
                    ObjectLogger.Log(actionParameters.ConvertToSerializableDictionary());
                    return;
                }
            }
            Logger.LogInfo("Before execution [Arguments are not logged].");
        }


        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            CreateAndStoreLogContext(actionContext);
            LogBeforeExecute(actionContext.ActionArguments);
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            var logContext = (CallContext.GetData(Constants.LogContextKey) as LogContext) ??
                                    BuildLogContext(filterContext.ActionContext,
                                        filterContext.ActionContext.ActionDescriptor.ActionName,
                                        filterContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName);

            logContext.HttpStatusCode = ((int) filterContext.Response.StatusCode).ToString("D");

            if (filterContext.Exception != null)
            {
                Logger.LogError("Exception occured. See exception details", filterContext.Exception, logContext);
            }
            else
            {
                Logger.LogInfo("After execution", logContext);
            }
            base.OnActionExecuted(filterContext);
        }

        private void CreateAndStoreLogContext(HttpActionContext context)
        {
            var logContext = BuildLogContext(context,
                context.ActionDescriptor.ActionName
                , context.ActionDescriptor.ControllerDescriptor.ControllerType.FullName);
            CallContext.SetData(Constants.LogContextKey, logContext);
        }

        private LogContext BuildLogContext(HttpActionContext actionContext, string actionName, string controllerName)
        {
            var logContext = new LogContext
            {
                Method = actionName,
                Class = controllerName,
                RequestId = Guid.NewGuid().ToString(),
                SessionId = Guid.NewGuid().ToString()
            };
            var principal = actionContext.ControllerContext.RequestContext.Principal;
            if (principal != null)
            {
                //in owin I don't get this. Probably we miss something at this moment.
                logContext.User = principal.Identity.Name;
            }
            var owinContext = GetOwinContext(actionContext);
            if (owinContext != null)
            {
                logContext.ClientIp = owinContext.Request.RemoteIpAddress;
                logContext.HttpStatusCode = owinContext.Response.StatusCode.ToString("D");
                logContext.SourceSiteId = null; //how to do this in owin?
            }
            return logContext;
        }

        private static IOwinContext GetOwinContext(HttpActionContext actionContext)
        {
            return actionContext.Request.Properties.ContainsKey("MS_OwinContext")
                ? actionContext.Request.Properties["MS_OwinContext"] as OwinContext
                : null;
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\FilterAttributes\OwinLogFilterAttribute.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\FilterAttributes\SerializableDictionary.cs==START]using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ServiceScheduler.WebApi.FilterAttributes
{
    [Serializable]
    [XmlRoot("Dictionary")]
    public class SerializableDictionary<TKey, TValue>
        : Dictionary<TKey, TValue>, IXmlSerializable
    {
        private const string DefaultTagItem = "Item";
        private const string DefaultTagKey = "Key";
        private const string DefaultTagValue = "Value";

        private static readonly XmlSerializer KeySerializer =
            new XmlSerializer(typeof(TKey));

        private static readonly XmlSerializer ValueSerializer =
            new XmlSerializer(typeof(TValue));

        public SerializableDictionary()
        {
        }

        protected SerializableDictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        protected virtual string ItemTagName
        {
            get { return DefaultTagItem; }
        }

        protected virtual string KeyTagName
        {
            get { return DefaultTagKey; }
        }

        protected virtual string ValueTagName
        {
            get { return DefaultTagValue; }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            var wasEmpty = reader.IsEmptyElement;

            reader.Read();

            if (wasEmpty)
            {
                return;
            }

            try
            {
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.ReadStartElement(ItemTagName);
                    try
                    {
                        TKey tKey;
                        TValue tValue;

                        reader.ReadStartElement(KeyTagName);
                        try
                        {
                            tKey = (TKey)KeySerializer.Deserialize(reader);
                        }
                        finally
                        {
                            reader.ReadEndElement();
                        }

                        reader.ReadStartElement(ValueTagName);
                        try
                        {
                            tValue = (TValue)ValueSerializer.Deserialize(reader);
                        }
                        finally
                        {
                            reader.ReadEndElement();
                        }

                        Add(tKey, tValue);
                    }
                    finally
                    {
                        reader.ReadEndElement();
                    }

                    reader.MoveToContent();
                }
            }
            finally
            {
                reader.ReadEndElement();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var keyValuePair in this)
            {
                writer.WriteStartElement(ItemTagName);
                try
                {
                    writer.WriteStartElement(KeyTagName);
                    try
                    {
                        KeySerializer.Serialize(writer, keyValuePair.Key);
                    }
                    finally
                    {
                        writer.WriteEndElement();
                    }

                    writer.WriteStartElement(ValueTagName);
                    try
                    {
                        ValueSerializer.Serialize(writer, keyValuePair.Value);
                    }
                    finally
                    {
                        writer.WriteEndElement();
                    }
                }
                finally
                {
                    writer.WriteEndElement();
                }
            }
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\FilterAttributes\SerializableDictionary.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Infrastructure\DictionaryExtensions.cs==START]using System.Collections.Generic;
using ServiceScheduler.WebApi.FilterAttributes;

namespace ServiceScheduler.WebApi.Infrastructure
{
    public static class DictionaryExtensions
    {
        public static SerializableDictionary<TKey, TValue> ConvertToSerializableDictionary<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }
            var result = new SerializableDictionary<TKey, TValue>();
            foreach (var key in dictionary.Keys)
            {
                result.Add(key, dictionary[key]);
            }
            return result;
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Infrastructure\DictionaryExtensions.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Infrastructure\JsonSerializerHelper.cs==START]using System.Text;
using Newtonsoft.Json;

namespace ServiceScheduler.WebApi.Infrastructure
{
    public class JsonSerializerHelper
    {
        public static T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public static string Serialize(object input)
        {
            return JsonConvert.SerializeObject(input);
        }

        public static byte[] SerializeToBytes(object input)
        {
            return Encoding.ASCII.GetBytes(Serialize(input));
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Infrastructure\JsonSerializerHelper.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Models\SetServiceSchedule.cs==START]using System.ComponentModel.DataAnnotations;

namespace ServiceScheduler.WebApi.Models
{
    public class SetServiceScheduleRequest
    {
        [Range(1, int.MaxValue)]
        public int ServiceId { get; set; }

        public int ServiceScheduleId { get; set; }

        [Required]
        public string ScheduleName { get; set; }

        [Required]
        public string Schedule { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Parameters { get; set; }

        public bool Enabled { get; set; }

        [Required]
        public string ModifiedBy { get; set; }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Models\SetServiceSchedule.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Models\StartServiceRequest.cs==START]using System.ComponentModel.DataAnnotations;

namespace ServiceScheduler.WebApi.Models
{
    public class StartServiceRequest
    {
        [Required]
        public string ServiceName { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string ServiceParameters { get; set; }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Models\StartServiceRequest.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Models\StartServiceResponse.cs==START]namespace ServiceScheduler.WebApi.Models
{
    public class StartServiceResponse
    {
        public int ServiceRunId { get; set; }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Models\StartServiceResponse.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Models\StopServiceRequest.cs==START]using System.ComponentModel.DataAnnotations;

namespace ServiceScheduler.WebApi.Models
{
    public class StopServiceRequest
    {
        [Required]
        public string ServiceName { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int ServiceRunId { get; set; }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Models\StopServiceRequest.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Models\StopServiceResponse.cs==START]namespace ServiceScheduler.WebApi.Models
{
    public class StopServiceResponse
    {
        public int ServiceRunId { get; set; }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Models\StopServiceResponse.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("ServiceScheduler.WebApi")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("ServiceScheduler.WebApi")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid("3d22c00f-6d61-4146-944a-900fff2dbcd3")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")][STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\app.config==START]<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="Microsoft.Owin" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-3.0.1.0" newVersion="3.0.1.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Http" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Http.Owin" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Net.Http.Formatting" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
</configuration>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\app.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\packages.config==START]<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Microsoft.AspNet.WebApi.Client" version="5.2.3" targetFramework="net45" />
  <package id="Microsoft.AspNet.WebApi.Core" version="5.2.3" targetFramework="net45" />
  <package id="Moq" version="4.2.1402.2112" targetFramework="net45" />
  <package id="Newtonsoft.Json" version="6.0.4" targetFramework="net45" />
  <package id="NUnit" version="2.6.4" targetFramework="net45" />
  <package id="Pinpoint.EnterpriseLogging" version="1.0.0.10" targetFramework="net452" />
</packages>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\packages.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\ServiceScheduler.WebApi.FunctionalTests.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{B24C3C2C-2827-4C4D-9DFF-2A7A36512640}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ServiceScheduler.WebApi.FunctionalTests</RootNamespace>
    <AssemblyName>ServiceScheduler.WebApi.FunctionalTests</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
    <TargetFrameworkProfile />
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition="'$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU'">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Moq">
      <HintPath>..\packages\Moq.4.2.1402.2112\lib\net40\Moq.dll</HintPath>
    </Reference>
    <Reference Include="Newtonsoft.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Newtonsoft.Json.6.0.4\lib\net45\Newtonsoft.Json.dll</HintPath>
    </Reference>
    <Reference Include="nunit.framework">
      <HintPath>..\packages\NUnit.2.6.4\lib\nunit.framework.dll</HintPath>
    </Reference>
    <Reference Include="Pinpoint.EnterpriseLogging">
      <HintPath>..\packages\Pinpoint.EnterpriseLogging.1.0.0.10\lib\net40\Pinpoint.EnterpriseLogging.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Net.Http" />
    <Reference Include="System.Net.Http.Formatting, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Microsoft.AspNet.WebApi.Client.5.2.3\lib\net45\System.Net.Http.Formatting.dll</HintPath>
    </Reference>
    <Reference Include="System.ServiceModel" />
    <Reference Include="System.Web.Http, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\Microsoft.AspNet.WebApi.Core.5.2.3\lib\net45\System.Web.Http.dll</HintPath>
    </Reference>
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Controllers\StartService\StopServiceControllerTests.cs" />
    <Compile Include="Controllers\StartService\StartServiceControllerTests.cs" />
    <Compile Include="Helpers\WebApiHelper.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="app.config" />
    <None Include="packages.config" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\ServiceScheduler.FunctionalTest\ServiceScheduler.FunctionalTest.csproj">
      <Project>{00C7FFF8-E054-44C3-9CB6-9051E24FDA32}</Project>
      <Name>ServiceScheduler.FunctionalTest</Name>
    </ProjectReference>
    <ProjectReference Include="..\ServiceScheduler.WebApi\ServiceScheduler.WebApi.csproj">
      <Project>{b0a9a6ea-a9cb-4000-ad2c-8dae4b3c8bf6}</Project>
      <Name>ServiceScheduler.WebApi</Name>
    </ProjectReference>
    <ProjectReference Include="..\ServiceScheduler\ServiceScheduler.csproj">
      <Project>{f14d9875-ef4d-4979-adec-e26cd8c9ec78}</Project>
      <Name>ServiceScheduler</Name>
    </ProjectReference>
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\ServiceScheduler.WebApi.FunctionalTests.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\ServiceScheduler.WebApi.FunctionalTests.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\ServiceScheduler.WebApi.FunctionalTests.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\Controllers\StartService\StartServiceControllerTests.cs==START]using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using ServiceScheduler.FunctionalTest;
using ServiceScheduler.WebApi.FunctionalTests.Helpers;
using ServiceScheduler.WebApi.Models;

namespace ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService
{
    [TestFixture]
    public class StartServiceControllerTests
    {
        private const string SERVICE_CONTROLLER = "Service";
        private const string SERVICE_BASE_URI = "http://localhost:9000";
        private TestServicesHelper _servicesHelper;
        private StartServiceRequest _serviceStartRequest;

        [SetUp]
        public void Setup()
        {
            _servicesHelper = new TestServicesHelper();

            _serviceStartRequest = new StartServiceRequest
            {
                ServiceName = _servicesHelper.TestServiceAName,
                ServiceParameters = _servicesHelper.TestServiceAParameters
            };

            _servicesHelper.CleanupServiceFolders();
            _servicesHelper.ResetServiceTables();
            _servicesHelper.StartServiceScheduler();

            _servicesHelper.DeployServicesVersion1();
            _servicesHelper.WaitForServicesToComplete();
        }

        [TearDown]
        public void TearDown()
        {
            _servicesHelper.StopServiceScheduler();
            _servicesHelper.ResetServiceTables();
            _servicesHelper.CleanupServiceFolders();
        }

        [Test, Explicit]
        public void Post_ServiceNotFound_ExpectNotFound()
        {
            using (var client = new WebApiHelper().CreateClient(SERVICE_BASE_URI, SERVICE_CONTROLLER, "Start"))
            {
                _serviceStartRequest.ServiceName = DateTime.Now.Ticks.ToString();
                _serviceStartRequest.ServiceParameters = "";
                var result = client.PostAsJsonAsync(client.BaseAddress, _serviceStartRequest).Result;
                var response = result.Content.ReadAsAsync<StartServiceResponse>().Result;

                Assert.IsFalse(result.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
                Assert.IsNull(response);
            }
        }

        [Test, Explicit]
        public void Post_ServiceIsRunning_ExpectConflict()
        {
            using (var client = new WebApiHelper().CreateClient(SERVICE_BASE_URI, SERVICE_CONTROLLER, "Start"))
            {
                // start service
                _serviceStartRequest.ServiceParameters = "";
                var result1 = client.PostAsJsonAsync(client.BaseAddress, _serviceStartRequest).Result;
                var response1 = result1.Content.ReadAsAsync<StartServiceResponse>().Result;

                Assert.IsTrue(result1.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.OK, result1.StatusCode);
                Assert.Greater(response1.ServiceRunId, 0);

                // try again, while service still running
                var result2 = client.PostAsJsonAsync(client.BaseAddress, _serviceStartRequest).Result;
                var response2 = result2.Content.ReadAsAsync<StartServiceResponse>().Result;

                Assert.IsFalse(result2.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.Conflict, result2.StatusCode);
                Assert.IsNull(response2);
            }
        }

        [Test, Explicit]
        public void Post_HappyPath_ExpectSuccess()
        {
            using (var client = new WebApiHelper().CreateClient(SERVICE_BASE_URI, SERVICE_CONTROLLER, "Start"))
            {
                _serviceStartRequest.ServiceParameters = "";
                var result = client.PostAsJsonAsync(client.BaseAddress, _serviceStartRequest).Result;
                var response = result.Content.ReadAsAsync<StartServiceResponse>().Result;

                Assert.IsTrue(result.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
                Assert.Greater(response.ServiceRunId, 0);
            }
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\Controllers\StartService\StartServiceControllerTests.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\Controllers\StartService\StopServiceControllerTests.cs==START]using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using ServiceScheduler.FunctionalTest;
using ServiceScheduler.WebApi.FunctionalTests.Helpers;
using ServiceScheduler.WebApi.Models;

namespace ServiceScheduler.WebApi.FunctionalTests.Controllers.StartService
{
    [TestFixture]
    public class StopServiceControllerTests
    {
        private const string SERVICES_CONTROLLER = "Service";
        private const string SERVICE_BASE_URI = "http://localhost:9000";
        private WebApiHelper _webApiHelper;
        private TestServicesHelper _servicesHelper;
        private StartServiceRequest _serviceStartRequest;
        private StopServiceRequest _serviceStopRequest;

        [SetUp]
        public void Setup()
        {
            _webApiHelper = new WebApiHelper();
            _servicesHelper = new TestServicesHelper();

            _serviceStartRequest = new StartServiceRequest
            {
                ServiceName = _servicesHelper.TestServiceAName,
                ServiceParameters = _servicesHelper.TestServiceAParameters
            };
            _serviceStopRequest = new StopServiceRequest
            {
                ServiceName = _servicesHelper.TestServiceAName
            };

            _servicesHelper.CleanupServiceFolders();
            _servicesHelper.ResetServiceTables();
            _servicesHelper.StartServiceScheduler();

            _servicesHelper.DeployServicesVersion1();
            _servicesHelper.WaitForServicesToComplete();
        }

        [TearDown]
        public void TearDown()
        {
            _servicesHelper.StopServiceScheduler();
            _servicesHelper.ResetServiceTables();
            _servicesHelper.CleanupServiceFolders();
        }

        [Test, Explicit]
        public void Post_ServiceBadRequest_ExpectNotFound()
        {
            using (var client = new WebApiHelper().CreateClient(SERVICE_BASE_URI, SERVICES_CONTROLLER, "Stop"))
            {
                _serviceStopRequest.ServiceName = DateTime.Now.Ticks.ToString();
                _serviceStopRequest.ServiceRunId = 0;
                var result = client.PostAsJsonAsync(client.BaseAddress, _serviceStopRequest).Result;
                var response = result.Content.ReadAsAsync<StopServiceResponse>().Result;

                Assert.IsFalse(result.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
                Assert.IsNotNull(response);
            }
        }

        [Test, Explicit]
        public void Post_ServiceNotFound_ExpectNotFound()
        {
            using (var client = new WebApiHelper().CreateClient(SERVICE_BASE_URI, SERVICES_CONTROLLER, "Stop"))
            {
                _serviceStopRequest.ServiceName = DateTime.Now.Ticks.ToString();
                _serviceStopRequest.ServiceRunId = int.MaxValue - 1;
                var result = client.PostAsJsonAsync(client.BaseAddress, _serviceStopRequest).Result;
                var response = result.Content.ReadAsAsync<StopServiceResponse>().Result;

                Assert.IsFalse(result.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
                Assert.IsNull(response);
            }
        }

        [Test, Explicit]
        public void Post_ServiceRunNotFound_ExpectNotFound()
        {
            using (var client = new WebApiHelper().CreateClient(SERVICE_BASE_URI, SERVICES_CONTROLLER, "Stop"))
            {
                _serviceStopRequest.ServiceRunId = 1;
                var result = client.PostAsJsonAsync(client.BaseAddress, _serviceStopRequest).Result;
                var response = result.Content.ReadAsAsync<StopServiceResponse>().Result;

                Assert.IsFalse(result.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
                Assert.IsNull(response);
            }
        }

        [Test, Explicit]
        public void Post_ServiceIsNotRunning_ExpectNotFound()
        {
            using (var client = new WebApiHelper().CreateClient(SERVICE_BASE_URI, SERVICES_CONTROLLER, "Start"))
            {
                // start service
                _serviceStartRequest.ServiceParameters = "";
                var result1 = client.PostAsJsonAsync(client.BaseAddress, _serviceStartRequest).Result;
                var response1 = result1.Content.ReadAsAsync<StartServiceResponse>().Result;

                Assert.IsTrue(result1.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.OK, result1.StatusCode);
                Assert.Greater(response1.ServiceRunId, 0);

                _serviceStopRequest.ServiceRunId = response1.ServiceRunId;

                // update incorrect process id
                _servicesHelper.UpdateServiceRunProcessId(response1.ServiceRunId, 999999);
            }

            using (var client = new WebApiHelper().CreateClient(SERVICE_BASE_URI, SERVICES_CONTROLLER, "Stop"))
            {
                // try to stop service after it has completed running
                var result2 = client.PostAsJsonAsync(client.BaseAddress, _serviceStopRequest).Result;
                var response2 = result2.Content.ReadAsAsync<StopServiceResponse>().Result;

                Assert.IsFalse(result2.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.NotFound, result2.StatusCode);
                Assert.IsNull(response2);
            }
        }

        [Test, Explicit]
        public void Post_HappyPath_ExpectSuccess()
        {
            using (var client = new WebApiHelper().CreateClient(SERVICE_BASE_URI, SERVICES_CONTROLLER, "Start"))
            {
                // start service
                var result1 = client.PostAsJsonAsync(client.BaseAddress, _serviceStartRequest).Result;
                var response1 = result1.Content.ReadAsAsync<StartServiceResponse>().Result;

                Assert.IsTrue(result1.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.OK, result1.StatusCode);
                Assert.Greater(response1.ServiceRunId, 0);

                _serviceStopRequest.ServiceRunId = response1.ServiceRunId;
            }

            using (var client = new WebApiHelper().CreateClient(SERVICE_BASE_URI, SERVICES_CONTROLLER, "Stop"))
            {
                // try to stop service after it has completed running
                var result2 = client.PostAsJsonAsync(client.BaseAddress, _serviceStopRequest).Result;
                var response2 = result2.Content.ReadAsAsync<StopServiceResponse>().Result;

                Assert.IsTrue(result2.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.OK, result2.StatusCode);
                Assert.AreEqual(_serviceStopRequest.ServiceRunId, response2.ServiceRunId);
            }
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\Controllers\StartService\StopServiceControllerTests.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\Helpers\WebApiHelper.cs==START]using System;
using System.Net.Http;

namespace ServiceScheduler.WebApi.FunctionalTests.Helpers
{
    public class WebApiHelper
    {
        public HttpClient CreateClient(string baseUri, string controller, string actionName)
        {
            return new HttpClient {BaseAddress = new Uri(new Uri(baseUri), string.Format("api/{0}/{1}", controller, actionName))};
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\Helpers\WebApiHelper.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ServiceScheduler.WebApi.FunctionalTests")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("ServiceScheduler.WebApi.FunctionalTests")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("b97a30a7-e9a0-49b9-870c-de9313f3bee8")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ServiceScheduler.WebApi.FunctionalTests\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\App.config==START]<?xml version="1.0"?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2"/>
    </startup>
  <appSettings>
    <add key="schedule" value="0 0/1 * 1/1 * ? *"/>
  </appSettings>
</configuration>
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\App.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\EventLogHelper.cs==START]using System;
using System.Diagnostics;

namespace TestService
{
    public class EventLogHelper : IEventLogHelper
    {
        private string _eventLogSource;
        private string _eventLogName;

        public EventLogHelper(string eventLogSource)
            : this(eventLogSource, null)
        {
        }

        public EventLogHelper(string eventLogSource, string eventLogName)
        {
            _eventLogSource = string.IsNullOrWhiteSpace(eventLogSource) ? "Application" : eventLogSource;
            _eventLogName = string.IsNullOrWhiteSpace(eventLogName) ? "Pinpoint" : eventLogName;

            try
            {
                if (!EventLog.SourceExists(_eventLogSource))
                {
                    EventLog.CreateEventSource(_eventLogSource, _eventLogName);
                }
            }
            catch
            {
            }
        }

        public void Error(string message)
        {
            Error(message, null);
        }

        public void Error(string message, Exception ex)
        {
            using (var eventLog = new EventLog())
            {
                if (ex != null)
                {
                    message += string.Format("\n\n{0}", ex);
                }

                eventLog.Source = _eventLogSource;
                eventLog.WriteEntry(message, EventLogEntryType.Error);
            }
        }

        public void Info(string message)
        {
            using (var eventLog = new EventLog())
            {
                eventLog.Source = _eventLogSource;
                eventLog.WriteEntry(message, EventLogEntryType.Information);
            }
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\EventLogHelper.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\IEventLogHelper.cs==START]using System;

namespace TestService
{
    public interface IEventLogHelper
    {
        void Error(string message);
        void Error(string message, Exception ex);
        void Info(string message);
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\IEventLogHelper.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\packages.config==START]<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Pinpoint.EnterpriseScheduling" version="1.0.0.10" targetFramework="net452" />
</packages>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\packages.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\Program.cs==START]namespace TestService
{
    public class Program
    {
        static void Main(string[] args)
        {
            new TestService().Execute(args);
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\Program.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\TestService.cs==START]using System;
using System.Threading;
using Pinpoint.EnterpriseScheduling;

namespace TestService
{
    public class TestService : IServiceApplication
    {
        public void Execute(string[] args)
        {
            new EventLogHelper("CEZAR").Info("v02. Executed at:" + DateTime.Now.ToString("F"));
            Thread.Sleep(TimeSpan.FromSeconds(30));
        }
    }
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\TestService.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\TestService.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{A4316C4C-7723-4C2E-9017-AC7E464984D9}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>TestService</RootNamespace>
    <AssemblyName>TestService</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <TargetFrameworkProfile />
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <Prefer32Bit>false</Prefer32Bit>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <Prefer32Bit>false</Prefer32Bit>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
    <Prefer32Bit>false</Prefer32Bit>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Pinpoint.EnterpriseScheduling">
      <HintPath>..\packages\Pinpoint.EnterpriseScheduling.1.0.0.10\lib\net452\Pinpoint.EnterpriseScheduling.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.ServiceModel" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="EventLogHelper.cs" />
    <Compile Include="IEventLogHelper.cs" />
    <Compile Include="Program.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
    <Compile Include="TestService.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
    <None Include="packages.config" />
  </ItemGroup>
  <ItemGroup>
    <Content Include="TestService.Schedule.xml">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\TestService.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\TestService.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\TestService.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\TestService.Schedule.xml==START]<root>
  <service name="TestService" allowConcurrency="false" useCalendar="false" isEnabled="true">
    <schedule value="0 0/1 * 1/1 * ? *" />
    <!-- Every minute -->
  </service>
</root>
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\TestService.Schedule.xml==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
using Pinpoint.EnterpriseScheduling;

[assembly: AssemblyTitle("TestService")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("TestService")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("c07dd247-0861-4560-9360-933086f04e1c")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.2")]
[assembly: AssemblyFileVersion("1.0.0.2")]

[assembly: ServiceApplication(ServiceName = "TestService")]
[assembly: ServiceApplicationSchedule(ScheduleName = "Every 1 mins on Mon, Wed, Fri", Schedule = "0 0/1 * ? * MON,WED,FRI *")]
[assembly: ServiceApplicationSchedule(ScheduleName = "Every 1 mins on Tue, Thu", Schedule = "0 0/1 * ? * TUE,THU *")]
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\TestService\Properties\AssemblyInfo.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ZipFilesUtility\App.config==START]<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
    </startup>
</configuration>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ZipFilesUtility\App.config==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ZipFilesUtility\Program.cs==START]using System.IO;
using System.IO.Compression;
using System.Linq;

namespace ZipFilesUtility
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string solutionFolder = @"C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk";
            ZipTestServices(solutionFolder);
        }

        private static void ZipTestServices(string solutionFolder)
        {
            var testServicesFolders =
                Directory.GetDirectories(solutionFolder, "Service*.v0*")
                    .Select(p => new {DebugPath = Path.Combine(p, "Bin", "Debug"), DestinationFileName = p + ".zit"})
                    .ToList();
            testServicesFolders.ForEach(p =>
            {
                if (File.Exists(p.DestinationFileName))
                {
                    File.Delete(p.DestinationFileName);
                }
                ZipFile.CreateFromDirectory(p.DebugPath, p.DestinationFileName);
            });
        }
    }
}[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ZipFilesUtility\Program.cs==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ZipFilesUtility\ZipFilesUtility.csproj==START]<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{FDCA97F9-E3BD-422A-A90F-181957B457E6}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ZipFilesUtility</RootNamespace>
    <AssemblyName>ZipFilesUtility</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'DebugLocal|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\DebugLocal\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <DebugType>full</DebugType>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <ErrorReport>prompt</ErrorReport>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
    <Prefer32Bit>false</Prefer32Bit>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.IO.Compression.FileSystem" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Program.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ZipFilesUtility\ZipFilesUtility.csproj==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ZipFilesUtility\ZipFilesUtility.csproj.vspscc==START]""
{
"FILE_VERSION" = "9237"
"ENLISTMENT_CHOICE" = "NEVER"
"PROJECT_FILE_RELATIVE_PATH" = ""
"NUMBER_OF_EXCLUDED_FILES" = "0"
"ORIGINAL_PROJECT_FILE_PATH" = ""
"NUMBER_OF_NESTED_PROJECTS" = "0"
"SOURCE_CONTROL_SETTINGS_PROVIDER" = "PROVIDER"
}
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ZipFilesUtility\ZipFilesUtility.csproj.vspscc==STOP][START==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ZipFilesUtility\Properties\AssemblyInfo.cs==START]using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ZipFilesUtility")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("ZipFilesUtility")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("81535680-af2e-467d-95ca-f42d34a2555e")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[STOP==C:\TFS\PinpointIT\Atlas\ServiceScheduler\Trunk\ZipFilesUtility\Properties\AssemblyInfo.cs==STOP]
