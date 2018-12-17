# RobotStore

This project is a Web Application that represents a robot store. In the store you can view, add and delete robots depending on
the type of your profile. The application is available at: INSERIR URL

## Testing information

The application has two users pre-configured and four robots:

Admin User - can read/add/delete robots
**username:** admin
**password:** admin

Reader user - can only view the robots list
**username:** reader
**password:** reader

## Architecture

The project is structured in 3 layers 

- Frontend AngularCLI application
- Backend ASP.NET Core application
- Persistence with In-Memory Database

## API

/api/robot/list - GET request that returns all the robots

/api/robot/add - POST request that adds a new robot.
                  Add to the body: 
                  {
                    Name: "robotName",
                    Price: "robotPrice"
                  }
                  
/api/delete/{id} - DELETE request that removes a robot

/api/robot/get/{id} - GET request that returns a robot by a given id

## Getting Started

In order to test locally, all you need to do is clone this repository, open the solution in Visual Studio, restore the packages and
run RobotWebStore

## Running the tests

To run the tests in Visual Studio go to Test -> Windows - > Test Explorer, build the solution and the tests should appear in the
Test Explorer. Just click "Run All" to run all the tests.


## Deployment

This application is deployed to Heroku in a Docker Container.

You can access the application here: 


## Authors

* **Diana Ribeiro** 

See also the list of [contributors](https://github.com/dianagribeiro/robotshop/graphs/contributors) who participated in this project.
