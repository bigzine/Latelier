# Latelier
# Run the project
1. Clone this repository
2. Build the solution using Visual Studio, or on the command line with dotnet build.
3. Run the project. The API will start up on https://localhost:7223 or http://localhost:5209 with dotnet run AtelierTennis.API
4.Use an Http client like Postman or Fiddler to GET https://localhost:7223 or swagger https://localhost:7223/swagger/index.html

# REST API

## Get list of Players

### Request

`GET /Players`

    curl -i -H 'Accept: application/json' https://localhost:7223/Players

## Get player

`GET /Players/id`

### Request
    curl -i -H 'Accept: application/json' https://localhost:7223/Players/id

## Get players stats

### Request

`GET /Players/stats`

    curl -i -H 'Accept: application/json' https://localhost:7223/Players/stats