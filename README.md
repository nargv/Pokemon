**Pokémon search engine**

This is a small, light-weight, fun & interactive pokemon search engine.

Enter a pokemon name and press search button or enter key to create the request. This will fetch a small sprite and a shakespeare translated description of the pokemon. These descriptions are a random pick of a list of available descriptions for any individual pokemon. If the pokemon doesn't exist or the entry is an invalid input, the UI will make sure to let you know.

All your searches are saved per session using redux tools. It stores a pokemon's name, description and the sprite. In the second tab of "History", you'll be able to view all the searches you've made in the session (newest to oldest).

**Technologies used**
* Back-end: .NET Core C#
* Front-end: React JS

**Testing**
* Back-end testing: I've written unit tests for Controllers and Services, providing a very a good code coverage for the solution.
* Front-end testing: I've unfortunately only been able to do minimal testing. Tests were conducted for api call and SearchResult component. I couldn't do more due to package issues. I've installed a few testing libraries but tests kept failing due to package dependency issues. I couldn't manage to figure out a solution fro this. Hence, I had to remove the tests that were not working.

**Prerequisites**
1. Install node js https://nodejs.org/en/download/
2. Install .NET SDK 3.1 https://dotnet.microsoft.com/en-us/download/dotnet/3.1

**Instructions to run:**
1. Download the zip file from the "Code" dropdown at the top, then extract to a folder of your choice.
2. Open CMD then navigate to "Pokemon-master\Pokemon\ClientApp" - run "npm install"
3. On CMD again, go one folder up "Pokemon-master\Pokemon" - run "dotnet run"
4. Copy the first localhost launch link and paste into your browser. 
5. Web Application is ready and running!
