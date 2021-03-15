# apps_todo
Application designed to manage to-do tasks

# Running the app
The only thing required to run the `TodoApp` is `docker`. After this perform the following actions:
- execute `docker-compose up` from the root folder
  - it may take some time to build the images the first time as the images will be downloaded and built
  - it may take some time to warm up the database for the first time as the `.db` volume will be created locally
  - when the `backend` app comes up it will apply the database migrations to initialize the db schema
- access the backend api on `http://localhost:5000/swagger/index.html`
- access the frontend url on `http://localhost:4201`

# App overview
- Backend
  - Database: Postgres + Entity Framework Migrations
  - Api Server: NET 5 web api
- Frontend
  - Web Server: NodeJS
  - UI: Angular

