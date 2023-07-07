A simple sample fro microservices project.

#1
	We Start with a empty solution to make some project in this solution.
	First Project:
	Catalog: Web API Project which work with Mongo DB
	Install mongo db with command "docker pull mongo"
	The MongoDB server in the image listens on the standard MongoDB port, 27017, so connecting via Docker networks will be the same as connecting to a remote mongod
	Write command "docker run -d -p 27017:27017 --name Shopping-mongo mongo" "-d" means dissmatch project "-p" means port number in docker:in your project "--name" project name and at the end image name
	"docker ps" command to show images which are going to use in this microservice project
	"docker logs -f shopping-mongo" command to show logs, becareful, it's case sensitive
	to execute image core, have to been written command "docker exec -it Shopping-mongo /bin/bash"

#2
	"docker exec -it Shopping-mongo /bin/bash" command to execute special image in docker
	"show dbs" finde databases
	"use catalogdb" to make  new db
	"db.createCollection("Products")" make a table named products
	"db.Product.insertMany()" Insert a json Data

#3
	Create Database MongoDb in project 
	Install MongoDB.drive Nuget Package
	Create Connection in appsettings.json
	create "Products" entity
	Create Context for mongodb connection

#4

#5
	to run containers and images on docker, first have to right click on project and choose "docker compose"
	it makes docker files on project.in docker-copose.yml has to add catalogdb: image: mongo as services (spaces are important).
		out of services has to write volumes: mongo_data:
	in file docker-compose.override.yml has to write these codes
		services:
			catalogdb:
			   container_name: catalogdb
			   restart: always
			   volumes:
				 - mongo_data:/data/db
			   ports:
				 - "27017:27017"
			catalog.api:
			   container_name: catalog.api
               environment:
                 - ASPNETCORE_ENVIRONMENT=Development
                 - "DatabaseSettings:ConnectionString=mongodb://catalogdb:27017"
               depends_on:
				 - catalogdb
			   ports:
				 - "8000:80"

	after set the settings up, has to write this command to run image and containers:
		docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d

