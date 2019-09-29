# logcorner-LogCorner.Hackaton.TennisPlayer
to run this sample code, please proceed as follows :

- locate appsettings.Development.json file on  ....\logcorner-LogCorner.Hackaton.TennisPlayer-master\logcorner-LogCorner.Hackaton.TennisPlayer-master\LogCorner.Hackaton.TennisPlayer.Presentation\appsettings.Development.json   
- update FullFilePath and indicate the full file path of Data.json located in your computer, 
in my case Data.json is located here : ....\logcorner-LogCorner.Hackaton.TennisPlayer-master\logcorner-LogCorner.Hackaton.TennisPlayer-master\LogCorner.Hackaton.TennisPlayer.Presentation\App_Data\Data.json.

appsettings.Development.json should look like this :
{
  "ConnectionStrings": {
    "FullFilePath": "{your-file-path}\\Data.json"
  }
}

- please launch LogCorner.Hackaton.TennisPlayer.Presentation.csproj using visual studio or run the  following commands 
            C:\Users\TOCANE\Desktop\TENNIS\LogCorner.Hackaton.TennisPlayer.Presentation> dotnet build  
            C:\Users\TOCANE\Desktop\TENNIS\LogCorner.Hackaton.TennisPlayer.Presentation> dotnet run   
 It will listen on http://localhost:58057 and you can use swagger on http://localhost:58057/swagger
- Note structure of Data.json is updated to an array of players [ ]  and is no longer an object  { "players": [ ] }
- The infrastructure layer is not implemented with the TDD approach. so she is not tested yet.
- To delete a player on Json file , I load the players, remove the player that I want to delete from the list and rewrite the file with the new list.
