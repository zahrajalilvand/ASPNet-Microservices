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
