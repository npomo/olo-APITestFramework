# olo-APITestFramework
REST API Testing Framework for Olo Code Challenge

Libraries Used
- RestSharp (for HTTP calls)
- FluentAssertions (Human readable Assertion Library)
- SlowCheetah (Env config transformations)
- Newtonsoft Json (JSON Serialization/Deserialization)

To run the tests from within Visual Studio (solution was built in VS 2019, .NET Framework 4.7.2):
- Clone the repo locally
- Load the solution in visual studio and build it
  - Note: you may need to install the SlowCheetah extension in order to use the App.Config transforms
- Open the Test Explorer (Test --> Test Explorer)
- Click the 'Run All Tests in View' button at the top of the Test Explorer

To Run the tests from the command line (for local use or use in a CI/CD pipeline):
- Follow the steps for running within VS to clone/build the solution
- open a windows command prompt
- vstest.console.exe is used to run the tests from the command line.  You need to either change directory to the location of that exe, or add it to your env vars path
  - Mine was found at: c:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow
- Run the command.  The example below is running with vstest.console.exe added to the classpath, and the current directory is the location of the DLL after building:
  - vstest.console.exe Olo-APITestFramework.dll /Settings:C:\github\olo-APITestFramework\Olo-APITestFramework\.runsettings /Logger:trx /TestCaseFilter:"TestCategory=Full"
- The options for the command line:
  - /Settings: Parallelizes test execution so tests run faster.  The runsettings files can be modifed to increase/reduce parallelization.
  - /Logger:trx: Generates a log file with the output of the tests.  This file can be imported into a CI/CD system like Teamcity to display the test results post execution
  - /TestCaseFilter:"TestCategory=<x>": There are varios Categories of tests that can be run, including: 
     - Smoke, Full, JSONPlaceHolder_GetEndpoints, JSONPlaceHolder_PostEndpoints, JSONPlaceHolder_PutEndpoints, JSONPlaceHolder_PutEndpoints
- The full suite will run 11 tests.  At the time of this submission, 1 of those tests is failing due to a defect on the Put implementation
  
  
