// Include Fake lib
#r @"packages/FAKE.3.28.5/tools/FakeLib.dll"
open Fake
open Fake.XUnit2Helper

// Build properties
let buildDir = "./dist"
let testDir  = buildDir + "/tests"
let xUnitRunner = "packages/xunit.runner.console.2.0.0/tools/xunit.console.exe"


// Targets
Target "Clean" (fun _ ->
  CleanDir buildDir
)

Target "Default" (fun _ ->
  trace "Hello, World!"
)

Target "BuildUnitTests" (fun _ ->
  trace testDir
  !! "*.UnitTests/*.csproj"
    |> MSBuildDebug testDir "Build"
    |> Log "AppBuild-Output: "
)

Target "RunUnitTests" (fun _ ->
  !! (testDir + "/*.UnitTests.dll")
    |> xUnit2 (fun p ->
        {p with
            ShadowCopy = false;
            HtmlOutput = true;
            XmlOutput = true;
            OutputDir = testDir;
            ToolPath  = xUnitRunner; })
)

// Dependencies
"Clean"
  ==> "BuildUnitTests"

"BuildUnitTests"
  ==> "RunUnitTests"

RunTargetOrDefault "Default"
