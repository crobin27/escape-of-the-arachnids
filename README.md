# Escape of The Arachnids
![image](https://github.com/crobin27/escape-of-the-arachnids/assets/76970281/01f871dc-fda8-4fa9-ad8c-9db1e18d4170)

## Contributors
Cole Robinson (colerobinson1112@gmail.com)

<details open="open">
<summary>Table of Contents</summary>
<br>

- [About](#about)
- [Documentation Files](#documentation-files)
- [Development Environment Setup](#development-environment-setup)
    - [Unity Engine] (#unity-engine)
    - [Build Platform] (#build-platform)
    - [
</details>

## About
Making use of the Unity Game Engine and under the supervision of Dr. Hugh Smith at Cal Poly San Luis Obispo, I was able to further my knowledge of game development techniques through the creation of this mobile 2D Android game. Broadening my knowledge, I focused on including important aspects of the software and game development process such as version control, object-oriented programming, storyboarding, design flow, and user testing. The Unity Engine’s cross platform build compatibility combined with its beginner friendly design made it the perfect choice to build the game on. 

## Documentation Files
Listed below are documents we have gathered that provide further insight into the development of this API.

To keep track of different classes, I've created a [UML diagram](documentation/UML_DIAGRAM.pdf)

In order to keep in touch with user flow, an example storyboard can be found [here](documentation/STORYBOARD.pdf)

To keep track of the scene flow, I created a [flowchart](documentation/FLOWCHART.pdf) to track potential user paths. 

For a comprehensive explanation of the game as a whole and the goals achieved, view the [Final Report](documentation/FINAL_REPORT.pdf)

## Development Environment Setup

### Unity Engine
This game was developed using Unity Game Engine 2021.3 version using a Student Professional license. Information on download details can be found [here](https://unity.com/)

### Build Platform
This game was developed for Android mobile devices
### Environment Variables
Upon creation of the local Docker container and Postgres database, the following environment variables must be configured in a .env file located in the root of the project. The following fields must be included to ensure a stable connection to the local database. 
```
POSTGRES_USER="postgres"
POSTGRES_PASSWORD="postgres"
POSTGRES_SERVER="localhost"
POSTGRES_PORT="54322"
POSTGRES_DB="postgres"
```

In addition to the Postgres connection variables, a Weather API Key must be obtained and set. Information on obtaining an API key can be found here(https://www.weatherapi.com/signup.aspx). Once the key is obtained, set the environment variable like below:
```
WEATHER_API_KEY="<your_api_key>"
```

### Alembic Migrations and Faker data population
In order to handle database migrations as our schema evolved, we made use of the alembic library's built in autogeneration functionality. More information can be found here(https://alembic.sqlalchemy.org/en/latest/autogenerate.html)

To update the local database to the most recent migration, run
![image](https://github.com/crobin27/music-api/assets/76970281/547337db-2ad0-4732-8f0d-1dcece8778a7)

We additionally created an autopopulation script that creates just over a million fake rows of data using the python 'faker' library. This step was crucial in testing the database with large sums of data. To populate with fake data, run
![image](https://github.com/crobin27/music-api/assets/76970281/30b181b8-95b9-4975-bbdd-9d983fe37d7c)


### Run the API
Run following on your terminal:
```
vercel dev
```
